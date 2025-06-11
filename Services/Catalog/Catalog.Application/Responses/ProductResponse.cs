namespace Catalog.Application.Responses
{
    public record ProductResponse(
        string Id,
        string Name,
        string Summary,
        string Description,
        string ImageFile,
        BrandResponse Brand,
        CategoryResponse Category,
        decimal Price)
    {
    }
}