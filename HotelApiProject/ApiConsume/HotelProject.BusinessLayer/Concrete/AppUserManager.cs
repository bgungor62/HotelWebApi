using HotelProjecr.EntityLayer.Concrete;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrete
{
    public class AppUserManager : IAppUserService
    {
        private readonly IAppUserDal _appUserDal;

        public AppUserManager(IAppUserDal appUserDal)
        {
            _appUserDal = appUserDal;
        }

        public void BDelete(AppUser t)
        {
            throw new NotImplementedException();
        }

        public AppUser BGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<AppUser> BGetList()
        {
            return _appUserDal.GetList();
        }

        public void BInsert(AppUser t)
        {
            throw new NotImplementedException();
        }

        public void BUpdate(AppUser t)
        {
            throw new NotImplementedException();
        }

        public List<AppUser> TAppUserListWithWorkLocation()
        {
            return _appUserDal.AppUserListWithWorkLocation();
        }
    }
}
