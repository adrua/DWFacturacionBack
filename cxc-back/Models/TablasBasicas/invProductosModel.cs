//invProductosModel.cs
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.OData.ModelBuilder;
using Microsoft.EntityFrameworkCore;

namespace Cxc.TablasBasicas.Models
{    
    [Table("Productos", Schema = "inv")]
    public class invProductos
	{	
        [MaxLength(8)]
        public string ProductoLinea {get; set;}

        [MaxLength(75)]
        public string ProductoDescripcion {get; set;}

        [Column(TypeName = "decimal(6, 2)")]
        public decimal? ProductoSaldo {get; set;}

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? ProductoCosto {get; set;}

        [Column(TypeName = "decimal(18, 2)")]
        public decimal ProductoPrecio {get; set;}

        [Column(TypeName = "decimal(8, 4)")]
        public decimal Productoiva {get; set;}

        public Enum_ProductoUnidad ProductoUnidad {get; set;}

        [MaxLength(15)]
        public string ProductoCodigoBarra {get; set;}

        [Column(TypeName = "decimal(6, 2)")]
        public decimal ProductoCantidadMinima {get; set;}

        [Column(TypeName = "decimal(6, 2)")]
        public decimal ProductoCantidadMaxima {get; set;}

        [MaxLength(10)]
        public string ProductoUbicacion {get; set;}

        public Enum_ProductoTipo ProductoTipo {get; set;}

        [Column(TypeName = "bit")]
        public bool ProductoControlSaldo {get; set;}

        public string ProductoObservaciones {get; set;}

        public ICollection<invSaldos> invSaldos { get; set; }
	}

    #region Enums
    public enum Enum_ProductoUnidad : int
    {
        Unidades = 1,
        Metros = 2,
        Docenas = 3,
        Litros = 4,
        Gramos = 5
    }

    public enum Enum_ProductoTipo : int
    {
        Fisico = 1,
        uso_ocasional = 2,
        Producto_Similar = 3,
        Proveedores = 4
    }
    #endregion

	
    /// <summary>
    /// Extensión para registrar mapping con el Entity Framework y oData
    /// </summary>
	public static class invProductosExtension
	{	        
        #region EF Mapping
        public static ModelBuilder invProductosMapping(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<invProductos>();
            
            //PrimaryKey
            entity.HasKey(c => new { c.ProductoLinea });

           //Relationships
            //Shadow Properties
            entity.Property<string>("Fuente").HasMaxLength(32).HasDefaultValue("CP4124");
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
        public static void invProductosMapping(this ODataConventionModelBuilder oDataModelBuilder)
        {
            var entityConfig = oDataModelBuilder.EntitySet<invProductos>(nameof(invProductos));

            var entity = entityConfig.EntityType;

            // PrimaryKey
            entity.HasKey(c => new { c.ProductoLinea });


            ////Ignored properties for oData
            // entityConfig.EntityType.Ignore(x => x.Summary);
        }		
        #endregion
    }
}
