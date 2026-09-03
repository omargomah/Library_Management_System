using LibraryManagementSystem.Dtos.BorrowingDtos;
using LibraryManagementSystem.Dtos.CategoryDtos;
using LibraryManagementSystem.Interfaces.IRepositories;
using Microsoft.IdentityModel.Tokens;
using System.Runtime.ConstrainedExecution;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LibraryManagementSystem.Managements
{
    public class ReportManagement
    {
        private readonly IBorrowingRepository _borrowingRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ReportManagement(
            IBorrowingRepository borrowingRepository,
            ICategoryRepository categoryRepository)
        {
            _borrowingRepository = borrowingRepository;
            _categoryRepository = categoryRepository;
        }
        public async Task ShowMenuAsync()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=================================");
                Console.WriteLine("        Reports Management        ");
                Console.WriteLine("=================================");
                Console.WriteLine("1) Most Borrowed Books");
                Console.WriteLine("2) Number of Books Per Category");
                Console.WriteLine("3) Member Borrowing History");
                Console.WriteLine("4) Book Borrowing History");
                Console.WriteLine("5) Return to Main Menu");
                Console.Write("\nSelect an option: ");

                ConsoleKey choice = Console.ReadKey().Key;

                switch (choice)
                {
                    case ConsoleKey.D1:
                        await GetMostBorrowedBooks();
                        break;

                    case ConsoleKey.D2:
                        await GetNumberofBooksPerCategoryAsync();
                        break;

                    case ConsoleKey.D3:
                        await GetMemberBorrowingHistoryAsync();
                        break;

                    case ConsoleKey.D4:
                        await GetBookBorrowingHistoryAsync();
                        break;

                    case ConsoleKey.D5:
                        return;

                    default:
                        Console.WriteLine("\nInvalid option! Please enter a number between 1 and 5.");
                        EndExecute();
                        break;
                }
            }
        }

        private async Task GetNumberofBooksPerCategoryAsync()
        {
            StartExecute("Number of Books Per Category");

            List<CategoryNameAndCountOfBooksInItDto> categoryNameAndCountOfBooksInItDto = _categoryRepository.GetCategoryByIdWithBooksCountAsync();

            if (categoryNameAndCountOfBooksInItDto.IsNullOrEmpty())
                Console.WriteLine("No category data available.");
            else
            {
                Console.WriteLine($"{"Book",-30} {"Borrow Count",-15}\n");
                Console.WriteLine(new string('-', 45));

                foreach (var category in categoryNameAndCountOfBooksInItDto)
                    Console.WriteLine($"{category.CategoryName,-30} {category.BooksCount,-15}");
            }

            EndExecute();
        }

        private void StartExecute(string action)
        {
            Console.Clear();
            Console.WriteLine($"--- {action} ---");
        }
        private void EndExecute()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        private async Task GetMostBorrowedBooks()
        {
            StartExecute("Most Borrowed Books");

            List<BooksNameAndBorrowCountDto> booksNameAndBorrowCountsDtos = await  _borrowingRepository.GetBooksAndCountOfBorrowAsync();

            if (booksNameAndBorrowCountsDtos.IsNullOrEmpty())
                Console.WriteLine("No borrowing data available.");
            else
            {
                Console.WriteLine($"{"Book",-30} {"Borrow Count",-15}\n");
                Console.WriteLine(new string('-', 45));

                foreach (var b in booksNameAndBorrowCountsDtos)
                    Console.WriteLine($"{b.BookName,-30} {b.BorrowCount,-15}");
            }

            EndExecute();
        }
    }
}
