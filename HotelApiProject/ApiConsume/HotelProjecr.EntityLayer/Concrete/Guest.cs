using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProjecr.EntityLayer.Concrete
{
    public class Guest
    {
        public int GuestID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
        public string? Mail { get; set; }
    }
}
