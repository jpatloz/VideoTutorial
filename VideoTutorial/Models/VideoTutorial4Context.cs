using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace VideoTutorial.Models;

public partial class VideoTutorial4Context : DbContext
{
    public VideoTutorial4Context()
    {
    }

    public VideoTutorial4Context(DbContextOptions<VideoTutorial4Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Area> Areas { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=VideoTutorial4;User Id=postgres;Password=Jesus2001.");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Area>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Area_pkey");

            entity.ToTable("Area");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.Nombre).HasColumnType("character varying");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Empleados_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.IdArea)
                .ValueGeneratedOnAdd()
                .UseIdentityAlwaysColumn();
            entity.Property(e => e.Nombre).HasColumnType("character varying");

            entity.HasOne(d => d.IdAreaNavigation).WithMany(p => p.InverseIdAreaNavigation)
                .HasForeignKey(d => d.IdArea)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_empleados");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
