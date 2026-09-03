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
    public class MemberManagement
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IUnitOfWork _unitOfWork;

        public MemberManagement(IMemberRepository memberRepository, IUnitOfWork unitOfWork)
        {
            _memberRepository = memberRepository;
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

        private void EndMessageOfAddAndUpdateAndDelete(string action, bool IsSuccess, string entityName = "Member")
        {
            if (IsSuccess)
                Console.WriteLine($"\n{entityName} {action} success");
            else
                Console.WriteLine($"\n{entityName} {action} fail");
            EndExecute();
        }
        private int GetValidId()
        {
            Console.Write("Enter the member Id: ");
            int memberId;
            while (!int.TryParse(Console.ReadLine(), out memberId) || memberId < 1)
            {
                Console.Write("Invalid value. Enter another member Id: ");
            }
            return memberId;
        }
        private async Task<Member?> GetEntityByIdAndCheckIsValidOrNotAsync(Func<int, Task<Member?>> funcToGetMemberById)
        {
            int id = GetValidId();
            Member? member = await funcToGetMemberById.Invoke(id);
            if (member is null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You entered an invalid member Id. Try again.");
                Console.ForegroundColor = ConsoleColor.White;
                EndExecute();
                return null;
            }
            return member;
        }
        public async Task ShowMenuAsync()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=================================");
                Console.WriteLine("        Member Management        ");
                Console.WriteLine("=================================");
                Console.WriteLine("1) Add Member");
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
                        await AddMemberAsync();
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
        private async Task AddMemberAsync()
        {
            StartExecute("Add New Member");
            Member newMember = Member.Create();
            await _memberRepository.AddAsync(newMember);
            EndMessageOfAddAndUpdateAndDelete("add", await _unitOfWork.SaveChangesAsync() > 0);
        }
        private async Task UpdateMemberAsync()
        {
            StartExecute("Update Member");
            Member? memberWillUpdate = await GetEntityByIdAndCheckIsValidOrNotAsync(_memberRepository.GetByIdAsync);
            if (memberWillUpdate is null)
                return;

            bool flag = true;
            while (flag)
            {
                Console.WriteLine($"\nCurrent Member: Name: {memberWillUpdate.Name}, Email: {memberWillUpdate.Email}, Phone: {memberWillUpdate.Phone}");
                Console.WriteLine("Choose what you want to update: ");
                Console.WriteLine("1) Update name");
                Console.WriteLine("2) Update email");
                Console.WriteLine("3) Update phone");
                Console.WriteLine("4) Save changes & exit");
                Console.WriteLine("5) Cancel update");

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                Console.WriteLine();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.D1:
                        memberWillUpdate.UpdateName();
                        Console.WriteLine("The name update done");
                        break;
                    case ConsoleKey.D2:
                        memberWillUpdate.UpdateEmail();
                        Console.WriteLine("The email update done");
                        break;
                    case ConsoleKey.D3:
                        memberWillUpdate.UpdatePhone();
                        Console.WriteLine("The phone update done");
                        break;
                    case ConsoleKey.D4:
                        flag = false;
                        break;
                    case ConsoleKey.D5:
                        Console.WriteLine("The Update member is cancelled");
                        EndExecute();
                        return;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }

            _memberRepository.Update(memberWillUpdate);
            EndMessageOfAddAndUpdateAndDelete("update", await _unitOfWork.SaveChangesAsync() > 0);
        }
        private async Task DeleteMemberAsync()
        {
            StartExecute("Delete Member");
            Member? memberWillDelete = await GetEntityByIdAndCheckIsValidOrNotAsync(_memberRepository.GetByIdAsync);
            if (memberWillDelete is null)
                return;

            Console.Write($"Are you sure you want to delete member '{memberWillDelete.Name}'? (y/n): ");
            ConsoleKey confirm = Console.ReadKey().Key;
            Console.WriteLine();

            if (confirm == ConsoleKey.Y)
            {
                _memberRepository.Delete(memberWillDelete);
                EndMessageOfAddAndUpdateAndDelete("delete", await _unitOfWork.SaveChangesAsync() > 0);
            }
            else
            {
                Console.WriteLine("\nOperation cancelled");
                EndExecute();
            }
        }
        private async Task GetMemberByIdAsync()
        {
            StartExecute("Find Member by ID");
            Member? member = await GetEntityByIdAndCheckIsValidOrNotAsync(_memberRepository.GetMemberWithBorrowingsByIdAsync);
            if (member is null)
                return;
            Console.WriteLine(member);
            EndExecute();
        }
        private async Task GetAllMembersAsync()
        {
            StartExecute("All Members");
            List<MemberWithBorrowingsDto> members = await _memberRepository.GetAllMembersWithBorrowingsAsync();

            if (members.IsNullOrEmpty())
                Console.WriteLine("There are no members yet.");
            else
            {
                foreach (var member in members)
                {
                    DisplayMemberWithBorrowings(member);
                    Console.WriteLine(new string('-', 50));
                }
            }
            EndExecute();
        }
        private void DisplayMemberWithBorrowings(MemberWithBorrowingsDto member)
        {
            Console.WriteLine($"\n[Member ID: {member.Id}] Name: {member.Name}");
            Console.WriteLine("Borrowing History:");

            if (member.Borrowings == null || !member.Borrowings.Any())
                Console.WriteLine("  -> No borrowing history found.");
            else
                foreach (var borrowing in member.Borrowings)
                    Console.WriteLine($"\tBook ID: {borrowing.BookId} | Title: {borrowing.BookTitle} | Borrowed: {borrowing.BorrowDate.ToShortDateString()} | Return Date: {(borrowing.ReturnDate.HasValue? borrowing.ReturnDate.Value.ToShortDateString() : "Not return yet" )}");
        }


    }
}
