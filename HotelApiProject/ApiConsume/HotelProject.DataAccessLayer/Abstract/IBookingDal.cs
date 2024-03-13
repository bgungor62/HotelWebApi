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
        void BookingStatusChangeApproved(int ID);

        int GetCountBooking();

        List<Booking> GetSpecialRequestBookingList();
        List<Booking> Last5Bookings();
    }
}
