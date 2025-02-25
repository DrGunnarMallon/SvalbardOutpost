using System.Diagnostics.Tracing;
using UnityEngine;

public class NewsManager : MonoBehaviour
{
    [SerializeField] private GameObject newsItemPrefab;
    [SerializeField] private Transform contentContainer;

    private void Start()
    {
        GameManager.Instance.EventManager.OnHistoricalEvent += AddNewsItem;
    }

    private void OnDestroy()
    {
        GameManager.Instance.EventManager.OnHistoricalEvent -= AddNewsItem;
    }

    public void AddNewsItem(HistoricalEventDataSO historicalEvent)
    {
        GameObject newsItemGO = Instantiate(newsItemPrefab, contentContainer);
        newsItemGO.transform.SetAsFirstSibling();

        NewsItem newsItem = newsItemGO.GetComponent<NewsItem>();
        if (newsItem != null)
        {
            newsItem.Setup(historicalEvent);
        }
    }
}
