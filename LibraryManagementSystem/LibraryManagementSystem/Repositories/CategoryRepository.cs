using LibraryManagementSystem.Data;
using LibraryManagementSystem.Dtos.CategoryDtos;
using LibraryManagementSystem.Entities;
using LibraryManagementSystem.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;
namespace LibraryManagementSystem.Repositories
{
    public class CategoryRepository(ApplicationDbContext dbContext) : Repository<Category>(dbContext) ,ICategoryRepository
    {

        public async Task<string> GetMostPopularCategoryAsync()
        {
            var MostPopularCategory = await _set.Select(x =>
            new{
                    CategoryName = x.Name,
                    BorrowingCount = x.Books.SelectMany(x => x.Borrowings).Count()
                }).OrderByDescending(x => x.BorrowingCount).FirstOrDefaultAsync();
            if (MostPopularCategory is null)
                return "There is No categories in System yet";
            return MostPopularCategory.CategoryName;
        }
        public async Task<List<CategoryNameAndCountOfBooksInItDto>> GetCategoryByIdWithBooksCountAsync() =>
            await _set.Select(x => new CategoryNameAndCountOfBooksInItDto() 
            {
                BooksCount = x.Books.Count,
                CategoryName = x.Name
            }).ToListAsync();
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
