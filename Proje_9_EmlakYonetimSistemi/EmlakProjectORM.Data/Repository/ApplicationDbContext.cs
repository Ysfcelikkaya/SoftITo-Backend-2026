using EmlakProjectORM.Models;
using Microsoft.EntityFrameworkCore;

namespace EmlakProjectORM.Data.Repository
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyType> PropertyTypes { get; set; }
        public DbSet<AdminUser> AdminUsers { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
    }
}