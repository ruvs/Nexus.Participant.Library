using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Nexus.ParticipantLibrary.Data._Config;
using Nexus.ParticipantLibrary.Core.Library;
using Nexus.ParticipantLibrary.ApiContract.Dtos;
using Nexus.ParticipantLibrary.Data.Context;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Nexus.ParticipantLibrary.Data.Domain;

namespace Nexus.ParticipantLibrary.Data.ParticipantLibrary
{
    public class EfParticipantLibraryReader :
        EfInitialiserBase, 
        IReadFromParticipantLibrary
    {

        public EfParticipantLibraryReader(IStoreReadConnectionConfig readConnectionConfig) 
            : base(readConnectionConfig.ConnectionString)
        {
        }

        public IEnumerable<ParticipantLibraryItemDto> ReadAll()
        {
            IEnumerable<ParticipantLibraryItem> dtos;

            try
            {
                using (var db = new ParticipantLibraryContext(optionsBuilder.Options))
                {
                    dtos = db.ParticipantLibraryItems.Include(x => x.Type).AsEnumerable();


                    var toReturn = new List<ParticipantLibraryItemDto>();
                    foreach (var dto in dtos)
                    {
                        toReturn.Add(Mapper.Map<ParticipantLibraryItemDto>(dto));
                    }

                    return toReturn;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ParticipantLibraryItemDto ReadByKey(Guid key)
        {
            ParticipantLibraryItem dto;

            try
            {
                using (var db = new ParticipantLibraryContext(optionsBuilder.Options))
                {
                    dto = db.ParticipantLibraryItems.SingleOrDefault(p => p.NexusKey == key);
                }

                var toReturn = Mapper.Map<ParticipantLibraryItemDto>(dto);
                return toReturn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<ParticipantLibraryItemDto> ReadByType(Guid typeKey)
        {
            IEnumerable<ParticipantLibraryItem> dtos;

            try
            {
                using (var db = new ParticipantLibraryContext(optionsBuilder.Options))
                {
                    dtos = db.ParticipantLibraryItems.Where(p => p.TypeKey == typeKey).Include(x => x.Type).AsEnumerable();

                    var toReturn = new List<ParticipantLibraryItemDto>();
                    foreach (var dto in dtos)
                    {
                        toReturn.Add(Mapper.Map<ParticipantLibraryItemDto>(dto));
                    }

                    return toReturn;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ParticipantLibraryItemTypeDto ReadTypeByKey(Guid key)
        {
            ParticipantLibraryItemType dto;

            try
            {
                using (var db = new ParticipantLibraryContext(optionsBuilder.Options))
                {
                    dto = db.ParticipantLibraryItemTypes.SingleOrDefault(x => x.NexusKey == key);

                    var toReturn = Mapper.Map<ParticipantLibraryItemTypeDto>(dto);
                    return toReturn;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<ParticipantLibraryItemTypeDto> ReadAllTypes()
        {
            IEnumerable<ParticipantLibraryItemType> dtos;

            try
            {
                using (var db = new ParticipantLibraryContext(optionsBuilder.Options))
                {
                    dtos = db.ParticipantLibraryItemTypes.AsEnumerable();

                    var toReturn = new List<ParticipantLibraryItemTypeDto>();
                    foreach (var dto in dtos)
                    {
                        toReturn.Add(Mapper.Map<ParticipantLibraryItemTypeDto>(dto));
                    }

                    return toReturn;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
} 