using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using Kutuphane.Model;

namespace Kutuphane.Data.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options)
            :base(options)
        {
        }
        public DbSet<Kitap>Kitaps { get; set; }
        public DbSet<Kategori>Kategoris { get; set; }
        public DbSet<Yazar> Yazars { get; set; }

    }

}
