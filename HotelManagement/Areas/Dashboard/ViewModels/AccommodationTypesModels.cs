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
    public class AccommodationTypesActionModel
    {
        public int ID { get; set; }
        public string Name { get; set; }    // Hotel room
        public string Description { get; set; }
    }
}