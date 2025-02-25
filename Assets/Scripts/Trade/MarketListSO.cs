using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewMarket", menuName = "Market/Market List")]
public class MarketListSO : ScriptableObject
{
    public List<MarketSO> markets = new List<MarketSO>();
}
