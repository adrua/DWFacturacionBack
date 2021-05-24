//CntCiudadesModel.cs
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.OData.ModelBuilder;
using Microsoft.EntityFrameworkCore;

namespace Cxc.TablasBasicas.Models
{    
    [Table("Ciudades", Schema = "CNT")]
    public class CntCiudades
	{	
        public int CiudadDepartamentoId {get; set;}

        public int Ciudadid {get; set;}

        public string CntComp  
        {
        	get { return $"{CiudadDepartamentoId}/{Ciudadid}"; } 
        	private set {}
        }

        [Column(TypeName = "decimal(8, 0)")]
        public decimal CiudadCodigoPoblado {get; set;}

        [MaxLength(60)]
        public string CiudadNombreDepartamento {get; set;}

        [MaxLength(68)]
        public string CiudadNombreCiudad {get; set;}

        [MaxLength(68)]
        public string CiudadNombrePoblado {get; set;}

        [MaxLength(5)]
        public string CiudadTipoMunicipio {get; set;}
	}

    #region Enum
    #endregion

	
    /// <summary>
    /// Extensión para registrar mapping con el Entity Framework y oData
    /// </summary>
	public static class CntCiudadesExtension
	{	        
        #region EF Mapping
        public static ModelBuilder CntCiudadesMapping(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<CntCiudades>();
            
            //PrimaryKey
            entity.HasKey(c => new { c.CiudadDepartamentoId, c.Ciudadid });

           //Relationships
            //Shadow Properties
            entity.Property<string>("Fuente").HasMaxLength(32).HasDefaultValue("CP3110");
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
        public static void CntCiudadesMapping(this ODataConventionModelBuilder oDataModelBuilder)
        {
            var entityConfig = oDataModelBuilder.EntitySet<CntCiudades>(nameof(CntCiudades));

            var entity = entityConfig.EntityType;

            // PrimaryKey
            entity.HasKey(c => new { c.CiudadDepartamentoId, c.Ciudadid });


            ////Ignored properties for oData
            // entityConfig.EntityType.Ignore(x => x.Summary);
        }		
        #endregion
    }
}
