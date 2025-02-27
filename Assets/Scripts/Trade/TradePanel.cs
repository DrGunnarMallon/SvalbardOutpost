using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TradePanel : MonoBehaviour
{
    [SerializeField] private Transform containerPanel;
    [SerializeField] private GameObject marketPanelPrefab;
    [SerializeField] private TextMeshProUGUI availableCoalText;

    // private int availableCoal;

    private void Start()
    {
        List<MarketSO> markets = GameManager.Instance.TradeManager.Markets.markets;
        // availableCoalText.text = GameManager.Instance.ResourceManager.Coal.ToString();
        // // availableCoal = GameManager.Instance.ResourceManager.Coal;

        // foreach (MarketSO market in markets)
        // {
        //     GameObject marketPanelGO = Instantiate(marketPanelPrefab, containerPanel, false);
        //     MarketUIElement marketPanel = marketPanelGO.GetComponent<MarketUIElement>();
        //     marketPanel.Initialize(market);
        // }
        foreach (MarketSO market in markets)
        {
            GameObject marketPanelGO = Instantiate(marketPanelPrefab, containerPanel, false);
            MarketUIElement marketPanel = marketPanelGO.GetComponent<MarketUIElement>();
            marketPanel.Initialize(market);
        }

        GameManager.Instance.ResourceManager.onCoalChanged += OnCoalChanged;
        availableCoalText.text = GameManager.Instance.ResourceManager.Coal.ToString();
    }

    private void OnDestroy()
    {
        GameManager.Instance.ResourceManager.onCoalChanged -= OnCoalChanged;
    }

    private void OnCoalChanged(int coal)
    {
        // availableCoal += coal;
        availableCoalText.text = coal.ToString();
    }
}
