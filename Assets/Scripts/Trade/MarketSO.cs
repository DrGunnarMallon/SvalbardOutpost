using UnityEngine;

[CreateAssetMenu(fileName = "NewMarekt", menuName = "Market/Market")]
public class MarketSO : ScriptableObject
{
    public string marketName;
    public int marketStock;
    public float marketPrice;
    public int marketShippingTime;
    public int marketShippingCost;

    public void AddStock(int amount)
    {
        marketStock += amount;
    }

    public float SellStock(int amount)
    {
        if (amount > marketStock)
        {
            amount = marketStock;
        }

        float salesValue = amount * marketPrice;
        marketStock -= amount;
        return salesValue;
    }

    public void ResetStock()
    {
        marketStock = 0;
    }
}
