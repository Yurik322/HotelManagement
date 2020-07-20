using HotelManagement.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Data
{
    public class HotelManagementContext : DbContext
    {
        public HotelManagementContext() : base("HMSConnectionString")
        {
        }

        public DbSet<AccommodationType> AccommodationTypes { get; set; }
        public DbSet<AccommodationPackage> AccommodationPackages { get; set; }
        public DbSet<Accommondation> Accommondations { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}