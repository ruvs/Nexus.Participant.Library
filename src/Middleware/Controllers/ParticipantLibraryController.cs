using System.Collections.Generic;
using System.Web.Http;
using Nexus.ParticipantLibrary.Core.Configuration;
using Nexus.ParticipantLibrary.ApiContract.Queries;
using Nexus.ParticipantLibrary.ApiContract.Dtos;

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


        private List<string> _participants = new List<string>() {
            "one", "two", "three"
        };

        [HttpGet]
        [Route("")]
        public IEnumerable<ParticipantLibraryItem> GetAll()
        {
            var query = new GetAllParticipantLibraryItemsQuery();
            library.Execute(query);
            return query.Result;
        }
    }
}
