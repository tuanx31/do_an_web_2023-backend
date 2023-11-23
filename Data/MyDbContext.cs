using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace web_api.Data
{
    public class MyDbContext : IdentityDbContext<ApplicationUser>
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<Product> products { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Trademark> Trademark { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Group_role> GroupRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SetRoles(builder);
        }
        private void SetRoles (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole() {  Name = "Admin" , ConcurrencyStamp = "1" ,NormalizedName = "Admin"},
                new IdentityRole() { Name = "User", ConcurrencyStamp = "1", NormalizedName = "User" }
                );
        }
    }
}
