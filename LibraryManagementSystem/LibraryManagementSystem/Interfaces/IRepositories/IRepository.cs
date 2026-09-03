using LibraryManagementSystem.Data;
using LibraryManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;
namespace LibraryManagementSystem.Interfaces.IRepositories
{
    public interface IRepository<T>
        where T: Entity
    {
        Task<bool> CheckIdIsExistAsync(int id);
        ValueTask < T> AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<T?> GetByIdAsync(int id);

    }
}
