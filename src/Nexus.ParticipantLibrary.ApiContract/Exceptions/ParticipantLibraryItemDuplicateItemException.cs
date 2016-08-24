using System;

namespace Nexus.ParticipantLibrary.ApiContract.Exceptions
{
    public class ParticipantLibraryItemDuplicateItemException: Exception
    {
        public ParticipantLibraryItemDuplicateItemException(string message)
            : base(message)
        {
        }
    }
}
