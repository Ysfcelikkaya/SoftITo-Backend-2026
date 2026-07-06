using EmlakProjectORM.Data.Repository.IRepository;

namespace EmlakProjectORM.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IPropertyRepository Property => new PropertyRepository(_context);
        public IPropertyTypeRepository PropertyType => new PropertyTypeRepository(_context);
        public IAdminUserRepository AdminUser => new AdminUserRepository(_context);
        public IAppUserRepository AppUser => new AppUserRepository(_context);
        public IFavoriteRepository Favorite => new FavoriteRepository(_context);
        public IAppointmentRepository Appointment => new AppointmentRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}