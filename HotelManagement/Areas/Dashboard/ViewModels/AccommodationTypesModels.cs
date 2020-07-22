using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelManagement.Entities;

namespace HotelManagement.Areas.Dashboard.ViewModels
{
    public class AccommodationTypesListingModel
    {
        public IEnumerable<AccommodationType> AccommodationTypes { get; set; } 
    }
}