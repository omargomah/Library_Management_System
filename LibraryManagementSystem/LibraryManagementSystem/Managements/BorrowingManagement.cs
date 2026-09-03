using LibraryManagementSystem.Dtos.BorrowingDtos;
using LibraryManagementSystem.Dtos.MemberDtos;
using LibraryManagementSystem.Entities;
using LibraryManagementSystem.Interfaces;
using LibraryManagementSystem.Interfaces.IRepositories;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Managements
{
    public class BorrowingManagement
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBookRepository _bookRepository;
        private readonly IBorrowingRepository _borrowingRepository;

        public BorrowingManagement(
            IMemberRepository memberRepository ,
            IUnitOfWork unitOfWork ,
            IBookRepository bookRepository,
            IBorrowingRepository borrowingRepository)
        {
            _memberRepository = memberRepository;
            _unitOfWork = unitOfWork;
            _bookRepository = bookRepository;
            _borrowingRepository = borrowingRepository;
        }
        private void StartExecute(string action)
        {
            Console.Clear();
            Console.WriteLine($"--- {action} ---");
        }
        private void EndExecute()
        {
            Console.Write("\nPress any key to continue...");
            Console.ReadKey();
        }
        private int GetValidId(string idOfWhat)
        {
            Console.Write($"Enter the {idOfWhat} Id: ");
            int memberId;
            while (!int.TryParse(Console.ReadLine(), out memberId) || memberId < 1)
                Console.Write($"Invalid value. Enter another {idOfWhat} Id: ");
            return memberId;
        }
        private void PrintMessageOfNotValidId(string entity)
        {            
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"You entered an invalid {entity} Id. Try again.");
            Console.ForegroundColor = ConsoleColor.White;
            EndExecute();
        }
        private void EndMessageOfAddAndUpdateAndDelete(string action, bool IsSuccess, string entityName)
        {
            if (IsSuccess)
                Console.WriteLine($"\n{entityName} {action} success");
            else
                Console.WriteLine($"\n{entityName} {action} fail");
            EndExecute();
        }
        public async Task ShowMenuAsync()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=================================");
                Console.WriteLine("        Borrowing Management        ");
                Console.WriteLine("=================================");
                Console.WriteLine("1) Borrow Book");
                Console.WriteLine("2) Return Book");
                Console.WriteLine("3) Member Borrowing History");
                Console.WriteLine("4) Book Borrowing History");
                Console.WriteLine("5) Return to Main Menu");
                Console.Write("\nSelect an option: ");

                ConsoleKey choice = Console.ReadKey().Key;

                switch (choice)
                {
                    case ConsoleKey.NumPad1:
                        await BorrowBookAsync();
                        break;

                    case ConsoleKey.NumPad2:
                        await ReturnBookAsync();
                        break;

                    case ConsoleKey.NumPad3:
                        await GetMemberBorrowingHistoryAsync();
                        break;

                    case ConsoleKey.NumPad4:
                        await GetBookBorrowingHistoryAsync();
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
        private async Task GetBookBorrowingHistoryAsync()
        {
            StartExecute("Get Book Borrowing History");
            int bookId = GetValidId("book");

            BookWithBorrowingDto? bookWithBorrowingHistory = await _bookRepository.GetBookWithBorrowingByIdAsync(bookId);
            if (bookWithBorrowingHistory is null)
            {
                PrintMessageOfNotValidId("book");
                return;
            }

            Console.WriteLine($"\nBook Title: {bookWithBorrowingHistory.BookTitle}");
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("Borrowing History:");

            if (bookWithBorrowingHistory.HistoryDtos.IsNullOrEmpty())
                Console.WriteLine("\tNot borrowed by any member yet.");
            else
                foreach (var b in bookWithBorrowingHistory.HistoryDtos)
                {
                    Console.WriteLine($"\tMember Name: {b.MemberName}");
                    Console.WriteLine($"\tBorrow Date: {b.BorrowDate.ToShortDateString()}");
                    Console.WriteLine($"\tReturn Date: {(b.ReturnDate.HasValue ? b.ReturnDate.Value.ToShortDateString() : "Not return yet")}");
                    Console.WriteLine(new string('-', 30));
                }

            EndExecute();

        }
        private async Task BorrowBookAsync()
        {
            StartExecute("Borrow Book");
            int memberId = GetValidId("member");
            bool IsValidMemberId = await _memberRepository.CheckIdIsExistAsync(memberId);
            if (!IsValidMemberId)
            {
                PrintMessageOfNotValidId("member");
                return;
            }
            int bookId = GetValidId("book");
            bool IsValidBookId = await _bookRepository.CheckIdIsExistAsync(bookId);
            if (!IsValidBookId)
            {
                PrintMessageOfNotValidId("book");
                return;
            }
            bool isAvailableBook = await _borrowingRepository.CheckThatBookIsAvailableToBorrowAsync(bookId);
            if (!isAvailableBook)
            {
                Console.WriteLine("This Book is not available to borrow now");
                EndExecute();
                return;
            }
            Borrowing borrowing = Borrowing.Create(memberId, bookId);
            await _borrowingRepository.AddAsync(borrowing);
            EndMessageOfAddAndUpdateAndDelete("borrow", await _unitOfWork.SaveChangesAsync() > 0,"book");
        }
        private async Task ReturnBookAsync()
        {
            StartExecute("Return Book");
            int borrowingId = GetValidId("Borrowing");
            Borrowing? borrowing = await _borrowingRepository.GetByIdAsync(borrowingId);
            if (borrowing is null)
            { 
                PrintMessageOfNotValidId("borrowing");
                return;
            }

            if (borrowing.ReturnDate.HasValue)
            { 
                Console.WriteLine("The book already returned.");
                EndExecute();
            }
            else
            {
                borrowing.ReturnBook();
                _borrowingRepository.Update(borrowing);
                EndMessageOfAddAndUpdateAndDelete("return" ,await _unitOfWork.SaveChangesAsync() > 0 ,"book");
            }
        }
        private async Task GetMemberBorrowingHistoryAsync()
        {
            StartExecute("Get Member Borrowing History");
            int memberId = GetValidId("member");

            MemberWithBorrowingHistoryDto? memberWithBorrowingHistory = await _memberRepository.GetMemberWithBorrowingsHistoryByIdAsync(memberId);
            if (memberWithBorrowingHistory is null)
            {
                PrintMessageOfNotValidId("Member");
                return;
            }

            Console.WriteLine($"\nMember Name: {memberWithBorrowingHistory.Name}");
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("Borrowing History:");

            if (memberWithBorrowingHistory.Borrowings.IsNullOrEmpty())
                Console.WriteLine("\tNo books borrowed yet.");
            else
                foreach (var b in memberWithBorrowingHistory.Borrowings)
                {
                    Console.WriteLine($"\tBook Title : {b.BookTitle}");
                    Console.WriteLine($"\tBorrow Date: {b.BorrowDate.ToShortDateString()}");
                    Console.WriteLine($"\tReturn Date: {(b.ReturnDate.HasValue? b.ReturnDate.Value.ToShortDateString() : "Not return yet")}");
                    Console.WriteLine(new string('-', 30));
                }

            EndExecute();

        }
    }
}
