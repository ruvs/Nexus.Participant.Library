using FakeItEasy;
using MassTransit;
using MassTransit.TestFramework;
using Microsoft.EntityFrameworkCore;
using Nexus.ParticipantLibrary.Core;
using Nexus.ParticipantLibrary.Data._Config;
using Nexus.ParticipantLibrary.Data.Context;
using Nexus.ParticipantLibrary.Data.ParticipantLibrary;

namespace Nexus.ParticipantLibrary.UnitTests
{
    public class DbUnitTestBase : InMemoryTestFixture
    {
        public DbContextOptionsBuilder<ParticipantLibraryContext> _dbOptions;
        public ParticipantItemLibrary _piLibrary;
        public ParticipantLibraryContext _plContext;
        public EfParticipantLibraryReader _libraryReader;
        public EfParticipantLibraryWriter _libraryWriter;
        public IPublishEndpoint _publishEndpoint;

        public void SetupDb(bool integrationTest = false)
        {
            if (integrationTest)
            {
                SetupIntegrationDb();
            }
            else
            {
                SetupInMemoryDb();
            }
        }

        private void SetupInMemoryDb()
        {
            _dbOptions = new DbContextOptionsBuilder<ParticipantLibraryContext>();
            _dbOptions.UseInMemoryDatabase();

            _plContext = new ParticipantLibraryContext(_dbOptions.Options);

            var iStoreReadConnectionConfig = A.Fake<IStoreReadConnectionConfig>();
            var iStoreWriteConnectionConfig = A.Fake<IStoreWriteConnectionConfig>();
            _publishEndpoint = A.Fake<IPublishEndpoint>();
            _libraryReader = new EfParticipantLibraryReader(_dbOptions, iStoreReadConnectionConfig);
            _libraryWriter = new EfParticipantLibraryWriter(_dbOptions, iStoreWriteConnectionConfig);
            _piLibrary = new ParticipantItemLibrary(_libraryWriter, _libraryReader, _publishEndpoint);
        }

        private void SetupIntegrationDb()
        {
            var connString = @"Data Source=HV-MUFASA\DEV01;Initial Catalog=ParticipantLibraryTests;Integrated Security=true;Connect Timeout=15;";

            _dbOptions = new DbContextOptionsBuilder<ParticipantLibraryContext>();
            _dbOptions.UseSqlServer(connString);

            _plContext = new ParticipantLibraryContext(_dbOptions.Options);

            var iStoreReadConnectionConfig = new ParticipantLibraryReadConnectionConfig(connString);
            var iStoreWriteConnectionConfig = new ParticipantLibraryWriteConnectionConfig(connString);

            _libraryReader = new EfParticipantLibraryReader(_dbOptions, iStoreReadConnectionConfig);
            _libraryWriter = new EfParticipantLibraryWriter(_dbOptions, iStoreWriteConnectionConfig);
            _piLibrary = new ParticipantItemLibrary(_libraryWriter, _libraryReader, Bus);
        }
    }
}
