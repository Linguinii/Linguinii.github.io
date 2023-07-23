using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LeaveState : State
{
    public LeaveState()
    {
        base.AddEntryAction(new Action(ActionType.DriveAway));
    }

    public override State Evolve(SimulationEvent ev)
    {
        State nextState = null;

        return nextState;
    }
}
