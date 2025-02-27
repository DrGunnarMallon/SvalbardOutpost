using System;

public class Shipment
{
    public MarketSO Market { get; private set; }
    public int Amount { get; private set; }
    public DateTime ShippingDate { get; private set; }
    public int ShippingTime { get; private set; }

    public Shipment(MarketSO market, int amount, DateTime shippingDate, int shippingTime)
    {
        this.Market = market;
        this.Amount = amount;
        this.ShippingDate = shippingDate;
        this.ShippingTime = shippingTime;
    }

    public void ReduceShippingTime()
    {
        ShippingTime--;
    }
}