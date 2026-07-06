using EmlakProjectORM.Data.Repository.IRepository;
using EmlakProjectORM.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmlakProjectORM.Data.Repository
{
    public class PropertyTypeRepository: Repository<PropertyType>,IPropertyTypeRepository
    {
        public PropertyTypeRepository(ApplicationDbContext context): base(context) { }
    }
}
