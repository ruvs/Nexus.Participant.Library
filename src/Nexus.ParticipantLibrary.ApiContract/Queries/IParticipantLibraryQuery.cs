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
        ParticipantLibraryItem Result { get; set; }
    }

    public interface IParticipantLibraryMultiQuery : IParticipantLibraryQuery
    {
        IEnumerable<ParticipantLibraryItem> Result { get; set; }
    }

}