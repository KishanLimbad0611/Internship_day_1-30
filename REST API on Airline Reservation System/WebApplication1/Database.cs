using WebApplication1.Model;

namespace WebApplication1
{
    // --------------------------Database for the Server side-------------------------
    public class Database
    {
        public List<ServerSide> flights;
        public static Database Obj = new Database();


        public Database()
        {

            flights = new List<ServerSide>()
            {
                new ServerSide { Id = 1, FlightNumber = "123", Origin = "New York", Destination = "London", DepartureTime = DateTime.Now, ArrivalTime = DateTime.Now.AddHours(8), TotalSeatsAvailable = 40 },
                new ServerSide { Id = 2, FlightNumber = "456", Origin = "London", Destination = "New York", DepartureTime = DateTime.Now, ArrivalTime = DateTime.Now.AddHours(7), TotalSeatsAvailable = 30},
                new ServerSide { Id = 3, FlightNumber = "789", Origin = "Rajkot", Destination = "Mumbai", DepartureTime = DateTime.Now, ArrivalTime = DateTime.Now.AddHours(3) , TotalSeatsAvailable = 50},
                new ServerSide { Id = 4, FlightNumber = "999", Origin = "Ahmedabad", Destination = "Hyderabad", DepartureTime = DateTime.Now, ArrivalTime = DateTime.Now.AddHours(2), TotalSeatsAvailable = 45 },
                new ServerSide { Id = 5, FlightNumber = "888", Origin = "Delhi", Destination = "London", DepartureTime = DateTime.Now, ArrivalTime = DateTime.Now.AddHours(6),TotalSeatsAvailable = 40 },
                new ServerSide { Id = 6, FlightNumber = "333", Origin = "Assam", Destination = "Delhi", DepartureTime = DateTime.Now, ArrivalTime = DateTime.Now.AddHours(2), TotalSeatsAvailable = 60 },
                new ServerSide { Id = 7, FlightNumber = "222", Origin = "Pune", Destination = "New York", DepartureTime = DateTime.Now, ArrivalTime = DateTime.Now.AddHours(4),TotalSeatsAvailable = 50 }
            };
        }
             
    }


    //-------------------------------DataBase regarding  customer information----------------- 
    public class DatabaseForCust
    {
        public List<CustClient> clients;
        public static DatabaseForCust Obj2 = new DatabaseForCust();

        public DatabaseForCust()
        {
            clients = new List<CustClient>()
            {
                new CustClient { Id = 1, Name = "ABCD", ContactInformation = "9987654321", SeatsRequired = 2 },
                new CustClient { Id = 2, Name = "DEFG", ContactInformation = "9090908787", SeatsRequired = 4 },
                new CustClient { Id = 3, Name = "HIJK", ContactInformation = "1254376589", SeatsRequired = 6 },
                new CustClient { Id = 4, Name = "LMNO", ContactInformation = "9987612345", SeatsRequired = 7 },
                new CustClient { Id = 5, Name = "PQRS", ContactInformation = "1234567890", SeatsRequired = 1 }
            };
        }
    }
}
