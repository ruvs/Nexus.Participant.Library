using Nexus.ParticipantLibrary.ApiContract.Dtos;
using System;
using System.Collections.Generic;

namespace Nexus.ParticipantLibrary.Core.Library
{
    public interface IReadFromParticipantLibrary
    {
        ParticipantLibraryItemDto ReadByKey(Guid key);
        ParticipantLibraryItemDetailsDto ReadDetailsByKey(Guid key);
        IEnumerable<ParticipantLibraryItemDto> ReadAll();
        IEnumerable<ParticipantLibraryItemDto> ReadByType(Guid typeKkey);
        ParticipantLibraryItemTypeDto ReadTypeByKey(Guid key);
        IEnumerable<ParticipantLibraryItemTypeDto> ReadAllTypes();
    }
}