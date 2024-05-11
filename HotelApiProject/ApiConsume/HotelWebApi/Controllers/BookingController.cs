using HotelProjecr.EntityLayer.Concrete;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        [HttpGet]
        public IActionResult ListBooking()
        {
            var values = _bookingService.BGetList();
            return Ok(values);
        }

        [HttpGet("getSpecialRequestBookingList")]
        public IActionResult GetSpecialRequestBookingList()
        {
            var values = _bookingService.TGetSpecialRequestBookingList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var values = _bookingService.BGetById(id);
            return Ok(values);
        }

        [HttpGet("getLast5Bookings")]
        public IActionResult GetLast5Bookings()
        {
            var values = _bookingService.TLast5Bookings();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddBooking(Booking booking)
        {
            _bookingService.BInsert(booking);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveBooking(int id)
        {
            var values = _bookingService.BGetById(id);
            _bookingService.BDelete(values);
            return Ok();
        }

        [HttpPut("UpdateBooking")]
        public IActionResult UpdateBooking(Booking booking)
        {
            _bookingService.BUpdate(booking);
            return Ok();
        }

        [HttpGet("updateBookingStatusApproved{id}")]
        public IActionResult UpdateStatusApproved(int id)
        {
            try
            {
                _bookingService.TBookingStatusChangeApproved(id);
                return Ok("Rezervasyon Onaylandı");
            }
            catch (Exception ex)
            {

               return BadRequest(ex.Message);
            }
           
        }

        [HttpGet("updateBookingStatusCancel{id}")]
        public IActionResult UpdateStatusCancel(int id)
        {
            try
            {
                _bookingService.TBookingStatusChangeCancel(id);
                return Ok("Rezervasyon İptal Edildi");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpGet("updateBookingStatusWait{id}")]
        public IActionResult UpdateStatusWait(int id)
        {
            try
            {
                _bookingService.TBookingStatusChangeWait(id);
                return Ok("Rezervasyon Beklete Alındı");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

    }
}
