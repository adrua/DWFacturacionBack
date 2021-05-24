//CntCodigosCiiuModel.cs
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.OData.ModelBuilder;
using Microsoft.EntityFrameworkCore;

namespace Cxc.TablasBasicas.Models
{    
    [Table("CodigosCiiu", Schema = "CNT")]
    public class CntCodigosCiiu
	{	
        [MaxLength(6)]
        public string CodigoCiiuId {get; set;}

        [MaxLength(246)]
        public string CodigoCiiuDescripcion {get; set;}

        [Column(TypeName = "bit")]
        public bool CodigoCiiuclase {get; set;}

        [Column(TypeName = "bit")]
        public bool CodigoCiiugrupo {get; set;}

        [Column(TypeName = "bit")]
        public bool CodigoCiiudivision {get; set;}

        [Column(TypeName = "bit")]
        public bool CodigoCiiuBloqueo {get; set;}
	}

    #region Enum
    #endregion

	
    /// <summary>
    /// Extensión para registrar mapping con el Entity Framework y oData
    /// </summary>
	public static class CntCodigosCiiuExtension
	{	        
        #region EF Mapping
        public static ModelBuilder CntCodigosCiiuMapping(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<CntCodigosCiiu>();
            
            //PrimaryKey
            entity.HasKey(c => new { c.CodigoCiiuId });

           //Relationships
            //Shadow Properties
            entity.Property<string>("Fuente").HasMaxLength(32).HasDefaultValue("CP3000");
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
        public static void CntCodigosCiiuMapping(this ODataConventionModelBuilder oDataModelBuilder)
        {
            var entityConfig = oDataModelBuilder.EntitySet<CntCodigosCiiu>(nameof(CntCodigosCiiu));

            var entity = entityConfig.EntityType;

            // PrimaryKey
            entity.HasKey(c => new { c.CodigoCiiuId });


            ////Ignored properties for oData
            // entityConfig.EntityType.Ignore(x => x.Summary);
        }		
        #endregion
    }
}
