﻿using Microsoft.Owin.Cors;
using Owin;
using System.Threading.Tasks;
using System.Web.Cors;

namespace Nexus.ParticipantLibrary.Middleware
{
    public static class CorsHelper
    {
        public static void Register(IAppBuilder app)
        {
            var corsPolicy = new CorsPolicy
            {
                AllowAnyMethod = true,
                AllowAnyHeader = true
            };

            // Try and load allowed origins from web.config
            // If none are specified we'll allow all origins

            var origins = ConfigHelper.CorsOrigins;

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
