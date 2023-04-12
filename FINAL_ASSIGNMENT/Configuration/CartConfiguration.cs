using FINAL_ASSIGNMENT.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace FINAL_ASSIGNMENT.Configuration
{
	public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(p => p.UserId);
            builder.Property(p => p.Description).
                HasColumnType("nvarchar(200)");
        }
    }
}
