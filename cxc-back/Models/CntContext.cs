using Cxc.Procesos.Models;
using Microsoft.EntityFrameworkCore;

namespace Cxc.TablasBasicas.Models
{
    public class CntContext
    : DbContext
    {
        public DbSet<CntFacturas> CntFacturas { get; set; }
        public DbSet<CntFacturaMovimientos> CntFacturaMovimientos { get; set; }
        public DbSet<invProductos> invProductos { get; set; }
        public DbSet<invSaldos> invSaldos { get; set; }
        public DbSet<CntCiudades> CntCiudades { get; set; }
        public DbSet<CntClientes> CntClientes { get; set; }

        public DbSet<CntBancos> CntBancos { get; set; }
        public DbSet<CntCodigosCiiu> CntCodigosCiiu { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.CntBancosMapping();
            modelBuilder.CntCodigosCiiuMapping();
            modelBuilder.CntClientesMapping();
            modelBuilder.CntCiudadesMapping();
            modelBuilder.invProductosMapping();
            modelBuilder.invSaldosMapping();
            modelBuilder.CntFacturasMapping();
            modelBuilder.CntFacturaMovimientosMapping();
        }

        public CntContext(DbContextOptions<CntContext> options) : base(options)
        {
        }
    }
}
