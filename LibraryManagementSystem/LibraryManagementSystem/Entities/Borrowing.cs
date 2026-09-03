using System.Diagnostics;

namespace LibraryManagementSystem.Entities
{
    public class Borrowing:Entity
    {
        private Borrowing(int memberId, int bookId)
        {
            BookId = bookId;
            MemberId = memberId;
            BorrowDate = DateTime.UtcNow;
            ReturnDate = null;
        }
        public int BookId { get; private set; }
        public int MemberId { get; private set; }
        public DateTime BorrowDate { get; private set; }
        public DateTime? ReturnDate { get; private set; }
        public Book Book { get; set; }
        public Member Member { get; set; }

        public static Borrowing Create(int memberId, int bookId) =>
            new Borrowing(memberId,bookId);

        public object ReturnBook() =>
            ReturnDate = DateTime.UtcNow;
    }
}
