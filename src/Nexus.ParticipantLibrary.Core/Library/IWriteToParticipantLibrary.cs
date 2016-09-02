using Nexus.ParticipantLibrary.ApiContract.Dtos;

namespace Nexus.ParticipantLibrary.Core.Library
{
    public interface IWriteToParticipantLibrary
    {
        void Save(ParticipantLibraryItemDto item);
    }
}