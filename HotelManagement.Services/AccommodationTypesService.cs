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
        public bool SaveAccommodationType(AccommodationType accommodationType)
        {
            var context = new HotelManagementContext();

            context.AccommodationTypes.Add(accommodationType);

            return context.SaveChanges() > 0;
        }
    }
}
