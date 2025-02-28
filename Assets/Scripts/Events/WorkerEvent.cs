using System;

public class WorkerEvent : IGameEvent
{
    public DateTime EventDate { get; private set; }
    public string EventName { get; private set; }
    public string EventDescription { get; private set; }

    public Worker EventWorker { get; private set; }

    public WorkerEvent(Worker worker, DateTime eventDate, string eventName, string eventDescription)
    {
        EventWorker = worker;
        EventDate = eventDate;
        EventName = eventName;
        EventDescription = eventDescription;
    }

    public void ApplyEvent()
    {
        // Apply any events
    }
}