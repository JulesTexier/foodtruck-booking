namespace foodtruck_booking.Models
{
    public class Report
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Plate { get; set; }
        public List<Reservation> Reservations { get; set; } = new List<Reservation>();
        public decimal TotalCost { get; set; }
        public int TotalReservations => Reservations.Count;
        public int TotalCancellations => Reservations.Count(r => r.Status == "Cancelled");

    }
}
