using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User.API.Data.Interface;
using User.API.Entities;
using User.API.Settings;

namespace User.API.Data
{
    public class UserContext : IUserContext
    {
        public UserContext(IUserDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            users = database.GetCollection<Users>(settings.CollectionName);

            UserContextSeed.SeedData(users);
        }

        public IMongoCollection<Users> users { get; }
    }
}
