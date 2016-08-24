using Nexus.ParticipantLibrary.ApiContract.Dtos;
using System;
using System.Collections.Generic;

namespace Nexus.ParticipantLibrary.ApiContract.Queries
{
    public class GetAllParticipantLibraryItemsQuery : IParticipantLibraryMultiQuery
    {
        public GetAllParticipantLibraryItemsQuery()
        {
        }

        public string Url
        {
            get { return string.Format(""); }
        }

        public IEnumerable<ParticipantLibraryItem> Result { get; set; }

        public override string ToString()
        {
            return string.Format("A {GetType().Name}");
        }

    }
}