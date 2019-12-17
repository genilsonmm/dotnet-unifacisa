using AgendaApp.MODEL;
using Microsoft.EntityFrameworkCore;

namespace AgendaApp.DATA
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Contact>().HasKey(nameof(Contact.Id));
            modelBuilder.Entity<Contact>().Property(p => p.Name).IsRequired().HasMaxLength(30);
        }

    }
}
