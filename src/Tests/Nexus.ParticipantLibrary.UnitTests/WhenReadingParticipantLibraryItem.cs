using FakeItEasy;
using Microsoft.EntityFrameworkCore;
using Nexus.ParticipantLibrary.ApiContract.Queries;
using Nexus.ParticipantLibrary.Core;
using Nexus.ParticipantLibrary.Core.Library;
using Nexus.ParticipantLibrary.Data._Config;
using Nexus.ParticipantLibrary.Data.Context;
using Nexus.ParticipantLibrary.Data.Domain;
using Nexus.ParticipantLibrary.Data.ParticipantLibrary;
using NUnit.Framework;
using Shouldly;
using System;

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
            pliItem1 = new ParticipantLibraryItem { NexusKey = Guid.NewGuid(), Name = PL_ITEM_1_NAME, TypeKey = pliType2.NexusKey };
            plContext.ParticipantLibraryItems.Add(pliItem1);
            plContext.SaveChanges();
       }

        [TearDown]
        public void Cleanup()
        {
            plContext.Database.EnsureDeleted();
        }

        [Test]
        public void ShouldReadParticipantLibraryItemDetailsViaQuery()
        {
            var query = new GetParticipantLibraryItemDetailsByKeyQuery()
            {
                Key = pliItem1.NexusKey
            };

            pil.Execute(query);
            var result = query.Result;

            //Assert
            result.NexusKey.ShouldBe(pliItem1.NexusKey);
            result.Name.ShouldBe(PL_ITEM_1_NAME);
            result.TypeName.ShouldBe(TYPE_2_NAME);
            result.Types.Count.ShouldBe(2);

            foreach(var t in result.Types)
            {
                t.Name.ShouldBeOneOf(pliType1.Name, pliType2.Name);
            }

            //A.CallTo(() => libraryReader.ReadDetailsByKey(pliItem1.NexusKey)).MustHaveHappened();
        }
    }
}
