using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Entities
{
    public class AccommodationPackage
    {
        public int ID { get; set; }

        public int AccommodationTypeID { get; set; }
        public virtual AccommodationType AccommodationType { get; set; }

        public string Name { get; set; }
        public int NoOfRoom { get; set; }
        public decimal FeePerNight { get; set; }

        public virtual List<AccommodationPackagePicture> AccommodationPackagePictures { get; set; }
    }
}