using Nexus.ParticipantLibrary.Messages.Interfaces;
using System;

namespace Nexus.ParticipantLibrary.Messages
{
    public class ParticipantLibraryItemCreated : PublishableMessage, IParticipantLibraryItemCreated
    {
        public Guid NexusKey { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string DisplayCode { get; set; }
        public string Iso2Code { get; set; }
        public string Iso3Code { get; set; }
        public Guid TypeKey { get; set; }
        public string TypeName { get; set; }
    }
}
