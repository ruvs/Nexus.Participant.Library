using FakeItEasy;
using Microsoft.EntityFrameworkCore;
using Nexus.ParticipantLibrary.ApiContract.Queries;
using Nexus.ParticipantLibrary.Core;
using Nexus.ParticipantLibrary.Core.Library;
using Nexus.ParticipantLibrary.Data.Context;
using Nexus.ParticipantLibrary.Data.Domain;
using Nexus.ParticipantLibrary.Data.ParticipantLibrary;
using NUnit.Framework;
using System;

namespace Nexus.ParticipantLibrary.UnitTests
{
    [TestFixture]
    public class WhenReadingParticipantLibraryItem
    {
        private ParticipantLibraryContext plContext;
        private ParticipantLibraryItemType pliType1;
        private ParticipantLibraryItemType pliType2;
        private const string TYPE_1_NAME = "TYPE_1_NAME";
        private const string TYPE_2_NAME = "TYPE_2_NAME";
        private ParticipantLibraryItem pliItem1;

        [SetUp]
        public void Setup()
        {
            var dbOptions = new DbContextOptionsBuilder<ParticipantLibraryContext>();
            dbOptions.UseInMemoryDatabase();

            plContext = new ParticipantLibraryContext(dbOptions.Options);

            SetupParticipantLibraryTypes();
            pliItem1 = new ParticipantLibraryItem { NexusKey = Guid.NewGuid(), Name = "NAME", TypeKey = pliType2.NexusKey };

        }

        private void SetupParticipantLibraryTypes()
        {
            pliType1 = new ParticipantLibraryItemType { NexusKey = Guid.NewGuid(), Name = TYPE_1_NAME };
            pliType2 = new ParticipantLibraryItemType { NexusKey = Guid.NewGuid(), Name = TYPE_2_NAME };
        }

        [TearDown]
        public void Cleanup()
        {
            plContext.Database.EnsureDeleted();
        }

        [Test]
        public void ParticipantLibraryItemsShouldBeEmptyByDefault()
        {
            Assert.IsEmpty(plContext.ParticipantLibraryItems);
        }

        [Test]
        public void ShouldReadParticipantLibraryItemDetailsViaQuery()
        {
            var getParticipantLibraryItemDetailsByKeyQuery = new GetParticipantLibraryItemDetailsByKeyQuery()
            {
                Key = pliItem1.NexusKey
            };

            var libraryReader = A.Fake<IReadFromParticipantLibrary>();
            var libraryWriter = A.Fake<IWriteToParticipantLibrary>();
            var pil = new ParticipantItemLibrary(libraryWriter, libraryReader);

            pil.Execute(getParticipantLibraryItemDetailsByKeyQuery);

            A.CallTo(() => libraryReader.ReadDetailsByKey(pliItem1.NexusKey)).MustHaveHappened();
        }
    }
}
