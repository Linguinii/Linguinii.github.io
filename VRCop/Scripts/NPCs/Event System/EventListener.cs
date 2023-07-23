using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventListener : MonoBehaviour
{
    public EventSystem eventSystem;

    public void SendAskedForDocsEvent(){
        eventSystem.SendEvent(new SimulationEvent(SimulationEventType.askedForDocuments));
    }

    public void SendReceivedDocsEvent(){
        eventSystem.SendEvent(new SimulationEvent(SimulationEventType.receivedDocuments));
    }

    public void AskedToLeaveEvent(){
        eventSystem.SendEvent(new SimulationEvent(SimulationEventType.askedToLeave));
    }

    public void SendEngineEvent(){
        eventSystem.SendEvent(new SimulationEvent(SimulationEventType.askedToTurnOffEngine));
    }

    public void SendEnterVehicleEvent(){
        eventSystem.SendEvent(new SimulationEvent(SimulationEventType.askedToEnterVehicle));
    }

    public void SendStopEvent(){
        eventSystem.SendEvent(new SimulationEvent(SimulationEventType.askedToStop));
    }
}
