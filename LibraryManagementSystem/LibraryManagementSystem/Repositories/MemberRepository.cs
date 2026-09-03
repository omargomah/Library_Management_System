using LibraryManagementSystem.Entities;
using LibraryManagementSystem.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Repositories
{
    public class MemberRepository:Repository<Member>,IMemberRepository
    {
    }
}
