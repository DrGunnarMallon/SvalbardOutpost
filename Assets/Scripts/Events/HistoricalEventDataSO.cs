using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NewHistoricalEvent", menuName = "Events/Historical Event")]
public class HistoricalEventDataSO : ScriptableObject, IGameEvent
{
    [Header("Event Date")]
    public int year;
    public int month;
    public int day;

    [field: SerializeField] public string EventName { get; private set; }
    [field: SerializeField] public string EventDescription { get; private set; }

    public DateTime EventDate => new DateTime(year, month, day);

    [Header("Resource Effects")]
    public int coalEffect;

    public void ApplyEvent()
    {
        ResourceManager resourceManager = GameManager.Instance.ResourceManager;

        if (coalEffect < 0)
        {
            resourceManager.UseCoal(coalEffect);
        }
        else if (coalEffect > 0)
        {
            resourceManager.AddCoal(coalEffect);
        }
    }
}
