using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nexus.ParticipantLibrary.Data.Domain
{
    public class ParticipantLibraryItemType
    {
        [Key]
        public Guid NexusKey { get; set; } //Key

        [Column(Order = 10)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } //Required

        [Required]
        [Column(Order = 20)]
        public string Name { get; set; } //Required

        [Required]
        [Column(Order = 30)]
        public string DisplayName { get; set; } //Required

        public virtual ICollection<ParticipantLibraryItem> ParticipantLibraryItems { get; set; }
    }
}