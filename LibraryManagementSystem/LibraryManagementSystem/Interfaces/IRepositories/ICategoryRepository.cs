using LibraryManagementSystem.Dtos.CategoryDtos;
using LibraryManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Interfaces.IRepositories
{
    public interface ICategoryRepository:IRepository<Category>
    {
        Task<List<SelectMenuOfCategoryDto>> GetAllCategoriesAsync();
    }
}
