using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WaitOutsideState : State
{
    private float thrrun, thrattack;

    public WaitOutsideState()
    {
        var runArea = 0.4f * Constants.fear;
        var attackArea = 0.4f * Constants.agression;
        thrrun = runArea;
        thrattack = 1 - attackArea;
        base.AddEntryAction(new Action(ActionType.Stop));
    }

    public override State Evolve(SimulationEvent ev)
    {
        State nextState = null;
        var rand = Random.Range(0, 1f);
        if (ev.GetEventType() == SimulationEventType.askedToEnterVehicle && rand <= thrrun)
        {
            nextState = new FleeState();
        } else if (ev.GetEventType() == SimulationEventType.askedToEnterVehicle && rand > thrrun && rand <= thrattack)
        {
            nextState = new EnterCarState();
        } else if(ev.GetEventType() == SimulationEventType.askedToEnterVehicle && rand > thrattack)
        {
            nextState = new ApproachState();
        }

        return nextState;
    }
}
