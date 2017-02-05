using System.Collections.Generic;
using System.Web.Http;
using Nexus.ParticipantLibrary.Core.Configuration;
using Nexus.ParticipantLibrary.ApiContract.Queries;
using Nexus.ParticipantLibrary.ApiContract.Dtos;
using System;
using Nexus.ParticipantLibrary.ApiContract.Commands;
using Nexus.ParticipantLibrary.Middleware.Hubs;

namespace Nexus.ParticipantLibrary.Middleware.Controllers
{
    [RoutePrefix("participants")]
    public class ParticipantLibraryController : ApiControllerWithHub<ParticipantLibraryBroadcaster>
    {
        private readonly IAmAParticipantLibrary library;

        public ParticipantLibraryController()
        {

        }

        public ParticipantLibraryController(IAmAParticipantLibrary library)
        {
            this.library = library;
        }

        [HttpPost]
        [Route("save")]
        public IHttpActionResult Post(SaveParticipantLibraryItemCommand command)
        {
            library.Execute(command);
            return Ok();
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
        [Route("{key:Guid}/details")]
        public ParticipantLibraryItemDetailsDto GetDetailsByKey(Guid key)
        {
            var query = new GetParticipantLibraryItemDetailsByKeyQuery(key);
            library.Execute(query);

            PublishEvent(ParticipantLibraryBroadcasterEventsEnum.ClientsAll_GetDetailsByKey);

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

        private void PublishEvent(ParticipantLibraryBroadcasterEventsEnum eventName)
        {
            switch(eventName)
            {
                case ParticipantLibraryBroadcasterEventsEnum.ClientsAll_GetDetailsByKey:
                    Hub.Clients.All.broadcastMessage("NAME", "Hey from signal R GetDetailsByKey!");
                    //Clients.All.OnGDBK("Hey from signal R GetDetailsByKey!");
                    break;
                default:
                    break;
            }
        }
    }
}
