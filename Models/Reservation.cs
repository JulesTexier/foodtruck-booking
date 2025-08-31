namespace foodtruck_booking.Models
{
    public class Reservation
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Plate { get; set; }
        public double Size { get; set; }
        public DateTime Date { get; set; }
        public decimal Cost { get; set; }
        public bool Cancelled { get; set; } = false;

    }
}
