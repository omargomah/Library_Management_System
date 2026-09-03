using LibraryManagementSystem.Dtos.BorrowingDtos;
using LibraryManagementSystem.Entities;
using LibraryManagementSystem.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace LibraryManagementSystem.Repositories
{
    public class BorrowingRepository:Repository<Borrowing>,IBorrowingRepository
    {
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
            Borrowing? borrowing = await _set.LastOrDefaultAsync(x => x.BookId == bookId);
               return borrowing is null ? true : borrowing.ReturnDate.HasValue; 
        }
    }
}
