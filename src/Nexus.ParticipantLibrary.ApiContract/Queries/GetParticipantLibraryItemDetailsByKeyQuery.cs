using System;
using Nexus.ParticipantLibrary.ApiContract.Dtos;

namespace Nexus.ParticipantLibrary.ApiContract.Queries
{
    public class GetParticipantLibraryItemDetailsByKeyQuery : IParticipantLibraryDetailsSingleQuery
    {
        public Guid Key { get; set; }
        public ParticipantLibraryItemDetailsDto Result { get; set; }

        public GetParticipantLibraryItemDetailsByKeyQuery()
        {
        }

        public GetParticipantLibraryItemDetailsByKeyQuery(Guid key)
        {
            Key = key;
        }

        public string Url
        {
            get { return string.Format("{0}",Key); }
        }
    }
}
