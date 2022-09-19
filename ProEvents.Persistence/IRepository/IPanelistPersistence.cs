using ProEventos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEvents.Persistence.IRepository
{
    public interface IPanelistPersistence
    {
        //Panelist
        Task<IEnumerable<Panelist>> GetAllPanelistsAsync();
        Task<Panelist> GetPanelistByIdAsync(Guid id);
        Task<IEnumerable<Panelist>> GetAllPanelistsByNameAsync(string name);

    }
}
