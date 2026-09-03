namespace LibraryManagementSystem.Dtos.BorrowingDtos
{
    public class BookWithBorrowingDto
    {
        public string BookTitle { get; set; }
        public List<BookBorrowingHistoryDto> HistoryDtos { get; set; } = new();
    }
}
