using System.Collections.Generic;
using System.Web.Http;
using Nexus.ParticipantLibrary.Core.Configuration;
using Nexus.ParticipantLibrary.ApiContract.Queries;
using Nexus.ParticipantLibrary.ApiContract.Dtos;
using System;

namespace Nexus.ParticipantLibrary.Middleware.Controllers
{
    [RoutePrefix("participants")]
    public class ParticipantLibraryController : ApiController
    {
        private readonly IAmAParticipantLibrary library;

        public ParticipantLibraryController()
        {

        }

        public ParticipantLibraryController(IAmAParticipantLibrary library)
        {
            this.library = library;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<ParticipantLibraryItemDto> GetAll()
        {
            var query = new GetAllParticipantLibraryItemsQuery();
            library.Execute(query);
            return query.Result;
        }

        [HttpGet]
        [Route("{key:Guid}")]
        public ParticipantLibraryItemDto GetByKey(Guid key)
        {
            var query = new GetParticipantLibraryItemByKeyQuery(key);
            library.Execute(query);
            return query.Result;
        }

        [HttpGet]
        [Route("byType/{typeKey:Guid}")]
        public IEnumerable<ParticipantLibraryItemDto> GetByType(Guid typeKey)
        {
            var query = new GetParticipantLibraryItemsByTypeQuery(typeKey);
            library.Execute(query);
            return query.Result;
        }

        [HttpGet]
        [Route("types/{key:Guid}")]
        public ParticipantLibraryItemTypeDto GetTypeByKey(Guid key)
        {
            var query = new GetParticipantLibraryItemTypeByKeyQuery(key);
            library.Execute(query);
            return query.Result;
        }

        [HttpGet]
        [Route("types")]
        public IEnumerable<ParticipantLibraryItemTypeDto> GetAllTypes()
        {
            var query = new GetAllParticipantLibraryItemTypesQuery();
            library.Execute(query);
            return query.Result;
        }
    }
}
