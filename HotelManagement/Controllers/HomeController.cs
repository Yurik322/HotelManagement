//-----------------------------------------------------------------------
// <copyright file="HomeController.cs" company="My">
//    Created by yurik_322 on 20/08/12.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelManagement.Services;
using HotelManagement.ViewModels;

namespace HotelManagement.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            HomeViewModels model = new HomeViewModels();

            AccommodationTypesService service = new AccommodationTypesService();
            AccommodationPackagesService accommodationPackagesService = new AccommodationPackagesService();

            model.AccommodationTypes = service.GetAllAccommodationTypes();
            model.AccommodationPackages = accommodationPackagesService.GetAllAccommodationPackages();

            return View(model);
        }
    }
}