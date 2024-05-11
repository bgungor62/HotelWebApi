using HotelProjecr.EntityLayer.Concrete;
using HotelProject.DtoLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.Abstract
{
    public interface IBookingDal : IGenericDal<Booking>
    {

        void BookingStatusChangeWait(int id);

        void BookingStatusChangeCancel(int id);

        void BookingStatusChangeApproved(int id);

        int GetCountBooking();

        List<Booking> GetSpecialRequestBookingList();
        List<Booking> Last5Bookings();
    }
}
