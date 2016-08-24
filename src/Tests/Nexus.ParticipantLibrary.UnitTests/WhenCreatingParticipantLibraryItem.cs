using Microsoft.Data.Entity;
using Nexus.ParticipantLibrary.Data.Context;
using Nexus.ParticipantLibrary.Data.Domain;
using NUnit.Framework;

namespace Nexus.ParticipantLibrary.UnitTests
{
    [TestFixture]
    public class WhenCreatingParticipantLibraryItem
    {
        private ParticipantLibraryContext plContext; 

        [SetUp]
        public void Setup()
        {
            var dbOptions = new DbContextOptionsBuilder();
            dbOptions.UseInMemoryDatabase();

            plContext = new ParticipantLibraryContext(dbOptions.Options);
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
        public void ShouldAddParticipantLibraryItem()
        {
            var participantLibraryItem = new ParticipantLibraryItem()
            {
                Name = "Name",
                ShortName = "N",
            };

            plContext.ParticipantLibraryItems.Add(participantLibraryItem);
            plContext.SaveChanges();

            Assert.IsNotNull(plContext.ParticipantLibraryItems.CountAsync(x => x.Name == "Name"));
        }

        [Test]
        public void ShouldNotBeAbleToAddParticipantLibraryItemWithoutAType()
        {
            var participantLibraryItem = new ParticipantLibraryItem()
            {
                Name = null,
                ShortName = "N",
            };

            plContext.ParticipantLibraryItems.Add(participantLibraryItem);
            plContext.SaveChanges();

            Assert.IsEmpty(plContext.ParticipantLibraryItems);
        }
    }
}
