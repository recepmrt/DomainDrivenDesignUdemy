using DomainDrivenDesignUdemy.Domain.Orders;
using MediatR;

namespace DomainDrivenDesign.Application.Features.Orders.CreateOrder;

public sealed record CreateOrderCommand(
    List<CreateOrderDto> CreateOrderDtos) : IRequest;