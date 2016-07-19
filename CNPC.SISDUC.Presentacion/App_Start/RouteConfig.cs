using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CNPC.SISDUC.Presentacion
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Login",
            //    url: "",
            //    defaults: new { controller = "Cuentas", action = "IniciarSesion", id = UrlParameter.Optional }
            //);

            routes.MapRoute(
                name: "Tuberia",
                url: "Tuberia",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Oleoducto",
                url: "Oleoducto",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
           
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
