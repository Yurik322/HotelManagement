﻿//-----------------------------------------------------------------------
// <copyright file="RouteConfig.cs" company="My">
//    Created by yurik_322 on 20/08/12.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HotelManagement
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "FEAccommodation",
                url: "Accommodations",
                defaults: new { area = "", controller = "Accommodations", action = "Index" },
                namespaces: new[] { "HotelManagement.Controllers" }
            );

            routes.MapRoute(
                name: "AccommodationPackageDetails",
                url: "accommodation-package/{accommodationPackageID}",
                defaults: new { area = "", controller = "Accommodations", action = "Details" },
                namespaces: new[] { "HotelManagement.Controllers" }
            );

            routes.MapRoute(
                name: "CheckAvailability",
                url: "accommodation-check-availability",
                defaults: new { area = "", controller = "Accommodations", action = "CheckAvailability" },
                namespaces: new[] { "HotelManagement.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
