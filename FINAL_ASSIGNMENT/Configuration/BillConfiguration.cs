using FINAL_ASSIGNMENT.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace FINAL_ASSIGNMENT.Configuration
{
    public class BillConfiguration : IEntityTypeConfiguration<Bill>
    {
        //public Guid Id { get; set; }
        //public DateTime CreateDate { get; set; }
        //public Guid UserId { get; set; }
        //public int Status { get; set; }
        //public virtual List<BillDetail> BillDetail { get; set; }
        //public virtual User User { get; set; }
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(p => p.Status).HasColumnType("int").
                IsRequired(); // int not null
            //builder.Property(p => p.Name).HasColumnType("nvarchar(100)").IsRequired();
            builder.Property(p => p.CreateDate).HasColumnType("Datetime");
            builder.HasOne(p => p.User).WithMany(p => p.Bill).
                HasForeignKey(p => p.UserId);
        }
    }
}
