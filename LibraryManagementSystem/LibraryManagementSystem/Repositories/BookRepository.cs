using LibraryManagementSystem.Entities;
using LibraryManagementSystem.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;
namespace LibraryManagementSystem.Repositories
{
    public class BookRepository:Repository<Book> ,IBookRepository
    {
        public async Task<List<Book>> GetAllBooksWithCategoryAsync() =>
            await GetAllBooksWithCategory().ToListAsync();
        public IQueryable<Book> GetAllBooksWithCategory() =>
            _set.Include(x => x.Category);
        public async Task<Book?> GetBookWithCategoryByIdAsync(int bookId) =>
            await _set.Include(x => x.Category).SingleOrDefaultAsync(x => x.Id == bookId);


    }
}
