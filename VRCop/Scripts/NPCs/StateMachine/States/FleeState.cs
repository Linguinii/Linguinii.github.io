using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FleeState : State
{
    private float thrstop;

    public FleeState()
    {
        base.AddEntryAction(new Action(ActionType.WalkAway));
        thrstop = 0.8f * Constants.fear;
    }

    public override State Evolve(SimulationEvent ev)
    {
        State nextState = null;
        var rand = Random.Range(0, 1f);
        if (ev.GetEventType() == SimulationEventType.askedToStop && rand <= thrstop)
        {
            nextState = new WaitOutsideState();
        } else if (ev.GetEventType() == SimulationEventType.askedToStop && rand > thrstop)
        {
            nextState = new RunState();
        }

        return nextState;
    }
}
