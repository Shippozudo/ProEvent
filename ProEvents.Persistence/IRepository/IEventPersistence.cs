using ProEventos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEvents.Persistence.IRepository
{
    public interface IEventPersistence
    {
        //Events
        Task<IEnumerable<Event>> GetAllEventsAsync();
        Task<Event> GetEventByIdAsync(Guid id);
        Task<IEnumerable<Event>> GetAllEventsByThemeAsync(string theme);

    }
}
