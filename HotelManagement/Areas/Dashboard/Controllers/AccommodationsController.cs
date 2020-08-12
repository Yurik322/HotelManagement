//-----------------------------------------------------------------------
// <copyright file="AccommodationsController.cs" company="My">
//    Created by yurik_322 on 20/08/12.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelManagement.Areas.Dashboard.ViewModels;
using HotelManagement.Entities;
using HotelManagement.Services;
using HotelManagement.ViewModels;

namespace HotelManagement.Areas.Dashboard.Controllers
{
    /// <summary>
    /// Class for AccommodationsController
    /// </summary>
    public class AccommodationsController : Controller
    {
        private readonly AccommodationsService _accommodationsService = new AccommodationsService();
        private readonly AccommodationPackagesService _accommodationPackagesService = new AccommodationPackagesService();

        public ActionResult Index(string searchTerm, int? accommodationPackageID, int? page)
        {
            int recordSize = 5;
            page = page ?? 1;

            AccommodationsListingModel model = new AccommodationsListingModel();

            model.SearchTerm = searchTerm;
            model.AccommodationPackageID = accommodationPackageID;
            model.AccommodationPackages = _accommodationPackagesService.GetAllAccommodationPackages();


            model.Accommodations = _accommodationsService.SearchAccommodations(searchTerm, accommodationPackageID, page.Value, recordSize);
            var totalRecords = _accommodationsService.SearchAccommodationsCount(searchTerm, accommodationPackageID);

            model.Pager = new Pager(totalRecords, page, recordSize);

            return View(model);
        }

        [HttpGet]
        public ActionResult Action(int? ID)
        {
            AccommodationActionModel model = new AccommodationActionModel();

            // trying to edit a record
            if (ID.HasValue)
            {
                var accommodation = _accommodationsService.GetAccommodationById(ID.Value);

                model.ID = accommodation.ID;
                model.AccommodationPackageID = accommodation.AccommodationPackageID;
                model.Name = accommodation.Name;
                model.Description = accommodation.Description;
            }

            model.AccommodationPackages = _accommodationPackagesService.GetAllAccommodationPackages();

            return PartialView("_Action", model);
        }

        [HttpPost]
        public JsonResult Action(AccommodationActionModel model)
        {
            JsonResult json = new JsonResult();

            var result = false;

            // trying to edit a record
            if (model.ID > 0)
            {
                var accommodation = _accommodationsService.GetAccommodationById(model.ID);

                accommodation.AccommodationPackageID = model.AccommodationPackageID;
                accommodation.Name = model.Name;
                accommodation.Description = model.Description;

                result = _accommodationsService.UpdateAccommodation(accommodation);
            }
            // trying to create a record
            else
            {
                Accommodation accommodation = new Accommodation();

                accommodation.AccommodationPackageID = model.AccommodationPackageID;
                accommodation.Name = model.Name;
                accommodation.Description = model.Description;

                result = _accommodationsService.SaveAccommodation(accommodation);
            }

            if (result)
            {
                json.Data = new { Success = true };
            }
            else
            {
                json.Data = new { Success = false, Message = "Unable to perform action on Accommodation." };
            }

            return json;
        }

        [HttpGet]
        public ActionResult Delete(int ID)
        {
            AccommodationActionModel model = new AccommodationActionModel();

            var accommodation = _accommodationsService.GetAccommodationById(ID);

            model.ID = accommodation.ID;

            return PartialView("_Delete", model);
        }

        [HttpPost]
        public JsonResult Delete(AccommodationActionModel model)
        {
            JsonResult json = new JsonResult();

            var result = false;

            var accommodation = _accommodationsService.GetAccommodationById(model.ID);

            result = _accommodationsService.DeleteAccommodation(accommodation);

            if (result)
            {
                json.Data = new { Success = true };
            }
            else
            {
                json.Data = new { Success = false, Message = "Unable to perform action on Accommodation." };
            }

            return json;
        }
    }
}