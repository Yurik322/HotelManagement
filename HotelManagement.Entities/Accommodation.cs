using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Entities
{
    public class Accommondation
    {
        public int ID { get; set; }
        public int AccommodationPackageID { get; set; }
        public AccommodationPackage AccommodationPackage { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
    }
}