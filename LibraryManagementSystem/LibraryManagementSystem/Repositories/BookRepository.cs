using LibraryManagementSystem.Data;
using LibraryManagementSystem.Dtos.BorrowingDtos;
using LibraryManagementSystem.Entities;
using LibraryManagementSystem.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;
namespace LibraryManagementSystem.Repositories
{
    public class BookRepository(ApplicationDbContext dbContext) : Repository<Book>(dbContext) ,IBookRepository
    {
        public async Task<List<string>> CurrentlyAvailableBooksAsync(List<int> borrowedBooksId) =>
                await _set.Where(x => !borrowedBooksId.Contains(x.Id)).Select(x => x.Title).ToListAsync();

        public async Task<double> GetAveragePriceOfBooks()
        {
            if (!await _set.AnyAsync())
                return 0;

            return await _set.AverageAsync(x => x.Price);
        }
        public async Task<List<Book>> GetAllBooksWithCategoryAsync() =>
            await GetAllBooksWithCategory().ToListAsync();
        public IQueryable<Book> GetAllBooksWithCategory() =>
            _set.Include(x => x.Category);
        public async Task<Book?> GetBookWithCategoryByIdAsync(int bookId) =>
            await _set.Include(x => x.Category).SingleOrDefaultAsync(x => x.Id == bookId);
        public async Task<BookWithBorrowingDto?> GetBookWithBorrowingByIdAsync(int bookId) =>
            await _set.Where(x => x.Id == bookId).Select(x => new BookWithBorrowingDto()
            {
                BookTitle = x.Title,
                HistoryDtos = x.Borrowings.Select(b => new BookBorrowingHistoryDto()
                {
                    BorrowDate = b.BorrowDate,
                    ReturnDate = b.ReturnDate,
                    MemberName = b.Member.Name
                }).ToList()
            }).FirstOrDefaultAsync();


    }
}
