using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Entities
{
    public class Borrowing:Entity
    {
        public int BookId { get; set; }
        public int MemberId { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public Book Book { get; set; }
        public Member Member { get; set; }
    }
}
