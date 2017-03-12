using Nexus.ParticipantLibrary.Messages.Interfaces;
using System;

namespace Nexus.ParticipantLibrary.Messages
{
    public abstract class PublishableMessage : IAmAPublishableMessage
    {
        public DateTime SentDate
        {
            get { return DateTime.UtcNow; }
        }
    }
}
