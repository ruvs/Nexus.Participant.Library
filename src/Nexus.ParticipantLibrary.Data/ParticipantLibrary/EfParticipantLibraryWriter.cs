﻿using System;
using Nexus.ParticipantLibrary.Data._Config;
using Nexus.ParticipantLibrary.ApiContract.Dtos;
using Nexus.ParticipantLibrary.Core.Library;
using Nexus.ParticipantLibrary.Data.Context;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Nexus.ParticipantLibrary.Data.ParticipantLibrary
{
    public class EfParticipantLibraryWriter :
        EfInitialiserBase, 
        IWriteToParticipantLibrary
    {
        public EfParticipantLibraryWriter(DbContextOptionsBuilder<ParticipantLibraryContext> contextOptions, 
            IStoreWriteConnectionConfig writeConnectionConfig) 
            : base(contextOptions, writeConnectionConfig.ConnectionString)
        {
        }

        public DbOperationType Save(ParticipantLibraryItemDto item)
        {
            var dto = Mapper.Map<Domain.ParticipantLibraryItem>(item);
            DbOperationType dbOperationType;

            try
            {
                using (var db = new ParticipantLibraryContext(optionsBuilder.Options))
                {
                    var existingItem = db.ParticipantLibraryItems.SingleOrDefault(p => p.NexusKey == item.NexusKey);

                    if (existingItem == null)
                    {
                        dbOperationType = DbOperationType.Create;
                        db.ParticipantLibraryItems.Add(dto);
                    }
                    else
                    {
                        dbOperationType = DbOperationType.Update;
                        existingItem.Name = item.Name;
                        existingItem.DisplayCode = item.DisplayCode;
                        existingItem.DisplayName = item.DisplayName;
                        existingItem.Iso2Code = item.Iso2Code;
                        existingItem.Iso3Code = item.Iso3Code;
                        existingItem.TypeKey = item.TypeKey;
                    }

                    db.SaveChanges();
                }

                return dbOperationType;
            }
            catch(Exception)
            {
                throw;
            }

            #region oldcode
            //using (var connection = new SqlConnection(ConnectionStringWrite))
            //{

            //    connection.Open();

            //    using (var tran = connection.BeginTransaction())
            //    {
            //        try
            //        {
            //            connection.Execute(EndorsementCatalogStatements.Save, dto,tran);
            //            tran.Commit();
            //        }

            //        catch (SqlException exception)
            //        {
            //            tran.Rollback();
            //            if (exception.Message.Contains(EndorsementCatalogStatements.UniqueConstraintViolation))
            //            {
            //                throw new CatalogLibraryDuplicateItemException(
            //                    string.Format(
            //                        "The Library already contains an item with Key:'{0}' and VersionNumber:{1}",
            //                        item.Key, item.VersionNumber));
            //            }
            //            if (exception.Message.Contains(EndorsementCatalogStatements.PrimaryKeyViolation))
            //            {
            //                throw new CatalogLibraryDuplicateItemException(
            //                    string.Format(
            //                        "The Library already contains an item with VersionKey:'{0}'",item.VersionKey));
            //            }

            //            if (exception.Message.Contains(EndorsementCatalogStatements.OutOfSequenceViolation))
            //            {
            //                throw new CatalogLibraryOutOfSequenceException(exception.Message);
            //            }
            //            throw;
            //        }
            //        catch (Exception)
            //        {
            //            tran.Rollback();
            //            throw;
            //        }
            //    }
            //}
            #endregion
        }
    }
}