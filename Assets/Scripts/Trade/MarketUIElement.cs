using UnityEngine;

public class MarketUIElement : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI marketNameText;
    [SerializeField] private TMPro.TextMeshProUGUI marketStockText;
    [SerializeField] private TMPro.TextMeshProUGUI marketPriceText;
    [SerializeField] private TMPro.TextMeshProUGUI marketShippingTimeText;
    [SerializeField] private TMPro.TextMeshProUGUI marketShippingCostText;
    [SerializeField] private TMPro.TextMeshProUGUI transferAmountText;

    private MarketSO market;
    private int transferAmount;

    public void Initialize(MarketSO market)
    {
        this.market = market;
        market.ResetStock();

        marketNameText.text = market.marketName;
        marketStockText.text = market.marketStock.ToString();
        marketPriceText.text = market.marketPrice.ToString();
        marketShippingTimeText.text = market.marketShippingTime.ToString();
        marketShippingCostText.text = market.marketShippingCost.ToString();
        transferAmountText.text = "0";

        GameManager.Instance.TradeManager.OnMarketStockChanged += OnMarketStockChanged;
    }

    private void Destroy()
    {
        GameManager.Instance.TradeManager.OnMarketStockChanged -= OnMarketStockChanged;
    }

    public void IncreaseTransferAmount(int amount)
    {
        transferAmount += amount;
        transferAmountText.text = transferAmount.ToString();
    }

    public void DecreaseTransferAmount(int amount)
    {
        transferAmount = Mathf.Max(transferAmount - amount, 0);
        transferAmountText.text = transferAmount.ToString();
    }

    public void ConfirmTransfer()
    {
        if (transferAmount > 0)
        {
            Shipment newShipment = new Shipment(market, transferAmount, GameManager.Instance.TimeManager.currentDate, market.marketShippingTime);
            GameManager.Instance.TradeManager.AddShipping(newShipment);
            GameManager.Instance.ResourceManager.UseMoney(market.marketShippingCost);
            transferAmount = 0;
            transferAmountText.text = "0";
        }
    }

    private void OnMarketStockChanged(MarketSO ujpdatedMarket)
    {
        if (market == ujpdatedMarket)
        {
            marketStockText.text = market.marketStock.ToString();
        }
    }

    // public void ChangeTransferAmount(int amount)
    // {
    //     int availableCoal = GameManager.Instance.ResourceManager.Coal;

    //     if (availableCoal < amount) return;

    //     GameManager.Instance.ResourceManager.UseCoal(amount);

    //     transferAmount += amount;
    //     if (transferAmount < 0)
    //     {
    //         transferAmount = 0;
    //     }
    //     transferAmountText.text = transferAmount.ToString();
    // }

    // public void ConfirmTransfer()
    // {
    //     if (transferAmount > 0)
    //     {
    //         GameManager.Instance.TradeManager.AddShipping(new Shipment(market, transferAmount, GameManager.Instance.TimeManager.currentDate, market.marketShippingTime));
    //         GameManager.Instance.ResourceManager.UseMoney(market.marketShippingCost);
    //         transferAmount = 0;
    //         transferAmountText.text = "0";
    //     }
    // }

    // private void OnMarketStockChanged(MarketSO market)
    // {
    //     if (this.market == market)
    //     {
    //         marketStockText.text = market.marketStock.ToString();
    //     }
    // }
}
