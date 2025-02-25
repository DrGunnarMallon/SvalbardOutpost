using UnityEngine;
using TMPro;

public class DatePanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dateText;

    private void Start()
    {
        GameManager.Instance.TimeManager.OnDayChanged += UpdateDate;
    }

    private void OnDisable()
    {
        GameManager.Instance.TimeManager.OnDayChanged -= UpdateDate;
    }

    private void UpdateDate(System.DateTime newDate)
    {
        dateText.text = newDate.ToString("MMM dd, yyyy");
    }
}
