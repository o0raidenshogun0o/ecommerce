using Catalog.Core.Entities;

namespace Catalog.Core.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategories();
        Task<Category> GetCategoryById(string id);
    }
}