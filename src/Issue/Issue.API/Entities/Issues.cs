using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Issue.API.Entities
{
    public class Issues
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public byte[] Image { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public int PostalCode { get; set; }
        public string Province { get; set; }
        public string Status { get; set; }
        public string Date { get; set; }
        public string RoadType { get; set; }
        public int IssueType { get; set; }
        public string AdminArea { get; set; }
        public int Count { get; set; }
        public string UID { get; set; }
    }
}
