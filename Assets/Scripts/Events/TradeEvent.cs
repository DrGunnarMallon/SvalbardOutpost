using System;

public class TradeEvent : IGameEvent
{
    public DateTime EventDate { get; private set; }
    public string EventName { get; private set; }
    public string EventDescription { get; private set; }

    public TradeEvent(DateTime eventDate, string eventName, string eventDescription)
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