namespace Nexus.ParticipantLibrary.Middleware.Configuration
{
    public interface IAppSettings
    {
        string CorsOrigins { get; set; }
        string ConnectionString_ParticipantLibrary_Read { get; set; }
        string ConnectionString_ParticipantLibrary_Write { get; set; }
        string IncludeErrorDetailPolicy { get; set; }
    }
}
