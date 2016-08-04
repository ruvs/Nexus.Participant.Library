using Microsoft.Owin.Extensions;
using Nexus.ParticipantLibrary.Middleware.Configuration;
using Owin;

namespace Nexus.ParticipantLibrary.Middleware.OwinConfiguration
{
    public static class AppBuilderExtensions
    {
        public static IAppBuilder UseParticipantLibraryCore(this IAppBuilder app)
        {
            app.UseStageMarker(PipelineStage.MapHandler);
            app.UseWebApi(WebApiConfig.Configure());
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
