using LibraryManagementSystem.Entities;
namespace LibraryManagementSystem.Interfaces.IRepositories
{
    public interface IBorrowingRepository:IRepository<Borrowing>
    {
        Task<bool> CheckThatBookIsAvailableToBorrowAsync(int bookId);

    }
}
