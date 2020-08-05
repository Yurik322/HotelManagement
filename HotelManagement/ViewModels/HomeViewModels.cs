using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelManagement.Entities;

namespace HotelManagement.ViewModels
{
    public class HomeViewModels
    {
        public IEnumerable<AccommodationType> AccommodationTypes { get; set; }
    }
}