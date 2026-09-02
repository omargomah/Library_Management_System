using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Entities
{
    public class Member:Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public ICollection<Borrowing> Borrowings { get; set; } = new HashSet<Borrowing>();
    }
}
