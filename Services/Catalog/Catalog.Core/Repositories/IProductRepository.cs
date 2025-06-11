using Catalog.Core.Entities;
using Catalog.Core.Specs;

namespace Catalog.Core.Repositories
{
    public interface IProductRepository
    {
        Task<PagedResult<Product>> GetAllProducts(CatalogSpecParams catalogSpecParams);
        Task<Product> GetProductById(string id);
        Task<Product> CreateProduct(Product product);
        Task<bool> UpdateProductById(Product product);
        Task<bool> DeleteProductById(string id);
    }
}