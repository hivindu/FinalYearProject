using Approve.API.Entites;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Approve.API.Data.Interfaces
{
    public interface IApproveContext
    {
        IMongoCollection<Approval> approval { get; }
    }
}
