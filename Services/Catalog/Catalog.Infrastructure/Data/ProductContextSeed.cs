using MongoDB.Driver;
using System.Text.Json;
using Catalog.Core.Entities;

namespace Catalog.Infrastructure.Data
{
    public class ProductContextSeed
    {
        public static async Task SeedData(IMongoCollection<Product> productCollection)
        {
            bool checkProducts = await productCollection.Find(FilterDefinition<Product>.Empty).AnyAsync();
            string path = Path.Combine(AppContext.BaseDirectory, "Data", "SeedData", "products.json");
            if (!checkProducts)
            {
                var productsData = await File.ReadAllTextAsync(path);
                var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                if (products is { Count: > 0 })
                {
                    //foreach (var product in products)
                    //{
                    //    await productCollection.InsertOneAsync(product);
                    //}
                    await productCollection.InsertManyAsync(products);
                }
            }
        }
    }
}