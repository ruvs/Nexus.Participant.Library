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
        private const string PL_ITEM_1_NAME_UPDATED = "PL_ITEM_1_NAME_UPDATED";
        private const string PL_ITEM_1_DISPLAY_CODE_UPDATED = "PL_ITEM_1_DISPLAY_CODE_UPDATED";
        private ParticipantLibraryItem pliItem1;

        [SetUp]
        public void Setup()
        {
            base.SetupDb(true);

            //SetupParticipantLibraryTypes();
            //SetupParticipantLibraryItems();
        }

        private void SetupParticipantLibraryTypes()
        {
            pliType1 = new ParticipantLibraryItemType { NexusKey = Guid.NewGuid(), Name = TYPE_1_NAME };
            pliType2 = new ParticipantLibraryItemType { NexusKey = Guid.NewGuid(), Name = TYPE_2_NAME };
            plContext.ParticipantLibraryItemTypes.Add(pliType1);
            plContext.ParticipantLibraryItemTypes.Add(pliType2);
            plContext.SaveChanges();
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
            //plContext.Database.EnsureDeleted();
        }

        [Test]
        public void Int_ShouldUpdateParticipantLibraryItemViaCommand()
        {
            Guid pKey = Guid.Parse("F0228211-6F9C-450E-9C2D-02EF670EA549");

            var getQuery = new GetParticipantLibraryItemByKeyQuery(pKey);
            pil.Execute(getQuery);

            var itemToUpdate = getQuery.Result;

            var saveCommand = new SaveParticipantLibraryItemCommand()
            {
                NexusKey = itemToUpdate.NexusKey,
                Name = PL_ITEM_1_NAME_UPDATED,
                DisplayName = itemToUpdate.DisplayName,
                DisplayCode = PL_ITEM_1_DISPLAY_CODE_UPDATED,
                Iso2Code = itemToUpdate.Iso2Code,
                Iso3Code = itemToUpdate.Iso3Code,
                TypeKey = itemToUpdate.TypeKey,
            };

            pil.Execute(saveCommand);

            //Assert
            pil.Execute(getQuery);
            var result = getQuery.Result;

            result.NexusKey.ShouldBe(pKey);
            result.Name.ShouldBe(PL_ITEM_1_NAME_UPDATED);
            result.DisplayCode.ShouldBe(PL_ITEM_1_DISPLAY_CODE_UPDATED);
            result.Iso2Code.ShouldBe(itemToUpdate.Iso2Code);
            result.TypeKey.ShouldBe(itemToUpdate.TypeKey);
            result.TypeName.ShouldBe(itemToUpdate.TypeName);
        }
    }
}
