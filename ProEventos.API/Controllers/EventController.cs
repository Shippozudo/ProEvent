using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventController : ControllerBase
    {
        public IEnumerable<Event> _event = new Event[]
        {
                new Event()
                {
                    EventId = Guid.NewGuid(),
                    Local = "Blumenau",
                    Date = DateTime.Now.AddDays(2).ToString(),
                    Theme = "Angular 11 e .NET 5",
                    PeopleAmount = 250,
                    Lot = "1º Lote"

                },

                new Event()
                {
                    EventId = Guid.NewGuid(),
                    Local = "Florianópolis",
                    Date = DateTime.Now.AddDays(5).ToString(),
                    Theme = "Angular 11 e .NET 5",
                    PeopleAmount = 150,
                    Lot = "2º Lote"

                }
        };

        public EventController()
        {
        }

        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return _event;
        }

        [HttpGet("{id}")]
        public IEnumerable<Event> GetById(Guid id)
        {
            return _event.Where(e => e.EventId == id);
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
