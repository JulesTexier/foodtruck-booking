using foodtruck_booking.Models;

namespace foodtruck_booking.Services
{
    public class ReportService
    {
        private readonly ReservationService _reservationService;
        public ReportService(ReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        public List<Report> GenerateReport()
        {
            var reservations = _reservationService.GetAllReservations();

            // Regrouper les réservations par Plate et retourner une liste
            var report = reservations
                .GroupBy(r => r.Plate)
                .Select(g => new Report
                {
                    Plate = g.Key,
                    Reservations = g.OrderBy(r => r.Date).ToList(),
                    TotalCost = g.Sum(r => r.Cost)
                })
                .ToList();

            return report;
        }

    }
}
