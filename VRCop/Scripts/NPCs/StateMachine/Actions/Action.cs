using System;

public class Action
{
    private ActionType type;

    public Action(ActionType type)
    {
        this.type = type;
    }

    public ActionType GetActionType()
    {
        return type;
    }

    public bool Equals(Action ac)
    {
        return type.Equals(ac.GetActionType());
    }
    public override string ToString()
    {
        return type.ToString();
    }
}
