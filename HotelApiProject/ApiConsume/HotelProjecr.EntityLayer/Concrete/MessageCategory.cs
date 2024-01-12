using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProjecr.EntityLayer.Concrete
{
    public class MessageCategory
    {
        public int MessageCategoryID { get; set; }
        public string Name { get; set; }
        //Contact sınıfında ilişki halindeolduğu için
        public virtual List<Contact> Contacts { get; set; }

    }
}
