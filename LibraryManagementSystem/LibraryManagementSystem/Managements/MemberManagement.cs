using LibraryManagementSystem.Entities;
using LibraryManagementSystem.Interfaces;
using LibraryManagementSystem.Interfaces.IRepositories;
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
        public async Task ShowMenuAsync()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=================================");
                Console.WriteLine("        Member Management        ");
                Console.WriteLine("=================================");
                Console.WriteLine("1. Add Member");
                Console.WriteLine("2. Update Member");
                Console.WriteLine("3. Delete Member");
                Console.WriteLine("4. Get Member By ID");
                Console.WriteLine("5. Get All Members");
                Console.WriteLine("6. Return to Main Menu");
                Console.Write("\nSelect an option (1-6): ");

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

        public async Task AddMemberAsync()
        {
            StartExecute("Add New Member");
            Member newMember = Member.Create();
            await _memberRepository.AddAsync(newMember);
            EndMessageOfAddAndUpdateAndDelete("add", await _unitOfWork.SaveChangesAsync() > 0);
        }

    }
}
