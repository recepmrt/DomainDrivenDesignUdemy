using MediatR;

namespace DomainDrivenDesignUdemy.Domain.Orders.Events;

public class SendOrderSmsEvent : INotificationHandler<OrderDomainEvent>
{
    public Task Handle(OrderDomainEvent notification, CancellationToken cancellationToken)
    {
        // sms gönderme işlemleri
        return Task.CompletedTask;
    }
}