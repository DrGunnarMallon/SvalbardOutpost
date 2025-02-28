using System;
using System.Collections.Generic;
using UnityEngine;

public class TradeManager : MonoBehaviour
{
    public event Action<MarketData> OnMarketStockChanged;
    public event Action<MarketData> OnMarketPriceChanged;

    [field: SerializeField] public MarketListSO MarketsList { get; private set; }
    [field: SerializeField] public Transform TradePanel { get; private set; }

    private ShippingService shippingService;
    public List<MarketData> Markets { get; private set; }

    private void Start()
    {
        Markets = new List<MarketData>();

        foreach (MarketSO market in MarketsList.markets)
        {
            Markets.Add(new MarketData(market));
        }

        shippingService = new ShippingService();
        shippingService.OnShipmentDelivered += HandleShipmentDelivered;
        GameManager.Instance.TimeManager.OnDayChanged += OnDayChanged;
        GameManager.Instance.TimeManager.OnMonthChanged += OnMonthChanged;
    }

    private void OnDestroy()
    {
        GameManager.Instance.TimeManager.OnDayChanged -= OnDayChanged;
        shippingService.OnShipmentDelivered -= HandleShipmentDelivered;
        GameManager.Instance.TimeManager.OnMonthChanged -= OnMonthChanged;
    }

    public void AddShipping(Shipment shipping)
    {
        shippingService.AddShipment(shipping);
    }

    // Expose a method to check if the market already has an active shipment.
    public bool HasActiveShipment(MarketData market)
    {
        return shippingService.HasActiveShipment(market);
    }

    // Expose a method to get the active shipment for a market.
    public Shipment GetActiveShipment(MarketData market)
    {
        return shippingService.GetActiveShipment(market);
    }

    private void OnDayChanged(DateTime currentDate)
    {
        shippingService.ProcessShipments();

        foreach (MarketData market in Markets)
        {
            float rn = UnityEngine.Random.Range(0f, 1f);
            if (rn < 0.02f)
            {
                market.UpdateMarketPrice(UnityEngine.Random.Range(0.9f, 1.1f));
                market.UpdateMarketShippingCost(UnityEngine.Random.Range(5, 10));
                market.UpdateMarketShippingTime(Mathf.RoundToInt(UnityEngine.Random.Range(-1, 1)));
                OnMarketPriceChanged?.Invoke(market);
            }
        }
    }

    private void OnMonthChanged(DateTime currentDate)
    {
        foreach (MarketData market in Markets)
        {
            market.UpdateMarketPrice(UnityEngine.Random.Range(0.9f, 1.1f));
            market.UpdateMarketShippingCost(UnityEngine.Random.Range(5, 10));
            market.UpdateMarketShippingTime(UnityEngine.Random.Range(-1, 1));
            OnMarketPriceChanged?.Invoke(market);
        }
    }

    private void HandleShipmentDelivered(Shipment shipment)
    {
        shipment.Market.AddStock(shipment.Amount);
        OnMarketStockChanged?.Invoke(shipment.Market);
        DateTime currentDate = GameManager.Instance.TimeManager.CurrentDate;
        TradeEvent tradeEvent = new TradeEvent(currentDate, "Shipment Delivered", $"Shipment of {shipment.Amount} coal has been delivered to {shipment.Market.MarketName}");
        GameManager.Instance.EventManager.RaiseTradeEvent(tradeEvent);
    }
}
