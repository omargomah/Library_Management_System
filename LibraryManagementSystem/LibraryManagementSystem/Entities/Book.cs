using LibraryManagementSystem.Dtos.CategoryDtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryManagementSystem.Entities
{
    public class Book :Entity
    {
        public string Title { get; private set; }
        public string Author { get; private set; }
        public double Price { get; private set; }
        public int PublishedYear { get; private set; }
        public int CategoryId { get; private set; }
        public Category Category { get; set; }
        public ICollection<Borrowing> Borrowings { get; set; } = new HashSet<Borrowing>();

        public static Book Create(List<SelectMenuOfCategoryDto> menuOfCategoryDtos)
        {
            string lineSeparate = $"\n{new string('=', 50)}\n"; 
            Book newBook = new Book();

            newBook.UpdateTitle();

            Console.WriteLine(lineSeparate);
            newBook.UpdateAuthor();

            Console.WriteLine(lineSeparate);
            newBook.UpdatePrice();

            Console.WriteLine(lineSeparate);
            newBook.UpdatePublishedYear();

            Console.WriteLine(lineSeparate);
            newBook.UpdateCategoryId(menuOfCategoryDtos);

            return newBook;

        }
        public void UpdateTitle()
        {
            Console.Write("Enter book Title: ");
            ValidationResult validationResult = SetTitle(Console.ReadLine()!);
            while (!validationResult.IsSuccess)
            {
                Console.WriteLine(validationResult.Message);
                Console.Write("Enter book Title: ");
                validationResult = SetTitle(Console.ReadLine()!);
            }
        }
        public void UpdateAuthor()
        {
            Console.Write("Enter book Author: ");
            var validationResult = SetAuthor(Console.ReadLine()!);
            while (!validationResult.IsSuccess)
            {
                Console.WriteLine(validationResult.Message);
                Console.Write("Enter book Author: ");
                validationResult = SetAuthor(Console.ReadLine()!);
            }
        }
        public void UpdatePrice()
        {
            Console.Write("Enter book Price: ");
            int price;
            while (!int.TryParse(Console.ReadLine(), out price))
            {
                Console.Write("Invalid number enter it again: ");
            }
            var validationResult = SetPrice(price);
            while (!validationResult.IsSuccess)
            {
                Console.WriteLine(validationResult.Message);
                Console.Write("Enter book price again: ");
                while (!int.TryParse(Console.ReadLine(), out price))
                {
                    Console.Write("Invalid number enter it again: ");
                }
                validationResult = SetPrice(price);
            }
        }
        public void UpdatePublishedYear()
        {
            Console.Write("Enter book publish year: ");
            int publishYear;
            while (!int.TryParse(Console.ReadLine(), out publishYear))
                Console.Write("Invalid number enter it again: ");
            var validationResult = SetPublishedYear(publishYear);
            while (!validationResult.IsSuccess)
            {
                Console.WriteLine(validationResult.Message);
                Console.Write("Enter book publish year again: ");
                while (!int.TryParse(Console.ReadLine(), out publishYear))
                {
                    Console.Write("Invalid number enter it again: ");
                }
                validationResult = SetPublishedYear(publishYear);
            }


        }
        public void UpdateCategoryId(List<SelectMenuOfCategoryDto> menuOfCategoryDtos)
        {
            Console.Write("Enter book Category Id: ");
            foreach (var category in menuOfCategoryDtos)
                Console.WriteLine($"{category.Id}) {category.Name}");
            int categoryId;
            while (!int.TryParse(Console.ReadLine(), out categoryId))
                Console.Write("Invalid number enter it again: ");
            var validIds = menuOfCategoryDtos.Select(x => x.Id);
            var validationResult = SetCategoryId(categoryId,validIds );
            while (!validationResult.IsSuccess)
            {
                Console.WriteLine(validationResult.Message);
                Console.Write("Enter book category id again: ");
                while (!int.TryParse(Console.ReadLine(), out categoryId))
                    Console.Write("Invalid number enter it again: ");
                validationResult = SetCategoryId(categoryId, validIds);
            }
        }

        public ValidationResult SetTitle(string newTitle)
        {
            if (string.IsNullOrWhiteSpace(newTitle))
                return ValidationResult.Fail("The Title should not be null or whiteSpace only");
            
            if (newTitle.Length > Constants.MaxTitleLength)
                return ValidationResult.Fail($"The Title Length should be less that {Constants.MaxTitleLength}");
            Title = newTitle.Trim();    
            return ValidationResult.Success("the Title is valid");            
        }
        public ValidationResult SetAuthor(string newAuthor)
        {
            if (string.IsNullOrWhiteSpace(newAuthor))
                return ValidationResult.Fail("The Author name should not be null or whiteSpace only");
            
            if (newAuthor.Length > Constants.MaxNameLength)
                return ValidationResult.Fail($"The Author name Length should be less that {Constants.MaxNameLength}");
            Author = newAuthor.Trim();
            return ValidationResult.Success("the Author name is valid");            
        }
        public ValidationResult SetPrice(double newPrice)
        {
            if (newPrice < 0)
                return ValidationResult.Fail("Invalid value of price shouldn't be negative");
            Price = newPrice;                            
            return ValidationResult.Success("the Price is valid");            
        }
        public ValidationResult SetPublishedYear(int newPublishedYear)
        {
            if (newPublishedYear < 0)
                return ValidationResult.Fail("Invalid value of Published Year shouldn't be negative");
            if (newPublishedYear > DateTime.Now.Year)
                return ValidationResult.Fail($"Invalid value of Published Year it should less that {DateTime.Now.Year}");
            PublishedYear = newPublishedYear;                            
            return ValidationResult.Success("the Published Year is valid");            
        }
        public ValidationResult SetCategoryId(int newCategoryId,IEnumerable<int> validCategoryId)
        {
            if (newCategoryId < 0)
                return ValidationResult.Fail("Invalid value of Category Id Year shouldn't be negative");
            if (!validCategoryId.Any(x => x == newCategoryId))
                 return ValidationResult.Fail($"Invalid value of Category Id it should be one of this [{string.Join(" , ",validCategoryId)}]");
            CategoryId = newCategoryId;                            
            return ValidationResult.Success("the Category Id Year is valid");            
        }
        public override string ToString() =>
            $"[Book] Title: {Title} | Author: {Author} | Year: {PublishedYear} | Price: {Price:C} | Category Id: {Category.Id} | Category Name: {Category.Name}";

    }
    public class ValidationResult
    {
        private ValidationResult(bool isSuccess , string message)
        {
            IsSuccess = isSuccess; Message = message.Trim();
        }
        public bool IsSuccess { get;}
        public string Message { get;}

        public static ValidationResult Success(string message) => new(true, message);
        public static ValidationResult Fail(string message) => new(false, message);

        public override string ToString() => Message;
    }
}
