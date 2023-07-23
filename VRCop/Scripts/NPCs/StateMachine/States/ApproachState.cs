using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ApproachState : State
{
    public ApproachState()
    {
        base.AddEntryAction(new Action(ActionType.Approach));
    }

    public override State Evolve(SimulationEvent ev)
    {
        State nextState = null;
        if (ev.GetEventType() == SimulationEventType.askedToStop)
        {
            nextState = new WaitOutsideState();
        }

        return nextState;
    }
}
