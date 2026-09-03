using LibraryManagementSystem.Entities;
using LibraryManagementSystem.Interfaces;
using LibraryManagementSystem.Interfaces.IRepositories;
using LibraryManagementSystem.Repositories;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace LibraryManagementSystem.Managements
{
    public class CategoryManagement
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryManagement(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task ShowMenuAsync()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=================================");
                Console.WriteLine("       Category Management       ");
                Console.WriteLine("=================================");
                Console.WriteLine("1. Add Category");
                Console.WriteLine("2. Update Category");
                Console.WriteLine("3. Delete Category");
                Console.WriteLine("4. Get Category By ID (with Books)");
                Console.WriteLine("5. Get All Categories");
                Console.WriteLine("6. Return to Main Menu");
                Console.Write("\nSelect an option: ");

                ConsoleKey choice = Console.ReadKey().Key;

                switch (choice)
                {
                    case ConsoleKey.NumPad1:
                        await AddCategoryAsync();
                        break;
                    case ConsoleKey.NumPad2:
                        await UpdateCategoryAsync();
                        break;
                    case ConsoleKey.NumPad3:
                        await DeleteCategoryAsync();
                        break;
                    case ConsoleKey.NumPad4:
                        await GetCategoryByIdAsync();
                        break;
                    case ConsoleKey.NumPad5:
                        await GetAllCategoriesAsync();
                        break;
                    case ConsoleKey.NumPad6:
                        return;
                    default:
                        Console.WriteLine("\nInvalid option you should chose number from 1 to 6");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }
        private async Task AddCategoryAsync()
        {
            StartExecute("Add New Category");
            Category newCategory = Category.Create(await _categoryRepository.GetAllCategoriesNameAsync());
            await _categoryRepository.AddAsync(newCategory);
            EndMessageOfAddAndUpdateAndDelete("add", await _unitOfWork.SaveChangesAsync() > 0);
        }
        private int GetValidId()
        {
            Console.Write("Enter the Id: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id) || id < 1)
                Console.Write("Invalid value enter another one: ");
            return id;
        }
        private async Task<Category?> GetEntityByIdAndCheckIsValidOrNotAsync(Func<int, Task<Category?>> funcToGetCategoryById)
        {
            Category? category = await funcToGetCategoryById.Invoke(GetValidId());
            if (category is null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You enter invalid category Id try again");
                Console.ForegroundColor = ConsoleColor.White;
                EndExecute();
                return null;
            }
            return category;
        }

        private void EndMessageOfAddAndUpdateAndDelete(string action ,bool IsSuccess)
        {
            if (IsSuccess)
                Console.WriteLine($"\nCategory {action} success");
            else
                Console.WriteLine($"\nCategory {action} fail");

            EndExecute();
        }
        private void StartExecute(string action)
        {
            Console.Clear();
            Console.WriteLine($"--- {action} ---");
        }
        private void EndExecute()
        {
            Console.Write("\nPress any key to continue...");
            Console.ReadKey();
        }

        private async Task UpdateCategoryAsync()
        {
            StartExecute("Update Category");

            Category? categoryWillUpdate = await GetEntityByIdAndCheckIsValidOrNotAsync(_categoryRepository.GetByIdAsync);
            if (categoryWillUpdate is null)
                return;
            categoryWillUpdate.UpdateName(await _categoryRepository.GetAllCategoriesNameAsync());
            _categoryRepository.Update(categoryWillUpdate);
            EndMessageOfAddAndUpdateAndDelete("update", await _unitOfWork.SaveChangesAsync() > 0);
        }
        private async Task DeleteCategoryAsync()
        {
            StartExecute("Delete Category");
            
            var category = await GetEntityByIdAndCheckIsValidOrNotAsync(_categoryRepository.GetByIdAsync);
            if (category == null)
                return;

            Console.Write($"Are you sure you want to delete '{category.Name}'? (y/n): ");
            ConsoleKey confirm = Console.ReadKey().Key;

            if (confirm == ConsoleKey.Y)
            {
                _categoryRepository.Delete(category);
                EndMessageOfAddAndUpdateAndDelete("delete", await _unitOfWork.SaveChangesAsync() > 0);
            }
            else
            {
                Console.WriteLine("\nOperation cancelled");
                EndExecute();
            }
        }
        private async Task GetCategoryByIdAsync()
        {
            StartExecute("Find Category by ID");

            var category = await GetEntityByIdAndCheckIsValidOrNotAsync(_categoryRepository.GetCategoryByIdWithBooksAsync);

            if (category is null)
                return;
            Console.WriteLine(category);
            EndExecute();
        }
        private async Task GetAllCategoriesAsync()
        {
            StartExecute("All Categories");

            var categories = await _categoryRepository.GetAllCategoriesWithBooksAsync();

            if (categories.IsNullOrEmpty())
                Console.WriteLine("No categories found in the system.");
            else
            {
                foreach (var category in categories)
                {
                    Console.WriteLine(category);
                    Console.WriteLine(new string('=', 50));
                }
            }
            EndExecute();
        }
    
    }
}
