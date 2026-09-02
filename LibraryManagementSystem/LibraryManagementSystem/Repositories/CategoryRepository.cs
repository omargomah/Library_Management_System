using LibraryManagementSystem.Dtos.CategoryDtos;
using LibraryManagementSystem.Entities;
using LibraryManagementSystem.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Repositories
{
    public class CategoryRepository : Repository<Category> ,ICategoryRepository
    {
        public async Task<List<string>> GetAllCategoriesNameAsync() =>
             await _set.Select(x => x.Name).ToListAsync();
        public async Task<List<Category>> GetAllCategoriesWithBooksAsync() =>
            await _set.Include(x => x.Books).ToListAsync();
        public async Task<Category?> GetCategoryByIdWithBooksAsync(int categoryId) =>
            await _set.Include(x => x.Books).SingleOrDefaultAsync(x => x.Id == categoryId);
        public async Task<List<SelectMenuOfCategoryDto>> GetAllCategoriesAsync() =>
             await _set.Select(x => new SelectMenuOfCategoryDto(x.Id,x.Name)).ToListAsync();
    }
}
