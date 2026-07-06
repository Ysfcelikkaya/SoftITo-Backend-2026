using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DbFirstProject.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Doktor> Doktors { get; set; }

    public virtual DbSet<Hasta> Hastas { get; set; }

    public virtual DbSet<Randevu> Randevus { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=Default");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Doktor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Doktors__3214EC07452B0BD2");

            entity.Property(e => e.Ad).HasMaxLength(50);
            entity.Property(e => e.Soyad).HasMaxLength(50);
            entity.Property(e => e.Telefon).HasMaxLength(20);
            entity.Property(e => e.UzmanlikAlani).HasMaxLength(100);
        });

        modelBuilder.Entity<Hasta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Hastas__3214EC07D7B2CBCE");

            entity.Property(e => e.Ad).HasMaxLength(50);
            entity.Property(e => e.Cinsiyet).HasMaxLength(10);
            entity.Property(e => e.Soyad).HasMaxLength(50);
            entity.Property(e => e.TcNo).HasMaxLength(11);
        });

        modelBuilder.Entity<Randevu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Randevus__3214EC07CD36198B");

            entity.Property(e => e.RandevuTarihi).HasColumnType("datetime");

            entity.HasOne(d => d.Doktor).WithMany(p => p.Randevus)
                .HasForeignKey(d => d.DoktorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Randevus_Doktors");

            entity.HasOne(d => d.Hasta).WithMany(p => p.Randevus)
                .HasForeignKey(d => d.HastaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Randevus_Hastas");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
