using LibraryManagementSystem.Data;
using LibraryManagementSystem.Dtos.BorrowingDtos;
using LibraryManagementSystem.Entities;
using LibraryManagementSystem.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;
namespace LibraryManagementSystem.Repositories
{
    public class BorrowingRepository(ApplicationDbContext dbContext) :Repository<Borrowing>(dbContext),IBorrowingRepository
    {

        public async Task<List<int>> CurrentlyBorrowedBooksIdAsync() =>
            await _set.Where(x => x.ReturnDate == null).Select(x => x.BookId).ToListAsync();
        public async Task<List<string>> CurrentlyBorrowedBooksNameAsync() =>
            await _set.Where(x => x.ReturnDate == null).Select(x => x.Book.Title).ToListAsync();
        public async Task<List<string>> MembersWhoCurrentlyHaveBorrowedBooksAsync() =>
            await _set.Where(x => x.ReturnDate == null).Select(x => x.Member.Name).Distinct().ToListAsync();
        public async Task<List<BooksNameAndBorrowCountDto>> GetBooksAndCountOfBorrowAsync()
        {
            return await _set.GroupBy(x => x.Book.Title).Select(x => 
                new BooksNameAndBorrowCountDto()
                {
                  BookName = x.Key,
                  BorrowCount = x.Count()
                }
            ).OrderByDescending(x => x.BorrowCount).ToListAsync();
        }
        public async Task<bool> CheckThatBookIsAvailableToBorrowAsync(int bookId)
        {
            Borrowing? borrowing = await _set.OrderBy(x => x.BookId).LastOrDefaultAsync(x => x.BookId == bookId);
               return borrowing is null ? true : borrowing.ReturnDate.HasValue; 
        }
    }
}
