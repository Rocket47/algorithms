namespace SoftwareDesign.sd1_12;

public class DeliveryCostCalculator
    : IDeliveryCalculator
{
    private const decimal FixedPrice = 30m;

    public decimal Calculate(decimal orderAmount, decimal weight)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(orderAmount);

        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(weight);

        return FixedPrice;
    }
}