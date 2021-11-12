namespace User.API.Settings
{
    public class UserDatabaseSettings : IUserDatabaseSettings
    {
        public string ConnectionString { get ; set ; }
        public string DatabaseName { get ; set ; }
        public string CollectionName { get ; set ; }
    }
}
