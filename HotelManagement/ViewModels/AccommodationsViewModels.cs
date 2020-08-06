using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelManagement.Entities;

namespace HotelManagement.ViewModels
{
    public class AccommodationsViewModel
    {
        public int SelectedAccommodationPackageID { get; set; }
        public AccommodationType AccommodationTypes { get; set; }
        public IEnumerable<AccommodationPackage> AccommodationPackages { get; set; }
        public IEnumerable<Accommodation> Accommodations { get; set; }
    }
}