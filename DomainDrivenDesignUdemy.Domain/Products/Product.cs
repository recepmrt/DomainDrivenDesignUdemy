using DomainDrivenDesignUdemy.Domain.Abstractions;
using DomainDrivenDesignUdemy.Domain.Categories;

namespace DomainDrivenDesignUdemy.Domain.Products;

public sealed class Product : Entity // sealed: no other class can inherit from this class
{
    public Product(Guid id) : base(id)
    {
    }

    public string Name { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public string Currency { get; set; }
    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
}