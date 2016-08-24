using System;

namespace Nexus.ParticipantLibrary.Core.Configuration
{
    internal class ParticipantLibraryConfigurationException : Exception
    {
        public ParticipantLibraryConfigurationException(string message):base(message)
        {
        }
    }
}