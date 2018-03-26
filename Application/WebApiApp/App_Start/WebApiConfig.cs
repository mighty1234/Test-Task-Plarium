using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebApiApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Конфигурация и службы веб-API

            // Маршруты веб-API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{offset}/{limit}",
               defaults: new { id = RouteParameter.Optional}
            );

            config.Routes.MapHttpRoute(
              name: "CustomDefaultApi",
              routeTemplate: "api/{controller}/{start}/{end}/{offset}/{limit}",
              defaults: new {start= DateTime.MinValue, end= DateTime.MaxValue, offset=0,limit=10 }

          );

            config.Routes.MapHttpRoute(
            name: "DateDefaultApi",
            routeTemplate: "api/{controller}/{n}/{start}/{end}",
            defaults: new { start = DateTime.MinValue, end = DateTime.MaxValue, n = 10 }
            );

            config.Routes.MapHttpRoute(
          name: "NroutsDefaultApi",
          routeTemplate: "api/{controller}/{n}/{start}/{end}",
          defaults: new { start = DateTime.MinValue, end = DateTime.MaxValue, n = 10 }
          );
        }
    }
}
