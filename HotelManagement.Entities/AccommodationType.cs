//-----------------------------------------------------------------------
// <copyright file="AccommodationType.cs" company="My">
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
    public class AccommodationType
    {
        public int ID { get; set; }
        public string Name { get; set; }    // Hotel room
        public string Description { get; set; }
    }
}