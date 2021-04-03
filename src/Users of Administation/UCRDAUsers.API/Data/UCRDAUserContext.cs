using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UCRDAUsers.API.Data.Interface;
using UCRDAUsers.API.Entities;
using UCRDAUsers.API.Settings;

namespace UCRDAUsers.API.Data
{
    public class UCRDAUserContext : IUCRDAUserContext
    {
        public UCRDAUserContext(IUCRDAUserDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            ucrdausers = database.GetCollection<UCRDAUser>(settings.CollectionName);

            UCRDAUserContextSeed.SeedData(ucrdausers);
        }
        public IMongoCollection<UCRDAUser> ucrdausers { get; }
    }
}
