using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WaitEngineOffState : State
{
    private float thrdoc;

    public WaitEngineOffState()
    {
        thrdoc = 1 - 0.8f * Constants.agression - 0.1f * Constants.fear;
    }

    public override State Evolve(SimulationEvent ev)
    {
        State nextState = null;
        var rand = Random.Range(0, 1f);
        if (ev.GetEventType() == SimulationEventType.askedForDocuments && rand <= thrdoc)
        {
            nextState = new WaitEnforcementEngineOffState();
        } else if (ev.GetEventType() == SimulationEventType.askedToLeave)
        {
            nextState = new LeaveEngineOffState();
        }

        return nextState;
    }
}
