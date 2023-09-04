using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SugerenciaPNetflix.Models;

public partial class SugerencaPeliculaContext : DbContext
{
    public SugerencaPeliculaContext()
    {
    }

    public SugerencaPeliculaContext(DbContextOptions<SugerencaPeliculaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Pelicula> Peliculas { get; set; }

    public virtual DbSet<PeliculaTipoPelicula> PeliculaTipoPeliculas { get; set; }

    public virtual DbSet<TipoPelicula> TipoPeliculas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<UsuarioTipoPelicula> UsuarioTipoPeliculas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=localhost; database=SugerencaPelicula; integrated security=true; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pelicula>(entity =>
        {
            entity.HasKey(e => e.IdPelicula).HasName("PK__Pelicula__E239B7429D1E05DD");

            entity.ToTable("Pelicula");

            entity.Property(e => e.IdPelicula).HasColumnName("Id_Pelicula");
            entity.Property(e => e.DuracionPelicula)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("duracion_pelicula");
            entity.Property(e => e.Imagen)
                .IsUnicode(false)
                .HasColumnName("imagen");
            entity.Property(e => e.NombrePelicula)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_pelicula");
        });

        modelBuilder.Entity<PeliculaTipoPelicula>(entity =>
        {
            entity.HasKey(e => e.IdPeliculaTipoPelicula).HasName("PK__pelicula__83509A56BA58D38E");

            entity.ToTable("pelicula_TipoPelicula");

            entity.Property(e => e.IdPeliculaTipoPelicula).HasColumnName("Id_peliculaTipoPelicula");
            entity.Property(e => e.IdPelicula).HasColumnName("Id_Pelicula");
            entity.Property(e => e.IdTipoPelicula).HasColumnName("Id_TipoPelicula");

            entity.HasOne(d => d.IdPeliculaNavigation).WithMany(p => p.PeliculaTipoPeliculas)
                .HasForeignKey(d => d.IdPelicula)
                .HasConstraintName("FK__pelicula___Id_Ti__4F7CD00D");

            entity.HasOne(d => d.IdTipoPeliculaNavigation).WithMany(p => p.PeliculaTipoPeliculas)
                .HasForeignKey(d => d.IdTipoPelicula)
                .HasConstraintName("FK__pelicula___Id_Ti__5070F446");
        });

        modelBuilder.Entity<TipoPelicula>(entity =>
        {
            entity.HasKey(e => e.IdTipoPelicula).HasName("PK__TipoPeli__9258762D5215C1C4");

            entity.ToTable("TipoPelicula");

            entity.Property(e => e.IdTipoPelicula).HasColumnName("Id_TipoPelicula");
            entity.Property(e => e.NombreTipoPelicula)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_TipoPelicula");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__DE4431C5D61E2F54");

            entity.ToTable("Usuario");

            entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");
            entity.Property(e => e.FechaNacimiento)
                .HasColumnType("date")
                .HasColumnName("fecha_nacimiento");
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_usuario");
        });

        modelBuilder.Entity<UsuarioTipoPelicula>(entity =>
        {
            entity.HasKey(e => e.IdUsuarioTipoPelicula).HasName("PK__UsuarioT__32EAF4A7C508CCBF");

            entity.ToTable("UsuarioTipoPelicula");

            entity.Property(e => e.IdUsuarioTipoPelicula).HasColumnName("Id_UsuarioTipoPelicula");
            entity.Property(e => e.IdTipoPelicula).HasColumnName("Id_TipoPelicula");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");

            entity.HasOne(d => d.IdTipoPeliculaNavigation).WithMany(p => p.UsuarioTipoPeliculas)
                .HasForeignKey(d => d.IdTipoPelicula)
                .HasConstraintName("FK__UsuarioTi__Id_Ti__5441852A");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.UsuarioTipoPeliculas)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__UsuarioTi__ID_Us__534D60F1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
