public class SimulationEvent
{
    private SimulationEventType type;

    public SimulationEvent(SimulationEventType type)
    {
        this.type = type;
    }

    public SimulationEventType GetEventType()
    {
        return type;
    }

    public bool Equals(SimulationEvent ev)
    {
        return type.Equals(ev.GetEventType());
    }

    public override string ToString()
    {
        return type.ToString();
    }
}