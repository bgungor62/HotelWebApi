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
    public class EFStaffDal : GenericRepository<Staff>, IStaffDal
    {
        public EFStaffDal(Context context) : base(context) { }

        public int GetStaffCount()
        {
            using var context = new Context();
            var value = context.Staff.Count();
            return value;
        }
    }
}
