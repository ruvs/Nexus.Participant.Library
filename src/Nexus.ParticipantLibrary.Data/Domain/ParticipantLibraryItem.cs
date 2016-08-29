using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nexus.ParticipantLibrary.Data.Domain
{
    public class ParticipantLibraryItem
    {
        [Key]
        public Guid NexusKey { get; set; } //Key
        public int Id { get; set; } //Required
        [Required]
        public string Name { get; set; } //Required
        public string ShortName { get; set; }
        [ForeignKey("Type")]
        public Guid TypeKey { get; set; }

        public virtual ParticipantLibraryItemType Type { get; set; }
    }
}
