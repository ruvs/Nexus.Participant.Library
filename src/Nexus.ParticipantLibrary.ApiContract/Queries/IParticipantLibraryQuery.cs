using System.Collections.Generic;
using Nexus.ParticipantLibrary.ApiContract.Dtos;

namespace Nexus.ParticipantLibrary.ApiContract.Queries
{
    public interface IParticipantLibraryQuery
    {
        string Url { get; }
    }

    public interface IParticipantLibrarySingleQuery : IParticipantLibraryQuery
    {
        ParticipantLibraryItemDto Result { get; set; }
    }

    public interface IParticipantLibraryMultiQuery : IParticipantLibraryQuery
    {
        IEnumerable<ParticipantLibraryItemDto> Result { get; set; }
    }

    public interface IParticipantLibraryItemTypeSingleQuery : IParticipantLibraryQuery
    {
        ParticipantLibraryItemTypeDto Result { get; set; }
    }

    public interface IParticipantLibraryItemTypeMultiQuery : IParticipantLibraryQuery
    {
        IEnumerable<ParticipantLibraryItemTypeDto> Result { get; set; }
    }
}