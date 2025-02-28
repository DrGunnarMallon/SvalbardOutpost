using System;

public class Shipment
{
    public MarketData Market { get; private set; }
    public int Amount { get; private set; }
    public DateTime ShippingDate { get; private set; }
    public int ShippingTime { get; private set; }
    public int TotalShippingTime { get; private set; } // New field to store the original shipping time.

    public Shipment(MarketData market, int amount, DateTime shippingDate, int shippingTime)
    {
        this.Market = market;
        this.Amount = amount;
        this.ShippingDate = shippingDate;
        this.ShippingTime = shippingTime;
        this.TotalShippingTime = shippingTime;
    }

    public void ReduceShippingTime()
    {
        ShippingTime--;
    }
}
