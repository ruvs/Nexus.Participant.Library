using System;

namespace Nexus.ParticipantLibrary.ApiContract.Commands
{

    public class SaveParticipantLibraryItemCommand : IParticipantLibraryCommand
    {
        public SaveParticipantLibraryItemCommand()
        {
        }

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

        public string Url
        {
            get { return ""; }
        }
    }
}