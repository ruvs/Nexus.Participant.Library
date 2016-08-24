namespace Nexus.ParticipantLibrary.Data._Config
{
    public class ParticipantLibraryReadConnectionConfig : IStoreReadConnectionConfig
    {
        public string ConnectionString { get; set; }

        public ParticipantLibraryReadConnectionConfig(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}