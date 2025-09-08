using foodtruck_booking.Models;
using System.Diagnostics;

namespace foodtruck_booking.Services
{
    public class ReservationService
    {
        private readonly List<Reservation> _reservations = new List<Reservation>();
        private const int MaxSlots = 7;
        public Reservation AddReservation(DateTime date, string plate, double size)
        {
            if (date < DateTime.Today || date > DateTime.Now.AddDays(7))
            {
                throw new Exception("Reservation must be made for a date within the next 7 days.");
            }

            int slots = date.DayOfWeek == DayOfWeek.Friday ? 6 : MaxSlots;

            var dailyReservations = _reservations
                .Where(r => r.Date.Date == date.Date)
                .ToList();

            double usedSlots = dailyReservations.Sum(r => r.Size == 5 ? 1 : 0.5);
            double requested = size == 5 ? 1 : 0.5;

            double numberOfSlotAvailable = slots - usedSlots;
            Debug.WriteLine($"Slots: {slots}, Used: {usedSlots}, Requested: {requested}, Available: {numberOfSlotAvailable}");
            Debug.WriteLine(dailyReservations);

            if (numberOfSlotAvailable == 0)
            {
                throw new Exception("No available slots for the selected date.");
            }

            decimal cost = date.Date == DateTime.Today ? 40 : 20;

            var res = new Reservation
            {
                Id = Guid.NewGuid(),
                Date = date,
                Plate = plate,
                Cost = cost,
                Size = size,
                Status = "Confirmed"
            };

            _reservations.Add(res);

            return res;

        }
        /// <summary>
        /// Gets all reservations.
        /// </summary>
        public IEnumerable<Reservation> GetAllReservations()
        {
            return _reservations;
        }

        /// <summary>
        /// Gets all active (confirmed) reservations.
        /// </summary>
        public IEnumerable<Reservation> GetActiveReservations()
        {
            return _reservations.Where(r => r.Status == "Confirmed");
        }

        /// <summary>
        /// Cancels a reservation by its ID.
        /// </summary>
        public void delete(Guid id)
        {
            var reservationToCancel = _reservations.FirstOrDefault(r => r.Id == id);

            if (reservationToCancel == null)
            {
                throw new Exception("Reservation not found.");
            }

            if ((reservationToCancel.Date - DateTime.Today).TotalDays >= 2)
            {
                reservationToCancel.Status = "Cancelled";
                reservationToCancel.Cost = 0;
            }
            else
            {
                reservationToCancel.Status = "Cancelled";
            }
        }
    }
}
