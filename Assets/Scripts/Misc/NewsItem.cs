using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NewsItem : MonoBehaviour
{
    // [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI dateText;
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI descriptionText;

    public void Setup(HistoricalEventDataSO historicalEvent)
    {
        // icon.sprite = historicalEvent.icon;
        dateText.text = historicalEvent.EventDate.ToString("MMM dd, yyyy");
        titleText.text = historicalEvent.eventName;
        descriptionText.text = historicalEvent.description;
    }

    public void Dismiss()
    {
        Destroy(gameObject);
    }
}