using Microsoft.EntityFrameworkCore;
using RetoSem11.Management.Domain.Models.Entities;

namespace RetoSem11.Shared.Infraestructure.Persistence.Configuration
{
    public class OperationContext(DbContextOptions options) : DbContext(options)
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
                    .IsRequired()
                    .ValueGeneratedOnAdd();
                
                entity.Property(o => o.Title)
                    .IsRequired()
                    .HasMaxLength(100);
                
                entity.Property(o => o.Description)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(o => o.Type)
                    .IsRequired()
                    .HasConversion<string>();
                
                entity.Property(o => o.Status)
                    .IsRequired();
            });
        }
    }
}