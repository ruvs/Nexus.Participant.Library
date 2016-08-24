using System;
using Nexus.ParticipantLibrary.ApiContract.Dtos;

namespace Nexus.ParticipantLibrary.ApiContract.Queries
{
    public class GetParticipantLibraryItemByKeyQuery : IParticipantLibrarySingleQuery
    {
        public Guid Key { get; set; }
        public ParticipantLibraryItem Result { get; set; }

        public GetParticipantLibraryItemByKeyQuery(Guid key)
        {
            Key = key;
        }

        public string Url
        {
            get { return string.Format("{0}",Key); }
        }
    }
}
