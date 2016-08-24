using System;

namespace Nexus.ParticipantLibrary.ApiContract.Exceptions
{
    public class ParticipantLibraryItemOutOfSequenceException: Exception
    {
        public ParticipantLibraryItemOutOfSequenceException(string message)
            : base(message)
        {
        }
    }
}