using System.Reflection;
using System.Web.Http;
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
           Log.Info("Starting ClcWorld Web API");

            AppConfig.Configure();

            AutoMappingConfig.Configuration();
            var config = new HttpConfiguration
            {
                // Configuración de Unity
                DependencyResolver = new UnityHierarchicalDependencyResolver(UnityHelpers.GetConfiguredContainer())
            };

            WebApiConfig.Register(config);
           // SwaggerConfig.Register(config);

            app.UseWebApi(config);
        }
    }
}
