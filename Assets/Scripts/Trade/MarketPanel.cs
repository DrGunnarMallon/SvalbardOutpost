using UnityEngine;

public class MarketPanel : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI marketNameText;
    [SerializeField] private TMPro.TextMeshProUGUI marketStockText;
    [SerializeField] private TMPro.TextMeshProUGUI marketPriceText;
    [SerializeField] private TMPro.TextMeshProUGUI marketShippingTimeText;
    [SerializeField] private TMPro.TextMeshProUGUI marketShippingCostText;

    private MarketSO market;

    public void Initialize(MarketSO market)
    {
        this.market = market;
        marketNameText.text = market.marketName;
        marketStockText.text = market.marketStock.ToString();
        marketPriceText.text = market.marketPrice.ToString();
        marketShippingTimeText.text = market.marketShippingTime.ToString();
        marketShippingCostText.text = market.marketShippingCost.ToString();
    }
}
