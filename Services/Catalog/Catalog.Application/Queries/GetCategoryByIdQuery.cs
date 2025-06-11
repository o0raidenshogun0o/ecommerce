using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Queries
{
    public record GetCategoryByIdQuery(string Id) : IRequest<CategoryResponse>
    {
    }
}