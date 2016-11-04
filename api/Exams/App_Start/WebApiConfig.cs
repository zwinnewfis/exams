using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Exams
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            EnableCORS(config);
            Format(config);
        }

        private static void Format(HttpConfiguration config)
        {
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
        }

        private static void EnableCORS(HttpConfiguration config)
        {
            const string allChar = "*";
            var cors = new EnableCorsAttribute("http://localhost:3000", allChar, allChar);
            cors.SupportsCredentials = true;
            config.EnableCors(cors);
        }
    }
}
