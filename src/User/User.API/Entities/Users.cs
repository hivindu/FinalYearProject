using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace User.API.Entities
{
    public class Users
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }
        public string NIC { get; set; }
        public string Password { get; set; }
        public int PostalCode { get; set; }
        public string Area { get; set; }

    }
}
