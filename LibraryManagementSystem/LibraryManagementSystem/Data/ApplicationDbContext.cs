using LibraryManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace LibraryManagementSystem.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Book> Books => Set<Book>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Member> Members => Set<Member>();
        public DbSet<Borrowing> Borrowings => Set<Borrowing>();

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        //    optionsBuilder.UseSqlServer(configuration.GetConnectionString("Default"));
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            AddSeedingData(modelBuilder);
        
        }

        private void AddSeedingData(ModelBuilder modelBuilder)
        {
            var categories = new[]
            {
                new { Id = 1, Name = "Software Engineering" },
                new { Id = 2, Name = "Database Architecture" },
                new { Id = 3, Name = "Computer Science" },
                new { Id = 4, Name = "Hardware & Embedded Systems" },
                new { Id = 5, Name = "Cloud & DevOps" },
                new { Id = 6, Name = "Frontend Development" },
                new { Id = 7, Name = "Science Fiction" },
                new { Id = 8, Name = "Classic Literature" },
                new { Id = 9, Name = "History" },
                new { Id = 10, Name = "Business & Productivity" }
            };

            var members = new[]
            {
                new { Id = 1, Name = "Omar Gomaa", Email = "omar@example.com", Phone = "01011112222" },
                new { Id = 2, Name = "Ahmed Mostafa", Email = "ahmed.e@example.com", Phone = "01022223333" },
                new { Id = 3, Name = "Ali Omar", Email = "Ali@example.com", Phone = "01033334444" },
                new { Id = 4, Name = "Malak Khaled", Email = "Malak@example.com", Phone = "01044445555" },
                new { Id = 5, Name = "Osman Mohammed", Email = "Osman@example.com", Phone = "01055556666" },
                new { Id = 6, Name = "Mohamed Bakr", Email = "mohamed.b@example.com", Phone = "01066667777" },
                new { Id = 7, Name = "Mennatallah Madian", Email = "menna@example.com", Phone = "01077778888" },
                new { Id = 8, Name = "Abdoo Sherif", Email = "abdoo@example.com", Phone = "01088889999" },
                new { Id = 9, Name = "Abdullah Saied", Email = "abdullah@example.com", Phone = "01099990000" },
                new { Id = 10, Name = "Omar Khaled", Email = "omar.k@example.com", Phone = "01112223333" },
                new { Id = 11, Name = "Essam Youssef", Email = "essam@example.com", Phone = "01123334444" },
                new { Id = 12, Name = "Nourhan Tarek", Email = "nourhan@example.com", Phone = "01134445555" },
                new { Id = 13, Name = "Karim Mostafa", Email = "karim@example.com", Phone = "01145556666" },
                new { Id = 14, Name = "Hadeer Ibrahim", Email = "hadeer@example.com", Phone = "01156667777" },
                new { Id = 15, Name = "Mahmoud Fawzy", Email = "mahmoud@example.com", Phone = "01167778888" },
                new { Id = 16, Name = "Nada Hassan", Email = "nada@example.com", Phone = "01278889999" },
                new { Id = 17, Name = "Ziad Kamal", Email = "ziad@example.com", Phone = "01289990000" },
                new { Id = 18, Name = "Farah Nabil", Email = "farah@example.com", Phone = "01290001111" },
                new { Id = 19, Name = "Youssef Ahmed", Email = "youssef@example.com", Phone = "01511112222" },
                new { Id = 20, Name = "Khaled Zaki", Email = "khaled@example.com", Phone = "01522223333" }
            };
            
            var books = new[]
            {
                // Software Engineering
                new { Id = 1, CategoryId = 1, Title = "Clean Architecture", Author = "Robert C. Martin", Price = 45.0, PublishedYear = 2017 },
                new { Id = 2, CategoryId = 1, Title = "C# in Depth", Author = "Jon Skeet", Price = 49.99, PublishedYear = 2019 },
                new { Id = 3, CategoryId = 1, Title = "Domain-Driven Design", Author = "Eric Evans", Price = 55.0, PublishedYear = 2003 },
                new { Id = 4, CategoryId = 1, Title = "Clean Code", Author = "Robert C. Martin", Price = 40.0, PublishedYear = 2008 },
                new { Id = 5, CategoryId = 1, Title = "Pro ASP.NET Core", Author = "Adam Freeman", Price = 52.0, PublishedYear = 2022 },
                // Database Architecture
                new { Id = 6, CategoryId = 2, Title = "Designing Data-Intensive Applications", Author = "Martin Kleppmann", Price = 39.99, PublishedYear = 2017 },
                new { Id = 7, CategoryId = 2, Title = "T-SQL Fundamentals", Author = "Itzik Ben-Gan", Price = 35.0, PublishedYear = 2016 },
                new { Id = 8, CategoryId = 2, Title = "Entity Framework Core in Action", Author = "Jon Smith", Price = 42.0, PublishedYear = 2021 },
                new { Id = 9, CategoryId = 2, Title = "PostgreSQL: Up and Running", Author = "Regina O. Obe", Price = 38.0, PublishedYear = 2017 },
                new { Id = 10, CategoryId = 2, Title = "Database System Concepts", Author = "Abraham Silberschatz", Price = 85.0, PublishedYear = 2019 },
                // Computer Science
                new { Id = 11, CategoryId = 3, Title = "Introduction to Algorithms", Author = "Thomas H. Cormen", Price = 95.0, PublishedYear = 2009 },
                new { Id = 12, CategoryId = 3, Title = "Grokking Algorithms", Author = "Aditya Bhargava", Price = 34.0, PublishedYear = 2016 },
                new { Id = 13, CategoryId = 3, Title = "Code Complete", Author = "Steve McConnell", Price = 45.0, PublishedYear = 2004 },
                new { Id = 14, CategoryId = 3, Title = "The Pragmatic Programmer", Author = "David Thomas", Price = 40.0, PublishedYear = 2019 },
                new { Id = 15, CategoryId = 3, Title = "Refactoring", Author = "Martin Fowler", Price = 48.0, PublishedYear = 2018 },
                // Hardware & Embedded Systems
                new { Id = 16, CategoryId = 4, Title = "Digital Design and Computer Architecture", Author = "David Harris", Price = 75.0, PublishedYear = 2012 },
                new { Id = 17, CategoryId = 4, Title = "Embedded C Programming", Author = "Mark Siegesmund", Price = 55.0, PublishedYear = 2014 },
                new { Id = 18, CategoryId = 4, Title = "STM32 Microcontroller Programming", Author = "Dogan Ibrahim", Price = 45.0, PublishedYear = 2020 },
                new { Id = 19, CategoryId = 4, Title = "VHDL for Engineers", Author = "Kenneth L. Short", Price = 65.0, PublishedYear = 2008 },
                new { Id = 20, CategoryId = 4, Title = "MIPS Assembly Language Programming", Author = "Robert Britton", Price = 35.0, PublishedYear = 2003 },
                // Cloud & DevOps
                new { Id = 21, CategoryId = 5, Title = "Docker Deep Dive", Author = "Nigel Poulton", Price = 30.0, PublishedYear = 2020 },
                new { Id = 22, CategoryId = 5, Title = "Kubernetes Up & Running", Author = "Brendan Burns", Price = 42.0, PublishedYear = 2019 },
                new { Id = 23, CategoryId = 5, Title = "The Phoenix Project", Author = "Gene Kim", Price = 25.0, PublishedYear = 2013 },
                new { Id = 24, CategoryId = 5, Title = "Continuous Delivery", Author = "Jez Humble", Price = 45.0, PublishedYear = 2010 },
                new { Id = 25, CategoryId = 5, Title = "Cloud Native Patterns", Author = "Cornelia Davis", Price = 40.0, PublishedYear = 2019 },
                // Frontend Development
                new { Id = 26, CategoryId = 6, Title = "Angular Up and Running", Author = "Shyam Seshadri", Price = 38.0, PublishedYear = 2018 },
                new { Id = 27, CategoryId = 6, Title = "Blazor WebAssembly by Example", Author = "Toi B. Wright", Price = 44.0, PublishedYear = 2021 },
                new { Id = 28, CategoryId = 6, Title = "JavaScript: The Good Parts", Author = "Douglas Crockford", Price = 29.0, PublishedYear = 2008 },
                new { Id = 29, CategoryId = 6, Title = "HTML5 and CSS3", Author = "Brian Hogan", Price = 32.0, PublishedYear = 2013 },
                new { Id = 30, CategoryId = 6, Title = "Learning TypeScript", Author = "Josh Goldberg", Price = 39.0, PublishedYear = 2022 },
                // Science Fiction
                new { Id = 31, CategoryId = 7, Title = "Dune", Author = "Frank Herbert", Price = 15.99, PublishedYear = 1965 },
                new { Id = 32, CategoryId = 7, Title = "Foundation", Author = "Isaac Asimov", Price = 14.99, PublishedYear = 1951 },
                new { Id = 33, CategoryId = 7, Title = "Neuromancer", Author = "William Gibson", Price = 16.0, PublishedYear = 1984 },
                new { Id = 34, CategoryId = 7, Title = "Snow Crash", Author = "Neal Stephenson", Price = 17.50, PublishedYear = 1992 },
                new { Id = 35, CategoryId = 7, Title = "The Martian", Author = "Andy Weir", Price = 18.0, PublishedYear = 2014 },
                // Classic Literature
                new { Id = 36, CategoryId = 8, Title = "1984", Author = "George Orwell", Price = 12.0, PublishedYear = 1949 },
                new { Id = 37, CategoryId = 8, Title = "To Kill a Mockingbird", Author = "Harper Lee", Price = 14.0, PublishedYear = 1960 },
                new { Id = 38, CategoryId = 8, Title = "Pride and Prejudice", Author = "Jane Austen", Price = 10.0, PublishedYear = 1813 },
                new { Id = 39, CategoryId = 8, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Price = 11.50, PublishedYear = 1925 },
                new { Id = 40, CategoryId = 8, Title = "Moby Dick", Author = "Herman Melville", Price = 15.0, PublishedYear = 1851 },
                // History
                new { Id = 41, CategoryId = 9, Title = "Sapiens", Author = "Yuval Noah Harari", Price = 22.0, PublishedYear = 2011 },
                new { Id = 42, CategoryId = 9, Title = "Guns, Germs, and Steel", Author = "Jared Diamond", Price = 20.0, PublishedYear = 1997 },
                new { Id = 43, CategoryId = 9, Title = "A People's History", Author = "Howard Zinn", Price = 19.50, PublishedYear = 1980 },
                new { Id = 44, CategoryId = 9, Title = "The Silk Roads", Author = "Peter Frankopan", Price = 24.0, PublishedYear = 2015 },
                new { Id = 45, CategoryId = 9, Title = "SPQR: A History of Ancient Rome", Author = "Mary Beard", Price = 21.0, PublishedYear = 2015 },
                // Business & Productivity
                new { Id = 46, CategoryId = 10, Title = "Thinking, Fast and Slow", Author = "Daniel Kahneman", Price = 18.0, PublishedYear = 2011 },
                new { Id = 47, CategoryId = 10, Title = "Atomic Habits", Author = "James Clear", Price = 20.0, PublishedYear = 2018 },
                new { Id = 48, CategoryId = 10, Title = "Good to Great", Author = "Jim Collins", Price = 22.0, PublishedYear = 2001 },
                new { Id = 49, CategoryId = 10, Title = "The Lean Startup", Author = "Eric Ries", Price = 19.0, PublishedYear = 2011 },
                new { Id = 50, CategoryId = 10, Title = "Zero to One", Author = "Peter Thiel", Price = 17.50, PublishedYear = 2014 }
            };
        
            var borrowings = new[]
            {
                // --- JUNE BORROWINGS (Returned in June) ---
                new { Id = 1, MemberId = 1, BookId = 1, BorrowDate = new DateTime(2026, 6, 2), ReturnDate = (DateTime?)new DateTime(2026, 6, 12) },
                new { Id = 2, MemberId = 1, BookId = 2, BorrowDate = new DateTime(2026, 6, 3), ReturnDate = (DateTime?)new DateTime(2026, 6, 10) },
                new { Id = 3, MemberId = 2, BookId = 3, BorrowDate = new DateTime(2026, 6, 4), ReturnDate = (DateTime?)new DateTime(2026, 6, 15) },
                new { Id = 4, MemberId = 2, BookId = 8, BorrowDate = new DateTime(2026, 6, 5), ReturnDate = (DateTime?)new DateTime(2026, 6, 14) },
                new { Id = 5, MemberId = 3, BookId = 1, BorrowDate = new DateTime(2026, 6, 5), ReturnDate = (DateTime?)new DateTime(2026, 6, 20) },
                new { Id = 6, MemberId = 3, BookId = 11, BorrowDate = new DateTime(2026, 6, 6), ReturnDate = (DateTime?)new DateTime(2026, 6, 18) },
                new { Id = 7, MemberId = 4, BookId = 4, BorrowDate = new DateTime(2026, 6, 8), ReturnDate = (DateTime?)new DateTime(2026, 6, 22) },
                new { Id = 8, MemberId = 5, BookId = 5, BorrowDate = new DateTime(2026, 6, 9), ReturnDate = (DateTime?)new DateTime(2026, 6, 16) },
                new { Id = 9, MemberId = 6, BookId = 2, BorrowDate = new DateTime(2026, 6, 10), ReturnDate = (DateTime?)new DateTime(2026, 6, 15) },
                new { Id = 10, MemberId = 7, BookId = 6, BorrowDate = new DateTime(2026, 6, 11), ReturnDate = (DateTime?)new DateTime(2026, 6, 25) },
                new { Id = 11, MemberId = 8, BookId = 10, BorrowDate = new DateTime(2026, 6, 12), ReturnDate = (DateTime?)new DateTime(2026, 6, 20) },
                new { Id = 12, MemberId = 9, BookId = 12, BorrowDate = new DateTime(2026, 6, 12), ReturnDate = (DateTime?)new DateTime(2026, 6, 21) },
                new { Id = 13, MemberId = 10, BookId = 13, BorrowDate = new DateTime(2026, 6, 13), ReturnDate = (DateTime?)new DateTime(2026, 6, 24) },
                new { Id = 14, MemberId = 11, BookId = 14, BorrowDate = new DateTime(2026, 6, 14), ReturnDate = (DateTime?)new DateTime(2026, 6, 26) },
                new { Id = 15, MemberId = 12, BookId = 15, BorrowDate = new DateTime(2026, 6, 15), ReturnDate = (DateTime?)new DateTime(2026, 6, 27) },
                new { Id = 16, MemberId = 13, BookId = 1, BorrowDate = new DateTime(2026, 6, 16), ReturnDate = (DateTime?)new DateTime(2026, 6, 28) },
                new { Id = 17, MemberId = 14, BookId = 23, BorrowDate = new DateTime(2026, 6, 17), ReturnDate = (DateTime?)new DateTime(2026, 6, 29) },
                new { Id = 18, MemberId = 15, BookId = 24, BorrowDate = new DateTime(2026, 6, 18), ReturnDate = (DateTime?)new DateTime(2026, 6, 30) },
                new { Id = 19, MemberId = 16, BookId = 25, BorrowDate = new DateTime(2026, 6, 19), ReturnDate = (DateTime?)new DateTime(2026, 6, 25) },
                new { Id = 20, MemberId = 17, BookId = 28, BorrowDate = new DateTime(2026, 6, 20), ReturnDate = (DateTime?)new DateTime(2026, 6, 28) },

                // --- JUNE BORROWINGS (Returned in July) ---
                new { Id = 21, MemberId = 18, BookId = 29, BorrowDate = new DateTime(2026, 6, 22), ReturnDate = (DateTime?)new DateTime(2026, 7, 2) },
                new { Id = 22, MemberId = 19, BookId = 30, BorrowDate = new DateTime(2026, 6, 23), ReturnDate = (DateTime?)new DateTime(2026, 7, 5) },
                new { Id = 23, MemberId = 20, BookId = 33, BorrowDate = new DateTime(2026, 6, 24), ReturnDate = (DateTime?)new DateTime(2026, 7, 8) },
                new { Id = 24, MemberId = 4, BookId = 7, BorrowDate = new DateTime(2026, 6, 25), ReturnDate = (DateTime?)new DateTime(2026, 7, 10) },
                new { Id = 25, MemberId = 4, BookId = 26, BorrowDate = new DateTime(2026, 6, 26), ReturnDate = (DateTime?)new DateTime(2026, 7, 12) },
                new { Id = 26, MemberId = 5, BookId = 27, BorrowDate = new DateTime(2026, 6, 27), ReturnDate = (DateTime?)new DateTime(2026, 7, 15) },
                new { Id = 27, MemberId = 6, BookId = 17, BorrowDate = new DateTime(2026, 6, 28), ReturnDate = (DateTime?)new DateTime(2026, 7, 5) },
                new { Id = 28, MemberId = 8, BookId = 19, BorrowDate = new DateTime(2026, 6, 28), ReturnDate = (DateTime?)new DateTime(2026, 7, 7) },
                new { Id = 29, MemberId = 10, BookId = 31, BorrowDate = new DateTime(2026, 6, 29), ReturnDate = (DateTime?)new DateTime(2026, 7, 9) },
                new { Id = 30, MemberId = 3, BookId = 43, BorrowDate = new DateTime(2026, 6, 30), ReturnDate = (DateTime?)new DateTime(2026, 7, 11) },

                // --- JULY BORROWINGS (Returned in July) ---
                new { Id = 31, MemberId = 2, BookId = 21, BorrowDate = new DateTime(2026, 7, 1), ReturnDate = (DateTime?)new DateTime(2026, 7, 10) },
                new { Id = 32, MemberId = 7, BookId = 18, BorrowDate = new DateTime(2026, 7, 2), ReturnDate = (DateTime?)new DateTime(2026, 7, 15) },
                new { Id = 33, MemberId = 9, BookId = 20, BorrowDate = new DateTime(2026, 7, 3), ReturnDate = (DateTime?)new DateTime(2026, 7, 12) },
                new { Id = 34, MemberId = 11, BookId = 36, BorrowDate = new DateTime(2026, 7, 4), ReturnDate = (DateTime?)new DateTime(2026, 7, 18) },
                new { Id = 35, MemberId = 12, BookId = 41, BorrowDate = new DateTime(2026, 7, 5), ReturnDate = (DateTime?)new DateTime(2026, 7, 14) },
                new { Id = 36, MemberId = 13, BookId = 22, BorrowDate = new DateTime(2026, 7, 6), ReturnDate = (DateTime?)new DateTime(2026, 7, 20) },
                new { Id = 37, MemberId = 14, BookId = 46, BorrowDate = new DateTime(2026, 7, 7), ReturnDate = (DateTime?)new DateTime(2026, 7, 16) },
                new { Id = 38, MemberId = 15, BookId = 32, BorrowDate = new DateTime(2026, 7, 8), ReturnDate = (DateTime?)new DateTime(2026, 7, 22) },
                new { Id = 39, MemberId = 16, BookId = 47, BorrowDate = new DateTime(2026, 7, 9), ReturnDate = (DateTime?)new DateTime(2026, 7, 19) },
                new { Id = 40, MemberId = 17, BookId = 37, BorrowDate = new DateTime(2026, 7, 10), ReturnDate = (DateTime?)new DateTime(2026, 7, 24) },
                new { Id = 41, MemberId = 18, BookId = 42, BorrowDate = new DateTime(2026, 7, 11), ReturnDate = (DateTime?)new DateTime(2026, 7, 21) },
                new { Id = 42, MemberId = 19, BookId = 48, BorrowDate = new DateTime(2026, 7, 12), ReturnDate = (DateTime?)new DateTime(2026, 7, 25) },
                new { Id = 43, MemberId = 20, BookId = 49, BorrowDate = new DateTime(2026, 7, 13), ReturnDate = (DateTime?)new DateTime(2026, 7, 23) },
                new { Id = 44, MemberId = 1, BookId = 34, BorrowDate = new DateTime(2026, 7, 14), ReturnDate = (DateTime?)new DateTime(2026, 7, 26) },
                new { Id = 45, MemberId = 2, BookId = 38, BorrowDate = new DateTime(2026, 7, 15), ReturnDate = (DateTime?)new DateTime(2026, 7, 28) },
                new { Id = 46, MemberId = 4, BookId = 50, BorrowDate = new DateTime(2026, 7, 16), ReturnDate = (DateTime?)new DateTime(2026, 7, 27) },
                new { Id = 47, MemberId = 5, BookId = 35, BorrowDate = new DateTime(2026, 7, 17), ReturnDate = (DateTime?)new DateTime(2026, 7, 29) },
                new { Id = 48, MemberId = 6, BookId = 39, BorrowDate = new DateTime(2026, 7, 18), ReturnDate = (DateTime?)new DateTime(2026, 7, 30) },
                new { Id = 49, MemberId = 7, BookId = 44, BorrowDate = new DateTime(2026, 7, 19), ReturnDate = (DateTime?)new DateTime(2026, 7, 31) },
                new { Id = 50, MemberId = 8, BookId = 1, BorrowDate = new DateTime(2026, 7, 20), ReturnDate = (DateTime?)new DateTime(2026, 7, 28) },

                // --- JULY BORROWINGS (Returned in August) ---
                new { Id = 51, MemberId = 9, BookId = 2, BorrowDate = new DateTime(2026, 7, 21), ReturnDate = (DateTime?)new DateTime(2026, 8, 2) },
                new { Id = 52, MemberId = 10, BookId = 3, BorrowDate = new DateTime(2026, 7, 22), ReturnDate = (DateTime?)new DateTime(2026, 8, 5) },
                new { Id = 53, MemberId = 11, BookId = 4, BorrowDate = new DateTime(2026, 7, 23), ReturnDate = (DateTime?)new DateTime(2026, 8, 4) },
                new { Id = 54, MemberId = 12, BookId = 5, BorrowDate = new DateTime(2026, 7, 24), ReturnDate = (DateTime?)new DateTime(2026, 8, 8) },
                new { Id = 55, MemberId = 13, BookId = 6, BorrowDate = new DateTime(2026, 7, 25), ReturnDate = (DateTime?)new DateTime(2026, 8, 6) },
                new { Id = 56, MemberId = 14, BookId = 7, BorrowDate = new DateTime(2026, 7, 26), ReturnDate = (DateTime?)new DateTime(2026, 8, 10) },
                new { Id = 57, MemberId = 15, BookId = 8, BorrowDate = new DateTime(2026, 7, 27), ReturnDate = (DateTime?)new DateTime(2026, 8, 7) },
                new { Id = 58, MemberId = 16, BookId = 9, BorrowDate = new DateTime(2026, 7, 28), ReturnDate = (DateTime?)new DateTime(2026, 8, 12) },
                new { Id = 59, MemberId = 17, BookId = 10, BorrowDate = new DateTime(2026, 7, 29), ReturnDate = (DateTime?)new DateTime(2026, 8, 9) },
                new { Id = 60, MemberId = 18, BookId = 11, BorrowDate = new DateTime(2026, 7, 30), ReturnDate = (DateTime?)new DateTime(2026, 8, 14) },

                // --- AUGUST BORROWINGS (Some returned, some active) ---
                new { Id = 61, MemberId = 19, BookId = 12, BorrowDate = new DateTime(2026, 8, 1), ReturnDate = (DateTime?)new DateTime(2026, 8, 12) },
                new { Id = 62, MemberId = 20, BookId = 13, BorrowDate = new DateTime(2026, 8, 2), ReturnDate = (DateTime?)new DateTime(2026, 8, 15) },
                new { Id = 63, MemberId = 1, BookId = 14, BorrowDate = new DateTime(2026, 8, 3), ReturnDate = (DateTime?)new DateTime(2026, 8, 14) },
                new { Id = 64, MemberId = 2, BookId = 15, BorrowDate = new DateTime(2026, 8, 4), ReturnDate = (DateTime?)new DateTime(2026, 8, 18) },
                new { Id = 65, MemberId = 3, BookId = 16, BorrowDate = new DateTime(2026, 8, 5), ReturnDate = (DateTime?)new DateTime(2026, 8, 16) },
                new { Id = 66, MemberId = 4, BookId = 17, BorrowDate = new DateTime(2026, 8, 6), ReturnDate = (DateTime?)new DateTime(2026, 8, 20) },
                new { Id = 67, MemberId = 5, BookId = 18, BorrowDate = new DateTime(2026, 8, 7), ReturnDate = (DateTime?)new DateTime(2026, 8, 19) },
                new { Id = 68, MemberId = 6, BookId = 19, BorrowDate = new DateTime(2026, 8, 8), ReturnDate = (DateTime?)new DateTime(2026, 8, 22) },
                new { Id = 69, MemberId = 7, BookId = 20, BorrowDate = new DateTime(2026, 8, 9), ReturnDate = (DateTime?)new DateTime(2026, 8, 21) },
                new { Id = 70, MemberId = 8, BookId = 21, BorrowDate = new DateTime(2026, 8, 10), ReturnDate = (DateTime?)new DateTime(2026, 8, 25) },
                new { Id = 71, MemberId = 9, BookId = 22, BorrowDate = new DateTime(2026, 8, 11), ReturnDate = (DateTime?)new DateTime(2026, 8, 23) },
                new { Id = 72, MemberId = 10, BookId = 23, BorrowDate = new DateTime(2026, 8, 12), ReturnDate = (DateTime?)new DateTime(2026, 8, 26) },
                new { Id = 73, MemberId = 11, BookId = 24, BorrowDate = new DateTime(2026, 8, 13), ReturnDate = (DateTime?)new DateTime(2026, 8, 24) },
                new { Id = 74, MemberId = 12, BookId = 25, BorrowDate = new DateTime(2026, 8, 14), ReturnDate = (DateTime?)new DateTime(2026, 8, 28) },
                new { Id = 75, MemberId = 13, BookId = 26, BorrowDate = new DateTime(2026, 8, 15), ReturnDate = (DateTime?)new DateTime(2026, 8, 26) },
                new { Id = 76, MemberId = 14, BookId = 27, BorrowDate = new DateTime(2026, 8, 16), ReturnDate = (DateTime?)new DateTime(2026, 8, 30) },
                new { Id = 77, MemberId = 15, BookId = 28, BorrowDate = new DateTime(2026, 8, 17), ReturnDate = (DateTime?)new DateTime(2026, 8, 27) },
                new { Id = 78, MemberId = 16, BookId = 29, BorrowDate = new DateTime(2026, 8, 18), ReturnDate = (DateTime?)new DateTime(2026, 8, 31) },
                new { Id = 79, MemberId = 17, BookId = 30, BorrowDate = new DateTime(2026, 8, 19), ReturnDate = (DateTime?)new DateTime(2026, 8, 28) },
                new { Id = 80, MemberId = 18, BookId = 31, BorrowDate = new DateTime(2026, 8, 20), ReturnDate = (DateTime?)new DateTime(2026, 9, 2) },

                // --- CURRENTLY ACTIVE BORROWINGS (ReturnDate is null) ---
                new { Id = 81, MemberId = 19, BookId = 32, BorrowDate = new DateTime(2026, 8, 21), ReturnDate = (DateTime?)null },
                new { Id = 82, MemberId = 20, BookId = 33, BorrowDate = new DateTime(2026, 8, 22), ReturnDate = (DateTime?)null },
                new { Id = 83, MemberId = 1, BookId = 34, BorrowDate = new DateTime(2026, 8, 23), ReturnDate = (DateTime?)null },
                new { Id = 84, MemberId = 2, BookId = 35, BorrowDate = new DateTime(2026, 8, 24), ReturnDate = (DateTime?)null },
                new { Id = 85, MemberId = 3, BookId = 36, BorrowDate = new DateTime(2026, 8, 25), ReturnDate = (DateTime?)null },
                new { Id = 86, MemberId = 4, BookId = 37, BorrowDate = new DateTime(2026, 8, 26), ReturnDate = (DateTime?)null },
                new { Id = 87, MemberId = 5, BookId = 38, BorrowDate = new DateTime(2026, 8, 27), ReturnDate = (DateTime?)null },
                new { Id = 88, MemberId = 6, BookId = 39, BorrowDate = new DateTime(2026, 8, 28), ReturnDate = (DateTime?)null },
                new { Id = 89, MemberId = 7, BookId = 40, BorrowDate = new DateTime(2026, 8, 29), ReturnDate = (DateTime?)null },
                new { Id = 90, MemberId = 8, BookId = 41, BorrowDate = new DateTime(2026, 8, 30), ReturnDate = (DateTime?)null },
                new { Id = 91, MemberId = 9, BookId = 42, BorrowDate = new DateTime(2026, 8, 25), ReturnDate = (DateTime?)null },
                new { Id = 92, MemberId = 10, BookId = 43, BorrowDate = new DateTime(2026, 8, 26), ReturnDate = (DateTime?)null },
                new { Id = 93, MemberId = 11, BookId = 44, BorrowDate = new DateTime(2026, 8, 27), ReturnDate = (DateTime?)null },
                new { Id = 94, MemberId = 12, BookId = 45, BorrowDate = new DateTime(2026, 8, 28), ReturnDate = (DateTime?)null },
                new { Id = 95, MemberId = 13, BookId = 46, BorrowDate = new DateTime(2026, 8, 29), ReturnDate = (DateTime?)null },
                new { Id = 96, MemberId = 14, BookId = 47, BorrowDate = new DateTime(2026, 8, 30), ReturnDate = (DateTime?)null },
                new { Id = 97, MemberId = 15, BookId = 48, BorrowDate = new DateTime(2026, 8, 31), ReturnDate = (DateTime?)null },
                new { Id = 98, MemberId = 16, BookId = 49, BorrowDate = new DateTime(2026, 9, 1), ReturnDate = (DateTime?)null },
                new { Id = 99, MemberId = 17, BookId = 50, BorrowDate = new DateTime(2026, 9, 2), ReturnDate = (DateTime?)null },
                new { Id = 100, MemberId = 1, BookId = 16, BorrowDate = new DateTime(2026, 9, 3), ReturnDate = (DateTime?)null }
            };

            modelBuilder.Entity<Category>().HasData(categories);
            modelBuilder.Entity<Member>().HasData(members);
            modelBuilder.Entity<Book>().HasData(books);
            modelBuilder.Entity<Borrowing>().HasData(borrowings);

        }
    }
}
