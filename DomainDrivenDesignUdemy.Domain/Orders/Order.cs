using DomainDrivenDesignUdemy.Domain.Abstractions;

namespace DomainDrivenDesignUdemy.Domain.Orders;

public sealed class Order : Entity
{
    public Order(Guid id, string orderNumber, DateTime createdDate, OrderStatusEnum statusEnum, ICollection<OrderLine> orderLines) : base(id)
    {
        OrderNumber = orderNumber;
        CreatedDate = createdDate;
        StatusEnum = statusEnum;
        OrderLines = orderLines;
    }

    public string OrderNumber { get; private set; }
    public DateTime CreatedDate { get; private set; }
    public OrderStatusEnum StatusEnum { get; private set; }
    public ICollection<OrderLine> OrderLines { get; private set; }
}