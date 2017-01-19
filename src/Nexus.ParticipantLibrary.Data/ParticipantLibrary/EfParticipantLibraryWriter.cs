using System;
using Nexus.ParticipantLibrary.Data._Config;
using Nexus.ParticipantLibrary.ApiContract.Dtos;
using Nexus.ParticipantLibrary.Core.Library;
using Nexus.ParticipantLibrary.Data.Context;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

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

        public void Save(ParticipantLibraryItemDto item)
        {
            var dto = Mapper.Map<Domain.ParticipantLibraryItem>(item);

            try
            {
                using (var db = new ParticipantLibraryContext(optionsBuilder.Options))
                {
                    db.ParticipantLibraryItems.Add(dto);
                    db.SaveChanges();
                }
            }
            catch(Exception)
            {
                throw;
            }
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
        }
    }
}