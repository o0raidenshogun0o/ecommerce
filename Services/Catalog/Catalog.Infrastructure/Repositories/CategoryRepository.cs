using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using Catalog.Infrastructure.Data;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Repositories
{
    public class CategoryRepository(ICatalogContext context) : ICategoryRepository
    {
        private readonly ICatalogContext _context = context;

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _context.Categories.Find(FilterDefinition<Category>.Empty).ToListAsync();
        }

        public async Task<Category> GetCategoryById(string id)
        {
            return await _context.Categories.Find(c => c.Id == id).FirstOrDefaultAsync();
        }
    }
}