﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CNPC.SISDUC.Presentacion
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes api/{controller}/{action}/{id}
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
