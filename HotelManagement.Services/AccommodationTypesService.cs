using HotelManagement.Data;
using HotelManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Services
{
    public class AccommodationTypesService
    {
        public IEnumerable<AccommodationType> GetAllAccommodationTypes()
        {
            var context = new HotelManagementContext();

            return context.AccommodationTypes.ToList();
        }

        public IEnumerable<AccommodationType> SearchAccommodationTypes(string searchTerm)
        {
            var context = new HotelManagementContext();

            var accommodationTypes = context.AccommodationTypes.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                accommodationTypes = accommodationTypes.Where(a => a.Name.ToLower().Contains(searchTerm.ToLower()));
            }

            return accommodationTypes.ToList();
        }

        public AccommodationType GetAccommodationTypeById(int ID)
        {
            var context = new HotelManagementContext();

            return context.AccommodationTypes.Find(ID);
        }

        public bool SaveAccommodationType(AccommodationType accommodationType)
        {
            var context = new HotelManagementContext();

            context.AccommodationTypes.Add(accommodationType);

            return context.SaveChanges() > 0;
        }

        public bool UpdateAccommodationType(AccommodationType accommodationType)
        {
            var context = new HotelManagementContext();

            context.Entry(accommodationType).State = System.Data.Entity.EntityState.Modified;

            return context.SaveChanges() > 0;
        }

        public bool DeleteAccommodationType(AccommodationType accommodationType)
        {
            var context = new HotelManagementContext();

            context.Entry(accommodationType).State = System.Data.Entity.EntityState.Deleted;

            return context.SaveChanges() > 0;
        }
    }
}
