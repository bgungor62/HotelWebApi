using HotelProjecr.EntityLayer.Concrete;
using HotelProject.DtoLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Abstract
{
    public interface IBookingService : IGenericService<Booking>
    {
        int TGetCountBooking();

        void TBookingStatusChangeWait(int id);

        void TBookingStatusChangeCancel(int id);

        void TBookingStatusChangeApproved(int id);

        List<Booking> TGetSpecialRequestBookingList();

        List<Booking> TLast5Bookings();
    }
}
