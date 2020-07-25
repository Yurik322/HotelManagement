using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelManagement.Areas.Dashboard.ViewModels;
using HotelManagement.Entities;
using HotelManagement.Services;

namespace HotelManagement.Areas.Dashboard.Controllers
{
    public class AccommodationPackagesController : Controller
    {
        readonly AccommodationPackagesService _accommodationPackagesService = new AccommodationPackagesService();
        // GET: Dashboard/AccommodationTypes
        public ActionResult Index(string searchTerm)
        {
            AccommodationPackagesListingModel model = new AccommodationPackagesListingModel();

            model.SearchTerm = searchTerm;

            model.AccommodationPackages = _accommodationPackagesService.SearchAccommodationPackages(searchTerm);

            return View(model);
        }

        [HttpGet]
        public ActionResult Action(int? ID)
        {
            AccommodationPackageActionModel model = new AccommodationPackageActionModel();

            // trying to edit a record
            if (ID.HasValue)
            {
                var accommodationPackage = _accommodationPackagesService.GetAccommodationPackageById(ID.Value);

                model.ID = accommodationPackage.ID;
                model.Name = accommodationPackage.Name;
                model.NoOfRoom = accommodationPackage.NoOfRoom;
                model.FeePerNight = accommodationPackage.FeePerNight;
            }

            return PartialView("_Action", model);
        }

        [HttpPost]
        public JsonResult Action(AccommodationPackageActionModel model)
        {
            JsonResult json = new JsonResult();

            var result = false;

            // trying to edit a record
            if (model.ID > 0)
            {
                var accommodationPackage = _accommodationPackagesService.GetAccommodationPackageById(model.ID);

                accommodationPackage.Name = model.Name;
                accommodationPackage.NoOfRoom = accommodationPackage.NoOfRoom;
                accommodationPackage.FeePerNight = accommodationPackage.FeePerNight;

                result = _accommodationPackagesService.UpdateAccommodationPackage(accommodationPackage);
            }
            // trying to create a record
            else
            {
                AccommodationPackage accommodationPackage = new AccommodationPackage();

                accommodationPackage.Name = model.Name;
                accommodationPackage.NoOfRoom = accommodationPackage.NoOfRoom;
                accommodationPackage.FeePerNight = accommodationPackage.FeePerNight;

                result = _accommodationPackagesService.SaveAccommodationPackage(accommodationPackage);
            }

            if (result)
            {
                json.Data = new { Success = true };
            }
            else
            {
                json.Data = new { Success = false, Message = "Unable to perform action on Accommodation Package." };
            }

            return json;
        }

        [HttpGet]
        public ActionResult Delete(int ID)
        {
            AccommodationPackageActionModel model = new AccommodationPackageActionModel();

            var accommodationPackage = _accommodationPackagesService.GetAccommodationPackageById(ID);

            model.ID = accommodationPackage.ID;

            return PartialView("_Delete", model);
        }

        [HttpPost]
        public JsonResult Delete(AccommodationPackageActionModel model)
        {
            JsonResult json = new JsonResult();

            var result = false;

            var accommodationPackage = _accommodationPackagesService.GetAccommodationPackageById(model.ID);

            result = _accommodationPackagesService.DeleteAccommodationPackage(accommodationPackage);

            if (result)
            {
                json.Data = new { Success = true };
            }
            else
            {
                json.Data = new { Success = false, Message = "Unable to perform action on Accommodation Package." };
            }

            return json;
        }


    }
}