using DomainDrivenDesignUdemy.Domain.Users;
using DomainDrivenDesignUdemy.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DomainDrivenDesignUdemy.Infrastructure.Repositories;

internal sealed class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _dbContext;

    public UserRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User> CreateAsync(string name, string email, string password, string country, string city, string street,
        string postalCode, string fullAddress, CancellationToken cancellationToken = default)
    {
        User user = User.CreateUser(name, email, password, country, city, street, postalCode, fullAddress);
        await _dbContext.AddAsync(user, cancellationToken);

        return user;
    }

    public Task<List<User>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return _dbContext.Users.ToListAsync(cancellationToken);
    }
}