using Approve.API.Entites;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Approve.API.Data
{
    public class ApproveContextSeed
    {
        internal static void SeedData(IMongoCollection<Approval> approvalCollection)
        {
            bool existApprove = approvalCollection.Find(p => true).Any();

            if (!existApprove)
            {
                approvalCollection.InsertManyAsync(GetPreconfiguredApproval());
            }
        }

        private static IEnumerable<Approval> GetPreconfiguredApproval()
        {
            return new List<Approval>()
            {
               new Approval()
               {
                  IssueId = "603934967861693204b982f7",
                  UserId ="60393f00e9703491fd13491c"
               }
            };
        }
    }
}
