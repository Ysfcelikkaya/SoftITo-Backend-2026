using EmlakProjectORM.Data.Repository.IRepository;
using EmlakProjectORM.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmlakProjectORM.Data.Repository
{
    public class FavoriteRepository:Repository<Favorite>,IFavoriteRepository
    {
        public FavoriteRepository(ApplicationDbContext context) : base(context) { }
    }
}
