namespace WebApplication1.Model
{
    public class ServerSide
    {
        public int Id { get; set; } = 0;
        public string FlightNumber { get; set; } = "";
        public string Origin { get; set; } = "";
        public string Destination { get; set; } = "";
        public DateTime DepartureTime { get; set; }= DateTime.Now;
        public DateTime ArrivalTime { get;set; } = DateTime.Now;
        public int TotalSeatsAvailable { get; set; } = 0;

    }
    public class CustClient
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = "";
        public string ContactInformation { get; set; } = "";
        public int SeatsRequired { get; set; } = 0;
    }
    public class search
    {
        public string OriginLocation { get; set; } = "";
        public string ArrivalLocation { get; set; } = "";
        public string Fnumber { get; set; } = "";

    }
}
