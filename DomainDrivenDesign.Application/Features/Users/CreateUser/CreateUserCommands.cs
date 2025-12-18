using MediatR;

namespace DomainDrivenDesign.Application.Features.Users.CreateUser;

public sealed record CreateUserCommands(
    string Name,
    string Email,
    string Password,
    string Country,
    string City,
    string Street,
    string PostalCode,
    string FullAddress) : IRequest;