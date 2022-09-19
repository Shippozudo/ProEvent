using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEvents.Persistence.Context;
using ProEvents.Persistence.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProEvents.Persistence
{
    public class EventPersistence : IEventPersistence
    {
        private readonly ProEventsContext _context;

        public EventPersistence(ProEventsContext context)
        {
            _context = context;
        }       

        public async Task<IEnumerable<Event>> GetAllEventsAsync()
        {
            var query = await _context.Events
                .Include(e => e.SocialMedia)
                .Include(e => e.PanelistEvent)
                .ThenInclude(pe => pe.Panelist)
                .AsNoTracking()
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
                 .AsNoTracking()
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
                 .AsNoTracking()
                 .ToListAsync();

            return query;

        }
        
    }
}
