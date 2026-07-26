namespace SoftwareDesign.sd1_11;

public sealed record OrderItem(
    Guid ProductId,
    string ProductName,
    decimal UnitPrice,
    int Quantity)
{
    public decimal TotalPrice => UnitPrice * Quantity;
}