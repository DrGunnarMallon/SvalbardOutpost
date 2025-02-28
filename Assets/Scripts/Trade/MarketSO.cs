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

    public void RemoveStock(int amount)
    {
        marketStock = Mathf.Max(marketStock - amount, 0);
    }

    public void ResetStock()
    {
        marketStock = 0;
    }
}
