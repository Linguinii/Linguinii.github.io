using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WaitEnforcementEngineOffState : State
{
    public WaitEnforcementEngineOffState()
    {
        base.AddEntryAction(new Action(ActionType.ProvideDocuments));
        base.AddExitAction(new Action(ActionType.ReceiveDocuments));
    }

    public override State Evolve(SimulationEvent ev)
    {
        State nextState = null;
        if (ev.GetEventType() == SimulationEventType.receivedDocuments)
        {
            nextState = new WaitEngineOffState();
        }

        return nextState;
    }
}
