using LibraryManagementSystem.Dtos.BorrowingDtos;
using LibraryManagementSystem.Dtos.MemberDtos;
using LibraryManagementSystem.Entities;
using LibraryManagementSystem.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Repositories
{
    public class MemberRepository:Repository<Member>,IMemberRepository
    {
        public async Task<Member?> GetMemberWithBorrowingsByIdAsync(int memberId) =>
            await _set.Include(x => x.Borrowings).ThenInclude(x => x.Book).SingleOrDefaultAsync(x => x.Id == memberId);
    }
}
