namespace UCRDAUsers.API.Settings
{
    public class UCRDAUserDatabaseSettings : IUCRDAUserDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string CollectionName { get; set; }
    }
}
