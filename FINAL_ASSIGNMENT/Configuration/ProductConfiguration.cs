using FINAL_ASSIGNMENT.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace FINAL_ASSIGNMENT.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            //     public Guid Id { get; set; }
            //public string Name { get; set; }
            //public int Price { get; set; }
            //public int AvailableQuantity { get; set; }
            //public int Status { get; set; }
            //public string Description { get; set; }
            //public string Supplier { get; set; }
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).
                HasColumnType("nvarchar(100)");
            // nvarchar(100)
            // nchar(100) vs nvarchar(100)
            builder.Property(c => c.Price).HasColumnType("decimal").IsRequired();
            builder.Property(c => c.AvailableQuantity).HasColumnType("int").IsRequired();
            builder.Property(c => c.Status).HasColumnType("int").IsRequired();
            builder.Property(c => c.UrlImage).HasColumnType("nvarchar(200)");
            builder.Property(p => p.Description).
                HasColumnType("nvarchar(100)");
            builder.Property(p => p.Supplier).HasMaxLength(100).
                IsUnicode(true).IsFixedLength();
            //builder.HasOne(p => p.Supplier).WithMany(p => p.Products).
            //    HasForeignKey(p => p.IdSupplier);
            //builder.HasOne(p => p.Category).WithMany(p => p.Products).
            //        HasForeignKey(p => p.IdCategory);
        }
    }
}
