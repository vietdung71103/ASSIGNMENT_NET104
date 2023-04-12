using FINAL_ASSIGNMENT.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FINAL_ASSIGNMENT.Service.Context
{
    public class WebContext:DbContext
    {
        public WebContext()
        {

        }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillDetail> BillDetails { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartDetail> CartDetails { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Product> Products { get; set; }
        public WebContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-CUA-DUYY\\SQLEXPRESS;Initial Catalog=NewDBNET104;Persist Security Info=True;User ID=ancutroi;Password=123");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
