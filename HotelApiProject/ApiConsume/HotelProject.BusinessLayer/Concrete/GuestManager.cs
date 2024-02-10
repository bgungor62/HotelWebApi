using HotelProjecr.EntityLayer.Concrete;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DtoLayer.Dtos.Guest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrete
{
    public class GuestManager : IGuestService
    {
        private readonly IGuestDal _guestDal;

        public GuestManager(IGuestDal guestDal)
        {
            this._guestDal = guestDal;
        }

        public void BDelete(Guest t)
        {
            _guestDal.Delete(t);
        }

        public Guest BGetById(int id)
        {
            return _guestDal.GetById(id);
        }

        public List<Guest> BGetList()
        {
            return _guestDal.GetList();
        }

        public void BInsert(Guest t)
        {
            _guestDal.Insert(t);
        }

        public void BUpdate(Guest t)
        {
            _guestDal.Update(t);
        }

        public int TGetCountGuest()
        {
            return _guestDal.GetCountGuest();
        }
    }
}
