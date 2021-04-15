using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UCRDAUsers.API.Entities;

namespace UCRDAUsers.API.Data
{
    public class UCRDAUserContextSeed
    {
        public static void SeedData(IMongoCollection<UCRDAUser> ucrdausers)
        {
            bool existUsers = ucrdausers.Find(p => true).Any();
            if (!existUsers)
            {
                ucrdausers.InsertManyAsync(GetPreconfiguredUCRDAusers());
            }
        }

        private static IEnumerable<UCRDAUser> GetPreconfiguredUCRDAusers()
        {
            return new List<UCRDAUser>()
            {
                new UCRDAUser()
                {
                    Name ="Deshan Pathirana",
                    Password="Deshn123",
                    LocationArea = "Kottawa",
                    NIC="992022469v",
                    Type = 0,
                    Work = 0
                },
                new UCRDAUser()
                {
                    Name ="Kaveen Pathirana",
                    Password="Deshn123",
                    LocationArea = "Maharagama",
                    NIC="992023469v",
                    Type = 1,
                    Work = 0
                },
                new UCRDAUser()
                {
                    Name ="Deshan Pathirana",
                    Password="Deshn123",
                    LocationArea = "Kottawa",
                    NIC="992022467v",
                    Type = 1,
                    Work = 1
                },
                new UCRDAUser()
                {
                    Name ="Deshan Perera",
                    Password="Deshn123",
                    LocationArea = "Horana",
                    NIC="99202249v",
                    Type = 0,
                    Work = 1
                }
            };
        }
    }
}
