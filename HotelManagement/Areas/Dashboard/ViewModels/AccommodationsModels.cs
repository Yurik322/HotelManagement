//-----------------------------------------------------------------------
// <copyright file="AccommodationModels.cs" company="My">
//    Created by yurik_322 on 20/08/12.
// </copyright>
//-----------------------------------------------------------------------
using HotelManagement.Entities;
using HotelManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManagement.Areas.Dashboard.ViewModels
{
    public class AccommodationsListingModel
    {
        public IEnumerable<Accommodation> Accommodations { get; set; }
        public string SearchTerm { get; set; }
        public IEnumerable<AccommodationPackage> AccommodationPackages { get; set; }
        public int? AccommodationPackageID { get; set; }

        public Pager Pager { get; set; }
    }
    public class AccommodationActionModel
    {
        public int ID { get; set; }

        public int AccommodationPackageID { get; set; }
        public AccommodationPackage AccommodationPackage { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public IEnumerable<AccommodationPackage> AccommodationPackages { get; set; }
    }
}