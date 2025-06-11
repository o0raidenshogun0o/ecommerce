using Catalog.Core.Entities;
using Catalog.Infrastructure.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data
{
    public class CatalogContext : ICatalogContext
    {
        public IMongoCollection<Product> Products { get; }
        public IMongoCollection<Brand> Brands { get; }
        public IMongoCollection<Category> Categories { get; }

        public CatalogContext(IOptions<DatabaseSettings> options)
        {
            var settings = options.Value;

            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            Brands = database.GetCollection<Brand>(settings.BrandsCollection);
            Categories = database.GetCollection<Category>(settings.CategoriesCollection);
            Products = database.GetCollection<Product>(settings.ProductsCollection);
        }

        //public CatalogContext(IConfiguration configuration)
        //{
        //    var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
        //    var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));
        //    Brands = database.GetCollection<Brand>(configuration.GetValue<string>("DatabaseSettings:BrandsCollection"));
        //    Categories =
        //        database.GetCollection<Category>(
        //            configuration.GetValue<string>("DatabaseSettings:CategoriesCollection"));
        //    Products = database.GetCollection<Product>(
        //        configuration.GetValue<string>("DatabaseSettings:ProductsCollection"));
        // builder.Services.Configure<DatabaseSettings>(
        // builder.Configuration.GetSection("DatabaseSettings"));
        //}

        public async Task SeedAsync()
        {
            await BrandContextSeed.SeedData(Brands);
            await CategoryContextSeed.SeedData(Categories);
            await ProductContextSeed.SeedData(Products);
        }
    }
}