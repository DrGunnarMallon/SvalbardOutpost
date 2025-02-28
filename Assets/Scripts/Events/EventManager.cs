using System;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public event Action<HistoricalEventDataSO> OnHistoricalEvent;
    public event Action<TradeEvent> OnTradeEvent;
    public event Action<WorkerEvent> OnWorkerEvent;
    public event Action<EnvironmentEvent> OnEnvironmentEvent;

    public List<IGameEvent> possibleRandomEvents;

    [Header("Historical Events Collection")]
    public HistoricalEventCollectionSO historicalEventsCollection;

    private Dictionary<DateTime, List<HistoricalEventDataSO>> historicalEventsDict = new Dictionary<DateTime, List<HistoricalEventDataSO>>();


    public void Initialize()
    {
        BuildHistoricalEventsDictionary();
    }

    private void BuildHistoricalEventsDictionary()
    {
        foreach (HistoricalEventDataSO historicalEvent in historicalEventsCollection.events)
        {
            DateTime date = historicalEvent.EventDate;
            if (!historicalEventsDict.ContainsKey(date))
            {
                historicalEventsDict[date] = new List<HistoricalEventDataSO>();
            }
            historicalEventsDict[date].Add(historicalEvent);
        }
    }

    public void CheckHistoricalEvent(DateTime newDate)
    {
        if (historicalEventsDict.ContainsKey(newDate))
        {
            List<HistoricalEventDataSO> eventsForDate = historicalEventsDict[newDate];

            foreach (HistoricalEventDataSO historicalEvent in eventsForDate)
            {
                ApplyHistoricalEvent(historicalEvent);
            }
        }
    }

    private void ApplyHistoricalEvent(HistoricalEventDataSO historicalEvent)
    {
        historicalEvent.ApplyEvent();

        OnHistoricalEvent?.Invoke(historicalEvent);
    }

    public void RaiseTradeEvent(TradeEvent tradeEvent)
    {
        tradeEvent.ApplyEvent();
        OnTradeEvent?.Invoke(tradeEvent);
    }

    public void RaiseWorkerEvent(WorkerEvent workerEvent)
    {
        workerEvent.ApplyEvent();
        OnWorkerEvent?.Invoke(workerEvent);
    }

    public void RaiseEnvironmentEvent(EnvironmentEvent environmentEvent)
    {
        environmentEvent.ApplyEvent();
        OnEnvironmentEvent?.Invoke(environmentEvent);
    }
}
