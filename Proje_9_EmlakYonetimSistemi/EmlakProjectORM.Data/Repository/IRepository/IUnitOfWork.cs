using System;

namespace EmlakProjectORM.Data.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IPropertyRepository Property { get; }
        IPropertyTypeRepository PropertyType { get; }
        IAdminUserRepository AdminUser { get; }
        IAppUserRepository AppUser { get; }
        IFavoriteRepository Favorite { get; }
        IAppointmentRepository Appointment { get; }

        void Save();
    }
}