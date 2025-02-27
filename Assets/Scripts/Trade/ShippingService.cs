using System;
using System.Collections.Generic;

public class ShippingService
{
    private readonly List<Shipment> activeShipments = new List<Shipment>();

    public event Action<Shipment> OnShipmentDelivered;

    public void AddShipment(Shipment shipment)
    {
        activeShipments.Add(shipment);
    }

    public void ProcessShipments()
    {
        List<Shipment> deliveredShipments = new List<Shipment>();

        foreach (Shipment shipment in activeShipments)
        {
            shipment.ReduceShippingTime();
            if (shipment.ShippingTime <= 0)
            {
                deliveredShipments.Add(shipment);
            }
        }

        foreach (Shipment shipment in deliveredShipments)
        {
            OnShipmentDelivered?.Invoke(shipment);
            activeShipments.Remove(shipment);
        }
    }
}