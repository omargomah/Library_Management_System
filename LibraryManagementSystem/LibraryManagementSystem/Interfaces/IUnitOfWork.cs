using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync();


    }
}
