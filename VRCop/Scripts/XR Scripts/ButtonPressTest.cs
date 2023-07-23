using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonPressTest : MonoBehaviour
{
    public InputActionProperty buttonPressA; //public para fazer set no Editor
    private bool activated = false;
    private string msg;

    void Start()
    {
        
    }

   
    void Update()
    {
        //ler input do trigger direito
        float buttonValue = buttonPressA.action.ReadValue<float>();
        if (buttonValue > 0) {
            activated = !activated;
            if (activated) msg = "activated"; else msg = "deactivated";
            //Debug.Log("PRESSED! ("+ msg + ")");
        }

        

    }
}
