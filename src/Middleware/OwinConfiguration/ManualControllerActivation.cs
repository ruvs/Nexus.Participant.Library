using System;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using Nexus.ParticipantLibrary.Core.Configuration;
using Nexus.ParticipantLibrary.Middleware.Controllers;

namespace Nexus.ParticipantLibrary.Middleware.OwinConfiguration
{
    public class ManualControllerActivation : IHttpControllerActivator
    {
        private readonly NanoContainer container;

        public ManualControllerActivation(NanoContainer container)
        {
            this.container = container;
        }

        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor,
            Type controllerType)
        {
            if (controllerType == typeof(ParticipantLibraryController))
            {
                var controller = new ParticipantLibraryController(container.Resolve<IAmAParticipantLibrary>());
                return controller;
            }
            
            throw new Exception("Please handle controller creation in ManualControllerActivation");
        }
    }
}