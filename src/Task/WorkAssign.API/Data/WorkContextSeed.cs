using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkAssign.API.Entities;

namespace WorkAssign.API.Data
{
    public class WorkContextSeed
    {
        internal static void SeedData(IMongoCollection<Work> taskCollection)
        {
            bool existTask = taskCollection.Find<Work>(p => true).Any();

            if (!existTask)
            {
                taskCollection.InsertManyAsync(GeneratePreconfiguredTasks());
            }
        }

        private static IEnumerable<Work> GeneratePreconfiguredTasks()
        {
            return new List<Work>()
            {
                new Work()
                {
                    UserUd = "603b3dacf55952ec898db53b",
                    IssueId ="603b40f24e56386b416d2868",
                    AssignedDate = DateTime.Now.Date,
                    Status = "In Progress"
                }
            };
        }
    }
}
