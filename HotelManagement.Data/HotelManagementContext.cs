//-----------------------------------------------------------------------
// <copyright file="HotelManagementContext.cs" company="My">
//    Created by yurik_322 on 20/08/12.
// </copyright>
//-----------------------------------------------------------------------
using HotelManagement.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HotelManagement.Data
{
    public class HotelManagementContext : IdentityDbContext<HotelManagementUser>
    {
        public HotelManagementContext() : base("HotelManagementConnectionString")
        {
        }

        public static HotelManagementContext Create()
        {
            return new HotelManagementContext();
        }

        public DbSet<AccommodationType> AccommodationTypes { get; set; }
        public DbSet<AccommodationPackage> AccommodationPackages { get; set; }
        public DbSet<AccommodationPackagePicture> AccommodationPackagePictures { get; set; }
        public DbSet<Accommodation> Accommodations { get; set; }
        public DbSet<AccommodationPicture> AccommodationPictures { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Picture> Pictures { get; set; }
    }
}
