﻿using Microsoft.Owin.Cors;
using Owin;
using System.Configuration;
using System.Threading.Tasks;
using System.Web.Cors;

namespace Nexus.ParticipantLibrary.Middleware
{
    public static class CorsHelper
    {
        private static readonly string CORS_ORIGINS_SETTINGS_KEY = "CorsOrigins";

        public static void Register(IAppBuilder app)
        {
            var corsPolicy = new CorsPolicy
            {
                AllowAnyMethod = true,
                AllowAnyHeader = true
            };

            // Try and load allowed origins from web.config
            // If none are specified we'll allow all origins

            var origins = ConfigurationManager.AppSettings[CORS_ORIGINS_SETTINGS_KEY];

            if (origins != null)
            {
                foreach (var origin in origins.Split(';'))
                {
                    corsPolicy.Origins.Add(origin);
                }
            }
            else
            {
                corsPolicy.AllowAnyOrigin = true;
            }

            var corsOptions = new CorsOptions
            {
                PolicyProvider = new CorsPolicyProvider
                {
                    PolicyResolver = context => Task.FromResult(corsPolicy)
                }
            };

            app.UseCors(corsOptions);
        }
    }
}
