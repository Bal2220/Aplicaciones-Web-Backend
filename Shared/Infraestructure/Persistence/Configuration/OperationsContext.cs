using Microsoft.EntityFrameworkCore;
using RetoSem10.Operations.Domain.Models.Entities;

namespace RetoSem10.Shared.Infraestructure.Persistence.Configuration
{
    public class OperationsContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Operation> Operations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Operation>(entity =>
            {
                entity.ToTable("Operations");
                entity.HasKey(o => o.Id);
                
                entity.Property(o => o.Id)
                    .ValueGeneratedOnAdd();
                
                entity.Property(o => o.Title)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(o => o.Type)
                    .IsRequired();

                entity.Property(o => o.Date)
                    .IsRequired();
                
                entity.Property(o => o.Status)
                    .IsRequired();
            });
        }
    }
}