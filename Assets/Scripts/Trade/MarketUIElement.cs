using System;
using UnityEngine;

public class MarketUIElement : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI marketNameText;
    [SerializeField] private TMPro.TextMeshProUGUI marketStockText;
    [SerializeField] private TMPro.TextMeshProUGUI marketPriceText;
    [SerializeField] private TMPro.TextMeshProUGUI marketShippingTimeText;
    [SerializeField] private TMPro.TextMeshProUGUI marketShippingCostText;
    [SerializeField] private TMPro.TextMeshProUGUI transferAmountText;
    [SerializeField] private TMPro.TextMeshProUGUI sellAmountText;

    [SerializeField] private ShipmentUI shipmentUI;

    private MarketData market;
    private int transferAmount = 0;
    private int sellAmount = 0;

    public void Initialize(MarketData market)
    {
        this.market = market;
        market.ResetStock();

        marketNameText.text = market.MarketName;
        marketStockText.text = market.MarketStock.ToString();
        marketPriceText.text = market.MarketPrice.ToString("F2");
        marketShippingTimeText.text = market.MarketShippingTime.ToString();
        marketShippingCostText.text = market.MarketShippingCost.ToString();
        transferAmountText.text = "0";
        sellAmountText.text = "0";

        if (shipmentUI != null)
            shipmentUI.gameObject.SetActive(false);

        GameManager.Instance.TradeManager.OnMarketStockChanged += OnMarketStockChanged;
        GameManager.Instance.TradeManager.OnMarketPriceChanged += OnMarketPriceChanged;
    }

    private void OnDestroy()
    {
        GameManager.Instance.TradeManager.OnMarketStockChanged -= OnMarketStockChanged;
        GameManager.Instance.TradeManager.OnMarketPriceChanged -= OnMarketPriceChanged;
    }

    public void ChangeTransferAmount(int amount)
    {
        if (amount > 0)
        {
            int availableCoal = GameManager.Instance.ResourceManager.Coal;
            if (availableCoal < amount) return;

            GameManager.Instance.ResourceManager.UseCoal(amount);
            transferAmount += amount;
        }
        else
        {
            int decrease = Mathf.Min(Mathf.Abs(amount), transferAmount);
            transferAmount -= decrease;
            GameManager.Instance.ResourceManager.AddCoal(decrease);
        }
        transferAmountText.text = transferAmount.ToString();
    }

    public void ChangeSellAmount(int amount)
    {
        if (amount > 0)
        {
            int availableStock = market.MarketStock;
            if (availableStock < amount) return;

            market.RemoveStock(amount);
            sellAmount += amount;
        }
        else
        {
            int decrease = Mathf.Min(Mathf.Abs(amount), sellAmount);
            Debug.Log($"Decrease: {decrease}");
            sellAmount -= decrease;
            market.AddStock(decrease);
        }
        marketStockText.text = market.MarketStock.ToString();
        sellAmountText.text = sellAmount.ToString();
    }

    public void ConfirmTransfer()
    {
        if (transferAmount > 0)
        {
            if (GameManager.Instance.TradeManager.HasActiveShipment(market)) { return; }

            Shipment newShipment = new Shipment(market, transferAmount, GameManager.Instance.TimeManager.CurrentDate, market.MarketShippingTime);
            GameManager.Instance.TradeManager.AddShipping(newShipment);
            GameManager.Instance.ResourceManager.UseMoney(market.MarketShippingCost);
            transferAmount = 0;
            transferAmountText.text = "0";
        }
    }

    public void ConfirmSale()
    {
        if (sellAmount > 0)
        {
            float salesValue = sellAmount * market.MarketPrice;
            GameManager.Instance.ResourceManager.AddMoney(Mathf.RoundToInt(salesValue));
            sellAmount = 0;
            sellAmountText.text = "0";
        }
    }

    public void CancelTransfer()
    {
        GameManager.Instance.ResourceManager.AddCoal(transferAmount);
        transferAmount = 0;
        transferAmountText.text = "0";
    }

    public void CancelSale()
    {
        market.AddStock(sellAmount);
        sellAmount = 0;
        sellAmountText.text = "0";
    }

    private void OnMarketStockChanged(MarketData updatedMarket)
    {
        if (market == updatedMarket)
        {
            marketStockText.text = market.MarketStock.ToString();
        }
    }

    private void OnMarketPriceChanged(MarketData updatedMarket)
    {
        if (market == updatedMarket)
        {
            marketPriceText.text = market.MarketPrice.ToString("F2");
            marketShippingCostText.text = market.MarketShippingCost.ToString();
            marketShippingTimeText.text = market.MarketShippingTime.ToString();
        }
    }

    private void Update()
    {
        if (shipmentUI != null)
        {
            Shipment shipment = GameManager.Instance.TradeManager.GetActiveShipment(market);
            if (shipment != null)
            {
                shipmentUI.gameObject.SetActive(true);
                shipmentUI.UpdateIndicator(shipment.TotalShippingTime, shipment.ShippingTime);
            }
            else
            {
                shipmentUI.gameObject.SetActive(false);
            }
        }
    }
}
