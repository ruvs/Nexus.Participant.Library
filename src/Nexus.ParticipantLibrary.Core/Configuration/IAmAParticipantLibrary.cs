using Nexus.ParticipantLibrary.ApiContract.Commands;
using Nexus.ParticipantLibrary.ApiContract.Queries;

namespace Nexus.ParticipantLibrary.Core.Configuration
{
    public interface IAmAParticipantLibrary
    {
        void Execute(IParticipantLibraryCommand command);

        void Execute(IParticipantLibraryQuery query);
   }
}