using System;
using System.Collections.Generic;
using System.Linq;

namespace DateReservation
{
    class Program
    {
        static void Main(string[] args)
        {
            var bookedReservations = GetBookedReservations();
            DisplayReservations(bookedReservations);

            Console.WriteLine("Insert new booking start date: (yyyy-MM-dd)");

            string startDateString = Console.ReadLine();
            DateTime startDate = DateTime.ParseExact(startDateString, "yyyy-MM-dd", null);

            Console.WriteLine("Insert new booking end date: (yyyy-MM-dd)");
            string endDateString = Console.ReadLine();
            DateTime endDate = DateTime.ParseExact(endDateString, "yyyy-MM-dd", null);

            bool isNewReservationPossible = IsNewReservationPossible(startDate, endDate, bookedReservations);

            if (isNewReservationPossible)
            {
                Console.WriteLine("Reservation booked");
            }
            else
            {
                Console.WriteLine("Select other booking dates");
            }
        }

        static bool IsNewReservationPossible(DateTime startDate, DateTime endDate, List<Reservation> bookedReservations)
        {
            //TODO: Implement the logic
            var newReservationDays = GetReservedDays(startDate,endDate);

            foreach (Reservation bookedReservation in bookedReservations)
            {
                var bookedReservationDays = GetReservedDays(bookedReservation.From, bookedReservation.To);

                for (int i = 0; i < bookedReservationDays.Count; i++)
                {
                    for (int n = 0; n < newReservationDays.Count; n++)
                    {
                        if (bookedReservationDays[i].Date.Equals(newReservationDays[n].Date))
                            return false;
                    }
                }
            }
            return true;
        }

        static List<DateTime> GetReservedDays(DateTime startDate, DateTime endDate)
        {
            List<DateTime> reservationDays = new List<DateTime> { startDate };
            do
            {
                DateTime currentDay = reservationDays[reservationDays.Count - 1];
                DateTime nextDay = currentDay.AddDays(1);
                reservationDays.Add(nextDay);
            } while (!reservationDays[reservationDays.Count - 1].Equals(endDate));
            return reservationDays;
        }

        static void DisplayReservations(List<Reservation> bookedReservations)
        {
            Console.WriteLine("Booked reservations:");
            foreach(var bookedReservation in bookedReservations)
            {
                Console.WriteLine($"From: {bookedReservation.From.ToString("yyyy-MM-dd")}, " +
                                  $"To: {bookedReservation.To.ToString("yyyy-MM-dd")}");
            }
        }

        static List<Reservation> GetBookedReservations()
        {
            var reservations = new List<Reservation>()
            {
                new Reservation(new DateTime(2021, 6, 10), new DateTime(2021, 6, 12)),
                new Reservation(new DateTime(2021, 6, 19), new DateTime(2021, 6, 20)),
                new Reservation(new DateTime(2021, 6, 24), new DateTime(2021, 6, 26)),
                new Reservation(new DateTime(2021, 7, 24), new DateTime(2021, 7, 25)),
            };

            return reservations;
        }
    }
}
