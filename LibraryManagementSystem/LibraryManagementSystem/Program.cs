using LibraryManagementSystem.Data;
using LibraryManagementSystem.Interfaces;
using LibraryManagementSystem.Interfaces.IRepositories;
using LibraryManagementSystem.Managements;
using LibraryManagementSystem.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManagementSystem
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            bool exit = false;

            var services = new ServiceCollection();

            RegisterAllServices(services);

            using var serviceProvider = services.BuildServiceProvider();

            BookManagement bookManagement = serviceProvider.GetRequiredService<BookManagement>();
            CategoryManagement categoryManagement = serviceProvider.GetRequiredService<CategoryManagement>();
            MemberManagement memberManagement = serviceProvider.GetRequiredService<MemberManagement>();
            BorrowingManagement borrowingManagement = serviceProvider.GetRequiredService<BorrowingManagement>();
            ReportManagement ReportManagement = serviceProvider.GetRequiredService<ReportManagement>();

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=================================");
                Console.WriteLine("    Library Management System    ");
                Console.WriteLine("=================================");
                Console.WriteLine("1. Book Management");
                Console.WriteLine("2. Category Management");
                Console.WriteLine("3. Member Management");
                Console.WriteLine("4. Borrowing Management");
                Console.WriteLine("5. Reports");
                Console.WriteLine("6. Exit");
                Console.Write("\nSelect an option: ");

                ConsoleKeyInfo choice = Console.ReadKey();

                switch (choice.Key)
                {
                    case ConsoleKey.NumPad1:
                        await bookManagement.ShowMenuAsync();
                        break;

                    case ConsoleKey.NumPad2:
                        await categoryManagement.ShowMenuAsync();
                        break;

                    case ConsoleKey.NumPad3:
                        await memberManagement.ShowMenuAsync();
                        break;

                    case ConsoleKey.NumPad4:
                        await borrowingManagement.ShowMenuAsync();
                        break;

                    case ConsoleKey.NumPad5:
                        await ReportManagement.ShowMenuAsync();
                        break;

                    case ConsoleKey.NumPad6:
                        exit = true;
                        Console.WriteLine("\nExiting application.");
                        break;

                    default:
                        Console.WriteLine("\nInvalid option! Please enter a number between 1 and 6. Press any key to try again.");
                        Console.WriteLine("Press any Key to continue...");
                        Console.ReadKey();
                        break;
                }

            }
        }

        private static void RegisterAllServices(ServiceCollection services)
        {
            var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

            //services.AddSingleton<IConfiguration>(configuration);

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Default")));

            // Register Repositories and Unit of Work
            services.AddScoped<IMemberRepository, MemberRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IBorrowingRepository, BorrowingRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Register Management classes
            services.AddTransient<BorrowingManagement>();
            services.AddTransient<ReportManagement>();
            services.AddTransient<BookManagement>();
            services.AddTransient<CategoryManagement>();
            services.AddTransient<MemberManagement>();

        }
    }
}
