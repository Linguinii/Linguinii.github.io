using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RunState : State
{

    public RunState()
    {
        base.AddEntryAction(new Action(ActionType.RunAway));
    }

    public override State Evolve(SimulationEvent ev)
    {
        State nextState = null;
        return nextState;
    }
}
