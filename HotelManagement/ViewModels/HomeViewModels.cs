//-----------------------------------------------------------------------
// <copyright file="HomeViewModels.cs" company="My">
//    Created by yurik_322 on 20/08/12.
// </copyright>
//-----------------------------------------------------------------------
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
        public IEnumerable<AccommodationPackage> AccommodationPackages { get; set; }
    }
}