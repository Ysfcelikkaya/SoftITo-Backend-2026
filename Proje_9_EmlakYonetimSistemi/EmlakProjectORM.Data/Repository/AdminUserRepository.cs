using EmlakProjectORM.Data.Repository.IRepository;
using EmlakProjectORM.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmlakProjectORM.Data.Repository
{
    internal class AdminUserRepository:Repository<AdminUser>,IAdminUserRepository
    {
        public AdminUserRepository(ApplicationDbContext context) : base(context) { }
    }
}
