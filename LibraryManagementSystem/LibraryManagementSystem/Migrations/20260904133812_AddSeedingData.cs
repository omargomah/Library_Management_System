using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Software Engineering" },
                    { 2, "Database Architecture" },
                    { 3, "Computer Science" },
                    { 4, "Hardware & Embedded Systems" },
                    { 5, "Cloud & DevOps" },
                    { 6, "Frontend Development" },
                    { 7, "Science Fiction" },
                    { 8, "Classic Literature" },
                    { 9, "History" },
                    { 10, "Business & Productivity" }
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "Email", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "omar@example.com", "Omar Gomaa", "01011112222" },
                    { 2, "ahmed.e@example.com", "Ahmed Mostafa", "01022223333" },
                    { 3, "Ali@example.com", "Ali Omar", "01033334444" },
                    { 4, "Malak@example.com", "Malak Khaled", "01044445555" },
                    { 5, "Osman@example.com", "Osman Mohammed", "01055556666" },
                    { 6, "mohamed.b@example.com", "Mohamed Bakr", "01066667777" },
                    { 7, "menna@example.com", "Mennatallah Madian", "01077778888" },
                    { 8, "abdoo@example.com", "Abdoo Sherif", "01088889999" },
                    { 9, "abdullah@example.com", "Abdullah Saied", "01099990000" },
                    { 10, "omar.k@example.com", "Omar Khaled", "01112223333" },
                    { 11, "essam@example.com", "Essam Youssef", "01123334444" },
                    { 12, "nourhan@example.com", "Nourhan Tarek", "01134445555" },
                    { 13, "karim@example.com", "Karim Mostafa", "01145556666" },
                    { 14, "hadeer@example.com", "Hadeer Ibrahim", "01156667777" },
                    { 15, "mahmoud@example.com", "Mahmoud Fawzy", "01167778888" },
                    { 16, "nada@example.com", "Nada Hassan", "01278889999" },
                    { 17, "ziad@example.com", "Ziad Kamal", "01289990000" },
                    { 18, "farah@example.com", "Farah Nabil", "01290001111" },
                    { 19, "youssef@example.com", "Youssef Ahmed", "01511112222" },
                    { 20, "khaled@example.com", "Khaled Zaki", "01522223333" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "CategoryId", "Price", "PublishedYear", "Title" },
                values: new object[,]
                {
                    { 1, "Robert C. Martin", 1, 45.0, 2017, "Clean Architecture" },
                    { 2, "Jon Skeet", 1, 49.990000000000002, 2019, "C# in Depth" },
                    { 3, "Eric Evans", 1, 55.0, 2003, "Domain-Driven Design" },
                    { 4, "Robert C. Martin", 1, 40.0, 2008, "Clean Code" },
                    { 5, "Adam Freeman", 1, 52.0, 2022, "Pro ASP.NET Core" },
                    { 6, "Martin Kleppmann", 2, 39.990000000000002, 2017, "Designing Data-Intensive Applications" },
                    { 7, "Itzik Ben-Gan", 2, 35.0, 2016, "T-SQL Fundamentals" },
                    { 8, "Jon Smith", 2, 42.0, 2021, "Entity Framework Core in Action" },
                    { 9, "Regina O. Obe", 2, 38.0, 2017, "PostgreSQL: Up and Running" },
                    { 10, "Abraham Silberschatz", 2, 85.0, 2019, "Database System Concepts" },
                    { 11, "Thomas H. Cormen", 3, 95.0, 2009, "Introduction to Algorithms" },
                    { 12, "Aditya Bhargava", 3, 34.0, 2016, "Grokking Algorithms" },
                    { 13, "Steve McConnell", 3, 45.0, 2004, "Code Complete" },
                    { 14, "David Thomas", 3, 40.0, 2019, "The Pragmatic Programmer" },
                    { 15, "Martin Fowler", 3, 48.0, 2018, "Refactoring" },
                    { 16, "David Harris", 4, 75.0, 2012, "Digital Design and Computer Architecture" },
                    { 17, "Mark Siegesmund", 4, 55.0, 2014, "Embedded C Programming" },
                    { 18, "Dogan Ibrahim", 4, 45.0, 2020, "STM32 Microcontroller Programming" },
                    { 19, "Kenneth L. Short", 4, 65.0, 2008, "VHDL for Engineers" },
                    { 20, "Robert Britton", 4, 35.0, 2003, "MIPS Assembly Language Programming" },
                    { 21, "Nigel Poulton", 5, 30.0, 2020, "Docker Deep Dive" },
                    { 22, "Brendan Burns", 5, 42.0, 2019, "Kubernetes Up & Running" },
                    { 23, "Gene Kim", 5, 25.0, 2013, "The Phoenix Project" },
                    { 24, "Jez Humble", 5, 45.0, 2010, "Continuous Delivery" },
                    { 25, "Cornelia Davis", 5, 40.0, 2019, "Cloud Native Patterns" },
                    { 26, "Shyam Seshadri", 6, 38.0, 2018, "Angular Up and Running" },
                    { 27, "Toi B. Wright", 6, 44.0, 2021, "Blazor WebAssembly by Example" },
                    { 28, "Douglas Crockford", 6, 29.0, 2008, "JavaScript: The Good Parts" },
                    { 29, "Brian Hogan", 6, 32.0, 2013, "HTML5 and CSS3" },
                    { 30, "Josh Goldberg", 6, 39.0, 2022, "Learning TypeScript" },
                    { 31, "Frank Herbert", 7, 15.99, 1965, "Dune" },
                    { 32, "Isaac Asimov", 7, 14.99, 1951, "Foundation" },
                    { 33, "William Gibson", 7, 16.0, 1984, "Neuromancer" },
                    { 34, "Neal Stephenson", 7, 17.5, 1992, "Snow Crash" },
                    { 35, "Andy Weir", 7, 18.0, 2014, "The Martian" },
                    { 36, "George Orwell", 8, 12.0, 1949, "1984" },
                    { 37, "Harper Lee", 8, 14.0, 1960, "To Kill a Mockingbird" },
                    { 38, "Jane Austen", 8, 10.0, 1813, "Pride and Prejudice" },
                    { 39, "F. Scott Fitzgerald", 8, 11.5, 1925, "The Great Gatsby" },
                    { 40, "Herman Melville", 8, 15.0, 1851, "Moby Dick" },
                    { 41, "Yuval Noah Harari", 9, 22.0, 2011, "Sapiens" },
                    { 42, "Jared Diamond", 9, 20.0, 1997, "Guns, Germs, and Steel" },
                    { 43, "Howard Zinn", 9, 19.5, 1980, "A People's History" },
                    { 44, "Peter Frankopan", 9, 24.0, 2015, "The Silk Roads" },
                    { 45, "Mary Beard", 9, 21.0, 2015, "SPQR: A History of Ancient Rome" },
                    { 46, "Daniel Kahneman", 10, 18.0, 2011, "Thinking, Fast and Slow" },
                    { 47, "James Clear", 10, 20.0, 2018, "Atomic Habits" },
                    { 48, "Jim Collins", 10, 22.0, 2001, "Good to Great" },
                    { 49, "Eric Ries", 10, 19.0, 2011, "The Lean Startup" },
                    { 50, "Peter Thiel", 10, 17.5, 2014, "Zero to One" }
                });

            migrationBuilder.InsertData(
                table: "Borrowings",
                columns: new[] { "Id", "BookId", "BorrowDate", "MemberId", "ReturnDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2026, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, new DateTime(2026, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2026, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 3, new DateTime(2026, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2026, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 8, new DateTime(2026, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2026, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 1, new DateTime(2026, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2026, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 11, new DateTime(2026, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2026, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 4, new DateTime(2026, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(2026, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 5, new DateTime(2026, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2026, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 2, new DateTime(2026, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, new DateTime(2026, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 6, new DateTime(2026, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, new DateTime(2026, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 10, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, new DateTime(2026, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 12, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 13, new DateTime(2026, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, new DateTime(2026, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, 14, new DateTime(2026, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, new DateTime(2026, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, 15, new DateTime(2026, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, new DateTime(2026, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, 1, new DateTime(2026, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, new DateTime(2026, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, 23, new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, new DateTime(2026, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, 24, new DateTime(2026, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, new DateTime(2026, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, 25, new DateTime(2026, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 16, new DateTime(2026, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, 28, new DateTime(2026, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 17, new DateTime(2026, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, 29, new DateTime(2026, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 18, new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, 30, new DateTime(2026, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 19, new DateTime(2026, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, 33, new DateTime(2026, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, new DateTime(2026, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24, 7, new DateTime(2026, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(2026, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25, 26, new DateTime(2026, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(2026, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 26, 27, new DateTime(2026, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2026, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27, 17, new DateTime(2026, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, new DateTime(2026, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 28, 19, new DateTime(2026, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, new DateTime(2026, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 29, 31, new DateTime(2026, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, new DateTime(2026, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 30, 43, new DateTime(2026, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2026, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 31, 21, new DateTime(2026, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2026, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 32, 18, new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, new DateTime(2026, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 33, 20, new DateTime(2026, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, new DateTime(2026, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 34, 36, new DateTime(2026, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, new DateTime(2026, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 35, 41, new DateTime(2026, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, new DateTime(2026, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 36, 22, new DateTime(2026, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, new DateTime(2026, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 37, 46, new DateTime(2026, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, new DateTime(2026, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 38, 32, new DateTime(2026, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, new DateTime(2026, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 39, 47, new DateTime(2026, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 16, new DateTime(2026, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 40, 37, new DateTime(2026, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 17, new DateTime(2026, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 41, 42, new DateTime(2026, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 18, new DateTime(2026, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 42, 48, new DateTime(2026, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 19, new DateTime(2026, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 43, 49, new DateTime(2026, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, new DateTime(2026, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 44, 34, new DateTime(2026, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2026, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 45, 38, new DateTime(2026, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2026, 7, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 46, 50, new DateTime(2026, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(2026, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 47, 35, new DateTime(2026, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2026, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 48, 39, new DateTime(2026, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, new DateTime(2026, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 49, 44, new DateTime(2026, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, new DateTime(2026, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 50, 1, new DateTime(2026, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, new DateTime(2026, 7, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 51, 2, new DateTime(2026, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, new DateTime(2026, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 52, 3, new DateTime(2026, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, new DateTime(2026, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 53, 4, new DateTime(2026, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, new DateTime(2026, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 54, 5, new DateTime(2026, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, new DateTime(2026, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 55, 6, new DateTime(2026, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, new DateTime(2026, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 56, 7, new DateTime(2026, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, new DateTime(2026, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 57, 8, new DateTime(2026, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, new DateTime(2026, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 58, 9, new DateTime(2026, 7, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 16, new DateTime(2026, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 59, 10, new DateTime(2026, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 17, new DateTime(2026, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 60, 11, new DateTime(2026, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 18, new DateTime(2026, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 61, 12, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 19, new DateTime(2026, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 62, 13, new DateTime(2026, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, new DateTime(2026, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 63, 14, new DateTime(2026, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2026, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 64, 15, new DateTime(2026, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2026, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 65, 16, new DateTime(2026, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2026, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 66, 17, new DateTime(2026, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(2026, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 67, 18, new DateTime(2026, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2026, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 68, 19, new DateTime(2026, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, new DateTime(2026, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 69, 20, new DateTime(2026, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, new DateTime(2026, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 70, 21, new DateTime(2026, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, new DateTime(2026, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 71, 22, new DateTime(2026, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, new DateTime(2026, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 72, 23, new DateTime(2026, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, new DateTime(2026, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 73, 24, new DateTime(2026, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, new DateTime(2026, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 74, 25, new DateTime(2026, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, new DateTime(2026, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 75, 26, new DateTime(2026, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, new DateTime(2026, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 76, 27, new DateTime(2026, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, new DateTime(2026, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 77, 28, new DateTime(2026, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, new DateTime(2026, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 78, 29, new DateTime(2026, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 16, new DateTime(2026, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 79, 30, new DateTime(2026, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 17, new DateTime(2026, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 80, 31, new DateTime(2026, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 18, new DateTime(2026, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 81, 32, new DateTime(2026, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 19, null },
                    { 82, 33, new DateTime(2026, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, null },
                    { 83, 34, new DateTime(2026, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null },
                    { 84, 35, new DateTime(2026, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null },
                    { 85, 36, new DateTime(2026, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null },
                    { 86, 37, new DateTime(2026, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, null },
                    { 87, 38, new DateTime(2026, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, null },
                    { 88, 39, new DateTime(2026, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, null },
                    { 89, 40, new DateTime(2026, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, null },
                    { 90, 41, new DateTime(2026, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, null },
                    { 91, 42, new DateTime(2026, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, null },
                    { 92, 43, new DateTime(2026, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, null },
                    { 93, 44, new DateTime(2026, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, null },
                    { 94, 45, new DateTime(2026, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, null },
                    { 95, 46, new DateTime(2026, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, null },
                    { 96, 47, new DateTime(2026, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, null },
                    { 97, 48, new DateTime(2026, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, null },
                    { 98, 49, new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 16, null },
                    { 99, 50, new DateTime(2026, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 17, null },
                    { 100, 16, new DateTime(2026, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Borrowings",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
