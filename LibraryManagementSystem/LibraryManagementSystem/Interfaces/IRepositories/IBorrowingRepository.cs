using LibraryManagementSystem.Dtos.BorrowingDtos;
using LibraryManagementSystem.Entities;
namespace LibraryManagementSystem.Interfaces.IRepositories
{
    public interface IBorrowingRepository:IRepository<Borrowing>
    {
        Task<int> GetCountOfActiveBorrowingBookForThisMemberAsync(int memberId);
        Task < List<string>> MembersWhoCurrentlyHaveBorrowedBooksAsync();
        Task<bool> CheckThatBookIsAvailableToBorrowAsync(int bookId);
        Task<List<BooksNameAndBorrowCountDto>> GetBooksAndCountOfBorrowAsync();
        Task<List<string>> CurrentlyBorrowedBooksNameAsync();
        Task<List<int>> CurrentlyBorrowedBooksIdAsync();

    }
}
