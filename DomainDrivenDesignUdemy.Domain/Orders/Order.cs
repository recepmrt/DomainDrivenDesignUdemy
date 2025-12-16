using DomainDrivenDesignUdemy.Domain.Abstractions;

namespace DomainDrivenDesignUdemy.Domain.Orders;

public sealed class Order : Entity
{
    public Order(Guid id) : base(id)
    {
    }

    public string OrderNumber { get; set; }
    public DateTime CreatedDate { get; set; }
    public OrderStatusEnum StatusEnum { get; set; }
    public ICollection<OrderLine> OrderLines { get; set; }
}