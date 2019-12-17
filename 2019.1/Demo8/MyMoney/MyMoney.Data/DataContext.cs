using Microsoft.EntityFrameworkCore;
using MyMoney.Data.Model;

namespace MyMoney.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet <Purchase> Purchases  { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Purchase>().Property(p => p.Value).HasColumnType("Decimal(10,2)");
        }
    }
}
