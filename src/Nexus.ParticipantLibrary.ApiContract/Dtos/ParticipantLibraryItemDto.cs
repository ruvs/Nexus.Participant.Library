using System;
using System.Runtime.Serialization;

namespace Nexus.ParticipantLibrary.ApiContract.Dtos
{
    public class ParticipantLibraryItemDto
    {
        public Guid NexusKey { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public Guid TypeKey { get; set; }
        public string TypeName { get; set; }

        public override string ToString()
        {
            return string.Format("An {GetType().Name} with Key:'{NexusKey}' Id:'{Id}' Name:'{Name}' Type:'{TypeName}'");
        }
    }
}
