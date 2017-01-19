using FakeItEasy;
using Nexus.ParticipantLibrary.ApiContract.Commands;
using Nexus.ParticipantLibrary.ApiContract.Dtos;
using Nexus.ParticipantLibrary.ApiContract.Queries;
using Nexus.ParticipantLibrary.Core;
using Nexus.ParticipantLibrary.Core.Library;
using Nexus.ParticipantLibrary.Data.Domain;
using NUnit.Framework;
using Shouldly;
using System;

namespace Nexus.ParticipantLibrary.UnitTests
{
    [TestFixture]
    public class WhenSavingParticipantLibraryItem : DbUnitTestBase
    {
        private ParticipantLibraryItemType pliType1;
        private ParticipantLibraryItemType pliType2;
        private const string TYPE_1_NAME = "TYPE_1_NAME";
        private const string TYPE_2_NAME = "TYPE_2_NAME";
        private const string PL_ITEM_1_NAME = "PL_ITEM_1_NAME";
        private const string PL_ITEM_1_DISPLAY_CODE = "PL_ITEM_1_DISPLAY_CODE";
        private const string PL_ITEM_1_NAME_UPDATED = "PL_ITEM_1_NAME_UPDATED";
        private const string PL_ITEM_1_DISPLAY_CODE_UPDATED = "PL_ITEM_1_DISPLAY_CODE_UPDATED";
        private ParticipantLibraryItem pliItem1;

        [SetUp]
        public void Setup()
        {
            base.SetupDb();

            SetupParticipantLibraryTypes();
            SetupParticipantLibraryItems();
        }

        private void SetupParticipantLibraryTypes()
        {
            pliType1 = new ParticipantLibraryItemType { NexusKey = Guid.NewGuid(), Name = TYPE_1_NAME };
            pliType2 = new ParticipantLibraryItemType { NexusKey = Guid.NewGuid(), Name = TYPE_2_NAME };
            plContext.ParticipantLibraryItemTypes.Add(pliType1);
            plContext.ParticipantLibraryItemTypes.Add(pliType2);
        }

        private void SetupParticipantLibraryItems()
        {
            pliItem1 = new ParticipantLibraryItem { NexusKey = Guid.NewGuid(), Name = PL_ITEM_1_NAME, DisplayCode = PL_ITEM_1_DISPLAY_CODE, TypeKey = pliType1.NexusKey };
            plContext.ParticipantLibraryItems.Add(pliItem1);
            plContext.SaveChanges();
        }

        [TearDown]
        public void Cleanup()
        {
            plContext.Database.EnsureDeleted();
        }

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

        [Test]
        public void ShouldUpdateParticipantLibraryItemViaCommand()
        {
            var saveCommand = new SaveParticipantLibraryItemCommand()
            {
                NexusKey = pliItem1.NexusKey,
                Name = PL_ITEM_1_NAME_UPDATED,
                DisplayCode = PL_ITEM_1_DISPLAY_CODE_UPDATED,
                TypeKey = pliType2.NexusKey,
            };

            pil.Execute(saveCommand);

            //Assert
            var query = new GetParticipantLibraryItemByKeyQuery()
            {
                Key = pliItem1.NexusKey
            };

            pil.Execute(query);
            var result = query.Result;

            result.NexusKey.ShouldBe(pliItem1.NexusKey);
            result.Name.ShouldBe(PL_ITEM_1_NAME_UPDATED);
            result.DisplayCode.ShouldBe(PL_ITEM_1_DISPLAY_CODE_UPDATED);
            result.Iso2Code.ShouldBe(pliItem1.Iso2Code);
            result.TypeKey.ShouldBe(pliType2.NexusKey);
            result.TypeName.ShouldBe(pliType2.DisplayName);
        }
    }
}
