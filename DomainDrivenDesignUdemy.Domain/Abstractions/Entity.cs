namespace DomainDrivenDesignUdemy.Domain.Abstractions;

public abstract class Entity
{
    public Guid Id { get; init; } // Once the ID is obtained, init can be used to prevent it from being changed.

    public Entity(Guid id)
    {
        Id = id;
    }
}

