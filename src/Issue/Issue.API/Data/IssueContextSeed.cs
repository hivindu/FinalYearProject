using Issue.API.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Issue.API.Data
{
    public class IssueContextSeed
    {
        internal static void SeedData(IMongoCollection<Issues> issueCollection)
        {
            bool existIssue = issueCollection.Find(p=> true).Any();

            if (!existIssue) 
            {
                issueCollection.InsertManyAsync(GetPreconfiguredIssues());
            }
        }

        private static IEnumerable<Issues> GetPreconfiguredIssues()
        {
            return new List<Issues>()
            {
               new Issues()
               {
                   Image = File.ReadAllBytes("images/1.jpg"),
                    Lat = 6.845149,
                    Long = 79.942416,
                    PostalCode = 10230 ,
                    Province = "Western Province",
                    Status = "Approved",
                    Date = "2021/12/02" ,
                    RoadType ="NoramlRoad",
                    IssueType = 1,
                    AdminArea = "Kottawa",
                    Count=0
               },
               new Issues()
               {
                   Image = File.ReadAllBytes("images/2.jpg"),
                    Lat = 6.860403,
                    Long = 79.977907,
                    PostalCode = 10235 ,
                    Province = "Western Province",
                    Status = "Working",
                    Date = "2021/12/02" ,
                    RoadType ="NoramlRoad",
                    IssueType = 1,
                    AdminArea = "Kottawa",
                    Count=0
               },
            };
        }
    }
}
