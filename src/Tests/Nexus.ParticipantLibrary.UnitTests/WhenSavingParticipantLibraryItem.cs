using FakeItEasy;
using Nexus.ParticipantLibrary.ApiContract.Commands;
using Nexus.ParticipantLibrary.ApiContract.Queries;
using Nexus.ParticipantLibrary.Data.Domain;
using Nexus.ParticipantLibrary.Messages.Interfaces;
using NUnit.Framework;
using Shouldly;
using System;
using System.Linq;
using System.Threading;

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
        private SaveParticipantLibraryItemCommand saveCommand;

        [SetUp]
        public void Setup()
        {
            base.SetupDb();

            SetupParticipantLibraryTypes();
            SetupParticipantLibraryItems();

            saveCommand = new SaveParticipantLibraryItemCommand()
            {
                NexusKey = Guid.NewGuid(),
                Name = "newName",
                DisplayCode = "newDisplayCode",
                DisplayName = "newDisplayName",
                TypeKey = Guid.NewGuid(),
                Iso2Code = "NewIso2Code",
                Iso3Code = "NewIso3Code"
            };
        }

        private void SetupParticipantLibraryTypes()
        {
            pliType1 = new ParticipantLibraryItemType { NexusKey = Guid.NewGuid(), Name = TYPE_1_NAME };
            pliType2 = new ParticipantLibraryItemType { NexusKey = Guid.NewGuid(), Name = TYPE_2_NAME };
            _plContext.ParticipantLibraryItemTypes.Add(pliType1);
            _plContext.ParticipantLibraryItemTypes.Add(pliType2);
            _plContext.SaveChanges();
        }

        private void SetupParticipantLibraryItems()
        {
            pliItem1 = new ParticipantLibraryItem { NexusKey = Guid.NewGuid(), Name = PL_ITEM_1_NAME, DisplayCode = PL_ITEM_1_DISPLAY_CODE, TypeKey = pliType1.NexusKey };
            _plContext.ParticipantLibraryItems.Add(pliItem1);
            _plContext.SaveChanges();
        }

        [TearDown]
        public void Cleanup()
        {
            _plContext.Database.EnsureDeleted();
        }

        [Test]
        public void ShouldAddParticipantLibraryItem()
        {
            _piLibrary.Execute(saveCommand);

            _plContext.ParticipantLibraryItems.Single(x => x.NexusKey == saveCommand.NexusKey).ShouldNotBeNull();
        }

        [Test]
        public void ShouldPublishItemCreatedEventWhenCreatingItem()
        {
            _piLibrary.Execute(saveCommand);

            A.CallTo(() => _publishEndpoint.Publish(A<IParticipantLibraryItemCreated>.That.Matches(
                x => x.NexusKey == saveCommand.NexusKey &&
                x.DisplayCode == saveCommand.DisplayCode &&
                x.DisplayName == saveCommand.DisplayName &&
                x.Iso2Code == saveCommand.Iso2Code &&
                x.Iso3Code == saveCommand.Iso3Code &&
                x.Name == saveCommand.Name &&
                x.TypeKey == saveCommand.TypeKey), default(CancellationToken)))
                .MustHaveHappened();
        }

        [Test]
        public void ShouldUpdateParticipantLibraryItem()
        {
            var saveCommand = new SaveParticipantLibraryItemCommand()
            {
                NexusKey = pliItem1.NexusKey,
                Name = PL_ITEM_1_NAME_UPDATED,
                DisplayCode = PL_ITEM_1_DISPLAY_CODE_UPDATED,
                TypeKey = pliType2.NexusKey,
            };

            _piLibrary.Execute(saveCommand);

            //Assert
            var query = new GetParticipantLibraryItemByKeyQuery()
            {
                Key = pliItem1.NexusKey
            };

            _piLibrary.Execute(query);
            var result = query.Result;

            result.NexusKey.ShouldBe(pliItem1.NexusKey);
            result.Name.ShouldBe(PL_ITEM_1_NAME_UPDATED);
            result.DisplayCode.ShouldBe(PL_ITEM_1_DISPLAY_CODE_UPDATED);
            result.Iso2Code.ShouldBe(pliItem1.Iso2Code);
            result.TypeKey.ShouldBe(pliType2.NexusKey);
            result.TypeName.ShouldBe(pliType2.Name);
        }

        [Test]
        public void ShouldPublishItemUpdatedEventWhenUpdatingItem()
        {
            var saveCommand = new SaveParticipantLibraryItemCommand()
            {
                NexusKey = pliItem1.NexusKey,
                Name = PL_ITEM_1_NAME_UPDATED,
                DisplayCode = PL_ITEM_1_DISPLAY_CODE_UPDATED,
                TypeKey = pliType2.NexusKey,
            };

            _piLibrary.Execute(saveCommand);

            A.CallTo(() => _publishEndpoint.Publish(A<IParticipantLibraryItemUpdated>.That.Matches(
                x => x.NexusKey == saveCommand.NexusKey &&
                x.DisplayCode == saveCommand.DisplayCode &&
                x.DisplayName == saveCommand.DisplayName &&
                x.Iso2Code == saveCommand.Iso2Code &&
                x.Iso3Code == saveCommand.Iso3Code &&
                x.Name == saveCommand.Name &&
                x.TypeKey == saveCommand.TypeKey), default(CancellationToken)))
                .MustHaveHappened();
        }
    }
}
