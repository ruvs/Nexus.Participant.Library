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

        public void SetupDb()
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
    }
}
