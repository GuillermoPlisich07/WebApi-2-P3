﻿using LogicaNegocio.Dominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDatos.Repositorios
{
    public class DBContext : DbContext
    {

        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<MovimientoStock> MovimientosStock { get; set; }
        public DbSet<MovimientoTipo> MovimientosTipo { get; set; }
        public DbSet<Rol> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // ARTICULO

            modelBuilder.Entity<Articulo>()
                .HasKey(a => a.id);

            modelBuilder.Entity<Articulo>()
                .Property(a => a.id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Articulo>()
                .Property(a => a.nombre)
                .IsRequired()
                .HasMaxLength(200)
                .HasAnnotation("MinLength", 10);

            modelBuilder.Entity<Articulo>()
                .Property(a => a.descripcion)
                .IsRequired()
                .HasMaxLength(200);

            modelBuilder.Entity<Articulo>()
                .Property(a => a.codigoProveedor)
                .IsRequired()
                .HasColumnType("bigint");

            modelBuilder.Entity<Articulo>()
                .Property(a => a.precioPublico)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Articulo>()
                .Property(a => a.stock);

            modelBuilder.Entity<Articulo>()
                .HasCheckConstraint("CK_Articulo_CodigoProveedor", "codigoProveedor >= 1000000000000");

            //USUARIO

            modelBuilder.Entity<Usuario>().HasIndex(u => u.email).IsUnique();

            modelBuilder.Entity<Usuario>()
                .HasKey(u => u.id);

            modelBuilder.Entity<Usuario>()
                .Property(u => u.id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Usuario>()
                .Property(u => u.email)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("nvarchar(100)");

            modelBuilder.Entity<Usuario>()
                .Property(u => u.nombre)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("nvarchar(50)");

            modelBuilder.Entity<Usuario>()
                .Property(u => u.apellido)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("nvarchar(50)");

            modelBuilder.Entity<Usuario>()
            .Ignore(e => e.password);

            modelBuilder.Entity<Usuario>()
                .Property(u => u.passwordHash)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("nvarchar(100)");

            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.rol)
                .WithMany()
                .HasForeignKey("RolId") // Opcional si la propiedad en Usuario se llama "RolId"
                .IsRequired();

            // ROL

            modelBuilder.Entity<Rol>()
                .HasKey(r => r.id);

            modelBuilder.Entity<Rol>()
                .Property(r => r.id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Rol>()
                .Property(r => r.nombre)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("nvarchar(50)");

            // MOVIMIENTO STOCK

            modelBuilder.Entity<MovimientoStock>()
                .HasKey(ms => ms.id);

            modelBuilder.Entity<MovimientoStock>()
                .Property(ms => ms.id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<MovimientoStock>()
                .Property(ms => ms.fechaDeMovimiento)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .IsRequired();

            modelBuilder.Entity<MovimientoStock>()
                .Property(ms => ms.cantidadMovidas)
                .IsRequired()
                .HasDefaultValue(0);

            modelBuilder.Entity<MovimientoStock>()
                .HasOne(ms => ms.articulo)
                .WithMany()
                .HasForeignKey("ArticuloId")
                .IsRequired();

            modelBuilder.Entity<MovimientoStock>()
                .HasOne(ms => ms.tipo)
                .WithMany()
                .HasForeignKey("TipoMovimientoId")
                .IsRequired();

            modelBuilder.Entity<MovimientoStock>()
                .HasOne(ms => ms.usuario)
                .WithMany()
                .HasForeignKey("UsuarioId")
                .IsRequired();

            // MOVIMIENTO TIPO
            
            modelBuilder.Entity<MovimientoTipo>()
                .HasKey(tm => tm.id);

            modelBuilder.Entity<MovimientoTipo>()
                .Property(tm => tm.id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<MovimientoTipo>()
                .Property(tm => tm.nombre)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<MovimientoTipo>()
                .HasIndex(tm => tm.nombre)
                .IsUnique();

            

            base.OnModelCreating(modelBuilder);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLOCALDB; Initial Catalog=Obligatorio2P3_2024; Integrated Security=SSPI;");
        }
    }
}