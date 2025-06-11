using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.Core.Entities
{
    public class Category : BaseEntity
    {
        [BsonElement("Name")]
        public string Name { get; set; }
    }
}