using FakeItEasy;
using Microsoft.EntityFrameworkCore;
using Nexus.ParticipantLibrary.Core;
using Nexus.ParticipantLibrary.Core.Library;
using Nexus.ParticipantLibrary.Data._Config;
using Nexus.ParticipantLibrary.Data.Context;
using Nexus.ParticipantLibrary.Data.ParticipantLibrary;

namespace Nexus.ParticipantLibrary.UnitTests
{
    public class DbUnitTestBase
    {
        public DbContextOptionsBuilder<ParticipantLibraryContext> dbOptions;
        public ParticipantItemLibrary pil;
        public ParticipantLibraryContext plContext;
        public EfParticipantLibraryReader libraryReader;
        public EfParticipantLibraryWriter libraryWriter;

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
            dbOptions = new DbContextOptionsBuilder<ParticipantLibraryContext>();
            dbOptions.UseInMemoryDatabase();

            plContext = new ParticipantLibraryContext(dbOptions.Options);

            var iStoreReadConnectionConfig = A.Fake<IStoreReadConnectionConfig>();
            var iStoreWriteConnectionConfig = A.Fake<IStoreWriteConnectionConfig>();
            libraryReader = new EfParticipantLibraryReader(dbOptions, iStoreReadConnectionConfig);
            libraryWriter = new EfParticipantLibraryWriter(dbOptions, iStoreWriteConnectionConfig);
            pil = new ParticipantItemLibrary(libraryWriter, libraryReader);
        }

        private void SetupIntegrationDb()
        {
            var connString = @"Data Source=HV-MUFASA\DEV01;Initial Catalog=ParticipantLibraryTests;Integrated Security=true;Connect Timeout=15;";

            dbOptions = new DbContextOptionsBuilder<ParticipantLibraryContext>();
            dbOptions.UseSqlServer(connString);

            plContext = new ParticipantLibraryContext(dbOptions.Options);

            var iStoreReadConnectionConfig = new ParticipantLibraryReadConnectionConfig(connString);
            var iStoreWriteConnectionConfig = new ParticipantLibraryWriteConnectionConfig(connString);
            libraryReader = new EfParticipantLibraryReader(dbOptions, iStoreReadConnectionConfig);
            libraryWriter = new EfParticipantLibraryWriter(dbOptions, iStoreWriteConnectionConfig);
            pil = new ParticipantItemLibrary(libraryWriter, libraryReader);
        }
    }
}
