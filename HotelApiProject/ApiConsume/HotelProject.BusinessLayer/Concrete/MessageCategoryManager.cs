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
    public class MessageCategoryManager : IMessageCategoryService
    {
        private readonly IMessageCategoryDal _messageCategoryDal;

        public MessageCategoryManager(IMessageCategoryDal messageCategoryDal)
        {
            _messageCategoryDal = messageCategoryDal;
        }

        public void BDelete(MessageCategory t)
        {
            _messageCategoryDal.Delete(t);
        }

        public MessageCategory BGetById(int id)
        {
            return _messageCategoryDal.GetById(id);
        }

        public List<MessageCategory> BGetList()
        {
            return _messageCategoryDal.GetList();
        }

        public void BInsert(MessageCategory t)
        {
            _messageCategoryDal.Insert(t);
        }

        public void BUpdate(MessageCategory t)
        {
            _messageCategoryDal.Update(t);
        }
    }
}
