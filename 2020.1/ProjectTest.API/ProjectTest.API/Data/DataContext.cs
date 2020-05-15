using Microsoft.EntityFrameworkCore;
using ProjectTest.API.Model;
using ProjectTest.Domain;

namespace ProjectTest.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}
