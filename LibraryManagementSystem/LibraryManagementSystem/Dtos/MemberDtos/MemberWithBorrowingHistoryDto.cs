using LibraryManagementSystem.Dtos.BorrowingDtos;
namespace LibraryManagementSystem.Dtos.MemberDtos
{
    public class MemberWithBorrowingHistoryDto
    {
        public string Name { get; set; }
        public IEnumerable<BorrowingHistoryDto> Borrowings { get; set; }
    }
}
