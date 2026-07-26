namespace SoftwareDesign.sd1_12;

public record CheckoutResult(
    decimal OrderAmount,
    decimal DeliveryCost,
    decimal TotalAmount);