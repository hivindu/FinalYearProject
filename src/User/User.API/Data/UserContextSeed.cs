using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User.API.Entities;

namespace User.API.Data
{
    public class UserContextSeed
    {
        public static void SeedData(IMongoCollection<Users> UserCollection)
        {
            bool existUsers = UserCollection.Find(p => true).Any();
            if (!existUsers)
            {
                UserCollection.InsertManyAsync(GetPeConfigueredUsers());
            }
        }

        private static IEnumerable<Users> GetPeConfigueredUsers()
        {
            return new List<Users>()
           {
               new Users()
               {
                    Name = "Hivindu Amaradeva",
                    NIC="992022469v",
                    Password ="h123456",
                    Type="Citizen",
                    PostalCode = 10230
               },
               new Users()
               {
                    Name = "Dasuni Amaradeva",
                    NIC="990622469v",
                    Password ="h123456",
                    Type="UC",
                    PostalCode = 10230
               },
               new Users()
               {
                    Name = "Daksith Amaradeva",
                    NIC="992122469v",
                    Password ="h123456",
                    Type="RDA",
                    PostalCode = 10240
               },
               new Users()
               {
                    Name = "Hansana Amaradeva",
                    NIC="992602469v",
                    Password ="h123456",
                    Type="Citizen",
                    PostalCode = 10230
               },
           };
        }
    }
}
