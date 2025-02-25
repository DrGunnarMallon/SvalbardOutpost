using System;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public event Action<DateTime> OnDayChanged;
    public DateTime currentDate { get; private set; } = new DateTime(1900, 1, 1);

    [SerializeField] float secondsPerDay = 1f;

    private float dayTimer = 0f;

    private void Update()
    {
        dayTimer += Time.deltaTime;

        if (dayTimer > secondsPerDay)
        {
            currentDate = currentDate.AddDays(1);
            dayTimer = 0f;
            OnDayChanged?.Invoke(currentDate);
        }
    }
}
