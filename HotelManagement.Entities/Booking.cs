//-----------------------------------------------------------------------
// <copyright file="Booking.cs" company="My">
//    Created by yurik_322 on 20/08/12.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Entities
{
    public class Booking
    {
        public int ID { get; set; }
        public string AccommodationID { get; set; }
        public Accommodation Accommodation { get; set; }
        public DateTime FromDate { get; set; }
        /// <summary>
        /// Number of stay nights.
        /// </summary>
        public int Duration { get; set; }
    }
}