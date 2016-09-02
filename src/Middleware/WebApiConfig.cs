using Nexus.ParticipantLibrary.Core.Configuration;
using Nexus.ParticipantLibrary.Middleware.Configuration;
using System;
using System.Web.Http;
using System.Web.Http.Cors;
using Nexus.ParticipantLibrary.Middleware.OwinConfiguration;
using System.Web.Http.Dispatcher;
using System.Linq;

namespace Nexus.ParticipantLibrary
{
    public static class WebApiConfig
    {
        private static HttpConfiguration config;

        public static HttpConfiguration Configure(IAppSettings appSettings, IAmAParticipantLibrary library)
        {
            config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            ConfigureParticipantLibrary(library);
            EnableCorsFromAppSettings(appSettings);
            DisableXmlSerializer();
            return config;
        }

        private static void DisableXmlSerializer()
        {
            config.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
        }

        private static void EnableCorsFromAppSettings(IAppSettings appSettings)
        {
            var origins = appSettings.CorsOrigins;

            if (string.IsNullOrEmpty(origins))
            {
                throw new Exception("CorsOrigin has not been set on AppSettings.");
            }

            var cors = new EnableCorsAttribute(origins, "*", "*");
            config.EnableCors(cors);
        }

        private static void ConfigureParticipantLibrary(IAmAParticipantLibrary library)
        {
            var nanoContainer = new NanoContainer();
            nanoContainer.Register(library);
            config.Services.Replace(typeof(IHttpControllerActivator), new ManualControllerActivation(nanoContainer));
            //config.Services.Replace(typeof(IExceptionHandler), new ParticipantLibraryExceptionHandler());
            //config.Services.Add(typeof(IExceptionLogger), new ParticipantLibraryExceptionLogger(logger));
        }

        //public static HttpConfiguration Configure(IAmAnEndorsementCatalogLibrary library, IEndorsementCatalogLogger logger)
        //{
        //    var config = new HttpConfiguration();

        //    config.MapHttpAttributeRoutes();

        //    var nanoContainer = new NanoContainer();
        //    nanoContainer.Register(library);
        //    config.Services.Replace(typeof(IHttpControllerActivator), new ManualControllerActivation(nanoContainer));
        //    config.Services.Replace(typeof(IExceptionHandler), new EndorsementCatalogExceptionHandler());
        //    config.Services.Add(typeof(IExceptionLogger), new EndorsementCatalogExceptionLogger(logger));

        //    return config;
        //}

    }
}
