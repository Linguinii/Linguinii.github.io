using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TurnOffEngineState : State
{

    public TurnOffEngineState()
    {
        base.AddEntryAction(new Action(ActionType.TurnOffEngine));
    }

    public override State Evolve(SimulationEvent ev)
    {
        State nextState = null;
        if (ev.GetEventType() == SimulationEventType.turnedOffEngine)
        {
            nextState = new WaitEngineOffState();
        }
        return nextState;
    }
}
