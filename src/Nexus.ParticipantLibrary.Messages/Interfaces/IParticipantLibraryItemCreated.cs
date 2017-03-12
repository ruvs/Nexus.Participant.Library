using System;

namespace Nexus.ParticipantLibrary.Messages.Interfaces
{
    public interface IParticipantLibraryItemCreated : IAmAPublishableMessage
    {
        Guid NexusKey { get; set; }
        int Id { get; set; }
        string Name { get; set; }
        string DisplayName { get; set; }
        string DisplayCode { get; set; }
        string Iso2Code { get; set; }
        string Iso3Code { get; set; }
        Guid TypeKey { get; set; }
        string TypeName { get; set; }
    }
}