using AutoMapper;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class GetCategoryByIdQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        : IRequestHandler<GetCategoryByIdQuery, CategoryResponse>
    {
        private readonly ICategoryRepository _categoryRepository = categoryRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<CategoryResponse> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetCategoryById(request.Id);
            var categoryResponse = _mapper.Map<CategoryResponse>(category);
            return categoryResponse;
        }
    }
}