using DomainDrivenDesignUdemy.Domain.Orders;
using DomainDrivenDesignUdemy.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DomainDrivenDesignUdemy.Infrastructure.Repositories;

internal sealed class OrderRepository : IOrderRepository
{
    private readonly ApplicationDbContext _dbContext;

    public OrderRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Order> CreateAsync(List<CreateOrderDto> createOrderDtos, CancellationToken cancellationToken = default)
    {
        Order order = new(
            Guid.NewGuid(),
            "1",
            DateTime.Now,
            OrderStatusEnum.AwaitApproval);
        
        order.CreateOrder(createOrderDtos);
        
        await _dbContext.Orders.AddAsync(order, cancellationToken);
        return order;
    }

    public async Task<List<Order>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Orders.ToListAsync(cancellationToken); 
    }
}