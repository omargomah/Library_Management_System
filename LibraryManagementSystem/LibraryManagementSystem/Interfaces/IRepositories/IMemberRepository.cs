using LibraryManagementSystem.Dtos.MemberDtos;
using LibraryManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Interfaces.IRepositories
{
    public interface IMemberRepository:IRepository<Member>
    {
        Task<List<MembersNameAndCountOfBorrowingDto>> GetAllMembersWithBorrowingsCountAsync();

        Task<Member?> GetMemberWithBorrowingsByIdAsync(int memberId);

        Task<List<MemberWithBorrowingsDto>> GetAllMembersWithBorrowingsAsync();

        Task<MemberWithBorrowingHistoryDto?> GetMemberWithBorrowingsHistoryByIdAsync(int memberId);


    }
}
