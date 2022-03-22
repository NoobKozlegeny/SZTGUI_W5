using Endpoint.Logic;
using Endpoint.Models;
using Endpoint.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        IMessageLogic msgLogic;
        IHubContext<SignalRHub> hub;

        public MessageController(IMessageLogic msgLogic, IHubContext<SignalRHub> hub)
        {
            this.msgLogic = msgLogic;
            this.hub = hub;
        }


        // GET: api/<MessageController>
        [HttpGet]
        public IEnumerable<Message> Get()
        {
            return msgLogic.GetAll();
        }

        // GET api/<MessageController>/5
        [HttpGet("{time}&{name}")]
        public Message Get(string time, string name)
        {
            return msgLogic.Get(DateTime.Parse(time), name);
        }

        // POST api/<MessageController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MessageController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MessageController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
