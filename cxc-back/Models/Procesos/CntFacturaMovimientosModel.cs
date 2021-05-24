//CntFacturaMovimientosModel.cs
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.OData.ModelBuilder;
using Microsoft.EntityFrameworkCore;
using Cxc.TablasBasicas.Models;

namespace Cxc.Procesos.Models
{    
    [Table("FacturaMovimientos", Schema = "CNT")]
    public class CntFacturaMovimientos
	{	
        public int FacturaId {get; set;}

        public int FacturaSerie {get; set;}

        [MaxLength(8)]
        public string ProductoLinea {get; set;}

        public string CntComp  
        {
        	get { return $"{FacturaId}/{FacturaSerie}/{ProductoLinea}"; } 
        	private set {}
        }

        [Column(TypeName = "decimal(4, 2)")]
        public decimal FacturaMovimientoCantidad {get; set;}

        [Column(TypeName = "decimal(18, 2)")]
        public decimal FacturaMovimientoValorUnidad {get; set;}

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? FacturaMovimientoTotal {get; set;}

        public invProductos invProductos { get; set; }
	}

    #region Enum
    #endregion

	
    /// <summary>
    /// Extensión para registrar mapping con el Entity Framework y oData
    /// </summary>
	public static class CntFacturaMovimientosExtension
	{	        
        #region EF Mapping
        public static ModelBuilder CntFacturaMovimientosMapping(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<CntFacturaMovimientos>();
            
            //PrimaryKey
            entity.HasKey(c => new { c.FacturaId, c.FacturaSerie, c.ProductoLinea });

           //Relationships
            entity.HasOne(typeof(invProductos), "invProductos")
                .WithMany()
                .HasForeignKey("ProductoLinea")
                .OnDelete(DeleteBehavior.Restrict); // no ON DELETE
                
            //Shadow Properties
            entity.Property<string>("Fuente").HasMaxLength(32).HasDefaultValue("CP4123");
            entity.Property<string>("FuenteImport").HasMaxLength(32);
            entity.Property<int?>("Proceso");
            entity.Property<DateTime?>("Fecha_Computador").HasDefaultValueSql("getdate()");
            entity.Property<string>("Usuario").HasMaxLength(255).HasDefaultValueSql("CURRENT_USER");

			return modelBuilder;
		}
		
        /// <summary>
        /// Mapping con el oData Framework
        /// </summary>
        /// <param name="oDataModelBuilder"></param>
        public static void CntFacturaMovimientosMapping(this ODataConventionModelBuilder oDataModelBuilder)
        {
            var entityConfig = oDataModelBuilder.EntitySet<CntFacturaMovimientos>(nameof(CntFacturaMovimientos));

            var entity = entityConfig.EntityType;

            // PrimaryKey
            entity.HasKey(c => new { c.FacturaId, c.FacturaSerie, c.ProductoLinea });


            ////Ignored properties for oData
            // entityConfig.EntityType.Ignore(x => x.Summary);
        }		
        #endregion
    }
}
