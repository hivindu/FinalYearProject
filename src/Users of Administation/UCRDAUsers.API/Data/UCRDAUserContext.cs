using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UCRDAUsers.API.Data.Interface;
using UCRDAUsers.API.Entities;

namespace UCRDAUsers.API.Data
{
    public class UCRDAUserContext : IUCRDAUserContext
    {
        public IMongoCollection<UCRDAUser> ucrdausers { get; }
    }
}
