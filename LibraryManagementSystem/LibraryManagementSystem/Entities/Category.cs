using System.Text;

namespace LibraryManagementSystem.Entities
{
    public class Category: Entity
    {
        public string Name { get; private set; }
        public ICollection<Book> Books { get; set; } = new HashSet<Book>();

        public static Category Create(List<string> oldCategoriesName)
        {
            Category category = new Category();
            category.UpdateName(oldCategoriesName);
            return category;
        }


        public void UpdateName(List<string> oldCategoriesName)
        {
            Console.Write("Enter category name: ");
            ValidationResult validationResult = SetName(Console.ReadLine()!, oldCategoriesName);
            while (!validationResult.IsSuccess)
            {
                Console.WriteLine(validationResult);
                Console.Write("Enter another category name: ");
                validationResult = SetName(Console.ReadLine()!, oldCategoriesName);
            }
        }
        public ValidationResult SetName(string newName , List<string> oldCategoriesName)
        {
            if (string.IsNullOrWhiteSpace(newName))
                return ValidationResult.Fail("Category name cannot be empty");

            if (newName.Length > Constants.MaxNameLength)
                return ValidationResult.Fail($"The Length of name should be Less than {Constants.MaxNameLength}");

            if (oldCategoriesName.Any(x => string.Equals(newName, x, StringComparison.OrdinalIgnoreCase)))
                return ValidationResult.Fail($"There is already category called {newName.Trim()}.");

            Name = newName.Trim();
            return ValidationResult.Success("Set Name Of category Success");
        }


        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Category id: {Id} | Category name: {Name}");
            foreach (var book in Books)
                stringBuilder.AppendLine($"\t[Book] Title: {book.Title} | Author: {book.Author} | Year: {book.PublishedYear} | Price: {book.Price:C}");
            return stringBuilder.ToString();
        }
    }
}
