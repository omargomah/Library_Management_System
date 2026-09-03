using LibraryManagementSystem.Dtos.BorrowingDtos;
using LibraryManagementSystem.Entities;
namespace LibraryManagementSystem.Interfaces.IRepositories
{
    public interface IBookRepository: IRepository<Book>
    {
        Task<double> GetAveragePriceOfBooks();
        Task < List<Book>> GetAllBooksWithCategoryAsync();
        Task<Book?> GetBookWithCategoryByIdAsync(int bookId);
        IQueryable<Book> GetAllBooksWithCategory();
        Task<BookWithBorrowingDto?> GetBookWithBorrowingByIdAsync(int bookId);

    }
}
