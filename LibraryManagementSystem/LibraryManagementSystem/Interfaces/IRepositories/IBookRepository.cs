using LibraryManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Interfaces.IRepositories
{
    public interface IBookRepository: IRepository<Book>
    {
        Task<List<Book>> GetAllBooksWithCategoryAsync();
        Task<Book?> GetBookWithCategoryByIdAsync(int bookId);
        IQueryable<Book> GetAllBooksWithCategory();

    }
}
