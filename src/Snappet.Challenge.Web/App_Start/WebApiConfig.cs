﻿using System.Net.Http.Headers;
using System.Web.Http;

namespace Snappet.Challenge.Web.App_Start
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
           name: "DefaultWithAction",
           routeTemplate: "api/{controller}/{action}/{id}",
           defaults: new { id = RouteParameter.Optional });

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
        }
    }
}