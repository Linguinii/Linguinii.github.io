using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ExitCarState : State
{
    private float thrafraid, thrmad;

    public ExitCarState()
    {
        var neutralArea = 0.1f;
        var afraidArea = 0f;
        if (Constants.fear != 0 || Constants.agression != 0)
        {
            afraidArea = (Constants.fear * 0.9f) / (Constants.fear + Constants.agression);
        }
        thrafraid = afraidArea;
        thrmad = thrafraid + neutralArea;
        base.AddEntryAction(new Action(ActionType.ExitCar));
    }

    public override State Evolve(SimulationEvent ev)
    {
        State nextState = null;
        var rand = Random.Range(0, 1f);
        if (ev.GetEventType() == SimulationEventType.leftCar && rand <= thrafraid)
        {
            nextState = new FleeState();
        } else if (ev.GetEventType() == SimulationEventType.leftCar && rand > thrafraid && rand <= thrmad)
        {
            nextState = new WaitOutsideState();
        } else if (ev.GetEventType() == SimulationEventType.leftCar && rand > thrmad)
        {
            nextState = new ApproachState();
        }
        //nextState = new WaitOutsideState();
        return nextState;
    }
}
