//invSaldosModel.cs
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.OData.ModelBuilder;
using Microsoft.EntityFrameworkCore;

namespace Cxc.TablasBasicas.Models
{    
    [Table("Saldos", Schema = "inv")]
    public class invSaldos
	{	
        [MaxLength(8)]
        public string ProductoLinea {get; set;}

        [MaxLength(15)]
        public string PeriodoDescripcionx {get; set;}

        public string invComp  
        {
        	get { return $"{ProductoLinea}/{PeriodoDescripcionx}"; } 
        	private set {}
        }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal InvSaldosCantidad {get; set;}

        [Column(TypeName = "decimal(6, 2)")]
        public decimal InvSaldosValor {get; set;}

        [Column(TypeName = "decimal(7, 2)")]
        public decimal? InvSaldosTotal {get; set;}

        [Column(TypeName = "decimal(6, 2)")]
        public decimal? InvSaldosValorPromedio {get; set;}

        [Column(TypeName = "decimal(6, 2)")]
        public decimal? InvSaldosUltimoValor {get; set;}

        [Column(TypeName = "decimal(6, 2)")]
        public decimal? InvSaldosMaximoValor {get; set;}
	}

    #region Enum
    #endregion

	
    /// <summary>
    /// Extensión para registrar mapping con el Entity Framework y oData
    /// </summary>
	public static class invSaldosExtension
	{	        
        #region EF Mapping
        public static ModelBuilder invSaldosMapping(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<invSaldos>();
            
            //PrimaryKey
            entity.HasKey(c => new { c.ProductoLinea, c.PeriodoDescripcionx });

           //Relationships
            //Shadow Properties
            entity.Property<string>("Fuente").HasMaxLength(32).HasDefaultValue("CP4124");
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
        public static void invSaldosMapping(this ODataConventionModelBuilder oDataModelBuilder)
        {
            var entityConfig = oDataModelBuilder.EntitySet<invSaldos>(nameof(invSaldos));

            var entity = entityConfig.EntityType;

            // PrimaryKey
            entity.HasKey(c => new { c.ProductoLinea, c.PeriodoDescripcionx });


            ////Ignored properties for oData
            // entityConfig.EntityType.Ignore(x => x.Summary);
        }		
        #endregion
    }
}
