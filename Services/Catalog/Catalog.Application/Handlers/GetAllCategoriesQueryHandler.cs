using AutoMapper;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class GetAllCategoriesQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        : IRequestHandler<GetAllCategoriesQuery, IEnumerable<CategoryResponse>>
    {
        private readonly ICategoryRepository _categoryRepository = categoryRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<CategoryResponse>> Handle(GetAllCategoriesQuery request,
            CancellationToken cancellationToken)
        {
            var categoryEnumerable = await _categoryRepository.GetAllCategories();
            var categoryResponseEnumerable = _mapper.Map<IEnumerable<CategoryResponse>>(categoryEnumerable);
            return categoryResponseEnumerable;
        }
    }
}