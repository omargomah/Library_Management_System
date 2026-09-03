using LibraryManagementSystem.Entities;
using LibraryManagementSystem.Interfaces;
using LibraryManagementSystem.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Net;
namespace LibraryManagementSystem.Managements
{
    public class BookManagement
    {
        private readonly IBookRepository _bookRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public BookManagement(IBookRepository bookRepository,ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _bookRepository = bookRepository;
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
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
        private void EndMessageOfAddAndUpdateAndDelete(string action, bool IsSuccess)
        {
            if (IsSuccess)
                Console.WriteLine($"\nBook {action} success");
            else
                Console.WriteLine($"\nBook {action} fail");
            EndExecute();
        }
        public async Task ShowMenuAsync()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=================================");
                Console.WriteLine("         Book Management         ");
                Console.WriteLine("=================================");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Update Book");
                Console.WriteLine("3. Delete Book");
                Console.WriteLine("4. Get Book By ID");
                Console.WriteLine("5. Get All Books");
                Console.WriteLine("6. Search and Filter Books");
                Console.WriteLine("7. Return to Main Menu");
                Console.Write("\nSelect an option: ");

                ConsoleKey choice = Console.ReadKey().Key;

                switch (choice)
                {
                    case ConsoleKey.NumPad1:
                        await AddBookAsync();
                        break;

                    case ConsoleKey.NumPad2:
                        await UpdateBookAsync();
                        break;

                    case ConsoleKey.NumPad3:
                        await DeleteBookAsync();
                        break;

                    case ConsoleKey.NumPad4:
                        await GetBookById();
                        break;

                    case ConsoleKey.NumPad5:
                        await GetAllBooks();
                        break;

                    case ConsoleKey.NumPad6:
                        await SearchAndFilterOnBooks();
                        break;

                    case ConsoleKey.NumPad7:
                        return;

                    default:
                        Console.WriteLine("\nInvalid option! Please enter a number between 1 and 7.");
                        EndExecute();
                        break;
                }
            }
        }
        private async Task AddBookAsync()
        {
            StartExecute("Add New Book");
            Book newBook = Book.Create(await _categoryRepository.GetAllCategoriesAsync());
            await _bookRepository.AddAsync(newBook);
            EndMessageOfAddAndUpdateAndDelete("add",await _unitOfWork.SaveChangesAsync() > 0);
        }
        private async Task DeleteBookAsync()
        {
            StartExecute("--- Delete Book ---");
            Book? bookWillDelete = await GetEntityByIdAndCheckIsValidOrNotAsync(_bookRepository.GetByIdAsync);
            if (bookWillDelete is null)
                return;
            Console.Write($"Are you sure you want to delete '{bookWillDelete.Title}'? (y/n): ");
            ConsoleKey confirm = Console.ReadKey().Key;

            if (confirm == ConsoleKey.Y)
            {
                _bookRepository.Delete(bookWillDelete);
                EndMessageOfAddAndUpdateAndDelete("delete",await _unitOfWork.SaveChangesAsync() > 0);
            }
            else
            {
                Console.WriteLine("\nOperation cancelled");
                EndExecute();
            }

        }
        private int GetValidId()
        {
            Console.Write("Enter the book Id: ");
            int bookId;
            while (!int.TryParse(Console.ReadLine(), out bookId) && bookId < 1)
                Console.Write("Invalid value enter another one: ");
            return bookId;
        }
        private async Task<Book?> GetEntityByIdAndCheckIsValidOrNotAsync(Func<int, Task<Book?>> funcToGetBookById)
        {
            Book? book = await funcToGetBookById.Invoke(GetValidId());
            if (book is null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You enter invalid book Id try again");
                Console.ForegroundColor = ConsoleColor.White;
                EndExecute();
                return null;
            }
            return book;
        }
        private async Task UpdateBookAsync()
        {
            StartExecute("--- Update Book ---");
            Book? bookWillUpdate = await GetEntityByIdAndCheckIsValidOrNotAsync(_bookRepository.GetByIdAsync);
            if (bookWillUpdate is null)
                return;
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Choose what you want to update: ");
                
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                Console.WriteLine("1) Update title");
                Console.WriteLine("2) Update author");
                Console.WriteLine("3) Update publish year");
                Console.WriteLine("4) Update price");
                Console.WriteLine("5) Update category");
                Console.WriteLine("6) ignore update");
                Console.WriteLine("7) Exit");
                switch (keyInfo.Key)
                {
                    case ConsoleKey.D1:
                        bookWillUpdate.UpdateTitle();
                        Console.WriteLine("The title update done");
                        break;
                    case ConsoleKey.D2:
                        bookWillUpdate.UpdateAuthor();
                        Console.WriteLine("The Author update done");
                        break;
                    case ConsoleKey.D3:
                        bookWillUpdate.UpdatePublishedYear();
                        Console.WriteLine("The Published Year update done");
                        break;
                    case ConsoleKey.D4:
                        bookWillUpdate.UpdatePrice();
                        Console.WriteLine("The Price update done");
                        break;
                    case ConsoleKey.D5:
                        bookWillUpdate.UpdateCategoryId(await _categoryRepository.GetAllCategoriesAsync());
                        Console.WriteLine("The Category update done");
                        break;
                    case ConsoleKey.D6:
                        Console.WriteLine("The Update book is cancel");
                        EndExecute();
                        return;
                    case ConsoleKey.D7:
                        flag = false;
                        break;
                    default:
                        break;
                }
            }
            _bookRepository.Update(bookWillUpdate);
            EndMessageOfAddAndUpdateAndDelete("update",await _unitOfWork.SaveChangesAsync() > 0);
        }
        private async Task GetBookById()
        {
            StartExecute("--- Find Book by ID ---");
            Book? book = await GetEntityByIdAndCheckIsValidOrNotAsync(_bookRepository.GetBookWithCategoryByIdAsync);
            if (book is null)
                return;
            Console.WriteLine(book);
            EndExecute();
        }
        private async Task GetAllBooks()
        {
            StartExecute("--- All Books ---");
            List<Book> books = await _bookRepository.GetAllBooksWithCategoryAsync();
            if(books.IsNullOrEmpty())
                Console.WriteLine("There is no books yet");
            else
                foreach (var book in books)
                    Console.WriteLine(book);
            EndExecute();
        }
        private async Task SearchAndFilterOnBooks()
        {
            ConsoleKey finishFilter = ConsoleKey.Enter;

            while (finishFilter == ConsoleKey.Enter)
            {
                StartExecute("--- Search and Filter Books ---");
                IQueryable<Book> query =  _bookRepository.GetAllBooksWithCategory();

                Console.Write("Enter book title search term: ");
                string? titleTerm = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(titleTerm))
                    query = query.Where(b => b.Title.Contains(titleTerm));

                Console.WriteLine("\nPrice Filter Options:");
                Console.WriteLine("1) Cheaper than a specific price");
                Console.WriteLine("2) More expensive than a specific price");
                Console.WriteLine("Press Enter to skip price filtering.");
                Console.Write("Select option: ");
                ConsoleKey priceChoice = Console.ReadKey().Key;

                if (priceChoice == ConsoleKey.D1 || priceChoice == ConsoleKey.D2)
                {
                    Console.Write("Enter the price amount: ");
                    double priceValue;
                    while (!double.TryParse(Console.ReadLine(), out priceValue) || priceValue < 0)
                        Console.Write("Invalid value Enter price again: ");
                    if (priceChoice == ConsoleKey.D1)
                        query = query.Where(b => b.Price < priceValue);
                    else
                        query = query.Where(b => b.Price > priceValue);
                }

                Console.Write("\nDisplay books published after year: ");
                string? yearInput = Console.ReadLine();
                if (int.TryParse(yearInput, out int yearValue))
                    query = query.Where(b => b.PublishedYear > yearValue);

                Console.WriteLine("\nSort Options:");
                Console.WriteLine("1) Title");
                Console.WriteLine("2) Price Ascending");
                Console.WriteLine("3) Price Descending");
                Console.WriteLine("Press Enter to skip sorting.");
                Console.Write("Select sort option: ");
                ConsoleKey? sortChoice = Console.ReadKey().Key;

                query = sortChoice switch
                {
                    ConsoleKey.D1 => query.OrderBy(b => b.Title),
                    ConsoleKey.D2 => query.OrderBy(b => b.Price),
                    ConsoleKey.D3 => query.OrderByDescending(b => b.Price),
                    _ => query
                };

                List<Book> result = await query.ToListAsync();

                Console.Clear();
                Console.WriteLine("=================================");
                Console.WriteLine($"         Search Result          ");
                Console.WriteLine("=================================");

                if (result.Count == 0)
                    Console.WriteLine("\nNo books matched your criteria.");
                else
                    foreach (var book in result)
                        Console.WriteLine(book);

                Console.WriteLine("\nPress any key to return to the main menu or Enter to make new search");
                finishFilter =  Console.ReadKey().Key;                
            }
        }

    }
}
