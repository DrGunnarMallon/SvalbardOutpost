using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject managementPanel;
    public EventPanel eventPanel;
    public GameObject timePanel;
    public ResourcePanel resourcePanel;

    public NewsPanel newsPanel;
    public ResearchPanel researchPanel;
    public TradePanel tradePanel;
    public WorkerPanel workersPanel;
    public MiningPanel miningPanel;
    public NavigationPanel navigationPanel;

    private void HideAllUI()
    {
        managementPanel.SetActive(false);
        newsPanel.gameObject.SetActive(false);
        researchPanel.gameObject.SetActive(false);
        tradePanel.gameObject.SetActive(false);
        workersPanel.gameObject.SetActive(false);
        miningPanel.gameObject.SetActive(false);
        GameManager.Instance.Player.gameObject.SetActive(false);
    }

    public void ShowEventUI()
    {
        HideAllUI();
        eventPanel.gameObject.SetActive(true);
    }

    public void ShowResourceUI()
    {
        HideAllUI();
        resourcePanel.gameObject.SetActive(true);
    }

    public void ShowManagementUI()
    {
        HideAllUI();
        managementPanel.SetActive(true);
    }

    public void ShowNewsUI()
    {
        HideAllUI();
        newsPanel.gameObject.SetActive(true);
    }

    public void ShowResearchUI()
    {
        HideAllUI();
        researchPanel.gameObject.SetActive(true);
    }

    public void ShowTradeUI()
    {
        HideAllUI();
        tradePanel.gameObject.SetActive(true);
    }

    public void ShowWorkersUI()
    {
        HideAllUI();
        workersPanel.gameObject.SetActive(true);
    }

    public void ShowMiningUI()
    {
        HideAllUI();
        GameManager.Instance.Player.gameObject.SetActive(true);
        miningPanel.gameObject.SetActive(true);
    }
}
