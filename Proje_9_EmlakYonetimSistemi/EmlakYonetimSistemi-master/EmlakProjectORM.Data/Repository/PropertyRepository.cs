using EmlakProjectORM.Models;
using EmlakProjectORM.Data.Repository.IRepository;

namespace EmlakProjectORM.Data.Repository
{
    public class PropertyRepository : Repository<Property>, IPropertyRepository
    {
        public PropertyRepository(ApplicationDbContext context) : base(context) { }
    }
}