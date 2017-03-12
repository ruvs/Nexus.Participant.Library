using Nexus.ParticipantLibrary.ApiContract.Dtos;

namespace Nexus.ParticipantLibrary.Core.Library
{
    public interface IWriteToParticipantLibrary
    {
        DbOperationType Save(ParticipantLibraryItemDto item);
    }
}