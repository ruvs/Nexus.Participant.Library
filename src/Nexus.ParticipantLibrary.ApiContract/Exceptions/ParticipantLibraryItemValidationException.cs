using System;

namespace Nexus.ParticipantLibrary.ApiContract.Exceptions
{
    public class ParticipantLibraryItemValidationException : Exception
    {
        public ParticipantLibraryItemValidationException(string message)
            : base(message)
        {
        }
    }
}