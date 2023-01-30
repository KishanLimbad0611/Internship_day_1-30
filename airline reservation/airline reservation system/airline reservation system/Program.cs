using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace airline_reservation_system
{
    class Program
    {
        static void Main(string[] args)
        {
            Flight flight = new Flight();
            Passenger passenger = new Passenger();
            Booking booking = new Booking();
            AirlineReservationSystem airlineReservationSystem = new AirlineReservationSystem();
        }

    }

    public class Flight
    {
        public string FlightNumber { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int SeatsAvailable { get; set; }
    }

    public class Passenger
    {
        public string Name { get; set; }
        public string ContactInformation { get; set; }
        public int SeatsRequired { get; set; }
    }


    //----------inheritance---------------
    public class Booking : Flight 
    {
        public Passenger Passenger { get; set; }
    }

    public class AirlineReservationSystem
    {
        //------------encapsulation---------------
        private List<Flight> flights; 

        public void MakeBooking(Flight flight, Passenger passenger)
        {
            if (flight.SeatsAvailable >= passenger.SeatsRequired)
            {
                flight.SeatsAvailable -= passenger.SeatsRequired;
                Booking booking = new Booking
                {
                    FlightNumber = flight.FlightNumber,
                    DepartureCity = flight.DepartureCity,
                    ArrivalCity = flight.ArrivalCity,
                    DepartureTime = flight.DepartureTime,
                    ArrivalTime = flight.ArrivalTime,
                    SeatsAvailable = flight.SeatsAvailable,
                    Passenger = passenger
                };
                Console.WriteLine("Booking successful.");
            }
            else
            {
                Console.WriteLine("Booking failed. Not enough seats available.");
            }
        }

        public void CancelBooking(Booking booking)
        {
            Flight flight = flights.Find(f => f.FlightNumber == booking.FlightNumber);
            flight.SeatsAvailable += booking.Passenger.SeatsRequired;
            Console.WriteLine("Booking cancelled.");
        }

        public void DisplayFlightDetails(Flight flight)
        {
            Console.WriteLine("Flight Number: " + flight.FlightNumber);
            Console.WriteLine("Departure City: " + flight.DepartureCity);
            Console.WriteLine("Arrival City: " + flight.ArrivalCity);
            Console.WriteLine("Departure Time: " + flight.DepartureTime);
            Console.WriteLine("Arrival Time: " + flight.ArrivalTime);
            Console.WriteLine("Seats Available: " + flight.SeatsAvailable);
            Console.WriteLine("\nBooking Seat...");
            //bool isBooked = flight.Book();
            //if (isBooked)
            //{
            //    Console.WriteLine("Seat Booked Successfully!");
            //}
            //else
            //{
            //    Console.WriteLine("No Seat Available!");
            //}
            //Console.WriteLine("Booked Seats: " + flight.BookedSeats);
            //Console.ReadLine();
        }

    }

}





