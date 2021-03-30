using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test81b.Models;

namespace Test81b.DAL
{
    public class DefaultContext: DbContext
    {
        public DefaultContext()
        {
        }
        public DefaultContext(DbContextOptions<DefaultContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Departamento> Departamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Departamento>(entity => {
                //entity.ToTable("stockCombustible", "gasStock");
                entity.HasKey(e => e.Codigo);
                entity.Property(e => e.Nombre);
            });

            modelBuilder.Entity<Departamento>().HasData(
                new Departamento { Codigo = 1, Nombre = "Recursos Humanos" },
                new Departamento { Codigo = 2, Nombre = "Informatica" },
                new Departamento { Codigo = 3, Nombre = "Contabilidad" }
                );

            modelBuilder.Entity<Usuario>(entity => {
                entity.Property(e => e.Id);
                entity.Property(e => e.Nombres);
                entity.Property(e => e.Apellidos);
                entity.Property(e => e.Genero);
                entity.Property(e => e.Cedula);
                entity.Property(e => e.FechaNacimiento);
                entity.HasOne(e => e.Departamento);
                entity.Property(e => e.Cargo);
                entity.Property(e => e.SupervisorInmediato);
            });

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
