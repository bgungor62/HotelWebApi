using HotelProjecr.EntityLayer.Concrete;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DtoLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrete
{
    public class BookingManager : IBookingService
    {
        private readonly IBookingDal _bookindal;

        public BookingManager(IBookingDal bookindal)
        {
            _bookindal = bookindal;
        }

        public void BDelete(Booking t)
        {
            _bookindal.Delete(t);
        }

        public Booking BGetById(int id)
        {
            return _bookindal.GetById(id);
        }

        public List<Booking> BGetList()
        {
            return _bookindal.GetList();
        }

        public void BInsert(Booking t)
        {
            _bookindal.Insert(t);
        }

        public void BUpdate(Booking t)
        {
            _bookindal.Update(t);
        }

        public void TBookingStatusChangeApproved(int id)
        {
            _bookindal.BookingStatusChangeApproved(id);
        }

        public void TBookingStatusChangeCancel(int id)
        {
            _bookindal.BookingStatusChangeCancel(id);
        }

        public void TBookingStatusChangeWait(int id)
        {
            _bookindal.BookingStatusChangeWait(id);
        }

        public int TGetCountBooking()
        {
            return _bookindal.GetCountBooking();
        }

        public List<Booking> TGetSpecialRequestBookingList()
        {
            return _bookindal.GetSpecialRequestBookingList();
        }

        public List<Booking> TLast5Bookings()
        {
            return _bookindal.Last5Bookings();
        }
    }
}
