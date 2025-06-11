using Catalog.Core.Entities;
using MongoDB.Driver;
using System.Text.Json;

namespace Catalog.Infrastructure.Data
{
    public static class BrandContextSeed
    {
        public static async Task SeedData(IMongoCollection<Brand> brandCollection)
        {
            bool checkBrands = await brandCollection.Find(FilterDefinition<Brand>.Empty).AnyAsync();
            string path = Path.Combine(AppContext.BaseDirectory, "Data", "SeedData", "brands.json");
            if (!checkBrands)
            {
                var brandsData = await File.ReadAllTextAsync(path);
                var brands = JsonSerializer.Deserialize<List<Brand>>(brandsData);
                if (brands is { Count: > 0 })
                {
                    //foreach (var brand in brands)
                    //{
                    //    await brandCollection.InsertOneAsync(brand);
                    //}
                    await brandCollection.InsertManyAsync(brands);
                }
            }
        }
    }
}