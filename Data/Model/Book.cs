using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Data.Model
{
    public class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Category { get; set; }

        public string Author { get; set; }

        public string FirstName { get; set; }
    }
}
