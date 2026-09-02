using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Entities
{
    public class Book :Entity
    {
        public string Titel { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }
        public DateOnly PublishedYear { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Borrowing> Borrowings { get; set; } = new HashSet<Borrowing>();
    }
}
