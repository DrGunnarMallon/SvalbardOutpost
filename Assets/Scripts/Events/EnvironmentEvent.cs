using System;

public class EnvironmentEvent : IGameEvent
{
    public DateTime EventDate { get; private set; }
    public string EventName { get; private set; }
    public string EventDescription { get; private set; }


    public EnvironmentEvent(DateTime eventDate, string eventName, string eventDescription)
    {
        EventDate = eventDate;
        EventName = eventName;
        EventDescription = eventDescription;
    }

    public void ApplyEvent()
    {
        // Apply any events
    }
}