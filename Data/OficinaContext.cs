using Microsoft.EntityFrameworkCore;
using OficinaHurigueller.Models;

namespace OficinaHurigueller.Data
{
    public class OficinaContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=OficinaHurigueller.db");
        }
    }
}
