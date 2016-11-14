using FakeItEasy;
using Microsoft.EntityFrameworkCore;
using Nexus.ParticipantLibrary.ApiContract.Commands;
using Nexus.ParticipantLibrary.ApiContract.Dtos;
using Nexus.ParticipantLibrary.Core;
using Nexus.ParticipantLibrary.Core.Library;
using Nexus.ParticipantLibrary.Data.Context;
using Nexus.ParticipantLibrary.Data.Domain;
using NUnit.Framework;
using System;

namespace Nexus.ParticipantLibrary.UnitTests
{
    [TestFixture]
    public class WhenCreatingParticipantLibraryItem
    {
        private ParticipantLibraryContext plContext; 

        [SetUp]
        public void Setup()
        {
            var dbOptions = new DbContextOptionsBuilder<ParticipantLibraryContext>();
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
            };

            plContext.ParticipantLibraryItems.Add(participantLibraryItem);
            plContext.SaveChanges();

            Assert.IsNotNull(plContext.ParticipantLibraryItems.CountAsync(x => x.Name == "Name"));
        }

        //[Test]
        //public void ShouldNotAllowaDuplicateNames()
        //{
        //    var participantLibraryItem = new ParticipantLibraryItem()
        //    {
        //        Name = "Name",
        //    };

        //    plContext.ParticipantLibraryItems.Add(participantLibraryItem);

        //    var participantLibraryItem2 = new ParticipantLibraryItem()
        //    {
        //        Name = "Name",
        //    };

        //    plContext.ParticipantLibraryItems.Add(participantLibraryItem2);
        //    plContext.SaveChanges();

        //    Assert.AreEqual(2, plContext.ParticipantLibraryItems.CountAsync().Result);
        //}

        [Test]
        public void ShouldAddParticipantLibraryItemViaCommand()
        {
            var saveCommand = new SaveParticipantLibraryItemCommand()
            {
                NexusKey = Guid.NewGuid(),
                Name = "newName",
                DisplayCode = "newDisplayCode",
                DisplayName = "newDisplayName",
                TypeKey = Guid.NewGuid(),
                Iso3Code = "NewIso3Code"
            };

            var libraryWriter = A.Fake<IWriteToParticipantLibrary>();
            var pil = new ParticipantItemLibrary(libraryWriter, A.Fake<IReadFromParticipantLibrary>());

            pil.Execute(saveCommand);

            A.CallTo(() => libraryWriter.Save(A<ParticipantLibraryItemDto>.That.Matches(
                x => x.NexusKey == saveCommand.NexusKey &&
                x.DisplayCode == saveCommand.DisplayCode &&
                x.DisplayName == saveCommand.DisplayName &&
                x.Iso3Code == saveCommand.Iso3Code &&
                x.Name == saveCommand.Name &&
                x.TypeKey == saveCommand.TypeKey
            ))).MustHaveHappened();
        }
    }
}
