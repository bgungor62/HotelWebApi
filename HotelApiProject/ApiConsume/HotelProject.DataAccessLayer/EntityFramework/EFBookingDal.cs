using HotelProjecr.EntityLayer.Concrete;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repository;
using HotelProject.DtoLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    public class EFBookingDal:GenericRepository<Booking>,IBookingDal
    {
        public EFBookingDal(Context context) : base(context) { }
  
        public void BookingStatusChangeApproved(BookingDto bookingDto)
        {
            var context = new Context();
            var query = context.Bookings.Where(x => x.BookingID == bookingDto.BookingID).FirstOrDefault();
            query.Status = "Onaylandı";
            context.SaveChanges();
        }
    }
}
