using AutoMapper;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class GetAllBrandsQueryHandler(IBrandRepository brandRepository, IMapper mapper)
        : IRequestHandler<GetAllBrandsQuery, IEnumerable<BrandResponse>>
    {
        private readonly IBrandRepository _brandRepository = brandRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<BrandResponse>> Handle(GetAllBrandsQuery request,
            CancellationToken cancellationToken)
        {
            var brandEnumerable = await _brandRepository.GetAllBrands();
            var brandResponseEnumerable = _mapper.Map<IEnumerable<BrandResponse>>(brandEnumerable);
            return brandResponseEnumerable;
        }
    }
}