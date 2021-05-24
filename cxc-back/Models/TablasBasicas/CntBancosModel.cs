//CntBancosModel.cs
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.OData.ModelBuilder;
using Microsoft.EntityFrameworkCore;

namespace Cxc.TablasBasicas.Models
{    
    [Table("Bancos", Schema = "CNT")]
    public class CntBancos
	{	
        public int BancoId {get; set;}

        [MaxLength(22)]
        public string BancoNombre {get; set;}

        public int BancoLongitud {get; set;}
	}

    #region Enum
    #endregion

	
    /// <summary>
    /// Extensión para registrar mapping con el Entity Framework y oData
    /// </summary>
	public static class CntBancosExtension
	{	        
        #region EF Mapping
        public static ModelBuilder CntBancosMapping(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<CntBancos>();
            
            //PrimaryKey
            entity.HasKey(c => new { c.BancoId });

           //Relationships
            //Shadow Properties
            entity.Property<string>("Fuente").HasMaxLength(32).HasDefaultValue("CP3121");
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
        public static void CntBancosMapping(this ODataConventionModelBuilder oDataModelBuilder)
        {
            var entityConfig = oDataModelBuilder.EntitySet<CntBancos>(nameof(CntBancos));

            var entity = entityConfig.EntityType;

            // PrimaryKey
            entity.HasKey(c => new { c.BancoId });


            ////Ignored properties for oData
            // entityConfig.EntityType.Ignore(x => x.Summary);
        }		
        #endregion
    }
}
