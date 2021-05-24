//CntFacturasModel.cs
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.OData.ModelBuilder;
using Microsoft.EntityFrameworkCore;
using Cxc.TablasBasicas.Models;

namespace Cxc.Procesos.Models
{    
    [Table("Facturas", Schema = "CNT")]
    public class CntFacturas
	{	
        public int FacturaId {get; set;}

        public int FacturaSerie {get; set;}

        public string CntComp  
        {
        	get { return $"{FacturaId}/{FacturaSerie}"; } 
        	private set {}
        }

        //[Column(TypeName = "Date")]
        public DateTime FacturaFecha {get; set;}

        [Column(TypeName = "decimal(6, 0)")]
        public decimal ClienteId {get; set;}

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? FacturaValor {get; set;}

        [Column(TypeName = "decimal(18, 2)")]
        public decimal FacturaValorNoGravado {get; set;}

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? FacturaImpuestos {get; set;}

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? FacturaTotal {get; set;}

        public CntClientes CntClientes { get; set; }

        public ICollection<CntFacturaMovimientos> CntFacturaMovimientos { get; set; }
	}

    #region Enum
    #endregion

	
    /// <summary>
    /// Extensión para registrar mapping con el Entity Framework y oData
    /// </summary>
	public static class CntFacturasExtension
	{	        
        #region EF Mapping
        public static ModelBuilder CntFacturasMapping(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<CntFacturas>();
            
            //PrimaryKey
            entity.HasKey(c => new { c.FacturaId, c.FacturaSerie });

           //Relationships
            entity.HasOne(typeof(CntClientes), "CntClientes")
                .WithMany()
                .HasForeignKey("ClienteId")
                .OnDelete(DeleteBehavior.Restrict); // no ON DELETE
                
            //Shadow Properties
            entity.Property<string>("Fuente").HasMaxLength(32).HasDefaultValue("CP4123");
            entity.Property<string>("FuenteImport").HasMaxLength(32);
            entity.Property<int?>("Proceso");
            entity.Property<DateTime?>("Fecha_Computador").HasDefaultValueSql("getdate()");
            entity.Property<string>("Usuario").HasMaxLength(255).HasDefaultValueSql("CURRENT_USER");
            entity.Property<DateTime?>("Fecha_Impresion");
            entity.Property<DateTime?>("Fecha_Reimpresion");

			return modelBuilder;
		}
		
        /// <summary>
        /// Mapping con el oData Framework
        /// </summary>
        /// <param name="oDataModelBuilder"></param>
        public static void CntFacturasMapping(this ODataConventionModelBuilder oDataModelBuilder)
        {
            var entityConfig = oDataModelBuilder.EntitySet<CntFacturas>(nameof(CntFacturas));

            var entity = entityConfig.EntityType;

            // PrimaryKey
            entity.HasKey(c => new { c.FacturaId, c.FacturaSerie });


            ////Ignored properties for oData
            // entityConfig.EntityType.Ignore(x => x.Summary);
        }		
        #endregion
    }
}
