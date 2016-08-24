using System;
using Nexus.ParticipantLibrary.Data._Config;
using Nexus.ParticipantLibrary.ApiContract.Dtos;
using Nexus.ParticipantLibrary.Core.Library;
using Nexus.ParticipantLibrary.Data.Context;
using AutoMapper;

namespace Nexus.ParticipantLibrary.Data.ParticipantLibrary
{
    public class EfParticipantLibraryWriter :
        //DapperSelfInitializingWriterBase, 
        IWriteToParticipantLibrary
    {
        public EfParticipantLibraryWriter(IStoreWriteConnectionConfig writeConnectionConfig) 
            //: base(writeConnectionConfig,EndorsementCatalogStatements.InitializeDatabase)
        {
        }

        public void Save(ParticipantLibraryItem item)
        {
            var dto = Mapper.Map<Domain.ParticipantLibraryItem>(item);

            try
            {
                using (var db = new ParticipantLibraryContext())
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