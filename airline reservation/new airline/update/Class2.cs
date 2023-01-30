using System;
public class Class1
{
    class Flight
    {
        private string flightNumber;
        private string departure;
        private string destination;
        private int seatsAvailable;

        public Flight(string flightNumber, string departure, string destination, int seatsAvailable)
        {
            this.flightNumber = flightNumber;
            this.departure = departure;
            this.destination = destination;
            this.seatsAvailable = seatsAvailable;
        }

        public bool ReserveSeat()
        {
            if (seatsAvailable > 0)
            {
                seatsAvailable--;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Display()
        {
            Console.WriteLine("Flight Number: " + flightNumber);
            Console.WriteLine("Departure: " + departure);
            Console.WriteLine("Destination: " + destination);
            Console.WriteLine("Seats Available: " + seatsAvailable);
        }
    }

    class Program
    {
       
        {
            Flight flight = new Flight("AI101", "New York", "London", 50);

            Console.WriteLine("Welcome to the Airline Reservation System");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine("1. Display flight information");
                Console.WriteLine("2. Reserve a seat");
                Console.WriteLine("3. Exit");
                Console.WriteLine();

                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        flight.Display();
                        Console.WriteLine();
                        break;
                    case 2:
                        if (flight.ReserveSeat())
                        {
                            Console.WriteLine("Seat reserved successfully");
                        }
                        else
                        {
                            Console.WriteLine("Sorry, flight is fully booked");
                        }
                        Console.WriteLine();
                        break;
                    case 3:
                        return;
                }
            }
        }
    }
}
}
