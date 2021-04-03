using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UCRDAUsers.API.Entities;

namespace UCRDAUsers.API.Data.Interface
{
    public interface IUCRDAUserContext
    {
        IMongoCollection<UCRDAUser> ucrdausers {get;}
    }
}
