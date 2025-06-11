using AutoMapper;
using Catalog.Application.Commands;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class UpdateProductByIdCommandHandler(
        IProductRepository productRepository,
        IBrandRepository brandRepository,
        ICategoryRepository categoryRepository,
        IMapper mapper) : IRequestHandler<UpdateProductByIdCommand, bool>
    {
        private readonly IProductRepository _productRepository = productRepository;
        private readonly IBrandRepository _brandRepository = brandRepository;
        private readonly ICategoryRepository _categoryRepository = categoryRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<bool> Handle(UpdateProductByIdCommand request, CancellationToken cancellationToken)
        {
            var existingProduct = await _productRepository.GetProductById(request.Id);
            //if (existingProduct is null)
            //{
            //    return false;
            //}

            _mapper.Map(request, existingProduct);
            existingProduct.Brand = await _brandRepository.GetBrandById(request.BrandId);
            existingProduct.Category = await _categoryRepository.GetCategoryById(request.CategoryId);

            var result = await _productRepository.UpdateProductById(existingProduct);
            return result;
        }
    }
}