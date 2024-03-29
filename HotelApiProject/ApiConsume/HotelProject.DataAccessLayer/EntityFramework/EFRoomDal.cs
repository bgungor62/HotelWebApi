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
    public class EFRoomDal : GenericRepository<Room>, IRoomDal
    {
        public EFRoomDal(Context context) : base(context)
        {

        }

        public int GetCountRoom()
        {
            var context = new Context();
            var value = context.Rooms.Count();
            return value;
        }
    }
}
