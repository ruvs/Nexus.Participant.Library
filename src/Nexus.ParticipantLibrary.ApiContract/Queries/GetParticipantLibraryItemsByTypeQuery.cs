using System;
using Nexus.ParticipantLibrary.ApiContract.Dtos;
using System.Collections.Generic;

namespace Nexus.ParticipantLibrary.ApiContract.Queries
{
    public class GetParticipantLibraryItemsByTypeQuery : IParticipantLibraryMultiQuery
    {
        public Guid TypeKey { get; set; }
        public IEnumerable<ParticipantLibraryItemDto> Result { get; set; }

        public GetParticipantLibraryItemsByTypeQuery(Guid typeKey)
        {
            TypeKey = typeKey;
        }

        public string Url
        {
            get { return string.Format("{TypeKey}"); }
        }
    }
}