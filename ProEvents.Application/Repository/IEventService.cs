using ProEventos.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProEvents.Application.Repository
{
    public interface IEventService
    {
        Task<Event> AddEvent(Event model);
        Task<Event> UpdateEvent(Guid id, Event entity);
        Task<Event> DeleteEvent(Guid id);

        Task<IEnumerable<Event>> GetAllEventsAsync();
        Task<Event> GetEventByIdAsync(Guid id);
        Task<IEnumerable<Event>> GetAllEventsByThemeAsync(string theme);
    }
}
