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
        AccommodationTypesService accommodationTypesService = new AccommodationTypesService();
        AccommodationPackagesService accommodationPackagesService = new AccommodationPackagesService();
        AccommodationsService accommodationsService = new AccommodationsService();

        public ActionResult Index(int accommodationTypeID, int? accommodationPackageID)
        {
            AccommodationsViewModels model = new AccommodationsViewModels();

            model.AccommodationTypes = accommodationTypesService.GetAccommodationTypeById(accommodationTypeID);
            model.AccommodationPackages = accommodationPackagesService.GetAllAccommodationPackagesByAccommodationType(accommodationTypeID);
            
            model.SelectedAccommodationPackageID = accommodationPackageID.HasValue ? accommodationPackageID.Value : model.AccommodationPackages.First().ID;
            
            model.Accommodations = accommodationsService.GetAllAccommodationsByAccommodationPackage(model.SelectedAccommodationPackageID);

            return View(model);
        }
    }
}