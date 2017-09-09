using System.Linq;
using System.Net.Http.Extensions.Compression.Core.Compressors;
using System.Net.Http.Formatting;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Cors;
using ClcWorld.WebApi.Attributes;
using log4net;
using Microsoft.AspNet.WebApi.Extensions.Compression.Server;
using Newtonsoft.Json.Serialization;

namespace ClcWorld.WebApi
{
    public static class WebApiConfig
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web
            Log.Info("Configure Web API.");

            // Web API configuration and services
            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));

            // Configuration de handleErrorWepApi
            config.Filters.Add(new HandleErrorAttribute());

            // Configure Fluent Validator
            //config.Filters.Add(new ValidateModelStateWebApiAttribute());
            //ValidatorOptions.CascadeMode = CascadeMode.StopOnFirstFailure;

            // Add jsonformatter camelCase.
            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();           

            // Wraps all API responses
           // config.MessageHandlers.Add(new ResponseWrappingHandler());

            // Add compression
            config.MessageHandlers.Insert(0, new ServerCompressionHandler(new GZipCompressor(), new DeflateCompressor()));

            // Add FluentValidation.
         //   FluentValidationModelValidatorProvider.Configure(config);
            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
