using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkAssign.API.Entities;

namespace WorkAssign.API.Data.Interface
{
    public interface IWorkContext
    {
        IMongoCollection<Work> task { get; }
    }
}
