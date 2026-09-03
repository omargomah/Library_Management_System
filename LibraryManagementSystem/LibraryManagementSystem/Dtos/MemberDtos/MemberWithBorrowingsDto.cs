using LibraryManagementSystem.Dtos.BorrowingDtos;
namespace LibraryManagementSystem.Dtos.MemberDtos
{
    public class MemberWithBorrowingsDto
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<BorrowingShortDetailsDto> Borrowings { get; set; };
    }
}
