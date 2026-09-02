using LibraryManagementSystem.Entities;
using LibraryManagementSystem.Interfaces;
using LibraryManagementSystem.Interfaces.IRepositories;
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
    }
}
