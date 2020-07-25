using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.Data;
using HotelManagement.Entities;

namespace HotelManagement.Services
{
    public class AccommodationPackagesService
    {
        public IEnumerable<AccommodationPackage> GetAllAccommodationTypes()
        {
            var context = new HotelManagementContext();

            return context.AccommodationPackages.ToList();
        }

        public IEnumerable<AccommodationPackage> SearchAccommodationPackages(string searchTerm)
        {
            var context = new HotelManagementContext();

            var accommodationPackages = context.AccommodationPackages.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                accommodationPackages = accommodationPackages.Where(a => a.Name.ToLower().Contains(searchTerm.ToLower()));
            }

            return accommodationPackages.ToList();
        }

        public AccommodationPackage GetAccommodationPackageById(int ID)
        {
            var context = new HotelManagementContext();

            return context.AccommodationPackages.Find(ID);
        }

        public bool SaveAccommodationPackage(AccommodationPackage accommodationPackage)
        {
            var context = new HotelManagementContext();

            context.AccommodationPackages.Add(accommodationPackage);

            return context.SaveChanges() > 0;
        }

        public bool UpdateAccommodationPackage(AccommodationPackage accommodationPackage)
        {
            var context = new HotelManagementContext();

            context.Entry(accommodationPackage).State = System.Data.Entity.EntityState.Modified;

            return context.SaveChanges() > 0;
        }

        public bool DeleteAccommodationPackage(AccommodationPackage accommodationPackage)
        {
            var context = new HotelManagementContext();

            context.Entry(accommodationPackage).State = System.Data.Entity.EntityState.Deleted;

            return context.SaveChanges() > 0;
        }
    }
}
