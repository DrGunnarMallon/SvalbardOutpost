using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HistoricalEventsCollection", menuName = "Events/Historical Events Collection")]
public class HistoricalEventCollectionSO : ScriptableObject
{
    public List<HistoricalEventDataSO> events;
}
