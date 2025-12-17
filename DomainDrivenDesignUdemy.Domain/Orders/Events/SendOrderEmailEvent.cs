using MediatR;

namespace DomainDrivenDesignUdemy.Domain.Orders.Events;

public class SendOrderEmailEvent : INotificationHandler<OrderDomainEvent>
{
    public Task Handle(OrderDomainEvent notification, CancellationToken cancellationToken)
    {
        // mail gönderme işlemleri
        return Task.CompletedTask;
    }
}