using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;
using WebApplication1.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;


namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustController : ControllerBase
    {
        // ---------------GET Client------------
        [HttpGet]
        public IActionResult Gets()
        {
            var clients = DatabaseForCust.Obj2.clients;
            if (clients.Count == 0)
            {
                return NotFound("Data not found");
            }
            return Ok(clients);
        }

        [HttpGet("GetInformation")]
        // ---------------------GET Client---------
        public IActionResult Get(int id)
        {
            var clients = DatabaseForCust.Obj2.clients;
            var client = clients.SingleOrDefault(c => c.Id == id);
            if (client == null)
            {
                return NotFound("Data not available");
            }
            return Ok(client);
        }


        //-----------------Post Client--------------
        [HttpPost]
        public IActionResult CreateCust(CustClient client)
        {
            var clients = DatabaseForCust.Obj2.clients;
            clients.Add(client);
            if (clients.Count == 0)
            {
                return NotFound("Your information was not listed....");
            }
            return Ok(clients);
        }

        //------------------PUT Client-----------------
        [HttpPut]
        public IActionResult PutCust(int id, CustClient client)
        {
            var clients = DatabaseForCust.Obj2.clients;

            foreach (var j in clients)
            {
                if (j.Id == id)
                {
                    j.Id = client.Id;
                    j.Name = client.Name;
                    j.ContactInformation = client.ContactInformation;
                    j.SeatsRequired = client.SeatsRequired;
                }
            }
            return Ok(clients);
        }


        //------------------ DELETE Client-----------------
        [HttpDelete]
        public IActionResult DeleteCust(int id)
        {
            var clients = DatabaseForCust.Obj2.clients;
            var client = clients.SingleOrDefault(c => c.Id == id);

            if (clients.Count == 0)
            {
                return NotFound("Not listed information....");
            } 
            else if (client == null)
            {
                return NotFound("No information available...");
            }
            clients.Remove(client);
            return Ok(clients);
        }
    
    }
}
