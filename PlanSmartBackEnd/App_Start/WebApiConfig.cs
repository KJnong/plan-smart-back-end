using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PlanSmartBackEnd
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
            config.EnableCors();
            config.Formatters.Clear();//clear the default data type
            config.Formatters.Add(new JsonMediaTypeFormatter());
        }
    }
}
