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
    public class StaffManager : IStaffService
    {
        private readonly IStaffDal _staffDal;

        public StaffManager(IStaffDal staffDal)
        {
            _staffDal = staffDal;
        }

        public void BDelete(Staff t)
        {
            _staffDal.Delete(t);
        }

        public Staff BGetById(int id)
        {
            return _staffDal.GetById(id);
        }

        public List<Staff> BGetList()
        {
            return _staffDal.GetList();
        }

        public void BInsert(Staff t)
        {
            _staffDal.Insert(t);
        }

        public void BUpdate(Staff t)
        {
            _staffDal.Update(t);
        }

        public int TGetStaffCount()
        {
            return _staffDal.GetStaffCount();
        }
    }
}
