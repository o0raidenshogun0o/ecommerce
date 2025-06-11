using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using Catalog.Infrastructure.Data;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Repositories
{
    public class BrandRepository(ICatalogContext context) : IBrandRepository
    {
        private readonly ICatalogContext _context = context;

        public async Task<IEnumerable<Brand>> GetAllBrands()
        {
            return await _context.Brands.Find(FilterDefinition<Brand>.Empty).ToListAsync();
        }

        public async Task<Brand> GetBrandById(string id)
        {
            return await _context.Brands.Find(b => b.Id == id).FirstOrDefaultAsync();
        }
    }
}