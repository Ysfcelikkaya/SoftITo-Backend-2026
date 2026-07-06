using EmlakProjectORM.Data.Repository.IRepository;
using EmlakProjectORM.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmlakProjectORM.Data.Repository
{
    public class AppUserRepository:Repository<AppUser>,IAppUserRepository
    {
        public AppUserRepository(ApplicationDbContext context):base(context) { }   
    }
}
