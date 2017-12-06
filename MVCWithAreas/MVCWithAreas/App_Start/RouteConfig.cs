using MVCWithAreas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVCWithAreas
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "calculs",
                url: "Calcul{action}/{v1}/{v2}",
                defaults: new { controller = "Calcul" },
                constraints: new { v1 = @"-?\d+(\.\d+)?", v2 = @"-?\d+(\.\d+)?" }//regex
            );

            routes.MapRoute(
                name: "calculs2",
                url: "Compute{action}/{v1}/{v2}",
                defaults: new { controller = "Calcul"},
                constraints: new {is42 = new MustBe42Constraint()}
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}