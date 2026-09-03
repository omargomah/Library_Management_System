using LibraryManagementSystem.Dtos.BorrowingDtos;
using LibraryManagementSystem.Dtos.CategoryDtos;
using LibraryManagementSystem.Dtos.MemberDtos;
using LibraryManagementSystem.Entities;
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
        private readonly IBookRepository _bookRepository;
        private readonly IMemberRepository _memberRepository;

        public ReportManagement(
            IBorrowingRepository borrowingRepository,
            ICategoryRepository categoryRepository,
            IBookRepository bookRepository,
            IMemberRepository memberRepository)
        {
            _borrowingRepository = borrowingRepository;
            _categoryRepository = categoryRepository;
            _bookRepository = bookRepository;
            _memberRepository = memberRepository;
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
                Console.WriteLine("3) Average Book Price");
                Console.WriteLine("4) Most Active Members");
                Console.WriteLine("5) Return to Main Menu");
                Console.Write("\nSelect an option: ");

                ConsoleKey choice = Console.ReadKey().Key;

                switch (choice)
                {
                    case ConsoleKey.NumPad1:
                        await GetMostBorrowedBooks();
                        break;

                    case ConsoleKey.NumPad2:
                        await GetNumberofBooksPerCategoryAsync();
                        break;

                    case ConsoleKey.NumPad3:
                        await GetAverageBookPriceAsync();
                        break;

                    case ConsoleKey.NumPad4:
                        await GetMostActiveMembersAsync();
                        break;

                    case ConsoleKey.NumPad5:
                        return;

                    default:
                        Console.WriteLine("\nInvalid option! Please enter a number between 1 and 5.");
                        EndExecute();
                        break;
                }
            }
        }
        private async Task GetMostActiveMembersAsync()
        {
            StartExecute("Most Active Members");

            List<MembersNameAndCountOfBorrowingDto> membersNameAndCountOfBorrowingDto = await _memberRepository.GetAllMembersWithBorrowingsCountAsync();

            if (membersNameAndCountOfBorrowingDto.IsNullOrEmpty())
                Console.WriteLine("No Members data available yet");
            else
            {
                Console.WriteLine($"{"Member",-30} {"Borrowing Count",-30}\n");
                Console.WriteLine(new string('-', 60));

                foreach (var member in membersNameAndCountOfBorrowingDto)
                    Console.WriteLine($"{member.MemberName,-30} {member.BorrowingCount,-30}");
            }

            EndExecute();
        }
        private async Task GetAverageBookPriceAsync()
        {
            StartExecute("Average Book Price");

            Console.WriteLine($"The average price of books = {await _bookRepository.GetAveragePriceOfBooks()}");

            EndExecute();
        }
        private async Task GetNumberofBooksPerCategoryAsync()
        {
            StartExecute("Number of Books Per Category");

            List<CategoryNameAndCountOfBooksInItDto> categoryNameAndCountOfBooksInItDto = await _categoryRepository.GetCategoryByIdWithBooksCountAsync();

            if (categoryNameAndCountOfBooksInItDto.IsNullOrEmpty())
                Console.WriteLine("No category data available.");
            else
            {
                Console.WriteLine($"{"Category",-30} {"  Number of Books",-30}\n");
                Console.WriteLine(new string('-', 60));

                foreach (var category in categoryNameAndCountOfBooksInItDto)
                    Console.WriteLine($"{category.CategoryName,-30} {category.BooksCount,-30}");
            }

            EndExecute();
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
