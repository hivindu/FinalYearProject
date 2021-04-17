using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkAssign.API.Entities
{
    public class Work
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string UserUd { get; set; }
        public string IssueId { get; set; }
        public DateTime AssignedDate { get; set; }
        public string Status { get; set; }
        public string Area { get; set; }
        public string WorkerName { get; set; }
    }
}
