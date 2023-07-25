using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace GroceryStoreApi.Models
{
    public class Grocery
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public string? Id { get; set; }
        [BsonElement("Name")]
        [JsonPropertyName("Name")]
        public string GroceryName { get; set; } = null!;
        public decimal Price { get; set; }
        public string Category { get; set; } = null!;

    }
}
