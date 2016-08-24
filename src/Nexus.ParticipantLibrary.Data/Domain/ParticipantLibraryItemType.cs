using System;
using System.Collections.Generic;

namespace Nexus.ParticipantLibrary.Data.Domain
{
    public class ParticipantLibraryItemType
    {
        public Guid NexusKey { get; set; } //Key
        public int Id { get; set; } //Required
        public string Name { get; set; } //Required

        public virtual ICollection<ParticipantLibraryItem> ParticipantLibraryItems { get; set; }
    }
}