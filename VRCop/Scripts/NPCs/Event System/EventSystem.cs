using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystem : MonoBehaviour
{
    public List<DriverNPC> NPCs;

    public void SendEvent(SimulationEvent ev)
    {
        foreach(DriverNPC npc in NPCs)
        {
            npc.ReceiveEvent(ev);
        }
    }
}

