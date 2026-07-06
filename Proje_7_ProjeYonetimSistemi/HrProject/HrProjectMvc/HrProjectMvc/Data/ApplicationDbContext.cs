
using Microsoft.EntityFrameworkCore;
using HrProjectMvc.Models;

namespace HrProjectMvc.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }

        public DbSet<Roles> Roles { get; set; }
    }
}