﻿using Nexus.ParticipantLibrary.Middleware;
using System.Diagnostics;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Nexus.ParticipantLibrary
{
    public static class WebApiConfig
    {
        public static HttpConfiguration Configure()
        {
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            EnableCorsFromConfig(config);
            return config;
        }

        private static void EnableCorsFromConfig(HttpConfiguration config)
        {
            var origins = ConfigHelper.CorsOrigins;
            //TODO - should remove if check to force config values to be set
            if (string.IsNullOrEmpty(origins))
            {
                origins = "*";
            }

            Debug.WriteLine("Adding cors origins: {origins}");
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
