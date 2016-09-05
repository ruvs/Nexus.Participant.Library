using Nexus.ParticipantLibrary.Core.Configuration;
using Nexus.ParticipantLibrary.Core.Library;
using Nexus.ParticipantLibrary.Data.ParticipantLibrary;
using System.Configuration;
using System.Linq;

namespace Nexus.ParticipantLibrary.Data._Config
{
    public class EfConfigure : ParticipantLibraryConfigure
    {
        public EfConfigure(ParticipantLibraryConfigure configure)
            : base(configure)
        {
        }

        public EfConfigure WithConnectionsNamed(string readConnectionName, string writeConnectionName)
        {
            var readConnectionSetting = ConfigurationManager.ConnectionStrings
                .Cast<ConnectionStringSettings>()
                .Single(x => x.Name == readConnectionName);

            var writeConnectionSetting = ConfigurationManager.ConnectionStrings
                .Cast<ConnectionStringSettings>()
                .Single(x => x.Name == writeConnectionName);

            Container.Register<IStoreReadConnectionConfig>(new ParticipantLibraryReadConnectionConfig(readConnectionSetting.ConnectionString));
            Container.Register<IStoreWriteConnectionConfig>(new ParticipantLibraryWriteConnectionConfig(writeConnectionSetting.ConnectionString));
            return this;
        }

        public EfConfigure WithConnectionStrings(string readConnectionString, string writeConnectionString)
        {
            Container.Register<IStoreReadConnectionConfig>(new ParticipantLibraryReadConnectionConfig(readConnectionString));
            Container.Register<IStoreWriteConnectionConfig>(new ParticipantLibraryWriteConnectionConfig(writeConnectionString));
            return this;
        }

        public override IAmAParticipantLibrary Build()
        {
            var readConnectionConfig = Container.Resolve<IStoreReadConnectionConfig>();
            var writeConnectionConfig = Container.Resolve<IStoreWriteConnectionConfig>();
            Container.Register<IReadFromParticipantLibrary>(new EfParticipantLibraryReader(readConnectionConfig));
            Container.Register<IWriteToParticipantLibrary>(new EfParticipantLibraryWriter(writeConnectionConfig));
            return base.Build();
        }
    }
}
