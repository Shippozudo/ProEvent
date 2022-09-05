using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProEvents.Persistence
{
    public class ProEventsPersistence : IProEventsPersistence
    {
        private readonly ProEventsContext _context;

        public ProEventsPersistence(ProEventsContext context)
        {
            _context = context;
        }

        public async Task Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public async Task Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public async Task Delete<T>(T[] entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task DeleteRange<T>(T entity) where T : class
        {
            _context.RemoveRange(entity);
        }

        public Task CommitAsync()
        {
            return _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Event>> GetAllEventsAsync()
        {
            var query = await _context.Events
                .Include(e => e.SocialMedia)
                .Include(e => e.PanelistEvent)
                .ThenInclude(pe => pe.Panelist)
                .ToListAsync();

            return query;

        }

        public async Task<Event> GetEventByIdAsync(Guid id)
        {
            var query = await _context.Events
                 .Include(e => e.SocialMedia)
                 .Include(e => e.PanelistEvent)
                 .ThenInclude(pe => pe.Panelist)
                 .Where(e => e.Id == id)
                 .FirstOrDefaultAsync();

            return query;
        }

        public async Task<IEnumerable<Event>> GetAllEventsByThemeAsync(string theme)
        {
            var query = await _context.Events
                 .Include(e => e.SocialMedia)
                 .Include(e => e.PanelistEvent)
                 .ThenInclude(pe => pe.Panelist)
                 .Where(e => e.Theme.ToUpper() == theme.ToUpper())
                 .ToListAsync();

            return query;

        }

        public async Task<IEnumerable<Panelist>> GetAllPanelistsAsync()
        {
            var query = await _context.Panelists
                .Include(p => p.Contact)
                .Include(p => p.PanelistEvent)
                .ToListAsync();

            return query;
        }

        public async Task<Panelist> GetPanelistByIdAsync(Guid id)
        {
            var query = await _context.Panelists
                .Include(p => p.Contact)
                .Include(p => p.PanelistEvent)
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();

            return query;
        }

        public async Task<IEnumerable<Panelist>> GetAllPanelistsByNameAsync(string name)
        {
            var query = await _context.Panelists
                .Include(p => p.Contact)
                .Include(p => p.PanelistEvent)
                .Where(p => p.Name.ToUpper() == name.ToUpper())
                .ToListAsync();

            return query;
        }

    }
}
