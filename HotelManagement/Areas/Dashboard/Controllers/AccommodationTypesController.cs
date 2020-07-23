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

        [HttpGet]
        public ActionResult Action()
        {
            AccommodationTypesActionModel model = new AccommodationTypesActionModel();

            return PartialView("_Action", model);
        }

        [HttpPost]
        public JsonResult Action(AccommodationTypesActionModel model)
        {
            JsonResult json = new JsonResult();

            AccommodationType accommodationType = new AccommodationType();

            accommodationType.Name = model.Name;
            accommodationType.Description = model.Description;

            var result = accommodationTypesService.SaveAccommodationType(accommodationType);

            if (result)
            {
                json.Data = new {Success = true};
            }
            else
            {
                json.Data = new { Success = false, Message = "Unable to add Accommodation Type." };
            }

            return json;
        }
    }
}