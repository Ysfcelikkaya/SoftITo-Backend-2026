namespace OgrenciSistemi.Models;
using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> DbContext)
         : base(DbContext)
        {

        }
        public DbSet<Bolum> Bolums { get; set; }
        public DbSet<Ogrenci> Ogrencis { get; set; }
        public DbSet<Ders> Derss { get; set; }
        public DbSet<Ogretmen> Ogretmens { get; set; }
    }
