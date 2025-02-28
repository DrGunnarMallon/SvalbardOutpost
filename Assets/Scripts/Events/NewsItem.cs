using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NewsItem : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI dateText;
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI descriptionText;

    [SerializeField] private Sprite historicalEventIcon;
    [SerializeField] private Sprite tradeEventIcon;

    public void Setup(IGameEvent gameEvent)
    {
        if (gameEvent is HistoricalEventDataSO)
        {
            icon.sprite = historicalEventIcon;
        }
        else if (gameEvent is TradeEvent)
        {
            icon.sprite = tradeEventIcon;
        }

        dateText.text = gameEvent.EventDate.ToString("MMM dd, yyyy");
        titleText.text = gameEvent.EventName;
        descriptionText.text = gameEvent.EventDescription;
    }

    public void Dismiss()
    {
        Destroy(gameObject);
    }
}