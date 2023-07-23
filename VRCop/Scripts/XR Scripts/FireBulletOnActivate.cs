using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class FireBulletOnActivate : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnPoint;
    public float fireSpeed = 20;
    private GameObject spawnedBullet;
    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(FireBullet); //need to add ActivateEventArgs
    }

    
    void Update()
    {
        
    }

    public void FireBullet(ActivateEventArgs arg)
    {
        spawnedBullet = Instantiate(bullet);
        Debug.Log("bang");
        //spawnedBullet.transform.rotation = spawnedBullet.transform.parent.rotation;
        spawnedBullet.transform.position = spawnPoint.position;
        spawnedBullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * fireSpeed;
        Destroy(spawnedBullet, 0.75f);

    }

//     private void OnCollisionEnter(Collision collision)
//    {
//       Destroy(spawnedBullet);
//    }
}
