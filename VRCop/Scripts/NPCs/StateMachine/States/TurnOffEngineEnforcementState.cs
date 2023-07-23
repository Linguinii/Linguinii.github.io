using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TurnOffEngineEnforcementState : State
{
    public TurnOffEngineEnforcementState()
    {
        base.AddEntryAction(new Action(ActionType.TurnOffEngine));
    }

    public override State Evolve(SimulationEvent ev)
    {
        State nextState = null;
        if (ev.GetEventType() == SimulationEventType.turnedOffEngine)
        {
            nextState = new WaitEnforcementEngineOffState();
        }

        return nextState;
    }
}
