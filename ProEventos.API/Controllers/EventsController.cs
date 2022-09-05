using Microsoft.AspNetCore.Mvc;
using ProEventos.Domain;
using ProEvents.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventsController : ControllerBase
    {

        private readonly ProEventsContext _context;

        public EventsController(ProEventsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return _context.Events;
        }

        [HttpGet("{id}")]
        public Event GetById(Guid id)
        {
            return _context.Events
                .FirstOrDefault(e => e.Id == id);
        }


        [HttpPost]
        public string Post()
        {
            return "Post";
        }

        [HttpPut]
        public string Put()
        {
            return "Put";
        }

        [HttpDelete]
        public string Delete()
        {
            return "Delete";
        }
    }
}
