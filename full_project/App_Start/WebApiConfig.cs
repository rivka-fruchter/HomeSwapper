using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace full_project
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //זה גורם שלא יהיה שגיאה של קורס
            config.EnableCors();
            
            // Web API configuration and services
            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
