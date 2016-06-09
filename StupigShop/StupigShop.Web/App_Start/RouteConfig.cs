﻿using System.Web.Mvc;
using System.Web.Routing;

namespace StupigShop.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Login",
                url: "login.html",
                defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional },
                namespaces: new string[] { "StupigShop.Web.Models" }
            );

            routes.MapRoute(
                name: "About",
                url: "about.html",
                defaults: new { controller = "About", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "StupigShop.Web.Models" }
            );

            routes.MapRoute(
                name: "Product Category",
                url: "{alias}.pc-{id}.html",
                defaults: new { controller = "Product", action = "Category", id = UrlParameter.Optional },
                namespaces: new string[] { "StupigShop.Web.Models" }
            );

            routes.MapRoute(
                name: "Product",
                url: "{alias}.p-{id}.html",
                defaults: new { controller = "Product", action = "Detail", id = UrlParameter.Optional },
                namespaces: new string[] { "StupigShop.Web.Models" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "StupigShop.Web.Models" }
            );
        }
    }
}