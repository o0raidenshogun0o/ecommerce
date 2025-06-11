using MediatR;

namespace Catalog.Application.Commands
{
    public record UpdateProductByIdCommand(
        string Id,
        string Name,
        string Summary,
        string Description,
        string ImageFile,
        string BrandId,
        string CategoryId,
        decimal Price) : IRequest<bool>
    {
    }
}