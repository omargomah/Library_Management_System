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
            if(await _unitOfWork.SaveChangesAsync() > 0)
                Console.WriteLine("\nCategory added success");
            else
                Console.WriteLine("\nCategory added fail");

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        private int GetValidId()
        {
            Console.Write("Enter the Id: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id) && id < 1)
                Console.Write("Invalid value enter another one: ");
            return id;
        }
        private async Task<Category?> GetEntityByIdAndCheckIsValidOrNot(Func<int, Task<Category>> funcToGetCategoryById)
        {
            Category? book = await funcToGetCategoryById.Invoke(GetValidId());
            if (book is null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You enter invalid book Id try again");
                Console.ForegroundColor = ConsoleColor.White;
                return null;
            }
            return book;
        }


        public async Task UpdateCategoryAsync()
        {
            Console.Clear();
            Console.WriteLine("--- Update Category ---");

            Category? categoryWillUpdate = await GetEntityByIdAndCheckIsValidOrNot(_categoryRepository.GetByIdAsync);
            if (categoryWillUpdate is null)
            {
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return;
            }

            categoryWillUpdate.UpdateName(await _categoryRepository.GetAllCategoriesNameAsync());

            _categoryRepository.Update(category);
            // await _categoryRepository.SaveChangesAsync();

            Console.WriteLine("\nSuccess: Category updated successfully!");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
