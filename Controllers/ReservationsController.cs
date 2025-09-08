using foodtruck_booking.Models;
using foodtruck_booking.Services;
using Microsoft.AspNetCore.Mvc;

namespace foodtruck_booking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly ReservationService _reservationService;
        public ReservationsController(ReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        // GET: api/<ReservationsController>
        [HttpGet]
        public ActionResult<IEnumerable<Reservation>> GetAll()
        {
            return Ok(_reservationService.GetAllReservations());
        }

        // GET: api/<ReservationsController>
        [HttpGet("active")]
        public ActionResult<IEnumerable<Reservation>> GetActiveReservations()
        {
            return Ok(_reservationService.GetActiveReservations());
        }

        // POST api/<ReservationsController>
        [HttpPost]
        public ActionResult<Reservation> Create([FromBody] DateTime Date, string Plate, double Size)
        {
            try
            {
                var res = _reservationService.AddReservation(Date, Plate, Size);
                return Ok(res);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return BadRequest(new { message = ex.Message });
            }
        }

        // DELETE api/<ReservationsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            try
            {
                _reservationService.delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
    }
}
