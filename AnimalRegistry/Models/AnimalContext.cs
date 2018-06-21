using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimalRegistry.Models
{
    public class AnimalContext : DbContext
    {
        public DbSet<Animal> Animals { get; set; }

        public AnimalContext(DbContextOptions<AnimalContext> options)
             : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Animal>(ConfigureAnimal);
        }

        private void ConfigureAnimal(EntityTypeBuilder<Animal> builder)
        {
            builder.ToTable("Animal");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id)
                .ForSqlServerUseSequenceHiLo("animal_hilo")
                .IsRequired();

            builder.Property(a => a.Class)
                .IsRequired(true)
                .HasMaxLength(50);

            builder.Property(a => a.Gender)
                .IsRequired(true)
                .HasMaxLength(4);

            builder.Property(a => a.Name)
                .IsRequired(true)
                .HasMaxLength(20);

            builder.Property(a => a.Location)
                .IsRequired(true)
                .HasMaxLength(30);

            builder.Property(a => a.Weight)
                .IsRequired(false);

            builder.Property(a => a.DateOfWeighing)
                .IsRequired(false);
        }
    }
}
