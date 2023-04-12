using FINAL_ASSIGNMENT.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace FINAL_ASSIGNMENT.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Username).HasColumnType("varchar(256)");
            builder.Property(p => p.FullName).HasColumnType("nvarchar(256)");
            builder.Property(p => p.Email).HasColumnType("varchar(256)");
            builder.Property(p => p.Password).HasColumnType("varchar(256)");
            builder.Property(p => p.Status).HasColumnType("int");
            builder.Property(p => p.Avatar).HasColumnType("varchar(256)");
            builder.HasOne(p => p.Role).WithMany(p => p.Users).
                HasForeignKey(p => p.RoleId);
        }
    }
}
