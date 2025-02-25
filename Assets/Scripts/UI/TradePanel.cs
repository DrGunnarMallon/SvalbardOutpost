using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TradePanel : MonoBehaviour
{
    [SerializeField] private Transform containerPanel;
    [SerializeField] private GameObject marketPanelPrefab;

    [SerializeField] private TextMeshProUGUI availableCoalText;

    private void Start()
    {
        List<MarketSO> markets = GameManager.Instance.TradeManager.Markets.markets;

        availableCoalText.text = GameManager.Instance.ResourceManager.Coal.ToString();

        foreach (MarketSO market in markets)
        {
            GameObject marketPanelGO = Instantiate(marketPanelPrefab, containerPanel, false);
            MarketPanel marketPanel = marketPanelGO.GetComponent<MarketPanel>();
            marketPanel.Initialize(market);
        }

        GameManager.Instance.ResourceManager.onCoalChanged += OnCoalChanged;
    }

    private void OnCoalChanged(int coal)
    {
        availableCoalText.text = coal.ToString();
    }
}
