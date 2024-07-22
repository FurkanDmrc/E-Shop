using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace E_Shop.Entitites;

public partial class EstoreContext : DbContext
{
    public EstoreContext()
    {

    }

    public EstoreContext(DbContextOptions<EstoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BeyazEsya> BeyazEsyas { get; set; }

    public virtual DbSet<Elektronik> Elektroniks { get; set; }

    public virtual DbSet<Iphone> Iphones { get; set; }

    public virtual DbSet<Kategoriler> Kategorilers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-V4PRQL1\\SQLEXPRESS;Database=EStore;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BeyazEsya>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BeyazEsy__3214EC078A22B4AA");

            entity.ToTable("BeyazEsya");

            entity.Property(e => e.Fiyat).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Marka)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Model)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Kategori).WithMany(p => p.BeyazEsyas)
                .HasForeignKey(d => d.KategoriId)
                .HasConstraintName("FK__BeyazEsya__Kateg__45F365D3");
        });

        modelBuilder.Entity<Elektronik>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Elektron__3214EC07A181A000");

            entity.ToTable("Elektronik");

            entity.Property(e => e.Fiyat).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Marka)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Model)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Kategori).WithMany(p => p.Elektroniks)
                .HasForeignKey(d => d.KategoriId)
                .HasConstraintName("FK__Elektroni__Kateg__48CFD27E");
        });

        modelBuilder.Entity<Iphone>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Iphone__3214EC076EFFBB95");

            entity.ToTable("Iphone");

            entity.Property(e => e.Fiyat).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Marka)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Model)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Kategori).WithMany(p => p.Iphones)
                .HasForeignKey(d => d.KategoriId)
                .HasConstraintName("FK__Iphone__Kategori__38996AB5");
        });

        modelBuilder.Entity<Kategoriler>(entity =>
        {
            entity.HasKey(e => e.KategoriId).HasName("PK__Kategori__1782CC7238515C49");

            entity.ToTable("Kategoriler");

            entity.Property(e => e.KategoriAdi)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
