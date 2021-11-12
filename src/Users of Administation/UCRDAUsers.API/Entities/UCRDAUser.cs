using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace UCRDAUsers.API.Entities
{
    public class UCRDAUser
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }
        public string Password { get; set; }
        public int Work { get; set; }
        public int Type { get; set; }
        public string LocationArea { get; set; }
        public string NIC { get; set; }
    }
}
