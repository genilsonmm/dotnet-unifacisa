using Demo4.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo4.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().Property(c => c.Id).HasColumnName("ContactId");
            modelBuilder.Entity<Contact>().HasKey(c => c.Id);
            modelBuilder.Entity<Contact>().Property(c => c.Name).HasMaxLength(30);
            modelBuilder.Entity<Contact>().Property(c => c.Phone).HasMaxLength(14);

            base.OnModelCreating(modelBuilder);
        }
    }
}
