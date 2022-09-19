using ProEventos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEvents.Persistence.IRepository
{
    public interface IRepositoryPersistence
    {
        Task Add<T>(T entity) where T : class;
        Task Update<T>(T entity) where T : class;
        Task Delete<T>(T entity) where T : class;
        Task DeleteRange<T>(T entity) where T : class;
        Task CommitAsync();

    }
}
