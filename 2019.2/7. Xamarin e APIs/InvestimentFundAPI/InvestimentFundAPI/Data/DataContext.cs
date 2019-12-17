using InvestimentFundAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace InvestimentFundAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Fund> Funds { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Fund>().HasKey(nameof(Fund.FundId));
            modelBuilder.Entity<Fund>().Property(p => p.Name).IsRequired().HasMaxLength(10);
        }
    }
}
