using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User.API.Entities;

namespace User.API.Data.Interface
{
    public interface IUserContext
    {
        IMongoCollection<Users> users { get; }
    }
}
