using System;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public event Action<DateTime> OnDayChanged;
    public event Action<DateTime> OnMonthChanged;
    public event Action<DateTime> OnYearChanged;

    public DateTime CurrentDate { get; private set; } = new DateTime(1900, 1, 1);

    [SerializeField] float secondsPerDay = 1f;

    private float dayTimer = 0f;

    private void Update()
    {
        dayTimer += Time.deltaTime;

        if (dayTimer > secondsPerDay)
        {
            CurrentDate = CurrentDate.AddDays(1);
            dayTimer = 0f;

            OnDayChanged?.Invoke(CurrentDate);

            if (CurrentDate.Day == 1)
            {
                OnMonthChanged?.Invoke(CurrentDate);
            }

            if (CurrentDate.Month == 1 && CurrentDate.Day == 1)
            {
                OnYearChanged?.Invoke(CurrentDate);
            }
        }
    }
}