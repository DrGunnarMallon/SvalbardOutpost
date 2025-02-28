using UnityEngine;

public class MarketData
{
    public string MarketName { get; private set; }
    public int MarketStock { get; private set; }
    public float MarketPrice { get; private set; }
    public int MarketShippingTime { get; private set; }
    public int MarketShippingCost { get; private set; }

    public MarketData(MarketSO marketSO)
    {
        MarketName = marketSO.marketName;
        MarketStock = marketSO.marketStock;
        MarketPrice = marketSO.marketPrice;
        MarketShippingTime = marketSO.marketShippingTime;
        MarketShippingCost = marketSO.marketShippingCost;
    }

    public void AddStock(int amount)
    {
        MarketStock += amount;
    }

    public void RemoveStock(int amount)
    {
        MarketStock = Mathf.Max(MarketStock - amount, 0);
    }

    public void ResetStock()
    {
        MarketStock = 0;
    }

    public void UpdateMarketPrice(float priceMultiplier)
    {
        MarketPrice *= priceMultiplier;
    }

    public void UpdateMarketShippingCost(int shippingCost)
    {
        MarketShippingCost += shippingCost;
        if (MarketShippingCost < 50)
        {
            MarketShippingCost = 50;
        }
    }

    public void UpdateMarketShippingTime(int shippingTime)
    {
        MarketShippingTime += shippingTime;
        if (MarketShippingTime < 4)
        {
            MarketShippingTime = 4;
        }
    }
}