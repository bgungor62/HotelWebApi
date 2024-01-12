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
    public class SendMessageManager : ISendMessageService
    {
        private readonly ISendMessageDal _isendmessagedal;
        public SendMessageManager(ISendMessageDal sendMessageDal)
        {
            _isendmessagedal = sendMessageDal;
        }

        public void BDelete(SendMessage t)
        {
            _isendmessagedal.Delete(t);
        }

        public SendMessage BGetById(int id)
        {
            return _isendmessagedal.GetById(id);

        }

        public List<SendMessage> BGetList()
        {

            return _isendmessagedal.GetList();

        }

        public void BInsert(SendMessage t)
        {
            _isendmessagedal.Insert(t);
        }

        public void BUpdate(SendMessage t)
        {
            _isendmessagedal?.Update(t);
        }

        public int TGetSendMessageCount()
        {
            return _isendmessagedal.GetSendMessageCount();
        }
    }
}
