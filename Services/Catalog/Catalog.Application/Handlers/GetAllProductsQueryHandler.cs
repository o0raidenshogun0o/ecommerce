using AutoMapper;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using Catalog.Core.Specs;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class GetAllProductsQueryHandler(IProductRepository productRepository, IMapper mapper)
        : IRequestHandler<GetAllProductsQuery, PagedResult<ProductResponse>>
    {
        private readonly IProductRepository _productRepository = productRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<PagedResult<ProductResponse>> Handle(GetAllProductsQuery request,
            CancellationToken cancellationToken)
        {
            var productPagedResult = await _productRepository.GetAllProducts(request.CatalogSpecParams);
            var productResponsePagedResult = _mapper.Map<PagedResult<ProductResponse>>(productPagedResult);
            return productResponsePagedResult;
        }
    }
}