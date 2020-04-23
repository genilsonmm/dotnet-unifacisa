using EFAppContact.WEB.Models;
using Microsoft.EntityFrameworkCore;

namespace EFAppContact.WEB.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Contact> contacts { get; set; }
        public DbSet<Role> roles { get; set; }
    }
}
