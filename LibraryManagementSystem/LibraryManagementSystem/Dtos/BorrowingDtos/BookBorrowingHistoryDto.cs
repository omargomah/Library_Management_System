namespace LibraryManagementSystem.Dtos.BorrowingDtos
{
    public class BookBorrowingHistoryDto
    {
        public string MemberName { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
