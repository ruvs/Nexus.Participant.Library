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
        public EfParticipantLibraryReader(DbContextOptionsBuilder<ParticipantLibraryContext> contextOptions,
            IStoreReadConnectionConfig readConnectionConfig) 
            : base(contextOptions, readConnectionConfig.ConnectionString)
        {
        }

        public IEnumerable<ParticipantLibraryItemDto> ReadAll()
        {
            IEnumerable<ParticipantLibraryItem> domainPlItems;

            try
            {
                using (var db = new ParticipantLibraryContext(optionsBuilder.Options))
                {
                    domainPlItems = db.ParticipantLibraryItems
                        .Include(x => x.Type)
                        .OrderBy(x => x.DisplayName);

                    var toReturn = new List<ParticipantLibraryItemDto>();
                    foreach (var dto in domainPlItems)
                    {
                        toReturn.Add(Mapper.Map<ParticipantLibraryItemDto>(dto));
                    }

                    return toReturn.OrderBy(x => x.DisplayName);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ParticipantLibraryItemDto ReadByKey(Guid key)
        {
            ParticipantLibraryItem domainPli;

            try
            {
                using (var db = new ParticipantLibraryContext(optionsBuilder.Options))
                {
                    domainPli = db.ParticipantLibraryItems.SingleOrDefault(p => p.NexusKey == key);
                }

                var toReturn = Mapper.Map<ParticipantLibraryItemDto>(domainPli);
                return toReturn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ParticipantLibraryItemDetailsDto ReadDetailsByKey(Guid key)
        {
            ParticipantLibraryItem domainPli;
            List<ParticipantLibraryItemType> domainTypes;

            try
            {
                using (var db = new ParticipantLibraryContext(optionsBuilder.Options))
                {
                    domainPli = db.ParticipantLibraryItems.SingleOrDefault(p => p.NexusKey == key);
                    domainTypes = db.ParticipantLibraryItemTypes.ToList();
                }

                var toReturn = Mapper.Map<ParticipantLibraryItemDetailsDto>(domainPli);

                foreach(var domainType in domainTypes)
                {
                    toReturn.Types.Add(Mapper.Map<ParticipantLibraryItemTypeDto>(domainType));
                }

                return toReturn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<ParticipantLibraryItemDto> ReadByType(Guid typeKey)
        {
            IEnumerable<ParticipantLibraryItem> domainPlItems;

            try
            {
                using (var db = new ParticipantLibraryContext(optionsBuilder.Options))
                {
                    domainPlItems = db.ParticipantLibraryItems
                        .Include(x => x.Type)
                        .Where(p => p.TypeKey == typeKey)
                        .OrderBy(x => x.DisplayName);

                    var toReturn = new List<ParticipantLibraryItemDto>();
                    foreach (var dto in domainPlItems)
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
            ParticipantLibraryItemType domainPlType;

            try
            {
                using (var db = new ParticipantLibraryContext(optionsBuilder.Options))
                {
                    domainPlType = db.ParticipantLibraryItemTypes.SingleOrDefault(x => x.NexusKey == key);

                    var toReturn = Mapper.Map<ParticipantLibraryItemTypeDto>(domainPlType);
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
            IEnumerable<ParticipantLibraryItemType> domainPlTypes;

            try
            {
                using (var db = new ParticipantLibraryContext(optionsBuilder.Options))
                {
                    domainPlTypes = db.ParticipantLibraryItemTypes
                        .OrderBy(x => x.DisplayName);

                    var toReturn = new List<ParticipantLibraryItemTypeDto>();
                    foreach (var dto in domainPlTypes)
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