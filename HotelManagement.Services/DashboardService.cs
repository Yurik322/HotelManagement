using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.Data;
using HotelManagement.Entities;

namespace HotelManagement.Services
{
    public class DashboardService
    {
        public bool SavePicture(Picture picture)
        {
            var context = new HotelManagementContext();

            context.Pictures.Add(picture);

            return context.SaveChanges() > 0;
        }

        public IEnumerable<Picture> GetPicturesByIDs(List<int> pictureIDs)
        {
            var context = new HotelManagementContext();

            return pictureIDs.Select(x => context.Pictures.Find(x)).ToList();
        }
    }
}
