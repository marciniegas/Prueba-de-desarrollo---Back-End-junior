using Microsoft.EntityFrameworkCore;
using System;

namespace Bovinos.Models
{
    public class AnimalDbContext : DbContext
    {
        public DbSet<Animal> Animals { get; set; }

        public AnimalDbContext(DbContextOptions<AnimalDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = "Server=localhost;Port=3306;Database=bovino_informacion;User=root;Password=3153470985;";
                optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            // Configuración de datos mediante el uso de Fluent API
            modelBuilder.Entity<Animal>()
            .HasIndex(a => new { a.Nombre })
            .IsUnique();

            /*modelBuilder.Entity<Animal>()
            .Property(a => a.FechaNacimiento)
            .IsRequired(false);
            */

            modelBuilder.Entity<Animal>()
            .Property(a => a.Precio)
            .IsRequired()
            .HasDefaultValue(0.0)
            .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Animal>()
            .Property(a => a.Raza)
            .IsRequired()
            .HasMaxLength(100);


        }
    }
}
