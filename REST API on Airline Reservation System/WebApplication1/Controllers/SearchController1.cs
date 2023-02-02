using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController1 : ControllerBase
    {
        //-------------------------------------------------------------//

        [HttpGet]
        public IActionResult Gets()
        {

            var od = Database.Obj.flights;

            if (od.Count == 0)
            {
                return NotFound("Not flight are found");
            }
            return Ok(od);
        }


        [HttpGet("SearchForFlight")]
        // ---------------------GET----------
        public IActionResult Get(string OriginLocation, string ArrivalLocation)

        {
            var flights = Database.Obj.flights;
            var flight = flights.SingleOrDefault(o => o.Origin == OriginLocation && o.Destination == ArrivalLocation);
            if (flight == null)
            {
                return NotFound("No flight available");
            }
            return Ok(flight);
        }


        //------------------------------------------------------//

        //--------------------------Search for the Flight Number -------------------
        [HttpGet("SearchForFlightNumber")]
        public IActionResult Get(string Fnumber)

        {
            var flights = Database.Obj.flights;
            var flight = flights.SingleOrDefault(o => o.FlightNumber == Fnumber);
            if (flight == null)
            {
                return NotFound("Sorry.. No flight available");
            }
            return Ok(flight);
        }



    }
}
