using AutoMapper;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class GetBrandByIdQueryHandler(IBrandRepository brandRepository, IMapper mapper)
        : IRequestHandler<GetBrandByIdQuery, BrandResponse>
    {
        private readonly IBrandRepository _brandRepository = brandRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<BrandResponse> Handle(GetBrandByIdQuery request, CancellationToken cancellationToken)
        {
            var brand = await _brandRepository.GetBrandById(request.Id);
            var brandResponse = _mapper.Map<BrandResponse>(brand);
            return brandResponse;
        }
    }
}