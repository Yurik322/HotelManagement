using HotelManagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelManagement.Areas.Dashboard.ViewModels;

namespace HotelManagement.Areas.Dashboard.Controllers
{
    public class AccommodationTypesController : Controller
    {
        AccommodationTypesService accommodationTypesService = new AccommodationTypesService();
        // GET: Dashboard/AccommodationTypes
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Listing()
        {
            AccommodationTypesListingModel model = new AccommodationTypesListingModel();

            model.AccommodationTypes = accommodationTypesService.GetAllAccommodationTypes();

            return PartialView("_Listing", model);
        }
    }
}