using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nexus.ParticipantLibrary.Data.Domain
{
    public class EntityBase
    {
        [Required]
        public DateTime CreatedDate { get; set; } //Required

        public DateTime UpdatedDate { get; set; }

        [Required]
        public DateTime ValidFrom { get; set; } //Required

        [Required]
        public DateTime? ValidTo { get; set; }

        public string UpdatedByKey { get; set; } //Required

        public string UpdatedByName { get; set; } //Required
    }
}
