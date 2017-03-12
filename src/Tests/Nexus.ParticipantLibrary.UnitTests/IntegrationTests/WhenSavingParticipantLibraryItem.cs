using MassTransit;
using Microsoft.EntityFrameworkCore;
using Nexus.ParticipantLibrary.ApiContract.Commands;
using Nexus.ParticipantLibrary.ApiContract.Queries;
using Nexus.ParticipantLibrary.Data.Domain;
using Nexus.ParticipantLibrary.Messages.Interfaces;
using NUnit.Framework;
using Shouldly;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Nexus.ParticipantLibrary.UnitTests.IntegrationTests
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
        private const string PL_ITEM_1_NAME_UPDATED = "PL_ITEM_1_NAME_UPDATED_";
        private const string PL_ITEM_1_DISPLAY_CODE_UPDATED = "PL_ITEM_1_DISPLAY_CODE_UPDATED_";
        private ParticipantLibraryItem pliItem1;
        Task<ConsumeContext<IParticipantLibraryItemCreated>> _createdPublishedMessageReceived;
        Task<ConsumeContext<IParticipantLibraryItemUpdated>> _updatedPublishedMessageReceived;

        [SetUp]
        public void Setup()
        {
            base.SetupDb(true);

            TruncateExistingData();
            SetupParticipantLibraryTypes();
            SetupParticipantLibraryItems();
        }

        private void SetupParticipantLibraryTypes()
        {
            pliType1 = new ParticipantLibraryItemType { NexusKey = Guid.NewGuid(), Name = TYPE_1_NAME, DisplayName = "DISPLAY_NAME_" + TYPE_1_NAME };
            pliType2 = new ParticipantLibraryItemType { NexusKey = Guid.NewGuid(), Name = TYPE_2_NAME, DisplayName = "DISPLAY_NAME_" + TYPE_2_NAME };
            _plContext.ParticipantLibraryItemTypes.Add(pliType1);
            _plContext.ParticipantLibraryItemTypes.Add(pliType2);
            _plContext.SaveChanges();
        }

        private void SetupParticipantLibraryItems()
        {
            pliItem1 = new ParticipantLibraryItem { NexusKey = Guid.NewGuid(), Name = PL_ITEM_1_NAME, DisplayName = "DISPLAY_NAME_" + PL_ITEM_1_NAME, DisplayCode = PL_ITEM_1_DISPLAY_CODE, TypeKey = pliType1.NexusKey };
            _plContext.ParticipantLibraryItems.Add(pliItem1);
            _plContext.SaveChanges();
        }

        [TearDown]
        public void Cleanup()
        {
            //plContext.Database.EnsureDeleted();
        }

        private void TruncateExistingData()
        {
            _plContext.Database.ExecuteSqlCommand("TRUNCATE TABLE dbo.ParticipantLibraryItem");
            _plContext.Database.ExecuteSqlCommand("DELETE FROM dbo.ParticipantLibraryItemType");
        }

        [Test]
        public async Task ShouldCreateParticipantLibraryItemAndPublishMessage()
        {
            var randomGuid = Guid.NewGuid();

            var saveCommand = new SaveParticipantLibraryItemCommand()
            {
                NexusKey = randomGuid,
                Name = PL_ITEM_1_NAME + randomGuid.ToString(),
                DisplayName = randomGuid.ToString(),
                DisplayCode = PL_ITEM_1_DISPLAY_CODE + randomGuid.ToString(),
                Iso2Code = randomGuid.ToString(),
                Iso3Code = randomGuid.ToString(),
                TypeKey = pliType1.NexusKey,
            };

            _piLibrary.Execute(saveCommand);
            await _createdPublishedMessageReceived;

            //Assert published message
            var publishedMessage = _createdPublishedMessageReceived.Result.Message;
            publishedMessage.ShouldBeAssignableTo<IParticipantLibraryItemCreated>();
            publishedMessage.NexusKey.ShouldBe(randomGuid);
            publishedMessage.Name.ShouldBe(PL_ITEM_1_NAME + randomGuid.ToString());
            publishedMessage.DisplayCode.ShouldBe(PL_ITEM_1_DISPLAY_CODE + randomGuid.ToString());
            publishedMessage.Iso2Code.ShouldBe(randomGuid.ToString());
            publishedMessage.TypeKey.ShouldBe(pliType1.NexusKey);
            publishedMessage.SentDate.ShouldBeInRange(DateTime.UtcNow.AddMinutes(-1), DateTime.UtcNow);

            //Assert
            var getItemQuery = new GetParticipantLibraryItemByKeyQuery(randomGuid);
            _piLibrary.Execute(getItemQuery);
            var result = getItemQuery.Result;

            result.NexusKey.ShouldBe(randomGuid);
            result.Name.ShouldBe(PL_ITEM_1_NAME + randomGuid.ToString());
            result.DisplayCode.ShouldBe(PL_ITEM_1_DISPLAY_CODE + randomGuid.ToString());
            result.Iso2Code.ShouldBe(randomGuid.ToString());
            result.TypeKey.ShouldBe(pliType1.NexusKey);
            result.TypeName.ShouldBe(pliType1.Name);

        }

        [Test]
        public void ShouldUpdateParticipantLibraryItem()
        {
            string randomGuidString = Guid.NewGuid().ToString();

            var getAllQuery = new GetAllParticipantLibraryItemsQuery();
            _piLibrary.Execute(getAllQuery);

            var plItemToUpdate = getAllQuery.Result.FirstOrDefault();

            if (plItemToUpdate != null)
            {
                var saveCommand = new SaveParticipantLibraryItemCommand()
                {
                    NexusKey = plItemToUpdate.NexusKey,
                    Name = PL_ITEM_1_NAME_UPDATED + randomGuidString,
                    DisplayName = plItemToUpdate.DisplayName,
                    DisplayCode = PL_ITEM_1_DISPLAY_CODE_UPDATED + randomGuidString,
                    Iso2Code = plItemToUpdate.Iso2Code,
                    Iso3Code = plItemToUpdate.Iso3Code,
                    TypeKey = plItemToUpdate.TypeKey,
                };

                _piLibrary.Execute(saveCommand);

                //Assert
                var getItemQuery = new GetParticipantLibraryItemByKeyQuery(plItemToUpdate.NexusKey);
                _piLibrary.Execute(getItemQuery);
                var result = getItemQuery.Result;

                result.NexusKey.ShouldBe(plItemToUpdate.NexusKey);
                result.Name.ShouldBe(PL_ITEM_1_NAME_UPDATED + randomGuidString);
                result.DisplayCode.ShouldBe(PL_ITEM_1_DISPLAY_CODE_UPDATED + randomGuidString);
                result.Iso2Code.ShouldBe(plItemToUpdate.Iso2Code);
                result.TypeKey.ShouldBe(plItemToUpdate.TypeKey);
                result.TypeName.ShouldBe(plItemToUpdate.TypeName);
            }
        }

        [Test]
        public async Task ShouldPublishItemUpdatedEventWhenUpdatingItem()
        {
            string randomGuidString = Guid.NewGuid().ToString();

            var getAllQuery = new GetAllParticipantLibraryItemsQuery();
            _piLibrary.Execute(getAllQuery);

            var plItemToUpdate = getAllQuery.Result.FirstOrDefault();

            if (plItemToUpdate != null)
            {
                var saveCommand = new SaveParticipantLibraryItemCommand()
                {
                    NexusKey = plItemToUpdate.NexusKey,
                    Name = PL_ITEM_1_NAME_UPDATED + randomGuidString,
                    DisplayName = plItemToUpdate.DisplayName,
                    DisplayCode = PL_ITEM_1_DISPLAY_CODE_UPDATED + randomGuidString,
                    Iso2Code = plItemToUpdate.Iso2Code,
                    Iso3Code = plItemToUpdate.Iso3Code,
                    TypeKey = plItemToUpdate.TypeKey,
                };

                _piLibrary.Execute(saveCommand);
                await _updatedPublishedMessageReceived;

                //Assert
                var publishedMessage = _updatedPublishedMessageReceived.Result.Message;
                publishedMessage.ShouldBeAssignableTo<IParticipantLibraryItemUpdated>();
                publishedMessage.NexusKey.ShouldBe(plItemToUpdate.NexusKey);
                publishedMessage.Name.ShouldBe(PL_ITEM_1_NAME_UPDATED + randomGuidString);
                publishedMessage.DisplayCode.ShouldBe(PL_ITEM_1_DISPLAY_CODE_UPDATED + randomGuidString);
                publishedMessage.Iso2Code.ShouldBe(plItemToUpdate.Iso2Code);
                publishedMessage.TypeKey.ShouldBe(plItemToUpdate.TypeKey);
                publishedMessage.SentDate.ShouldBeInRange(DateTime.UtcNow.AddMinutes(-1), DateTime.UtcNow);
            }
        }

        protected override void ConfigureInMemoryReceiveEndpoint(IInMemoryReceiveEndpointConfigurator configurator)
        {
            _createdPublishedMessageReceived = Handled<IParticipantLibraryItemCreated>(configurator);
            _updatedPublishedMessageReceived = Handled<IParticipantLibraryItemUpdated>(configurator);
        }
    }
}
