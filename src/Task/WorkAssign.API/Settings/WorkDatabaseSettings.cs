using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User.API.Settings
{
    public class WorkDatabaseSettings : IWorkDatabaseSettings
    {
        public string ConnectionString { get ; set ; }
        public string DatabaseName { get ; set ; }
        public string CollectionName { get ; set ; }
    }
}
