﻿using Nexus.ParticipantLibrary.ApiContract.Commands;
using Nexus.ParticipantLibrary.ApiContract.Dtos;
using Nexus.ParticipantLibrary.ApiContract.Queries;
using Nexus.ParticipantLibrary.Core.Configuration;
using Nexus.ParticipantLibrary.Core.Library;
using System.Collections.Generic;

namespace Nexus.ParticipantLibrary.Core
{
    public class ParticipantItemLibrary : IAmAParticipantLibrary
    {
        //private readonly IResolveClaimsPrincipal claimsPrincipalResolver;
        private readonly IWriteToParticipantLibrary libraryWriter;
        private readonly IReadFromParticipantLibrary libraryReader;

        public ParticipantItemLibrary(//IResolveClaimsPrincipal claimsPrincipalResolver, 
                                         IWriteToParticipantLibrary libraryWriter,
                                         IReadFromParticipantLibrary libraryReader)
        {
            //this.claimsPrincipalResolver = claimsPrincipalResolver;
            this.libraryWriter = libraryWriter;
            this.libraryReader = libraryReader;
        }

        public void Execute(IParticipantLibraryCommand command)
        {
            var saveParticipantLibraryItemCommand = command as SaveParticipantLibraryItemCommand;
            if (saveParticipantLibraryItemCommand != null)
            {
                if (libraryReader.ReadByKey(saveParticipantLibraryItemCommand.NexusKey) == null)
                {
                    //AssignVersionKeyIfNotSet(saveParticipantLibraryItemCommand);

                    Validate(saveParticipantLibraryItemCommand);

                    libraryWriter.Save(new ParticipantLibraryItemDto()
                    {
                        NexusKey = saveParticipantLibraryItemCommand.NexusKey,
                        DisplayCode = saveParticipantLibraryItemCommand.DisplayCode,
                        Iso2Code = saveParticipantLibraryItemCommand.Iso2Code,
                        Iso3Code = saveParticipantLibraryItemCommand.Iso3Code,
                        Name = saveParticipantLibraryItemCommand.Name,
                        DisplayName = saveParticipantLibraryItemCommand.DisplayName,
                        TypeKey = saveParticipantLibraryItemCommand.TypeKey,
                    });
                }
                else
                {
                    Validate(saveParticipantLibraryItemCommand);

                    libraryWriter.Save(new ParticipantLibraryItemDto()
                    {
                        NexusKey = saveParticipantLibraryItemCommand.NexusKey,
                        DisplayCode = saveParticipantLibraryItemCommand.DisplayCode,
                        Iso2Code = saveParticipantLibraryItemCommand.Iso2Code,
                        Iso3Code = saveParticipantLibraryItemCommand.Iso3Code,
                        Name = saveParticipantLibraryItemCommand.Name,
                        DisplayName = saveParticipantLibraryItemCommand.DisplayName,
                        TypeKey = saveParticipantLibraryItemCommand.TypeKey,
                    });
                }
            }
        }

        //private void AssignVersionKeyIfNotSet(SaveParticipantLibraryItemCommand command)
        //{
        //    if (command.VersionKey == Guid.Empty)
        //    {
        //        command.VersionKey = Guid.NewGuid();
        //    }
        //}

        private void Validate(SaveParticipantLibraryItemCommand saveParticipantLibraryItemCommand)
        {
            var errors = new List<string>();

            //if(string.IsNullOrEmpty(saveCatalogEntryCommand.Name))
            //{
            //    errors.Add("You must specify a Name");
            //}
            //if (string.IsNullOrEmpty(saveCatalogEntryCommand.ReferenceNumber))
            //{
            //    errors.Add("You must specify a Reference Number");
            //}
            //if (string.IsNullOrEmpty(saveCatalogEntryCommand.SourceSystem))
            //{
            //    errors.Add("You must specify a Source System");
            //}
            //if (saveCatalogEntryCommand.Key == Guid.Empty)
            //{
            //    errors.Add("You must specify a Key");
            //}
            //if (saveCatalogEntryCommand.VersionNumber <= 0)
            //{
            //    errors.Add("You must specify a VersionNumber");
            //}
            //if (saveCatalogEntryCommand.MetaDataItems.Count(md => md.DataType == MetaDataItemDataType.EndorsementCategory) > 1)
            //{
            //    errors.Add("An endorsement cannot have more than one EndorsementCategory as part of its MetaData.");
            //}
            //if (errors.Any())
            //{
            //    throw new CatalogLibraryValidationException(errors.ToCommaDelimitedString());
            //}
        }

        public void Execute(IParticipantLibraryQuery query)
        {
            var getAllParticipantLibraryItemsQuery = query as GetAllParticipantLibraryItemsQuery;
            if (getAllParticipantLibraryItemsQuery != null)
            {
                getAllParticipantLibraryItemsQuery.Result =
                    libraryReader.ReadAll();
                return;
            }

            var getParticipantLibraryItemByKeyQuery = query as GetParticipantLibraryItemByKeyQuery;
            if (getParticipantLibraryItemByKeyQuery != null)
            {
                getParticipantLibraryItemByKeyQuery.Result = 
                    libraryReader.ReadByKey(getParticipantLibraryItemByKeyQuery.Key);
                return;
            }

            var getParticipantLibraryItemDetailsByKeyQuery = query as GetParticipantLibraryItemDetailsByKeyQuery;
            if (getParticipantLibraryItemDetailsByKeyQuery != null)
            {
                getParticipantLibraryItemDetailsByKeyQuery.Result =
                    libraryReader.ReadDetailsByKey(getParticipantLibraryItemDetailsByKeyQuery.Key);
                return;
            }

            var getParticipantLibraryItemsByTypeQuery = query as GetParticipantLibraryItemsByTypeQuery;
            if (getParticipantLibraryItemsByTypeQuery != null)
            {
                getParticipantLibraryItemsByTypeQuery.Result = 
                    libraryReader.ReadByType(getParticipantLibraryItemsByTypeQuery.TypeKey);
                return;
            }

            var getParticipantLibraryItemTypeByKeyQuery = query as GetParticipantLibraryItemTypeByKeyQuery;
            if (getParticipantLibraryItemTypeByKeyQuery != null)
            {
                getParticipantLibraryItemTypeByKeyQuery.Result =
                    libraryReader.ReadTypeByKey(getParticipantLibraryItemTypeByKeyQuery.Key);
                return;
            }

            var getAllParticipantLibraryItemTypesQuery = query as GetAllParticipantLibraryItemTypesQuery;
            if (getAllParticipantLibraryItemTypesQuery != null)
            {
                getAllParticipantLibraryItemTypesQuery.Result =
                    libraryReader.ReadAllTypes();
                return;
            }

        }
    }
}