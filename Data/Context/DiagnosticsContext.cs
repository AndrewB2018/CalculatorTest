using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class DiagnosticsContext : DbContext
    {
        public DbSet<DiagnosticsLog> DiagnosticsLog { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(LocalDb)\\MSSQLLocalDB;database=SampleDatabase;trusted_connection=true;");
        }
    }
}
