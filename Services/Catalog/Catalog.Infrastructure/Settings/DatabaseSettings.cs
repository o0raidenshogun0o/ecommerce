namespace Catalog.Infrastructure.Settings
{
    public class DatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string ProductsCollection { get; set; }
        public string BrandsCollection { get; set; }
        public string CategoriesCollection { get; set; }
    }
}
