using Cxc.TablasBasicas.Models;
using Cxc.TablasBasicas.Interfaces;
using Cxc.TablasBasicas.Managers;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.OData.ModelBuilder;
using Cxc.Procesos.Models;
using Cxc.Procesos.Managers;
using Cxc.Procesos.Interfaces;

namespace Cxc.OData
{
    public class ConventionModelBuilder
    {
        public ConventionModelBuilder(ODataConventionModelBuilder modelBuilder) 
        {
            modelBuilder.CntBancosMapping();
            modelBuilder.CntCodigosCiiuMapping();
            modelBuilder.CntClientesMapping();
            modelBuilder.CntCiudadesMapping();
            modelBuilder.invProductosMapping();
            modelBuilder.invSaldosMapping();
            modelBuilder.CntFacturasMapping();
            modelBuilder.CntFacturaMovimientosMapping();
        }

        public static void AddODataScoped(IServiceCollection services) 
        {
            services.AddScoped<ICntBancosManager, CntBancosManager>();
            services.AddScoped<ICntCodigosCiiuManager, CntCodigosCiiuManager>();
            services.AddScoped<ICntClientesManager, CntClientesManager>();
            services.AddScoped<ICntCiudadesManager, CntCiudadesManager>();
            services.AddScoped<IinvProductosManager, invProductosManager>();
            services.AddScoped<IinvSaldosManager, invSaldosManager>();
            services.AddScoped<ICntFacturasManager, CntFacturasManager>();
            services.AddScoped<ICntFacturaMovimientosManager, CntFacturaMovimientosManager>();
        }
    } 
}

