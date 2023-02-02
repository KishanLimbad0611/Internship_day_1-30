using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
  
        // GET: api/Flight
        [HttpGet]
        public IActionResult Gets()
        {

            var flights = Database.Obj.flights;

            if (flights.Count == 0)
            {
                return NotFound("Not flight are found");
            }
            return Ok(flights);
        }

        [HttpGet("Getflight")]
        // ---------------------GET----------
        public IActionResult Get(int id)

        {
            var flights = Database.Obj.flights;
            var flight = flights.SingleOrDefault(f => f.Id == id);
            if (flight == null)
            {
                return NotFound("No flight available");
            }
            return  Ok(flight);
        }

        // ------------------POST------------
        [HttpPost]

        public IActionResult Create(ServerSide flight)
        {
            var flights = Database.Obj.flights;
            flights.Add(flight);
            if (flights.Count == 0)
            {
                return NotFound("Not listed....");
            }
            return Ok(flights);
        }



        //------------------PUT-----------------
        [HttpPut]
        public IActionResult Put(int id, ServerSide flight)
        {
            var flights = Database.Obj.flights;

            foreach (var i in flights)
            {
                if(i.Id == id)
                {
                    i.Id = flight.Id;
                    i.FlightNumber = flight.FlightNumber;
                    i.Origin = flight.Origin;
                    i.Destination = flight.Destination;
                    i.DepartureTime = flight.DepartureTime;
                    i.ArrivalTime = flight.ArrivalTime;
                }
            }
            return Ok(flights);
        }


        //------------------DELETE-----------------
        [HttpDelete] 
        public IActionResult Delete(int id)
        {
            var flights = Database.Obj.flights;
            var flight = flights.SingleOrDefault(f => f.Id == id);
            if (flights.Count == 0)
            {
                return NotFound("Not listed information....");
            }
            else if (flight == null)
            {
                return NotFound("No information available...");
            }
            flights.Remove(flight);
            return Ok(flights);
        }
    }
}
