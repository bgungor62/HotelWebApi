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
    public class EFBookingDal : GenericRepository<Booking>, IBookingDal
    {
        public EFBookingDal(Context context) : base(context) { }

        public void BookingStatusChangeApproved(int id)
        {
            var context = new Context();
            var values = context.Bookings.Find(id);
            values.Status = "Onaylandı";
            context.SaveChanges();

        }

        public void BookingStatusChangeCancel(int id)
        {
            var context = new Context();
            var values = context.Bookings.Find(id);
            values.Status = "İptal Edildi";
            context.SaveChanges();
        }

        public void BookingStatusChangeWait(int id)
        {
            var context = new Context();
            var values = context.Bookings.Find(id);
            values.Status = "Müşteri Aranacak";
            context.SaveChanges();
        }

        public int GetCountBooking()
        {
            var context = new Context();
            var result = context.Bookings.Where(x => x.Status.Contains("Onaylandı")).Count();
            return result;
        }

        public List<Booking> GetSpecialRequestBookingList()
        {
            var context = new Context();
            var query = context.Bookings.Where(x => x.Status.Contains("Onaylandı")).OrderByDescending(x => x.BookingID).Take(5).ToList();
            return query;
        }

        public List<Booking> Last5Bookings()
        {
            var context = new Context();
            var query = context.Bookings.OrderByDescending(x => x.BookingID).Take(5).ToList();
            return query;
        }
    }
}
