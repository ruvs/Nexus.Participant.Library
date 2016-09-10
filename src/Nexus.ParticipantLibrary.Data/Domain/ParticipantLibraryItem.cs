using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nexus.ParticipantLibrary.Data.Domain
{
    public class ParticipantLibraryItem
    {
        [Key]
        public Guid NexusKey { get; set; } //Key

        [Required]
        [Column(Order = 10)]
        public int Id { get; set; } //Required

        [Required]
        [Column(Order = 20)]
        public string Name { get; set; } //Required

        [Required]
        [Column(Order = 30)]
        public string DisplayName { get; set; } //Required

        [Column(Order = 40)]
        public string DisplayCode { get; set; }

        [Column(Order = 50)]
        public string Iso2Code { get; set; }

        [Column(Order = 60)]
        public string Iso3Code { get; set; }

        [Column(Order = 70)]
        [ForeignKey("Type")]
        public Guid TypeKey { get; set; }

        public virtual ParticipantLibraryItemType Type { get; set; }
    }
}
