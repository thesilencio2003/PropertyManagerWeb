using Microsoft.EntityFrameworkCore;
using PropertyManagerWeb.Models;

namespace PropertyManagerWeb.Data
{
    public class PropertyManagerContext : DbContext
    {
        public DbSet<Propiedades> Propiedades { get; set; }
        public DbSet<Inquilinos> Inquilinos { get; set; }
        public DbSet<Contratos> Contratos { get; set; }
        public DbSet<Pagos> Pagos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\mssqllocaldb;Database=PropertyManagerDB;Trusted_Connection=True;");
        }
    } 
}
