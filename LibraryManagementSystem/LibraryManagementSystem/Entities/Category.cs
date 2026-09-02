using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace LibraryManagementSystem.Entities
{
    public class Category: Entity
    {
        public int Name { get; set; }
        public ICollection<Book> Books { get; set; } = new HashSet<Book>();
    }
}
