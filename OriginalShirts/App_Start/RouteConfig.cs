using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OriginalShirts
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "",
                url: "{controller}/{action}/{tag}/{page}",
                defaults: new { controller = "Product", action = "Index", tag = UrlParameter.Optional, page = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Product", action = "Details" }
            );

            routes.MapRoute(
                name: "",
                url: "{controller}/{action}/"
            );

            //routes.MapRoute(
            //    name: "2",
            //    url: "Product/{action}/",
            //    defaults: new { action = "Index" }
            //);

            //routes.MapRoute(
            //    name: "3",
            //    url: "{controller}/{action}/",
            //    defaults: new { controller = "Product", action = "Index" }
            //);
        }
    }
}
