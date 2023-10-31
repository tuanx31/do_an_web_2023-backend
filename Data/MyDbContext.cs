using Microsoft.EntityFrameworkCore;
using web_api.Data;

namespace web_api.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Product> products { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<web_api.Data.Trademark>? Trademark { get; set; }
    }
}
