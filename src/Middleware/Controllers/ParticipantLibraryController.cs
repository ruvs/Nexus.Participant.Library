using System.Collections.Generic;
using System.Web.Http;

namespace Nexus.Participant.Library.Middleware.Controllers
{
    [RoutePrefix("participants")]
    public class ParticipantLibraryController : ApiController
    {
        private List<string> _participants = new List<string>() {
            "one", "two", "three"
        };

        [Route("")]
        public IHttpActionResult GetAll()
        {
            if (_participants == null)
            {
                return NotFound();
            }
            return Ok(_participants);
        }
    }
}
