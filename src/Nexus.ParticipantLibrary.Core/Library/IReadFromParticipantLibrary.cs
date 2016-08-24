using Nexus.ParticipantLibrary.ApiContract.Dtos;
using System;
using System.Collections.Generic;

namespace Nexus.ParticipantLibrary.Core.Library
{
    public interface IReadFromParticipantLibrary
    {
        ParticipantLibraryItem ReadByKey(Guid key);
        IEnumerable<ParticipantLibraryItem> ReadAll();
        IEnumerable<ParticipantLibraryItem> ReadByType(Guid typeKkey);
    }
}