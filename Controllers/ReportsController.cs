using foodtruck_booking.Models;
using foodtruck_booking.Services;
using Microsoft.AspNetCore.Mvc;

namespace foodtruck_booking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly ReportService _reportService;

        public ReportsController(ReportService reportService)
        {
            _reportService = reportService;
        }

        /// <summary>
        /// Get a report of reservations grouped by Plate.
        /// </summary>
        // GET: api/<ReportsController>
        [HttpGet]
        public ActionResult<Report> GetReport()
        {
            var report = _reportService.GenerateReport();
            return Ok(report);
        }
    }
}
