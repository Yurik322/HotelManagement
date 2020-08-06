using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Entities
{
    public class AccommodationPackagePicture
    {
        public int ID { get; set; }
        public int AccommodationPackageID { get; set; }
        public int PictureID { get; set; }
        public virtual Picture Picture { get; set; }
    }
}
