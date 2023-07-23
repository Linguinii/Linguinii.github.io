using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
	private State currentState;
	private float thrhero, thrvillain, thrsupervillain;

	public List<Action> Innit()
    {
		var heroArea = (1 - Constants.chanceOfExiting) * (0.4f * Constants.fear + 0.1f * Constants.agression);
		var villainArea = Constants.chanceOfExiting;
		var superVillainArea = (1 - Constants.chanceOfExiting) * (0.4f * Constants.agression + 0.1f * Constants.fear);
		thrhero = heroArea;
        thrvillain = 1 - superVillainArea - villainArea;
		thrsupervillain = 1 - superVillainArea;
		var rand = Random.Range(0, 1f);
		if (rand <= thrhero)
        {
			currentState = new TurnOffEngineState();
        } else if (rand > thrhero && rand <= thrvillain)
        {
			currentState = new WaitState();
        } else if (rand > thrvillain && rand <= thrsupervillain)
        {
			currentState = new ExitCarState();
        } else if (rand > thrsupervillain)
        {
			currentState = new LeaveState();
        }
		Debug.Log("Fear: " + Constants.fear + "\nCurrent State: " + currentState.GetType() + "\nVillain Threshold: " + 
			thrvillain + "\nHero Threshold: " + thrhero + "\nSupervillain Threshold: " + thrsupervillain);

		return currentState.GetEntryActions();
	}

	public List<Action> Evolve(SimulationEvent ev)
    {
		List<Action> actions = new List<Action>();

		State nextState = currentState.Evolve(ev);

		Debug.Log("Current State: " + currentState + "\nEvent: " + ev + "\nNext State: " + nextState);

		if (nextState != null)
        {
			List<Action> exitActions = currentState.GetExitActions();
			List<Action> entryActions = nextState.GetEntryActions();

			for (int i = 0; i < exitActions.Count; i++)
            {
				actions.Add(exitActions[i]);
            }

			for (int i = 0; i < entryActions.Count; i++)
			{
				actions.Add(entryActions[i]);
			}

			currentState = nextState;
		}

		return actions;
    }

	public State GetCurrentState()
    {
		return currentState;
    }
}
