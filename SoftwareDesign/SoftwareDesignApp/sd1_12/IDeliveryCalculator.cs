namespace SoftwareDesign.sd1_12;

public interface IDeliveryCalculator
{
    decimal Calculate(decimal orderAmount, decimal weight);
}