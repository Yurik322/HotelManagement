using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelManagement.Entities;
using HotelManagement.Services;

namespace HotelManagement.Areas.Dashboard.Controllers
{
    public class DashboardController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult UploadPictures()
        {
            JsonResult result = new JsonResult();

            var dashboardService = new DashboardService();
            var picturesList = new List<Picture>();

            // For saving pictures in folder
            var files = Request.Files;

            for (int i = 0; i < files.Count; i++)
            {
                var picture = files[i];

                var fileName = Guid.NewGuid() + Path.GetExtension(picture.FileName);
                var filePath = Server.MapPath("~/images/site/") + fileName;

                picture.SaveAs(filePath);

                var dbPicture = new Picture();
                dbPicture.Url = fileName;


                if (dashboardService.SavePicture(dbPicture))
                {
                    picturesList.Add(dbPicture);
                }
            }

            result.Data = picturesList;

            return result;
        }
    }
}