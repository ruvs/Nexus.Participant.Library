namespace Nexus.ParticipantLibrary.Data._Config
{
    public class ParticipantLibraryWriteConnectionConfig : IStoreWriteConnectionConfig
    {
        public string ConnectionString { get; set; }

        public ParticipantLibraryWriteConnectionConfig(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}