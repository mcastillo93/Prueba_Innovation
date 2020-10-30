using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_Innovation.Models
{
    public class InnovationContext : DbContext
    {
        public InnovationContext()
        {
        }

        public InnovationContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlServer("Data Source=(local);Initial Catalog=DBInnovation;user id=sa;password=g34rs0fw4r.");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Conductor>()
            .HasIndex(p => new { p.DNI })
            .IsUnique(true);
        }

        public DbSet<Conductor> Conductores { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Infracciones> Infracciones { get; set; }

    }
}