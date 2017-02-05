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
using Nexus.ParticipantLibrary.Data.Context;
using Microsoft.EntityFrameworkCore;

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
                apiAppSettings.CorsOrigins = ApiAppSettings.GetAppSettingValue("CorsOrigins");
                apiAppSettings.IncludeErrorDetailPolicy = ApiAppSettings.GetAppSettingValue("IncludeErrorDetailPolicy");
            }

            if (webConfigFile.ConnectionStrings.ConnectionStrings.Count > 0)
            {
                apiAppSettings.ConnectionString_ParticipantLibrary_Read = 
                    ApiAppSettings.GetConnectionStringValue("ParticipantLibrary_Read");

                apiAppSettings.ConnectionString_ParticipantLibrary_Write = 
                    ApiAppSettings.GetConnectionStringValue("ParticipantLibrary_Write");
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

            var optionsBuilder = new DbContextOptionsBuilder<ParticipantLibraryContext>();
            optionsBuilder.UseSqlServer(apiAppSettings.ConnectionString_ParticipantLibrary_Read);
            var ctx = new ParticipantLibraryContext(optionsBuilder.Options);

            app.MapSignalR();
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
        public string ConnectionString_ParticipantLibrary_Read { get; set; }
        public string ConnectionString_ParticipantLibrary_Write { get; set; }
        public string IncludeErrorDetailPolicy { get; set; }

        public static string GetAppSettingValue(string keyName)
        {
            Configuration webConfigFile = WebConfigurationManager.OpenWebConfiguration("/");

            if (webConfigFile.AppSettings.Settings[keyName] != null)
            {
                KeyValueConfigurationElement configItem = webConfigFile.AppSettings.Settings[keyName];
                return configItem.Value;
            }
            else
            {
                Debug.WriteLine($"No '{keyName}' application setting found.");
                return string.Empty;
            }
        }
        public static string GetConnectionStringValue(string keyName)
        {
            Configuration webConfigFile = WebConfigurationManager.OpenWebConfiguration("/");

            if (webConfigFile.ConnectionStrings.ConnectionStrings[keyName] != null)
            {
                ConnectionStringSettings configItem = webConfigFile.ConnectionStrings.ConnectionStrings[keyName];
                return configItem.ConnectionString;
            }
            else
            {
                Debug.WriteLine($"No '{keyName}' connection string found.");
                return string.Empty;
            }
        }
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
