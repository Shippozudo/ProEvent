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
    public class PanelistPersistence : IPanelistPersistence
    {
        private readonly ProEventsContext _context;

        public PanelistPersistence(ProEventsContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Panelist>> GetAllPanelistsAsync()
        {
            var query = await _context.Panelists
                .Include(p => p.Contact)
                .Include(p => p.PanelistEvent)
                .AsNoTracking()
                .ToListAsync();

            return query;
        }

        public async Task<Panelist> GetPanelistByIdAsync(Guid id)
        {
            var query = await _context.Panelists
                .Include(p => p.Contact)
                .Include(p => p.PanelistEvent)
                .Where(p => p.Id == id)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return query;
        }

        public async Task<IEnumerable<Panelist>> GetAllPanelistsByNameAsync(string name)
        {
            var query = await _context.Panelists
                .Include(p => p.Contact)
                .Include(p => p.PanelistEvent)
                .Where(p => p.Name.ToUpper() == name.ToUpper())
                .AsNoTracking()
                .ToListAsync();

            return query;
        }

    }
}
