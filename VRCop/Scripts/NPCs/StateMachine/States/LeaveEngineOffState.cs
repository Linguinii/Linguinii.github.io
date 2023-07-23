using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LeaveEngineOffState : State
{
    public LeaveEngineOffState()
    {
        base.AddEntryAction(new Action(ActionType.DriveAwayNoEngine));
    }

    public override State Evolve(SimulationEvent ev)
    {
        State nextState = null;
        
        return nextState;
    }
}
