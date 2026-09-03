using LibraryManagementSystem.Data;
using LibraryManagementSystem.Entities;
using LibraryManagementSystem.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;
namespace LibraryManagementSystem.Repositories
{
    public class Repository<T>:IRepository<T>
        where T: Entity
    {
        protected readonly DbSet<T> _set;
        protected readonly ApplicationDbContext _dbContext;

        public Repository()
        {
            _dbContext = new ApplicationDbContext();
            _set = _dbContext.Set<T>();
        }
        public async ValueTask<T> AddAsync(T entity)
        {
            return (await _set.AddAsync(entity)).Entity;
        }
        public void Update(T entity)
        {
             _set.Update(entity);
        }
        public async void Delete(T entity)
        {
            _set.Remove(entity);
        }
        public async Task<T?> GetByIdAsync(int id) =>
            await _set.SingleOrDefaultAsync(x => x.Id == id);

        public async Task<bool> CheckIdIsExistAsync(int id) =>
            await _set.AnyAsync(x => x.Id == id);

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
