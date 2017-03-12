using System;

namespace Nexus.ParticipantLibrary.Messages.Interfaces
{
    public interface IAmAPublishableMessage
    {
        DateTime SentDate { get; }
    }
}
