﻿using HotelProjecr.EntityLayer.Concrete;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    public class EFAppUserDal : GenericRepository<AppUser>, IAppUserDal
    {
        public EFAppUserDal(Context context) : base(context)
        {
        }

        public List<AppUser> AppUserListWithWorkLocation()
        {
            var context = new Context();
            return context.Users.Include(x => x.WorkLocation).ToList();
        }

        public List<AppUser> UsersListWithWorkLocation()
        {
            var context = new Context();
            var values = context.Users.Include(x => x.WorkLocation).ToList();
            return values;
        }
    }
}
