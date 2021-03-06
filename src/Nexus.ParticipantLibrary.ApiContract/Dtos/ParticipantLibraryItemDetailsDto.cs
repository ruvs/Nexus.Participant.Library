﻿using System;
using System.Collections.Generic;

namespace Nexus.ParticipantLibrary.ApiContract.Dtos
{
    public class ParticipantLibraryItemDetailsDto
    {
        public ParticipantLibraryItemDetailsDto()
        {
            Types = new List<ParticipantLibraryItemTypeDto>();
        }

        public Guid NexusKey { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string DisplayCode { get; set; }

        public string Iso2Code { get; set; }

        public string Iso3Code { get; set; }

        public Guid TypeKey { get; set; }

        public string TypeName { get; set; }

        public IList<ParticipantLibraryItemTypeDto> Types { get; set; }

        public override string ToString()
        {
            return string.Format("An {GetType().Name} with Key:'{NexusKey}' Id:'{Id}' Name:'{Name}' Type:'{TypeName}'");
        }
    }
}
