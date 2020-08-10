using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelManagement.Services;
using HotelManagement.ViewModels;

namespace HotelManagement.Controllers
{
    public class AccommodationsController : Controller
    {
        readonly AccommodationTypesService _accommodationTypesService = new AccommodationTypesService();
        readonly AccommodationPackagesService _accommodationPackagesService = new AccommodationPackagesService();
        readonly AccommodationsService _accommodationsService = new AccommodationsService();

        public ActionResult Index(int accommodationTypeID, int? accommodationPackageID)
        {
            AccommodationsViewModel model = new AccommodationsViewModel();

            model.AccommodationTypes = _accommodationTypesService.GetAccommodationTypeById(accommodationTypeID);
            model.AccommodationPackages = _accommodationPackagesService.GetAllAccommodationPackagesByAccommodationType(accommodationTypeID);
            
            model.SelectedAccommodationPackageID = accommodationPackageID.HasValue ? accommodationPackageID.Value : model.AccommodationPackages.First().ID;
            
            model.Accommodations = _accommodationsService.GetAllAccommodationsByAccommodationPackage(model.SelectedAccommodationPackageID);

            return View(model);
        }

        public ActionResult Details(int accommodationPackageID)
        {
            AccommodationPackageDetailsViewModel model = new AccommodationPackageDetailsViewModel();

            model.AccommodationPackage = _accommodationPackagesService.GetAccommodationPackageById(accommodationPackageID);

            return View(model);
        }
        
        public ActionResult CheckAvailability(CheckAccommodationAvailabilityViewModel model)
        {
            return View();
        }
    }
}