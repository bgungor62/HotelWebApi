﻿using HotelProjecr.EntityLayer.Concrete;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    public class EFMessageCategoryDal : GenericRepository<MessageCategory>, IMessageCategoryDal
    {
        public EFMessageCategoryDal(Context context):base(context)
        {               
        }
    }
}
