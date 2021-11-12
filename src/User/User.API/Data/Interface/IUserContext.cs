using MongoDB.Driver;
using User.API.Entities;

namespace User.API.Data.Interface
{
    public interface IUserContext
    {
        IMongoCollection<Users> users { get; }
    }
}
