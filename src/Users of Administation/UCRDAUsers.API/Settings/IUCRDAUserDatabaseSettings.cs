using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UCRDAUsers.API.Settings
{
    public interface IUCRDAUserDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string CollectionName { get; set; }
    }
}
