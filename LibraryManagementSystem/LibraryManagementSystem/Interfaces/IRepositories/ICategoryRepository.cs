using LibraryManagementSystem.Dtos.CategoryDtos;
using LibraryManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Interfaces.IRepositories
{
    public interface ICategoryRepository:IRepository<Category>
    {
        Task<string> GetMostPopularCategoryAsync();
        Task<List<CategoryNameAndCountOfBooksInItDto>> GetCategoryByIdWithBooksCountAsync();
        Task < List<SelectMenuOfCategoryDto>> GetAllCategoriesAsync();
        Task<List<string>> GetAllCategoriesNameAsync();
        Task<Category?> GetCategoryByIdWithBooksAsync(int categoryId);
        Task<List<Category>> GetAllCategoriesWithBooksAsync();

    }
}
