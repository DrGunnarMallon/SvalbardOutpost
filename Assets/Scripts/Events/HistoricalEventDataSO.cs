using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NewHistoricalEvent", menuName = "Events/Historical Event")]
public class HistoricalEventDataSO : ScriptableObject
{
    [Header("Event Date")]
    public int year;
    public int month;
    public int day;

    [Header("Event Details")]
    public string eventName;
    [TextArea(2, 4)]
    public string description;

    [Header("Resource Effects")]
    public int coalEffect;
    public int foodEffect;
    public int toolsEffect;

    // Additional fields if needed: 
    // e.g., a sprite for an event icon, 
    // or bool indicating if it's a single-use event, etc.

    // A helper property to get the event's DateTime 
    // (assuming only 1900+ range, but can expand)
    public DateTime EventDate
    {
        get
        {
            return new DateTime(year, month, day);
        }
    }
}
