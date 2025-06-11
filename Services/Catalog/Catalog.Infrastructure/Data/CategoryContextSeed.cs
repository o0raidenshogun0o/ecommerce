using MongoDB.Driver;
using System.Text.Json;
using Catalog.Core.Entities;

namespace Catalog.Infrastructure.Data
{
    public static class CategoryContextSeed
    {
        public static async Task SeedData(IMongoCollection<Category> categoryCollection)
        {
            bool checkCategories = await categoryCollection.Find(FilterDefinition<Category>.Empty).AnyAsync();
            string path = Path.Combine(AppContext.BaseDirectory, "Data", "SeedData", "categories.json");
            if (!checkCategories)
            {
                var categoriesData = await File.ReadAllTextAsync(path);
                var categories = JsonSerializer.Deserialize<List<Category>>(categoriesData);
                if (categories is { Count: > 0 })
                {
                    //foreach (var category in categories)
                    //{
                    //    await categoryCollection.InsertOneAsync(category);
                    //}
                    await categoryCollection.InsertManyAsync(categories);
                }
            }
        }
    }
}