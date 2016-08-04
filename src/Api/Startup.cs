using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Nexus.ParticipantLibrary.Middleware.OwinConfiguration;
using Nexus.ParticipantLibrary.Middleware.Configuration;

[assembly: OwinStartup(typeof(Nexus.ParticipantLibrary.Startup))]

namespace Nexus.ParticipantLibrary
{
    public class Startup
    {
        private const string CONNECTION_STRING_NAME_READ = "EndorsementCatalog_Read";
        private const string CONNECTION_STRING_NAME_WRITE = "EndorsementCatalog_Write";

        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888

            //IEndorsementCatalogLogger logWriter = new EndorsementCatalogLogger();

            IAppSettings apiAppSettings = new ApiAppSettings();

            app.Map("/api", parLibApp =>
                    parLibApp.UseParticipantLibraryCore(apiAppSettings));
            //app.Map("/api", parLibApp =>
            //        parLibApp.UseEndorsementCatalogLibraryCore(BootStrapQuestionLibrary(logWriter), logWriter));
        }

        //private IAmAnEndorsementCatalogLibrary BootStrapQuestionLibrary(IEndorsementCatalogLogger logWriter)
        //{
        //IResolveClaimsPrincipal claimsPrincipalResolver = new ClaimsPrincipalResolver();

        //IAmAnEndorsementCatalogLibrary catalogLibrary = EndorsementCatalogConfigure
        //    .Init()
        //    .With(logWriter)
        //    .With(claimsPrincipalResolver)
        //    .DapperPersistence()
        //    .WithConnectionsNamed(CONNECTION_STRING_NAME_READ, CONNECTION_STRING_NAME_WRITE)
        //    .Build();

        //return catalogLibrary;
        //}
    }


    internal class ApiAppSettings : IAppSettings
    {
        public string CorsOrigins { get; set; }
    }

    //internal class ClaimsPrincipalResolver : IResolveClaimsPrincipal
    //{
    //    public ClaimsPrincipal ClaimsPrincipal { get { return ClaimsPrincipal.Current; } }
    //}

    //public class EndorsementCatalogLogger : IEndorsementCatalogLogger
    //{
    //    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

    //    public void Error(string message)
    //    {
    //        Logger.Error(message);
    //    }
    //}
}
