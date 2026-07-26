namespace SoftwareDesign.sd1_12;

public class CheckoutService(IDeliveryCalculator deliveryCalculator)
{
    public CheckoutResult Checkout(
        decimal orderAmount,
        decimal weight)
    {
        var deliveryCost = deliveryCalculator.Calculate(orderAmount, weight);

        return new CheckoutResult(
            OrderAmount: orderAmount,
            DeliveryCost: deliveryCost,
            TotalAmount: orderAmount + deliveryCost);
    }
}