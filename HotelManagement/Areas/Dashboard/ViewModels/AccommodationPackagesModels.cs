using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelManagement.Entities;
using HotelManagement.ViewModels;

namespace HotelManagement.Areas.Dashboard.ViewModels
{
    public class AccommodationPackagesListingModel
    {
        public IEnumerable<AccommodationPackage> AccommodationPackages { get; set; }
        public string SearchTerm { get; set; }
        public IEnumerable<AccommodationType> AccommodationTypes { get; set; }
        public int? AccommodationTypeID { get; set; }

        public Pager Pager { get; set; }
    }
    public class AccommodationPackageActionModel
    {
        public int ID { get; set; }

        public int AccommodationTypeID { get; set; }
        public AccommodationType AccommodationType { get; set; }

        public string Name { get; set; }
        public int NoOfRoom { get; set; }
        public decimal FeePerNight { get; set; }

        public IEnumerable<AccommodationType> AccommodationTypes { get; set; }
    }
}