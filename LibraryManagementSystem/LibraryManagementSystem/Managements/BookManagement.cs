using LibraryManagementSystem.Entities;
using LibraryManagementSystem.Interfaces;
using LibraryManagementSystem.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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
        public async Task<bool> AddBookAsync()
        {
            Book newBook = Book.Create(await _categoryRepository.GetAllCategoriesAsync());
            await _bookRepository.AddAsync(newBook);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }
        public async Task DeleteBookAsync()
        {
            Book? bookWillDelete = await GetBookAndCheckIsValidAsync();
            if (bookWillDelete is null)
                return;
            _bookRepository.Delete(bookWillDelete);
            await _unitOfWork.SaveChangesAsync();
        }
        private int GetValidId()
        {
            Console.Write("Enter the book Id: ");
            int bookId;
            while (!int.TryParse(Console.ReadLine(), out bookId) && bookId < 1)
                Console.Write("Invalid value enter another one: ");
            return bookId;
        }
        private async Task<Book?> GetBookAndCheckIsValidAsync()
        {
            int bookId = GetValidId();
            Book? book = await _bookRepository.GetByIdAsync(bookId);
            if (book is null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You enter invalid book Id try again");
                Console.ForegroundColor = ConsoleColor.White;
                return null;
            }
            return book;


        }
        public async Task UpdateBookAsync()
        {
            Book? bookWillUpdate = await GetBookAndCheckIsValidAsync();
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
                        return;
                    case ConsoleKey.D7:
                        flag = false;
                        return;
                    default:
                        break;
                }
            }
            _bookRepository.Update(bookWillUpdate);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task GetBookById()
        {
            int bookId = GetValidId();
            Book? book = await _bookRepository.GetBookWithCategoryByIdAsync(bookId);
            if (book is null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You enter invalid book Id try again");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            Console.WriteLine(book);
        }
        public async Task GetAllBooks()
        {
            List<Book> books = await _bookRepository.GetAllBooksWithCategoryAsync();
            if(books.IsNullOrEmpty())
                Console.WriteLine("There is no books yet");
            else
                foreach (var book in books)
                    Console.WriteLine(book);
        }
        public async Task SearchAndFilterOnBooks()
        {
            ConsoleKey finishFilter = ConsoleKey.Enter;

            while (finishFilter == ConsoleKey.Enter)
            {
                IQueryable<Book> query =  _bookRepository.GetAllBooksWithCategory();

                Console.Clear();
                Console.WriteLine("=================================");
                Console.WriteLine("     Search and Filter Books     ");
                Console.WriteLine("=================================");

                Console.Write("Enter book title search term (leave blank to skip): ");
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
                    while (double.TryParse(Console.ReadLine(), out priceValue))
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
                Console.WriteLine($"      Search Results ({result.Count})     ");
                Console.WriteLine("=================================");

                if (result.Count == 0)
                    Console.WriteLine("No books matched your criteria.");
                else
                    foreach (var book in result)
                        Console.WriteLine(book);

                Console.WriteLine("\nPress any key to return to the main menu or Enter to make new search");
                finishFilter =  Console.ReadKey().Key;                
            }
        }

    }
}
