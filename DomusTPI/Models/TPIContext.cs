using System;
using DomusTPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DomusTPITPI.Models
{
    public partial class TPIContext : DbContext
    {
        public TPIContext()
        {
        }

        public TPIContext(DbContextOptions<TPIContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Agenda> Agendas { get; set; }
        public virtual DbSet<Calendario> Calendario { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Empleado> Empleados { get; set; }
        public virtual DbSet<Horarios> Horarios { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
