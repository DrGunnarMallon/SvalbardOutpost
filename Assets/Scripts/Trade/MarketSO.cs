using UnityEngine;

[CreateAssetMenu(fileName = "NewMarekt", menuName = "Market/Market")]
public class MarketSO : ScriptableObject
{
    public string marketName;
    public int marketStock;
    public float marketPrice;
    public int marketShippingTime;
    public int marketShippingCost;
}
