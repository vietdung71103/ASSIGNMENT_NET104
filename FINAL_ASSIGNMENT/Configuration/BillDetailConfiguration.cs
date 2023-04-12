using FINAL_ASSIGNMENT.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace FINAL_ASSIGNMENT.Configuration
{
    public class BillDetailConfiguration : IEntityTypeConfiguration<BillDetail>
    {
        public void Configure(EntityTypeBuilder<BillDetail> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Quantity).HasColumnType("int");
            // Set khóa ngoại
            builder.HasOne(p => p.Bill).WithMany(x => x.BillDetail).
                HasForeignKey(k => k.IdHD);
            //builder.HasOne<Product>().WithMany()
            //    .HasForeignKey(p => p.IdSP);
            builder.HasOne(p => p.Product).WithMany(p => p.BillDetail).
                HasForeignKey(k => k.IdSP);
        }
    }
}
