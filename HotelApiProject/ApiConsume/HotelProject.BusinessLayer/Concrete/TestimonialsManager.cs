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
    public class TestimonialsManager : ITestimonialsService
    {
        private readonly ITestimonialsDal _testimonialsDal;

        public TestimonialsManager(ITestimonialsDal testimonialsDal)
        {
            _testimonialsDal = testimonialsDal;
        }

        public void BDelete(Testimonial t)
        {
            _testimonialsDal.Delete(t);
        }

        public Testimonial BGetById(int id)
        {
           return _testimonialsDal.GetById(id);
        }

        public List<Testimonial> BGetList()
        {
            return _testimonialsDal.GetList();
        }

        public void BInsert(Testimonial t)
        {
            _testimonialsDal.Insert(t);
        }

        public void BUpdate(Testimonial t)
        {
            _testimonialsDal.Update(t);
        }
    }
}
