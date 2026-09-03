using LibraryManagementSystem.Entities;
using LibraryManagementSystem.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace LibraryManagementSystem.Repositories
{
    public class BorrowingRepository:Repository<Borrowing>,IBorrowingRepository
    {
        public async Task<bool> CheckThatBookIsAvailableToBorrowAsync(int bookId)
        {
            Borrowing? borrowing = await _set.LastOrDefaultAsync(x => x.BookId == bookId);
               return borrowing is null ? true : borrowing.ReturnDate.HasValue; 
        }
    }
}
