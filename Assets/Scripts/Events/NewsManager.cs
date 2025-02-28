using UnityEngine;

public class NewsManager : MonoBehaviour
{
    [SerializeField] private GameObject newsItemPrefab;
    [SerializeField] private Transform contentContainer;

    private void Start()
    {
        GameManager.Instance.EventManager.OnHistoricalEvent += AddHistoricalNewsItem;
        GameManager.Instance.EventManager.OnTradeEvent += AddTradeNewsItem;
    }

    private void OnDestroy()
    {
        GameManager.Instance.EventManager.OnHistoricalEvent -= AddHistoricalNewsItem;
        GameManager.Instance.EventManager.OnTradeEvent -= AddTradeNewsItem;
    }

    private void AddHistoricalNewsItem(IGameEvent historicalEvent)
    {
        GameObject newsItemGO = Instantiate(newsItemPrefab, contentContainer);
        newsItemGO.transform.SetAsFirstSibling();

        NewsItem newsItem = newsItemGO.GetComponent<NewsItem>();
        if (newsItem != null)
        {
            newsItem.Setup(historicalEvent);
        }
    }

    private void AddTradeNewsItem(IGameEvent tradeEvent)
    {
        GameObject newsItemGO = Instantiate(newsItemPrefab, contentContainer);
        newsItemGO.transform.SetAsFirstSibling();

        NewsItem newsItem = newsItemGO.GetComponent<NewsItem>();
        if (newsItem != null)
        {
            newsItem.Setup(tradeEvent);
        }
    }
}
