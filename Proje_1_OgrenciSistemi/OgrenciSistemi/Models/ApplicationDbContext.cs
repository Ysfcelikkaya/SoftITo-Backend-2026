namespace OgrenciSistemi.Models;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
         : base(options)
        {

        }
        public DbSet<Bolum> Bolums { get; set; }
        public DbSet<Ogrenci> Ogrencis { get; set; }
        public DbSet<Ders> Derss { get; set; }
        public DbSet<Ogretmen> Ogretmens { get; set; }
    }
