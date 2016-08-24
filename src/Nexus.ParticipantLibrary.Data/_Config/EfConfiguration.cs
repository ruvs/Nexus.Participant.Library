using Nexus.ParticipantLibrary.Core.Configuration;

namespace Nexus.ParticipantLibrary.Data._Config
{
    public static class EfConfiguration
    {
        public static EfConfigure EfPersistence(this ParticipantLibraryConfigure configure)
        {
            return new EfConfigure(configure);
        }
    }
}
