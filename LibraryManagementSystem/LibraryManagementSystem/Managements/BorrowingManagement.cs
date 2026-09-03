using LibraryManagementSystem.Entities;
using LibraryManagementSystem.Interfaces;
using LibraryManagementSystem.Interfaces.IRepositories;
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
            Console.WriteLine("\nPress any key to continue...");
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
        private async void PrintMessageOfNotValidId(string entity)
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
                Console.WriteLine("2) Update Member");
                Console.WriteLine("3) Delete Member");
                Console.WriteLine("4) Get Member By ID");
                Console.WriteLine("5) Get All Members");
                Console.WriteLine("6) Return to Main Menu");
                Console.Write("\nSelect an option: ");

                ConsoleKey choice = Console.ReadKey().Key;

                switch (choice)
                {
                    case ConsoleKey.D1:
                        await BorrowBookAsync();
                        break;

                    case ConsoleKey.D2:
                        await UpdateMemberAsync();
                        break;

                    case ConsoleKey.D3:
                        await DeleteMemberAsync();
                        break;

                    case ConsoleKey.D4:
                        await GetMemberByIdAsync();
                        break;

                    case ConsoleKey.D5:
                        await GetAllMembersAsync();
                        break;

                    case ConsoleKey.D6:
                        return;

                    default:
                        Console.WriteLine("\nInvalid option! Please enter a number between 1 and 6.");
                        EndExecute();
                        break;
                }
            }
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
            bool IsValidBookId = await _memberRepository.CheckIdIsExistAsync(GetValidId("book"));
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
    }
}
