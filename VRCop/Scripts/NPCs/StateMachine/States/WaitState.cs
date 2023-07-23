using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WaitState : State
{
    private float thrdoc, threngine;

    public WaitState()
    {
        thrdoc = 1 - 0.8f * Constants.agression - 0.1f * Constants.fear;
        threngine = 1 - 0.4f * Constants.agression + 0.5f * Constants.fear;
    }

    public override State Evolve(SimulationEvent ev)
    {
        State nextState = null;
        var rand = Random.Range(0, 1f);
        if (ev.GetEventType() == SimulationEventType.askedForDocuments && rand <= thrdoc)
        {
            nextState = new WaitEnforcementState();
        } else if (ev.GetEventType() == SimulationEventType.askedToTurnOffEngine && rand <= threngine)
        {
            nextState = new TurnOffEngineState();
        } else if (ev.GetEventType() == SimulationEventType.askedToLeave)
        {
            nextState = new LeaveState();
        }

        return nextState;
    }
}
