namespace LibraryManagementSystem.Entities
{
    public class Category: Entity
    {
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; } = new HashSet<Book>();
    }
}
