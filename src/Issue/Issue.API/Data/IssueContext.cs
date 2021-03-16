using Issue.API.Data.Interfaces;
using Issue.API.Entities;
using Issue.API.Settings;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Issue.API.Data
{
    public class IssueContext : IIssueContext
    {
        public IssueContext(IIssueDatabaseSettings settings)
        {
           var client = new MongoClient(settings.ConnectionString);
           var database = client.GetDatabase(settings.DatabaseName);
           issues = database.GetCollection<Issues>(settings.CollectionName);

            IssueContextSeed.SeedData(issues);
        }

        public IMongoCollection<Issues> issues { get; }
    }
}
