using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.Data;
using HotelManagement.Entities;

namespace HotelManagement.Services
{
    public class AccommodationsService
    {
        public IEnumerable<Accommodation> GetAllAccommodations()
        {
            var context = new HotelManagementContext();

            return context.Accommodations.ToList();
        }

        public IEnumerable<Accommodation> SearchAccommodations(string searchTerm, int? accommodationPackageID, int page, int recordSize)
        {
            var context = new HotelManagementContext();

            var accommodations = context.Accommodations.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                accommodations = accommodations.Where(a => a.Name.ToLower().Contains(searchTerm.ToLower()));
            }

            if (accommodationPackageID.HasValue && accommodationPackageID.Value > 0)
            {
                accommodations = accommodations.Where(a => a.AccommodationPackageID == accommodationPackageID.Value);
            }

            // my pagination:
            var skip = (page - 1) * recordSize;
            // skip = (1-1) = 0*3=0
            // skip = (2-1) = 1*3=3
            // skip = (3-1) = 2*3=6

            return accommodations.OrderBy(x => x.AccommodationPackageID).Skip(skip).Take(recordSize).ToList();
        }

        public int SearchAccommodationsCount(string searchTerm, int? accommodationPackageID)
        {
            var context = new HotelManagementContext();

            var accommodations = context.Accommodations.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                accommodations = accommodations.Where(a => a.Name.ToLower().Contains(searchTerm.ToLower()));
            }

            if (accommodationPackageID.HasValue && accommodationPackageID.Value > 0)
            {
                accommodations = accommodations.Where(a => a.AccommodationPackageID == accommodationPackageID.Value);
            }

            return accommodations.Count();
        }

        public Accommodation GetAccommodationById(int ID)
        {
            using (var context = new HotelManagementContext())
            {
                return context.Accommodations.Find(ID);
            }
        }

        public bool SaveAccommodation(Accommodation accommodation)
        {
            var context = new HotelManagementContext();

            context.Accommodations.Add(accommodation);

            return context.SaveChanges() > 0;
        }

        public bool UpdateAccommodation(Accommodation accommodation)
        {
            var context = new HotelManagementContext();

            context.Entry(accommodation).State = System.Data.Entity.EntityState.Modified;

            return context.SaveChanges() > 0;
        }

        public bool DeleteAccommodation(Accommodation accommodation)
        {
            var context = new HotelManagementContext();

            context.Entry(accommodation).State = System.Data.Entity.EntityState.Deleted;

            return context.SaveChanges() > 0;
        }
    }
}
