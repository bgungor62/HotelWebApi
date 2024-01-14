using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProjecr.EntityLayer.Concrete
{
    public class WorkLocation
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public List<AppUser> AppUsers { get; set; }

    }
}
