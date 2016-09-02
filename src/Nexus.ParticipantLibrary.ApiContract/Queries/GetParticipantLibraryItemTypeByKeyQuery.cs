using Nexus.ParticipantLibrary.ApiContract.Dtos;
using System;

namespace Nexus.ParticipantLibrary.ApiContract.Queries
{
    public class GetParticipantLibraryItemTypeByKeyQuery : IParticipantLibraryItemTypeSingleQuery
    {
        public GetParticipantLibraryItemTypeByKeyQuery(Guid key)
        {
            Key = key;
        }

        public Guid Key { get; set; }
        public string Url
        {
            get { return string.Format(""); }
        }

        public ParticipantLibraryItemTypeDto Result { get; set; }

        public override string ToString()
        {
            return string.Format($"A {GetType().Name} with key '{Key}'");
        }

    }
}