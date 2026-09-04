using LibraryManagementSystem.Dtos.MemberDtos;
using LibraryManagementSystem.Entities;
namespace LibraryManagementSystem.Interfaces.IRepositories
{
    public interface IMemberRepository:IRepository<Member>
    {
        IQueryable<Member> GetMembersQuery();

        Task < List<MembersNameAndCountOfBorrowingDto>> GetAllMembersWithBorrowingsCountAsync();

        Task<Member?> GetMemberWithBorrowingsByIdAsync(int memberId);

        Task<List<MemberWithBorrowingsDto>> GetAllMembersWithBorrowingsAsync();

        Task<MemberWithBorrowingHistoryDto?> GetMemberWithBorrowingsHistoryByIdAsync(int memberId);


    }
}
