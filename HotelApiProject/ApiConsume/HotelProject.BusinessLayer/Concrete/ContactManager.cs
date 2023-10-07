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

    public class ContactManager : IContactService

    {

        private readonly IContactDal _icontactDal;

        public ContactManager(IContactDal icontactDal)
        {
            _icontactDal = icontactDal;
        }

        public void BDelete(Contact t)
        {
            _icontactDal.Delete(t);
        }

        public Contact BGetById(int id)
        {
            return _icontactDal.GetById(id);
        }

        public List<Contact> BGetList()
        {
            return _icontactDal.GetList();
        }

        public void BInsert(Contact t)
        {
             _icontactDal.Insert(t);
        }

        public void BUpdate(Contact t)
        {
            _icontactDal.Update(t);
        }
    }
}
