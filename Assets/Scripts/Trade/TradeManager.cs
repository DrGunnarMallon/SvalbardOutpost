using System;
using System.Collections.Generic;
using UnityEngine;

public class TradeManager : MonoBehaviour
{
    public event Action<MarketSO> OnMarketStockChanged;

    [field: SerializeField] public MarketListSO Markets { get; private set; }
    [field: SerializeField] public Transform TradePanel { get; private set; }

    private ShippingService shippingService;

    private void Start()
    {
        shippingService = new ShippingService();
        shippingService.OnShipmentDelivered += HandleShipmentDelivered;
        GameManager.Instance.TimeManager.OnDayChanged += OnDayChanged;
    }

    private void OnDestroy()
    {
        GameManager.Instance.TimeManager.OnDayChanged -= OnDayChanged;
        shippingService.OnShipmentDelivered -= HandleShipmentDelivered;
    }


    public void AddShipping(Shipment shipping)
    {
        shippingService.AddShipment(shipping);
    }

    private void OnDayChanged(DateTime currentDate)
    {
        shippingService.ProcessShipments();
    }

    private void HandleShipmentDelivered(Shipment shipment)
    {
        shipment.Market.AddStock(shipment.Amount);
        OnMarketStockChanged?.Invoke(shipment.Market);
        Debug.Log($"Shipment of {shipment.Amount} to {shipment.Market.marketName} has arrived.");
    }
}
