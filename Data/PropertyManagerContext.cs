using Microsoft.EntityFrameworkCore;
using PropertyManagerWeb.Models;

namespace PropertyManagerWeb.Data
{
    public class PropertyManagerContext : DbContext
    {
        public PropertyManagerContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Propiedades> Propiedades { get; set; }
        public DbSet<Inquilinos> Inquilinos { get; set; }
        public DbSet<Contratos> Contratos { get; set; }
        public DbSet<Pagos> Pagos { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
