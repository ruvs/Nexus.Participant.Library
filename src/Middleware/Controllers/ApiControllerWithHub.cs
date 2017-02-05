using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Web.Http;

namespace Nexus.ParticipantLibrary.Middleware.Controllers
{
    public abstract class ApiControllerWithHub<THub> : ApiController where THub : IHub
    {
        Lazy<IHubContext> hub = new Lazy<IHubContext>(() => GlobalHost.ConnectionManager.GetHubContext<THub>());

        protected IHubContext Hub
        {
            get { return hub.Value; }
        }

        //private readonly IHubContext _hub;
        //public IHubConnectionContext<dynamic> Clients { get; private set; }
        //public IGroupManager Groups { get; private set; }
        //protected ApiHubController(IConnectionManager signalRConnectionManager)
        //{
        //    var _hub = signalRConnectionManager.GetHubContext<T>();
        //    Clients = _hub.Clients;
        //    Groups = _hub.Groups;
        //}
    }
}
