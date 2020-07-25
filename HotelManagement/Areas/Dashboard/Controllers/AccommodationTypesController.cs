using HotelManagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelManagement.Areas.Dashboard.ViewModels;
using HotelManagement.Entities;

namespace HotelManagement.Areas.Dashboard.Controllers
{
    public class AccommodationTypesController : Controller
    {
        readonly AccommodationTypesService _accommodationTypesService = new AccommodationTypesService();
        // GET: Dashboard/AccommodationTypes
        public ActionResult Index(string searchTerm)
        {
            AccommodationTypesListingModel model = new AccommodationTypesListingModel();

            model.SearchTerm = searchTerm;

            model.AccommodationTypes = _accommodationTypesService.SearchAccommodationTypes(searchTerm);

            return View(model);
        }

        [HttpGet]
        public ActionResult Action(int? ID)
        {
            AccommodationTypeActionModel model = new AccommodationTypeActionModel();

            // trying to edit a record
            if (ID.HasValue)
            {
                var accommodationType = _accommodationTypesService.GetAccommodationTypeById(ID.Value);

                model.ID = accommodationType.ID;
                model.Name = accommodationType.Name;
                model.Description = accommodationType.Description;
            }

            return PartialView("_Action", model);
        }

        [HttpPost]
        public JsonResult Action(AccommodationTypeActionModel model)
        {
            JsonResult json = new JsonResult();

            var result = false;

            // trying to edit a record
            if (model.ID > 0)
            {
                var accommodationType = _accommodationTypesService.GetAccommodationTypeById(model.ID);

                accommodationType.Name = model.Name;
                accommodationType.Description = model.Description;

                result = _accommodationTypesService.UpdateAccommodationType(accommodationType);
            }
            // trying to create a record
            else
            {
                AccommodationType accommodationType = new AccommodationType();

                accommodationType.Name = model.Name;
                accommodationType.Description = model.Description;

                result = _accommodationTypesService.SaveAccommodationType(accommodationType);
            }

            if (result)
            {
                json.Data = new {Success = true};
            }
            else
            {
                json.Data = new { Success = false, Message = "Unable to perform action on Accommodation Type." };
            }

            return json;
        }

        [HttpGet]
        public ActionResult Delete(int ID)
        {
            AccommodationTypeActionModel model = new AccommodationTypeActionModel();

            var accommodationType = _accommodationTypesService.GetAccommodationTypeById(ID);

            model.ID = accommodationType.ID;

            return PartialView("_Delete", model);
        }

        [HttpPost]
        public JsonResult Delete(AccommodationTypeActionModel model)
        {
            JsonResult json = new JsonResult();

            var result = false;

            var accommodationType = _accommodationTypesService.GetAccommodationTypeById(model.ID);

            result = _accommodationTypesService.DeleteAccommodationType(accommodationType);

            if (result)
            {
                json.Data = new { Success = true };
            }
            else
            {
                json.Data = new { Success = false, Message = "Unable to perform action on Accommodation Type." };
            }

            return json;
        }
    }
}