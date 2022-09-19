using ProEvents.Persistence.Context;
using ProEvents.Persistence.IRepository;
using System.Threading.Tasks;

namespace ProEvents.Persistence
{
    public class Repository : IRepositoryPersistence
    {
        private readonly ProEventsContext _context;

        public Repository(ProEventsContext context)
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

        public async Task Delete<T>(T entity) where T : class
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
    }
}
