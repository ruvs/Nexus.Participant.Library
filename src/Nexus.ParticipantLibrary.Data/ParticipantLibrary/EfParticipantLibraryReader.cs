using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Nexus.ParticipantLibrary.Data._Config;
using Nexus.ParticipantLibrary.Core.Library;
using Nexus.ParticipantLibrary.ApiContract.Dtos;
using Nexus.ParticipantLibrary.Data.Context;
using AutoMapper;

namespace Nexus.ParticipantLibrary.Data.ParticipantLibrary
{
    public class EfParticipantLibraryReader : 
        //DapperSelfInitializingReaderBase, 
        IReadFromParticipantLibrary
    {

        public EfParticipantLibraryReader(IStoreReadConnectionConfig readConnectionConfig) 
            //: base(readConnectionConfig,EndorsementCatalogStatements.InitializeDatabase)
        {
        }

        public IEnumerable<ParticipantLibraryItem> ReadAll()
        {
            IEnumerable<Domain.ParticipantLibraryItem> dtos;

            try
            {
                using (var db = new ParticipantLibraryContext())
                {
                    dtos = db.ParticipantLibraryItems.AsEnumerable();
                }

                var toReturn = new List<ParticipantLibraryItem>();
                foreach (var dto in dtos)
                {
                    toReturn.Add(Mapper.Map<ParticipantLibraryItemEfDto>(dto));
                }

                return toReturn;
            }
            catch (Exception)
            {
                throw;
            }

            //using (var connection = new SqlConnection(ConnectionStringRead))
            //{
            //   var dto = connection.Query<EndorsementCatalogItemDapperDto>(EndorsementCatalogStatements.GetLatest, new
            //        {
            //            Key = key
            //        }).Single();

            //   return Mapper.Map<ParticipantLibraryItem>(dto);
            //}
        }

        public ParticipantLibraryItem ReadByKey(Guid key)
        {
            Domain.ParticipantLibraryItem dto;

            try
            {
                using (var db = new ParticipantLibraryContext())
                {
                    dto = db.ParticipantLibraryItems.SingleOrDefault(p => p.NexusKey == key);
                }

                var toReturn = Mapper.Map<ParticipantLibraryItemEfDto>(dto);
                return toReturn;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<ParticipantLibraryItem> ReadByType(Guid typeKey)
        {
            IEnumerable<Domain.ParticipantLibraryItem> dtos;

            try
            {
                using (var db = new ParticipantLibraryContext())
                {
                    dtos = db.ParticipantLibraryItems.Where(p => p.TypeKey == typeKey).AsEnumerable();
                }

                var toReturn = new List<ParticipantLibraryItem>();
                foreach (var dto in dtos)
                {
                    toReturn.Add(Mapper.Map<ParticipantLibraryItemEfDto>(dto));
                }

                return toReturn;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
} 