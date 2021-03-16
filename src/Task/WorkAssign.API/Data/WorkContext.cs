using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkAssign.API.Data.Interface;
using WorkAssign.API.Entities;
using User.API.Settings;

namespace WorkAssign.API.Data
{
    public class WorkContext : IWorkContext
    {
        public WorkContext(IWorkDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            task = database.GetCollection<Work>(settings.CollectionName);

            WorkContextSeed.SeedData(task);
        }
        public IMongoCollection<Work> task { get; }
    }
}
