using System.Net.Http.Headers;
using System.Web.Http;
using ContactRest.Exceptions;
using ContactRest.Exceptions.Handler;

namespace ContactRest
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.EnableCors();

            config.Filters.Add(new WebApiExceptionHandling());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "contacts",
                routeTemplate: "api/{controller}/contacts",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

        }
    }
}
