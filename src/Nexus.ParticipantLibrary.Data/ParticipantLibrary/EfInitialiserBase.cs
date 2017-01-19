using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Nexus.ParticipantLibrary.ApiContract.Dtos;
using Nexus.ParticipantLibrary.Data.Context;
using Nexus.ParticipantLibrary.Data.Domain;

namespace Nexus.ParticipantLibrary.Data.ParticipantLibrary
{
    public class EfInitialiserBase
    {
        protected DbContextOptionsBuilder<ParticipantLibraryContext> optionsBuilder;
        public EfInitialiserBase(DbContextOptionsBuilder<ParticipantLibraryContext> contextOptions, string connectionString)
        {
            optionsBuilder = contextOptions;
            SetupConnection(connectionString);
            RegisterAutoMappings();
        }

        private void SetupConnection(string connectionString)
        {
            if (!optionsBuilder.IsConfigured) // This prevents multiple configurations
            {
                optionsBuilder = new DbContextOptionsBuilder<ParticipantLibraryContext>();
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        public static void RegisterAutoMappings()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<ParticipantLibraryProfile>();
            });
        }

        internal class ParticipantLibraryProfile : Profile
        {
            public ParticipantLibraryProfile()
            {
                CreateMap<ParticipantLibraryItem, ParticipantLibraryItemDto>();
                CreateMap<ParticipantLibraryItemDto, ParticipantLibraryItem>();

                CreateMap<ParticipantLibraryItemType, ParticipantLibraryItemTypeDto>();
                CreateMap<ParticipantLibraryItemTypeDto, ParticipantLibraryItemType>();

                CreateMap<ParticipantLibraryItem, ParticipantLibraryItemDetailsDto>();
                //CreateMap<ParticipantLibraryItemDetailsDto, ParticipantLibraryItem>();

                //map.UseValue(Enum.GetNames(typeof(ScheduleStatus)).ToArray()))
                //CreateMap<ParticipantLibraryItem, ParticipantLibraryItemDto>()
                //    .ForMember(m => m.TypeName, opt => opt.MapFrom(m => m.Type.Name));
            }
        }
    }
}
