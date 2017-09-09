using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.Routing;
using ClcWorld.WebApi.Helpers;
using log4net;
using Microsoft.Owin;
using Microsoft.Practices.Unity.WebApi;
using Owin;

[assembly: OwinStartup(typeof(ClcWorld.WebApi.Startup))]

namespace ClcWorld.WebApi
{
    public class Startup
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public void Configuration(IAppBuilder app)
        {
            // Get app version.
         //   ApplicationVersion.Configure(HostingEnvironment.MapPath("~/"), "holafibra_webapi_version");

           // Log.Info($"Starting Holafibra Web API v{ApplicationVersion.Version.FullDescription} in {(Config.Config.GetWebPageConfig(HostingEnvironment.MapPath("~/bin")).EsProduccion ? "Production" : "Develop")} environment.");

            //AppConfig.Configure();

          //  WebApiConfig.Register(RouteTable.Routes);

           // AutoMappingConfig.Configuration();
            var config = new HttpConfiguration
            {
                // Configuración de Unity
                DependencyResolver = new UnityHierarchicalDependencyResolver(UnityHelpers.GetConfiguredContainer())
            };

            WebApiConfig.Register(config);
           // SwaggerConfig.Register(config);

           // ConfigureAuth(app);
            app.UseWebApi(config);
        }
    }
}
