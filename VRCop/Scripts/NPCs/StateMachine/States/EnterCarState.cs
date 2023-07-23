using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnterCarState : State
{

    public EnterCarState()
    {
        base.AddEntryAction(new Action(ActionType.EnterCar));
    }

    public override State Evolve(SimulationEvent ev)
    {
        State nextState = null;

        if (ev.GetEventType() == SimulationEventType.enteredCar)
        {
            nextState = new WaitState();
        }

        return nextState;
    }
}
