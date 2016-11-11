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
        public string DisplayCode { get; set; }
        public string DisplayName { get; set; }
        public string Iso3Code { get; set; }
        public Guid TypeKey { get; set; }
        //public string TypeName { get; set; }


        public override string ToString()
        {
            return string.Format($"An {GetType().Name} with Key:'{NexusKey}' Id:'{Id}' Name:'{Name}' DisplayName:'{DisplayName}' DisplayCode:'{DisplayCode}'");
        }

        public string Url
        {
            get { return ""; }
        }
    }
}