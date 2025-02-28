using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TradePanel : MonoBehaviour
{
    [SerializeField] private Transform containerPanel;
    [SerializeField] private GameObject marketPanelPrefab;

    private void Start()
    {
        foreach (MarketData market in GameManager.Instance.TradeManager.Markets)
        {
            GameObject marketPanelGO = Instantiate(marketPanelPrefab, containerPanel, false);
            MarketUIElement marketPanel = marketPanelGO.GetComponent<MarketUIElement>();
            marketPanel.Initialize(market);
        }
    }

}
