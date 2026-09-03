using LibraryManagementSystem.Dtos.BorrowingDtos;
using LibraryManagementSystem.Dtos.MemberDtos;
using LibraryManagementSystem.Entities;
using LibraryManagementSystem.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Repositories
{
    public class MemberRepository:Repository<Member>,IMemberRepository
    {
        public async Task<List<MemberWithBorrowingsDto>> GetAllMembersWithBorrowingsAsync() =>
            await _set.Select(x => new MemberWithBorrowingsDto() 
            {
                Id = x.Id,
                Name = x.Name,
                Borrowings = x.Borrowings.Select(b => new BorrowingShortDetailsDto() 
                {
                    BookId = b.BookId,
                    BookTitle = b.Book.Title,
                    BorrowDate = b.BorrowDate,
                    ReturnDate = b.ReturnDate,
                })
            }).ToListAsync();
        public async Task<Member?> GetMemberWithBorrowingsByIdAsync(int memberId) =>
            await _set.Include(x => x.Borrowings).ThenInclude(x => x.Book).SingleOrDefaultAsync(x => x.Id == memberId);
    
    }
}
