using Microsoft.Owin;
using Owin;
using Nexus.ParticipantLibrary.Middleware.OwinConfiguration;
using Nexus.ParticipantLibrary.Middleware.Configuration;
using System.Configuration;
using System.Web.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using Nexus.ParticipantLibrary.Core.Configuration;
using Nexus.ParticipantLibrary.Core.Logging;
using Nexus.ParticipantLibrary.Data._Config;
using NLog;
using Nexus.ParticipantLibrary.Api;

[assembly: OwinStartup(typeof(Startup))]

namespace Nexus.ParticipantLibrary.Api
{
    public class Startup
    {
        private const string CONNECTION_STRING_NAME_READ = "ParticipantLibrary_Read";
        private const string CONNECTION_STRING_NAME_WRITE = "ParticipantLibrary_Write";
        IAppSettings apiAppSettings = new ApiAppSettings();

        public Startup()
        {
            Configuration webConfigFile = WebConfigurationManager.OpenWebConfiguration("/");

            if (webConfigFile.AppSettings.Settings.Count > 0)
            {
                KeyValueConfigurationElement corsOrigins =
                    webConfigFile.AppSettings.Settings["CorsOrigins"];
                if (corsOrigins != null)
                {
                    apiAppSettings.CorsOrigins = corsOrigins.Value;
                }
                else
                {
                    Debug.WriteLine("No CorsOrigins application setting");
                }
            }
        }

        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888

            IParticipantLibraryLogger logWriter = new ParticipantLibraryLogger();

            app.Map("/api", parLibApp =>
                    parLibApp.UseParticipantLibraryCore(apiAppSettings, BootStrapParticipantLibrary(logWriter)));
        }

        private IAmAParticipantLibrary BootStrapParticipantLibrary(IParticipantLibraryLogger logWriter)
        {
            //IResolveClaimsPrincipal claimsPrincipalResolver = new ClaimsPrincipalResolver();

            IAmAParticipantLibrary participantLibrary = ParticipantLibraryConfigure
                .Init()
                .With(logWriter)
                //.With(claimsPrincipalResolver)
                .EfPersistence()
                .WithConnectionsNamed(CONNECTION_STRING_NAME_READ, CONNECTION_STRING_NAME_WRITE)
                .Build();

            return participantLibrary;
        }
    }


    internal class ApiAppSettings : IAppSettings
    {
        public string CorsOrigins { get; set; }
    }

    //internal class ClaimsPrincipalResolver : IResolveClaimsPrincipal
    //{
    //    public ClaimsPrincipal ClaimsPrincipal { get { return ClaimsPrincipal.Current; } }
    //}

    public class ParticipantLibraryLogger : IParticipantLibraryLogger
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public void Error(string message)
        {
            Logger.Error(message);
        }
    }
}
