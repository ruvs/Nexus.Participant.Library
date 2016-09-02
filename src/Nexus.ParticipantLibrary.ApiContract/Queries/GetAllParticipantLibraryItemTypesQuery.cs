using Nexus.ParticipantLibrary.ApiContract.Dtos;
using System.Collections.Generic;

namespace Nexus.ParticipantLibrary.ApiContract.Queries
{
    public class GetAllParticipantLibraryItemTypesQuery : IParticipantLibraryItemTypeMultiQuery
    {
        public GetAllParticipantLibraryItemTypesQuery()
        {
        }

        public string Url
        {
            get { return string.Format(""); }
        }

        public IEnumerable<ParticipantLibraryItemTypeDto> Result { get; set; }

        public override string ToString()
        {
            return string.Format("A {GetType().Name}");
        }

    }
}