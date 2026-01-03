using DomainDrivenDesignUdemy.Domain.Products;
using MediatR;

namespace DomainDrivenDesign.Application.Features.Products.GetAllProduct;

public sealed record GetAllProductQuery() : IRequest<List<Product>>;

internal sealed class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, List<Product>>
{
    private readonly IProductRepository _productRepository;

    public GetAllProductQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<List<Product>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
    {
        return await _productRepository.GetAllAsync(cancellationToken);
    }
}