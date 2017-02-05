using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Extensions;
using Nexus.ParticipantLibrary.Core.Configuration;
using Nexus.ParticipantLibrary.Middleware.Configuration;
using Owin;

namespace Nexus.ParticipantLibrary.Middleware.OwinConfiguration
{
    public static class AppBuilderExtensions
    {
        public static IAppBuilder UseParticipantLibraryCore(this IAppBuilder app, IAppSettings appSettings, IAmAParticipantLibrary library)
        {
            app.UseStageMarker(PipelineStage.MapHandler);
            app.UseWebApi(WebApiConfig.Configure(appSettings, library));
            CorsHelper.Register(app);
            ConfigureSignalR(app, appSettings);
            return app;
        }

        private static void ConfigureSignalR(IAppBuilder app, IAppSettings appSettings)
        {
            app.Map("/signalr", map =>
            {
                map.UseCors(CorsOptions.AllowAll);
                var hubConfig = new HubConfiguration()
                {
                    EnableDetailedErrors = appSettings.IncludeErrorDetailPolicy != "Never",
                };
                map.RunSignalR(hubConfig);
            });
        }

        //public static class AppBuilderExtensions
        //{
        //    public static IAppBuilder UseEndorsementCatalogLibraryCore(this IAppBuilder app,
        //        IAmAnEndorsementCatalogLibrary library, IEndorsementCatalogLogger logger)
        //    {
        //        app.UseStageMarker(PipelineStage.MapHandler);
        //        app.UseWebApi(WebApiConfig.Configure(library, logger));
        //        return app;
        //    }
        //}
    }
}
