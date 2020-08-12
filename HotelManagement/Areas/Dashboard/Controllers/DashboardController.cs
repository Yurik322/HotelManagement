//-----------------------------------------------------------------------
// <copyright file="DashboardController.cs" company="My">
//    Created by yurik_322 on 20/08/12.
// </copyright>
//-----------------------------------------------------------------------
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
    /// <summary>
    /// Class DashboardController for admin access
    /// </summary>
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