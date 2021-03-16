using Issue.API.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Issue.API.Data.Interfaces
{
    public interface IIssueContext
    {
        IMongoCollection<Issues> issues { get; }
    }
}
