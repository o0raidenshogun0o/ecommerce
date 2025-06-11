//using System.Security.Cryptography.X509Certificates;
//using AutoMapper;

//namespace Catalog.Application.Mappers
//{
//    public static class ProductMapper
//    {
//        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
//        {
//            var config = new MapperConfiguration(cfg =>
//            {
//                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
//                cfg.AddProfile<ProductMappingProfile>();
//            });
//            var mapper = config.CreateMapper();
//            return mapper;
//        });

//        public static IMapper Mapper => Lazy.Value;
//    }
//}

//using Catalog.Application.Mappers;
//builder.Services.AddSingleton<CatalogContext>();
//var builder = WebApplication.CreateBuilder(args);
//var app = builder.Build();

//// Lấy service CatalogContext từ DI container
//using (var scope = app.Services.CreateScope())
//{
//    var catalogContext = scope.ServiceProvider.GetRequiredService<CatalogContext>();
//    await catalogContext.SeedAsync();
//}

//app.Run();
//builder.Services.AddAutoMapper(typeof(ProductMappingProfile));