using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WaitEnforcementState : State
{
    private float threngine;

    public WaitEnforcementState()
    {
        threngine = 1 - 0.4f * Constants.agression + 0.5f * Constants.fear;
        base.AddEntryAction(new Action(ActionType.ProvideDocuments));
        base.AddExitAction(new Action(ActionType.ReceiveDocuments));
    }

    public override State Evolve(SimulationEvent ev)
    {
        State nextState = null;
        var rand = Random.Range(0, 1f);
        if (ev.GetEventType() == SimulationEventType.receivedDocuments)
        {
            nextState = new WaitState();
        }
        else if (ev.GetEventType() == SimulationEventType.askedToTurnOffEngine && rand <= threngine)
        {
            nextState = new TurnOffEngineEnforcementState();
        }

        return nextState;
    }
}
