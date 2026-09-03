namespace LibraryManagementSystem.Dtos.BorrowingDtos
{
    public class BorrowingShortDetailsDto
    {
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
