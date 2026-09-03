using LibraryManagementSystem.Entities;
namespace LibraryManagementSystem.Interfaces.IRepositories
{
    public interface IBorrowingRepository:IRepository<Borrowing>
    {
        public async Task<bool> CheckThatBookIsAvailableToBorrowAsync(int bookId)

    }
}
