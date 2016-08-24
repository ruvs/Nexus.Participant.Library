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
            return app;
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
