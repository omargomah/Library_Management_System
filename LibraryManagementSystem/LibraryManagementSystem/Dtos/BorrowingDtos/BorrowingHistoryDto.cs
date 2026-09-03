namespace LibraryManagementSystem.Dtos.BorrowingDtos
{
    public class BorrowingHistoryDto
    {
        public string BookTitle { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }

    }
}
