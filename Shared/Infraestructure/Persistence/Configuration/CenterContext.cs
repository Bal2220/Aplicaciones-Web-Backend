using Microsoft.EntityFrameworkCore;
using RetoSem9.Catalog.Domain.Models.Entities;

namespace RetoSem9.Shared.Infraestructure.Persistence.Configuration;

public class CenterContext(DbContextOptions options) : DbContext(options)
{
    /*public DbSet<Product> Products { get; set; }
    public DbSet<MembershipStatus> MembershipStatus { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");
            entity.HasKey(p => p.Id);

            entity.Property(p => p.Id)
                .ValueGeneratedOnAdd();

            entity.Property(p => p.ProductType)
                .IsRequired()
                .HasMaxLength(10);

            entity.Property(p => p.ProductPriceOriginal)
                .IsRequired();

            entity.Property(p => p.ProductPriceDiscount)
                .IsRequired();
            
            entity.HasOne(p => p.MembershipStatus)
                .WithMany(m => m.Products)
                .HasForeignKey(p => p.MembershipStatusID);
        });
        
        builder.Entity<MembershipStatus>(entity =>
        {
            entity.ToTable("MembershipStatus");
            entity.HasKey(m => m.Id);

            entity.Property(m => m.Id)
                .ValueGeneratedOnAdd();
            
            entity.Property(m => m.Status)
                .IsRequired()
                .HasMaxLength(10);
        });
    }*/
    
    public DbSet<Discount> Purchases { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Discount>(entity =>
        {
            entity.ToTable("Purchase");
            entity.HasKey(p => p.Id);

            entity.Property(p => p.Id)
                .ValueGeneratedOnAdd();

            entity.Property(p => p.MembershipStatus)
                .IsRequired()
                .HasMaxLength(7);

            entity.Property(p => p.ProductType)
                .IsRequired()
                .HasMaxLength(10);

            entity.Property(p => p.ProductPriceOriginal)
                .IsRequired();
        });
    }
}