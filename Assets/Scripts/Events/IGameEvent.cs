using System;

public interface IGameEvent
{
    DateTime EventDate { get; }
    string EventName { get; }
    string EventDescription { get; }

    void ApplyEvent();
}