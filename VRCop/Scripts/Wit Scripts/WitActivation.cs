using System.Collections;
using System.Collections.Generic;
using Meta.WitAi;
using UnityEngine;
using UnityEngine.InputSystem;

public class WitActivation : MonoBehaviour
{
    [SerializeField] private Wit wit;
    public InputActionProperty buttonPressA; //public para fazer set no Editor

    private void OnValidate()
    {
        if (!wit) wit = GetComponent<Wit>();
    }

    void Update()
    {
        float buttonValue = buttonPressA.action.ReadValue<float>();
        if (buttonValue > 0)
        {
            Debug.Log("A pressed");
            wit.Activate();
            //Invoke("TurnItOff", 2);
        }
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     wit.Activate();
        //     //Invoke("TurnItOff", 2);
        // }
    }

    private void TurnItOff(){
        wit.Deactivate();
    }
}
