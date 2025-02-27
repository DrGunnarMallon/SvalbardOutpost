using System;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public List<GameEvent> possibleRandomEvents;

    public event Action<HistoricalEventDataSO> OnHistoricalEvent;

    [Header("Historical Events Collection")]
    public HistoricalEventCollectionSO historicalEventsCollection;

    private Dictionary<DateTime, List<HistoricalEventDataSO>> historicalEventsDict = new Dictionary<DateTime, List<HistoricalEventDataSO>>();

    private float eventInterval = 30f;
    private float timeSinceLastEvent = 0f;

    public void Initialize()
    {
        BuildHistoricalEventsDictionary();
    }

    private void Update()
    {
        timeSinceLastEvent += Time.deltaTime;
        if (timeSinceLastEvent >= eventInterval)
        {
            TriggerRandomEvent();
            timeSinceLastEvent = 0f;
        }
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

    private void TriggerRandomEvent()
    {
        if (possibleRandomEvents.Count == 0) return;

        int index = UnityEngine.Random.Range(0, possibleRandomEvents.Count);
        GameEvent chosenEvent = possibleRandomEvents[index];
        chosenEvent.ApplyEvent();
    }

    private void ApplyHistoricalEvent(HistoricalEventDataSO historicalEvent)
    {
        OnHistoricalEvent?.Invoke(historicalEvent);

        ResourceManager rm = GameManager.Instance.ResourceManager;

        if (historicalEvent.coalEffect < 0)
        {
            rm.UseCoal(historicalEvent.coalEffect);
        }
        else if (historicalEvent.coalEffect > 0)
        {
            rm.AddCoal(historicalEvent.coalEffect);
        }

        if (historicalEvent.foodEffect < 0)
        {
            rm.UseFood(historicalEvent.foodEffect);
        }
        else if (historicalEvent.foodEffect > 0)
        {
            rm.AddFood(historicalEvent.foodEffect);
        }

        if (historicalEvent.toolsEffect < 0)
        {
            rm.UseTools(historicalEvent.toolsEffect);
        }
        else if (historicalEvent.toolsEffect > 0)
        {
            rm.AddTools(historicalEvent.toolsEffect);
        }
    }
}
