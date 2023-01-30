using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Class1
{
	public Class1()
	{

	}

    //-------------abstraction-----------------
    public abstract class Passenger
    {
        protected string name;
        protected string address;
        protected string contactInfo;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string ContactInfo
        {
            get { return contactInfo; }
            set { contactInfo = value; }
        }

        public abstract decimal CalculatePrice();
    }

    //-------------------inheritance-------------------
    public class Flight : Passenger
    {
        private string flightNumber;
        private DateTime departureDate;
        private string destination;

        public string FlightNumber
        {
            get { return flightNumber; }
            set { flightNumber = value; }
        }

        public DateTime DepartureDate
        {
            get { return departureDate; }
            set { departureDate = value; }
        }

        public string Destination
        {
            get { return destination; }
            set { destination = value; }
        }
    }

    public class Reservation
    {
        private List<Flight> flights;

        public void AddReservation(Flight flight)
        {
            flights.Add(flight);
        }

        public void UpdateReservation(Flight flight)
        {
            flights.Update(flight);
        }

        public void DeleteReservation(Flight flight)
        {
            flights.Remove(flight);
        }
    }
}
