using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
    }
}
