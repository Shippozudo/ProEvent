using ProEventos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEvents.Persistence
{
    public interface IProEventsPersistence
    {
        Task Add<T>(T entity) where T : class;
        Task Update<T>(T entity) where T : class;
        Task Delete<T>(T[] entity) where T : class;
        Task DeleteRange<T>(T entity) where T : class;
        Task CommitAsync();

        //Events
        Task<IEnumerable<Event>> GetAllEventsAsync();
        Task<Event> GetEventByIdAsync(Guid id);
        Task<IEnumerable<Event>> GetAllEventsByThemeAsync(string theme);

        //Panelist
        Task<IEnumerable<Panelist>> GetAllPanelistsAsync();
        Task<Panelist> GetPanelistByIdAsync(Guid id);
        Task<IEnumerable<Panelist>> GetAllPanelistsByNameAsync(string name);

    }
}
