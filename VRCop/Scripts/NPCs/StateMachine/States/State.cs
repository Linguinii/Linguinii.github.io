using System.Collections;
using System.Collections.Generic;
using System.Linq;

public abstract class State
{
    private List<Action> entryActions, exitActions;

    public State()
    {
        entryActions = new List<Action>();
        exitActions = new List<Action>();
    }

    public abstract State Evolve(SimulationEvent ev);

    internal void AddEntryAction(Action ac)
    {
        entryActions.Add(ac);
    }

    internal void AddExitAction(Action ac)
    {
        exitActions.Add(ac);
    }

    public List<Action> GetEntryActions()
    {
        return entryActions;
    }

    public List<Action> GetExitActions()
    {
        return exitActions;
    }

    public bool Equals(State state)
    {
        return GetType() == state.GetType();
    }
}
