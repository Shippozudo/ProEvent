using Microsoft.AspNetCore.Mvc;
using ProEventos.Domain;
using ProEvents.Application.Repository;
using System;
using System.Threading.Tasks;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventsController : ControllerBase
    {

        private readonly IEventService _repository;

        public EventsController(IEventService repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var getAll = await _repository.GetAllEventsAsync();
            return Ok(getAll);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var getEvent = await _repository.GetEventByIdAsync(id);
            return Ok(getEvent);
        }


        [HttpGet("{theme}")]
        public async Task<IActionResult> GetByTheme(string theme)
        {
            var getEvent = await _repository.GetAllEventsByThemeAsync(theme);
            return Ok(getEvent);
        }


        [HttpPost]
        public async Task<IActionResult> Post(Event entity)
        {
            var addEntity = await _repository.AddEvent(entity);
            return Ok(addEntity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, Event entity)
        {
            var addEntity = await _repository.UpdateEvent(id, entity);
            return Ok(addEntity);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleteEntity = await _repository.DeleteEvent(id);
            return Ok(deleteEntity);
        }
    }
}
