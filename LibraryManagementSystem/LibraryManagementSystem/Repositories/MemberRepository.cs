using LibraryManagementSystem.Data;
using LibraryManagementSystem.Dtos.BorrowingDtos;
using LibraryManagementSystem.Dtos.MemberDtos;
using LibraryManagementSystem.Entities;
using LibraryManagementSystem.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Repositories
{
    public class MemberRepository(ApplicationDbContext dbContext) :Repository<Member>(dbContext),IMemberRepository
    {
        public async Task<List<MembersNameAndCountOfBorrowingDto>> GetAllMembersWithBorrowingsCountAsync() =>
            await _set.Select( x => new MembersNameAndCountOfBorrowingDto() 
            {
                MemberName = x.Name,
                BorrowingCount = x.Borrowings.Count
            }).OrderByDescending(x => x.BorrowingCount).ToListAsync();
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

        public async Task<MemberWithBorrowingHistoryDto?> GetMemberWithBorrowingsHistoryByIdAsync(int memberId) =>

            await _set.Where(x => x.Id == memberId).Select(x => new MemberWithBorrowingHistoryDto()
            {
                Name = x.Name,
                Borrowings = x.Borrowings.Select(b => new BorrowingHistoryDto()
                {
                    BookTitle = b.Book.Title,
                    BorrowDate = b.BorrowDate,
                    ReturnDate = b.ReturnDate,
                })
            }).FirstOrDefaultAsync();


    }
}
