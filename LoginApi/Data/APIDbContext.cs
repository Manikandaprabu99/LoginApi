using Microsoft.EntityFrameworkCore;
using LoginApi.Models;

namespace LoginApi.Data
{
    public class APIDbContext : DbContext
    {
        public APIDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Form>? Forms { get; set; }
        public DbSet<Admin> AdminDetail { get; set; }
    }
}
