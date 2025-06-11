using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using Catalog.Core.Specs;
using Catalog.Infrastructure.Data;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Repositories
{
    public class ProductRepository(ICatalogContext context) : IProductRepository
    {
        private readonly ICatalogContext _context = context;

        public async Task<Product> CreateProduct(Product product)
        {
            await _context.Products.InsertOneAsync(product);
            return product;
        }

        public async Task<bool> UpdateProductById(Product product)
        {
            var updatedProduct = await _context.Products.ReplaceOneAsync(p => p.Id == product.Id, product);
            return updatedProduct is { IsAcknowledged: true, ModifiedCount: > 0 };
        }

        public async Task<bool> DeleteProductById(string id)
        {
            var deletedProduct = await _context.Products.DeleteOneAsync(p => p.Id == id);
            return deletedProduct is { IsAcknowledged: true, DeletedCount: > 0 };
        }

        public async Task<Product> GetProductById(string id)
        {
            return await _context.Products.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<PagedResult<Product>> GetAllProducts(CatalogSpecParams catalogSpecParams)
        {
            var filter = GetFilterDefinition(catalogSpecParams);

            var pageNumber = catalogSpecParams.PageNumber;
            var pageSize = catalogSpecParams.PageSize;
            var totalItems = await _context.Products.CountDocumentsAsync(filter);
            var items = await GetItemsFilter(catalogSpecParams, filter);
            return new PagedResult<Product>(pageNumber, pageSize, totalItems, items);
        }

        private FilterDefinition<Product> GetFilterDefinition(CatalogSpecParams catalogSpecParams)
        {
            var builder = Builders<Product>.Filter;
            var filterDefinition = builder.Empty;
            if (!string.IsNullOrEmpty(catalogSpecParams.Search))
            {
                filterDefinition = filterDefinition &
                                   builder.Regex(p => p.Name, new BsonRegularExpression(catalogSpecParams.Search, "i"));
            }

            if (!string.IsNullOrEmpty(catalogSpecParams.BrandId))
            {
                filterDefinition = filterDefinition & builder.Eq(p => p.Brand.Id, catalogSpecParams.BrandId);
            }

            if (!string.IsNullOrEmpty(catalogSpecParams.CategoryId))
            {
                filterDefinition = filterDefinition & builder.Eq(p => p.Category.Id, catalogSpecParams.CategoryId);
            }

            return filterDefinition;
        }

        private SortDefinition<Product> GetSortDefinition(CatalogSpecParams catalogSpecParams)
        {
            var builder = Builders<Product>.Sort;
            var sortDefinition = catalogSpecParams.Sort switch
            {
                "priceAsc" => builder.Ascending(p => p.Price),
                "priceDesc" => builder.Descending(p => p.Price),
                _ => builder.Ascending(p => p.Name)
            };
            return sortDefinition;
        }

        private async Task<IReadOnlyList<Product>> GetItemsFilter(CatalogSpecParams catalogSpecParams,
            FilterDefinition<Product> filterDefinition)
        {
            var sortDefinition = GetSortDefinition(catalogSpecParams);

            var pageNumber = catalogSpecParams.PageNumber;
            var pageSize = catalogSpecParams.PageSize;
            var skip = (pageNumber - 1) * pageSize;
            var limit = pageSize;
            return await _context.Products
                .Find(filterDefinition)
                .Sort(sortDefinition)
                .Skip(skip)
                .Limit(limit)
                .ToListAsync();
        }
    }
}