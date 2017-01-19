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

        public void SetupDb()
        {
            dbOptions = new DbContextOptionsBuilder<ParticipantLibraryContext>();
            dbOptions.UseInMemoryDatabase();

            plContext = new ParticipantLibraryContext(dbOptions.Options);

            var iStoreReadConnectionConfig = A.Fake<IStoreReadConnectionConfig>();
            var libraryReader = new EfParticipantLibraryReader(dbOptions, iStoreReadConnectionConfig); //A.Fake<IReadFromParticipantLibrary>();
            var libraryWriter = A.Fake<IWriteToParticipantLibrary>();
            pil = new ParticipantItemLibrary(libraryWriter, libraryReader);
        }
    }
}
