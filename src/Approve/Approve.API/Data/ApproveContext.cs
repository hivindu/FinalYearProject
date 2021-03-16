using Approve.API.Data.Interfaces;
using Approve.API.Entites;
using Issue.API.Settings;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Approve.API.Data
{
    public class ApproveContext : IApproveContext
    {
        public ApproveContext(IApproveDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            approval = database.GetCollection<Approval>(settings.CollectionName);

            ApproveContextSeed.SeedData(approval);
        }

        public IMongoCollection<Approval> approval { get; }

    }
}
