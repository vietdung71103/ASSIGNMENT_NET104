using FINAL_ASSIGNMENT.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace FINAL_ASSIGNMENT.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(p => p.RoleId);
            builder.Property(p => p.RoleName).HasColumnType("varchar(100)");
            builder.Property(p => p.Description).HasColumnType("nvarchar(200)");
        }
    }
}
