﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProjecr.EntityLayer.Concrete
{
    public class Contact
    {

        public int ContactID { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
        //Başka bir tablo ile ilişki kurma
        public int MessageCategoryID { get; set; }
        //public virtual MessageCategory MessageCategory { get; set; }

    }
}
