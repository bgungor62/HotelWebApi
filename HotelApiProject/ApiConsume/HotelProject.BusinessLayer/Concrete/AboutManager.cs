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
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal _ıaboutdal;

        public AboutManager(IAboutDal ıaboutdal)
        {
            _ıaboutdal = ıaboutdal;
        }

        public void BDelete(About t)
        {
            _ıaboutdal.Delete(t);
        }

        public About BGetById(int id)
        {
            return _ıaboutdal.GetById(id);
        }

        public List<About> BGetList()
        {
            return _ıaboutdal.GetList();
        }

        public void BInsert(About t)
        {
            _ıaboutdal.Insert(t);
        }

        public void BUpdate(About t)
        {
            _ıaboutdal.Update(t);
        }
    }
}
