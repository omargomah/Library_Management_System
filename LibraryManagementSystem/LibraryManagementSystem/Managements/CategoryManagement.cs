using LibraryManagementSystem.Entities;
using LibraryManagementSystem.Interfaces;
using LibraryManagementSystem.Interfaces.IRepositories;
using LibraryManagementSystem.Repositories;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

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
        public async Task AddCategoryAsync()
        {
            Console.Clear();
            Console.WriteLine("--- Add New Category ---");
            Category newCategory = Category.Create(await _categoryRepository.GetAllCategoriesNameAsync());
            await _categoryRepository.AddAsync(newCategory);
            EndMessageOfAddAndUpdateAndDelete("add", await _unitOfWork.SaveChangesAsync() > 0);
        }
        private int GetValidId()
        {
            Console.Write("Enter the Id: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id) && id < 1)
                Console.Write("Invalid value enter another one: ");
            return id;
        }
        private async Task<Category?> GetEntityByIdAndCheckIsValidOrNot(Func<int, Task<Category?>> funcToGetCategoryById)
        {
            Category? category = await funcToGetCategoryById.Invoke(GetValidId());
            if (category is null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You enter invalid book Id try again");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
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

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

        }

        public async Task UpdateCategoryAsync()
        {
            Console.Clear();
            Console.WriteLine("--- Update Category ---");

            Category? categoryWillUpdate = await GetEntityByIdAndCheckIsValidOrNot(_categoryRepository.GetByIdAsync);
            if (categoryWillUpdate is null)
                return;
            categoryWillUpdate.UpdateName(await _categoryRepository.GetAllCategoriesNameAsync());
            _categoryRepository.Update(categoryWillUpdate);
            EndMessageOfAddAndUpdateAndDelete("update", await _unitOfWork.SaveChangesAsync() > 0);
        }
        public async Task DeleteCategoryAsync()
        {
            Console.Clear();
            Console.WriteLine("--- Delete Category ---");
            
            var category = await GetEntityByIdAndCheckIsValidOrNot(_categoryRepository.GetByIdAsync);
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
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
