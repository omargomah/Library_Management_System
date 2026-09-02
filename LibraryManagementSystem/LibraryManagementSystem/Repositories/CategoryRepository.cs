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
        public async Task<List<SelectMenuOfCategoryDto>> GetAllCategoriesAsync() =>
             await _set.Select(x => new SelectMenuOfCategoryDto(x.Id,x.Name)).ToListAsync();
    }
}
