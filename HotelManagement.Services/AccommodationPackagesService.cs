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
        public IEnumerable<AccommodationPackage> GetAllAccommodationPackages()
        {
            var context = new HotelManagementContext();

            return context.AccommodationPackages.ToList();
        }

        public IEnumerable<AccommodationPackage> GetAllAccommodationPackagesByAccommodationType(int accommodationTypeID)
        {
            var context = new HotelManagementContext();

            return context.AccommodationPackages.Where(x => x.AccommodationTypeID == accommodationTypeID).ToList();
        }

        public IEnumerable<AccommodationPackage> SearchAccommodationPackages(string searchTerm, int? accommodationTypeID, int page, int recordSize)
        {
            var context = new HotelManagementContext();

            var accommodationPackages = context.AccommodationPackages.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                accommodationPackages = accommodationPackages.Where(a => a.Name.ToLower().Contains(searchTerm.ToLower()));
            }

            if (accommodationTypeID.HasValue && accommodationTypeID.Value > 0)
            {
                accommodationPackages = accommodationPackages.Where(a => a.AccommodationTypeID == accommodationTypeID.Value);
            }

            // my pagination:
            var skip = (page - 1) * recordSize;
            // skip = (1-1) = 0*3=0
            // skip = (2-1) = 1*3=3
            // skip = (3-1) = 2*3=6

            return accommodationPackages.OrderBy(x => x.AccommodationTypeID).Skip(skip).Take(recordSize).ToList();
        }

        public int SearchAccommodationPackagesCount(string searchTerm, int? accommodationTypeID)
        {
            var context = new HotelManagementContext();

            var accommodationPackages = context.AccommodationPackages.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                accommodationPackages = accommodationPackages.Where(a => a.Name.ToLower().Contains(searchTerm.ToLower()));
            }

            if (accommodationTypeID.HasValue && accommodationTypeID.Value > 0)
            {
                accommodationPackages = accommodationPackages.Where(a => a.AccommodationTypeID == accommodationTypeID.Value);
            }

            return accommodationPackages.Count();
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

            var existingAccommodationPackage = context.AccommodationPackages.Find(accommodationPackage.ID);

            context.AccommodationPackagePictures.RemoveRange(existingAccommodationPackage.AccommodationPackagePictures);

            context.Entry(existingAccommodationPackage).CurrentValues.SetValues(accommodationPackage);

            context.AccommodationPackagePictures.AddRange(accommodationPackage.AccommodationPackagePictures);

            return context.SaveChanges() > 0;
        }

        public bool DeleteAccommodationPackage(AccommodationPackage accommodationPackage)
        {
            var context = new HotelManagementContext();

            var existingAccommodationPackage = context.AccommodationPackages.Find(accommodationPackage.ID);

            context.AccommodationPackagePictures.RemoveRange(existingAccommodationPackage.AccommodationPackagePictures);

            context.Entry(existingAccommodationPackage).State = System.Data.Entity.EntityState.Deleted;

            return context.SaveChanges() > 0;
        }

        public List<AccommodationPackagePicture> GetPicturesByAccommodationPackageID(int accommodationPackageID)
        {
            var context = new HotelManagementContext();

            return context.AccommodationPackages.Find(accommodationPackageID).AccommodationPackagePictures.ToList();
        }
    }
}