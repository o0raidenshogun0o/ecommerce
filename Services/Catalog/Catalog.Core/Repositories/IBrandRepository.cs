using Catalog.Core.Entities;

namespace Catalog.Core.Repositories
{
    public interface IBrandRepository
    {
        Task<IEnumerable<Brand>> GetAllBrands();
        Task<Brand> GetBrandById(string id);
    }
}