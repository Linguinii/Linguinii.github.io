using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DriverNPC : MonoBehaviour
{
    private StateMachine stateMachine;
    private Animator anim;
    private bool canMove, canSpeak, socket, goingToCar, approach, walkingInApproach, idleInApproach, walkingToCar;
    private List<Action> actionQueue;
    private NavMeshAgent navAgent;
    private Vector3 initialPosition;
    private Quaternion initialRotation;

    public AudioClip AskedEngineReply, askedDocumentsReply, receivedDocumentsReply, askedLeaveReply, accelerate, enterCarReply, approachingReply;
    public AudioSource engineAudioSource, replySource, ignitionSource;
    public EventSystem eventSystem;
    public Animator carAnimator, doorAnimator;
    public Animator[] wheelsAnimator;
    public GameObject id;
    public Transform carWaypoint, leaveWaypoint, player;
    public float walkSpeed = 1f, runSpeed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        ToggleId("off");
        stateMachine = new StateMachine();
        actionQueue = new List<Action>();
        AddActionsToQueue(stateMachine.Innit());
        anim = GetComponent<Animator>();
        canMove = true;
        canSpeak = true;
        navAgent = GetComponent<NavMeshAgent>();
        goingToCar = false;
        approach = false;
        walkingInApproach = false;
        idleInApproach = false;
        walkingToCar = false;
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove && canSpeak && actionQueue.Count > 0)
        {
            Act(actionQueue[0]);
            actionQueue.RemoveAt(0);
        }
        if(!canSpeak && !replySource.isPlaying)
        {
            canSpeak = true;
        }
        if (goingToCar)
        {
            if (!walkingToCar){
                Debug.Log("walkkkkk");
                walkingToCar = true;
                anim.SetTrigger("walkTrigger");
            }

            transform.LookAt(new Vector3(carWaypoint.position.x, transform.position.y, carWaypoint.position.z));
            if (Vector3.Distance(transform.position, carWaypoint.position) <= 0.1f)
            {
                walkingToCar = false;
                goingToCar = false;
                navAgent.enabled = false;
                transform.position = carWaypoint.position;
                transform.LookAt(new Vector3(initialPosition.x, transform.position.y, initialPosition.z));
                anim.SetTrigger("enterTrigger");
                doorAnimator.SetTrigger("doorTrigger");
            }
        }
        if (approach)
        {
            navAgent.SetDestination(player.position);
            transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
            if (Vector3.Distance(transform.position, player.position) <= 3f)
            {
                navAgent.isStopped = true;
                if (!idleInApproach)
                {
                    anim.SetTrigger("stopTrigger");
                    idleInApproach = true;
                }
                walkingInApproach = false;
            } else
            {
                navAgent.SetDestination(player.position);
                navAgent.isStopped = false;
                navAgent.speed = walkSpeed;
                if (!walkingInApproach)
                {
                    anim.SetTrigger("walkTrigger");
                    walkingInApproach = true;
                }
                idleInApproach = false;
            }
        }
    }

    private void MuteEngine()
    {
        engineAudioSource.mute = !engineAudioSource.mute;
    }

    public void Reply(AudioClip reply)
    {
        canSpeak = false;
        replySource.clip = reply;
        replySource.Play();
    }

    private void DriveOff(){
        engineAudioSource.clip = accelerate;
        engineAudioSource.Play();
        engineAudioSource.loop = false;
        carAnimator.SetTrigger("Drive");
        for (int i=0; i < wheelsAnimator.Length; i++){
            wheelsAnimator[i].SetTrigger("Wheels");    
        }  
        
    }

    // Toggles the ID's mesh renderer on or off 
    private void ToggleId(string str){
        if (str.Equals("on")){
            id.GetComponent<MeshRenderer>().enabled = true;
        }
        else if (str.Equals("off")){
            id.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    private void AddActionsToQueue(List<Action> actions)
    {
        foreach (Action action in actions)
        {
            actionQueue.Add(action);
        }
    }

    public void ReceiveEvent(SimulationEvent ev)
    {
        AddActionsToQueue(stateMachine.Evolve(ev));
    }

    private void Act(Action ac)
    {
        switch (ac.GetActionType())
        {
            case ActionType.TurnOffEngine:
                Reply(AskedEngineReply);
                Invoke("MuteEngine", replySource.clip.length); 
                eventSystem.SendEvent(new SimulationEvent(SimulationEventType.turnedOffEngine));
                break;

            case ActionType.ProvideDocuments:
                canMove = false;
                ToggleId("on");
                anim.SetTrigger("docsTrigger");
                Reply(askedDocumentsReply);
                break;

            case ActionType.ReceiveDocuments:
                canMove = false;
                anim.SetTrigger("docsTrigger");
                Reply(receivedDocumentsReply);
                break;

            case ActionType.DriveAwayNoEngine:
                Reply(askedLeaveReply); // condutor diz adeus 
                ignitionSource.Play();
                Invoke("MuteEngine", ignitionSource.clip.length);
                Invoke("DriveOff", ignitionSource.clip.length + 0.9f);
                break;

            case ActionType.DriveAway:
                Reply(askedLeaveReply); // condutor diz adeus 
                Invoke("DriveOff", replySource.clip.length + 0.5f);
                break;

            case ActionType.ExitCar:
                canMove = false;
                transform.position = new Vector3(transform.position.x, carWaypoint.position.y, transform.position.z);
                anim.SetTrigger("exitTrigger");
                doorAnimator.SetTrigger("doorTrigger");
                break;
            
            case ActionType.EnterCar:
                canMove = false;
                navAgent.SetDestination(carWaypoint.position);
                navAgent.isStopped = false;
                navAgent.speed = walkSpeed;
                Reply(enterCarReply);
                goingToCar = true;
                break;

            case ActionType.WalkAway:
                navAgent.SetDestination(leaveWaypoint.position);
                navAgent.isStopped = false;
                navAgent.speed = walkSpeed;
                anim.SetTrigger("walkTrigger");
                break;

            case ActionType.RunAway:
                navAgent.SetDestination(leaveWaypoint.position);
                navAgent.isStopped = false;
                navAgent.speed = runSpeed;
                anim.SetTrigger("runTrigger");
                break;

            case ActionType.Approach:
                anim.SetTrigger("walkTrigger");
                approach = true;
                navAgent.SetDestination(carWaypoint.position);
                navAgent.isStopped = false;
                navAgent.speed = walkSpeed;
                Reply(approachingReply);
                anim.SetTrigger("walkTrigger");
                break;

            case ActionType.Stop:
                goingToCar = false;
                approach = false;
                navAgent.isStopped = true;
                anim.SetTrigger("stopTrigger");
                Debug.Log("coiso");
                break;

            default:
                Debug.Log("action not supported");
                break;
        }
    }

    public void RefreshMove()
    {
        canMove = true;
    }

    public void SocketInteraction(){
        if (socket){
            anim.SetTrigger("socketTrigger");
        }
        socket = true;
    }

    public void LeaveCar()
    {
        transform.position = carWaypoint.position;
        navAgent.enabled = true;
        RefreshMove();
        eventSystem.SendEvent(new SimulationEvent(SimulationEventType.leftCar));
    }

    public void EnterCar()
    {
        transform.position = initialPosition;
        transform.rotation = initialRotation;
        anim.SetTrigger("sitTrigger");
        RefreshMove();
        eventSystem.SendEvent(new SimulationEvent(SimulationEventType.enteredCar));
    }
}
