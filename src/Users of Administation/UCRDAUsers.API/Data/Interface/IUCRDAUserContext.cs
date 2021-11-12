using MongoDB.Driver;
using UCRDAUsers.API.Entities;

namespace UCRDAUsers.API.Data.Interface
{
    public interface IUCRDAUserContext
    {
        IMongoCollection<UCRDAUser> ucrdausers {get;}
    }
}
