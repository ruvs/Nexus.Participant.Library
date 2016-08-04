using Nexus.ParticipantLibrary.Middleware.Configuration;
using System;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Nexus.ParticipantLibrary
{
    public static class WebApiConfig
    {
        private static HttpConfiguration config;

        public static HttpConfiguration Configure()
        {
            config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            EnableCorsFromAppSettings();
            return config;
        }

        private static void EnableCorsFromAppSettings()
        {
            var origins = AppSettings.CorsOrigins;

            if (string.IsNullOrEmpty(origins))
            {
                throw new Exception("CorsOrigin has not been set on AppSettings.");
            }

            var cors = new EnableCorsAttribute(origins, "*", "*");
            config.EnableCors(cors);
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
