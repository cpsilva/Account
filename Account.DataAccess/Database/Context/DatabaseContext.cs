using Account.DataAccess.Database.Configuration;
using Account.DataAccess.Database.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Account.DataAccess.Database.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContaCorrenteEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new LancamentoEntityTypeConfiguration());
            modelBuilder.Seed();
        }
    }
}