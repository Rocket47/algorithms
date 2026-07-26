using System.Collections.Immutable;

namespace SoftwareDesign.sd1_11;

public class Sd11FunctionalProgramming
{
    public sealed record Order(
        Guid Id,
        Guid CustomerId,
        ImmutableList<OrderItem> Items,
        OrderStatus Status)
    {
        public decimal TotalAmount => Items.Sum(item => item.TotalPrice);

        public static Order Create(Guid customerId)
        {
            if (customerId == Guid.Empty)
                throw new ArgumentException(
                    "Не указан идентификатор клиента.",
                    nameof(customerId));

            return new Order(
                Id: Guid.NewGuid(),
                CustomerId: customerId,
                Items: ImmutableList<OrderItem>.Empty,
                Status: OrderStatus.Draft);
        }
    }
}