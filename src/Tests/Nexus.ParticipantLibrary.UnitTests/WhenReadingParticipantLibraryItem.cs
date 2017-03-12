using Nexus.ParticipantLibrary.ApiContract.Queries;
using Nexus.ParticipantLibrary.Data.Domain;
using NUnit.Framework;
using Shouldly;
using System;
using System.Linq;

namespace Nexus.ParticipantLibrary.UnitTests
{
    [TestFixture]
    public class WhenReadingParticipantLibraryItem : DbUnitTestBase
    {
        private ParticipantLibraryItemType pliType1;
        private ParticipantLibraryItemType pliType2;
        private const string TYPE_1_NAME = "TYPE_1_NAME";
        private const string TYPE_2_NAME = "TYPE_2_NAME";
        private const string PL_ITEM_1_NAME = "PL_ITEM_1_NAME";
        private const string PL_ITEM_2_NAME = "PL_ITEM_2_NAME";
        private ParticipantLibraryItem pliItem1;
        private ParticipantLibraryItem pliItem2;

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
            _plContext.ParticipantLibraryItemTypes.Add(pliType1);
            _plContext.ParticipantLibraryItemTypes.Add(pliType2);
            _plContext.SaveChanges();
        }

        private void SetupParticipantLibraryItems()
        {
            pliItem1 = new ParticipantLibraryItem { NexusKey = Guid.NewGuid(), Name = PL_ITEM_1_NAME, TypeKey = pliType1.NexusKey };
            pliItem2 = new ParticipantLibraryItem { NexusKey = Guid.NewGuid(), Name = PL_ITEM_2_NAME, TypeKey = pliType2.NexusKey };
            _plContext.ParticipantLibraryItems.Add(pliItem1);
            _plContext.ParticipantLibraryItems.Add(pliItem2);
            _plContext.SaveChanges();
       }

        [TearDown]
        public void Cleanup()
        {
            _plContext.Database.EnsureDeleted();
        }

        [Test]
        public void ShouldReadParticipantLibraryItemByKey()
        {
            var query = new GetParticipantLibraryItemByKeyQuery()
            {
                Key = pliItem1.NexusKey
            };

            _piLibrary.Execute(query);
            var result = query.Result;

            //Assert
            result.NexusKey.ShouldBe(pliItem1.NexusKey);
            result.Name.ShouldBe(PL_ITEM_1_NAME);
            result.TypeKey.ShouldBe(pliType1.NexusKey);
            result.TypeName.ShouldBe(TYPE_1_NAME);
        }

        [Test]
        public void ShouldReadAllParticipantLibraryItems()
        {
            var query = new GetAllParticipantLibraryItemsQuery();

            _piLibrary.Execute(query);
            var result = query.Result.ToList();

            //Assert
            result.Count.ShouldBe(2);
            var item1 = result.Single(x => x.NexusKey == pliItem1.NexusKey);
            item1.TypeKey.ShouldBe(pliType1.NexusKey);

            var item2 = result.Single(x => x.NexusKey == pliItem2.NexusKey);
            item2.TypeKey.ShouldBe(pliType2.NexusKey);
        }

        [Test]
        public void ShouldReadParticipantLibraryItemDetailsViaQuery()
        {
            var query = new GetParticipantLibraryItemDetailsByKeyQuery()
            {
                Key = pliItem1.NexusKey
            };

            _piLibrary.Execute(query);
            var result = query.Result;

            //Assert
            result.NexusKey.ShouldBe(pliItem1.NexusKey);
            result.Name.ShouldBe(PL_ITEM_1_NAME);
            result.TypeName.ShouldBe(TYPE_1_NAME);
            result.Types.Count.ShouldBe(2);

            foreach (var t in result.Types)
            {
                t.Name.ShouldBeOneOf(pliType1.Name, pliType2.Name);
            }
        }
    }
}
