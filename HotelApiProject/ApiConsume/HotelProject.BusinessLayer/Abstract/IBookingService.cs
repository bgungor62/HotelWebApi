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
        void TBookingStatusChangeApproved(BookingDto bookingDto);

        int TGetCountBooking();
    }
}
