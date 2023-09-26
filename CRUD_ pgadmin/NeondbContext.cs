using System;
using System.Collections.Generic;
using CRUD__pgadmin.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD__pgadmin;

public partial class NeondbContext : DbContext
{
    public NeondbContext()
    {
    }

    public NeondbContext(DbContextOptions<NeondbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Publish> Publishes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=ep-winter-frog-92114323.us-east-2.aws.neon.tech;Username=kek.20;Password=QRIiynfvcx23;Database=neondb");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.IdBook).HasName("book_pkey");

            entity.ToTable("book");

            entity.Property(e => e.IdBook).HasColumnName("id_book");
            entity.Property(e => e.IdPublish).HasColumnName("id_publish");
            entity.Property(e => e.NameBook)
                .HasMaxLength(128)
                .HasColumnName("name_book");
            entity.Property(e => e.Price).HasColumnName("price");

            entity.HasOne(d => d.IdPublishNavigation).WithMany(p => p.Books)
                .HasForeignKey(d => d.IdPublish)
                .HasConstraintName("FK_book_id_publish");
        });

        modelBuilder.Entity<Publish>(entity =>
        {
            entity.HasKey(e => e.IdPublish).HasName("publish_pkey");

            entity.ToTable("publish");

            entity.Property(e => e.IdPublish).HasColumnName("id_publish");
            entity.Property(e => e.Adress)
                .HasColumnType("character varying")
                .HasColumnName("adress");
            entity.Property(e => e.NamePublish)
                .HasColumnType("character varying")
                .HasColumnName("name_publish");
            entity.Property(e => e.Phone).HasColumnName("phone");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
