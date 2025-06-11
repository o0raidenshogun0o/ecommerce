using AutoMapper;
using Catalog.Application.Commands;
using Catalog.Application.Responses;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class CreateProductCommandHandler(
        IProductRepository productRepository,
        IBrandRepository brandRepository,
        ICategoryRepository categoryRepository,
        IMapper mapper) : IRequestHandler<CreateProductCommand, ProductResponse>
    {
        private readonly IProductRepository _productRepository = productRepository;
        private readonly IBrandRepository _brandRepository = brandRepository;
        private readonly ICategoryRepository _categoryRepository = categoryRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<ProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);

            product.Brand = await _brandRepository.GetBrandById(request.BrandId);
            product.Category = await _categoryRepository.GetCategoryById(request.CategoryId);

            var newProduct = await _productRepository.CreateProduct(product);
            var newProductResponse = _mapper.Map<ProductResponse>(newProduct);
            return newProductResponse;
        }
    }
}