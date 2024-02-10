using HotelProjecr.EntityLayer.Concrete;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    public class EFGuestDal : GenericRepository<Guest>, IGuestDal
    {
        public EFGuestDal(Context context) : base(context)
        {

        }

        public int GetCountGuest()
        {
            var context = new Context();
            var value = context.Guests.Where(x => x.Status == false).Count();
            return value;
        }
    }
}
