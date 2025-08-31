using foodtruck_booking.Models;
using foodtruck_booking.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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

        // GET api/<ReservationsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }


        // PUT api/<ReservationsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ReservationsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
