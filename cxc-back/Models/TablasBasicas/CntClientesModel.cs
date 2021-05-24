//CntClientesModel.cs
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.OData.ModelBuilder;
using Microsoft.EntityFrameworkCore;

namespace Cxc.TablasBasicas.Models
{    
    [Table("Clientes", Schema = "CNT")]
    public class CntClientes
	{	
        [Column(TypeName = "decimal(6, 0)")]
        public decimal ClienteId {get; set;}

        public Enum_ClienteClasificacion ClienteClasificacion {get; set;}

        public Enum_ClienteTipoID ClienteTipoID {get; set;}

        [MaxLength(20)]
        public string ClienteNit {get; set;}

        [MaxLength(6)]
        public string CodigoCiiuId {get; set;}

        public Enum_ClienteEstado ClienteEstado {get; set;}

        [MaxLength(111)]
        public string ClienteRazonSocial {get; set;}

        [MaxLength(90)]
        public string ClienteDireccion {get; set;}

        public int CiudadDepartamentoId {get; set;}

        public int Ciudadid {get; set;}

        public string CntComp  
        {
        	get { return $"{CiudadDepartamentoId}/{Ciudadid}"; } 
        	private set {}
        }

        [MaxLength(20)]
        public string ClienteTelefono {get; set;}

        [MaxLength(24)]
        public string ClienteCelular {get; set;}

        [MaxLength(150)]
        public string ClienteEmail {get; set;}

        [MaxLength(36)]
        public string ClienteContacto {get; set;}

        [MaxLength(20)]
        public string ClienteTelefonoContacto {get; set;}

        [MaxLength(150)]
        public string ClienteEmailContacto {get; set;}

        public CntCodigosCiiu CntCodigosCiiu { get; set; }

        public CntCiudades CntCiudades { get; set; }
	}

    #region Enums
    public enum Enum_ClienteClasificacion : int
    {
        Natural = 0,
        Juridica = 1
    }

    public enum Enum_ClienteTipoID : int
    {
        Numero_Identificacion_Tributaria = 0,
        Cedula_Ciudadania = 1,
        Pasaporte = 2,
        Tarjeta_de_Identidad = 3,
        Cedula_Extranjeria = 4,
        Tarjeta_Extranjeria = 5
    }

    public enum Enum_ClienteEstado : int
    {
        Activo = 0,
        Anulado = 1
    }
    #endregion

	
    /// <summary>
    /// Extensión para registrar mapping con el Entity Framework y oData
    /// </summary>
	public static class CntClientesExtension
	{	        
        #region EF Mapping
        public static ModelBuilder CntClientesMapping(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<CntClientes>();
            
            //PrimaryKey
            entity.HasKey(c => new { c.ClienteId });

           //Relationships
            entity.HasOne(typeof(CntCodigosCiiu), "CntCodigosCiiu")
                .WithMany()
                .HasForeignKey("CodigoCiiuId")
                .OnDelete(DeleteBehavior.Restrict); // no ON DELETE
                
            entity.HasOne(typeof(CntCiudades), "CntCiudades")
                .WithMany()
                .HasForeignKey("CiudadDepartamentoId", "Ciudadid")
                .OnDelete(DeleteBehavior.Restrict); // no ON DELETE
                
            //Shadow Properties
            entity.Property<string>("Fuente").HasMaxLength(32).HasDefaultValue("CP3024");
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
        public static void CntClientesMapping(this ODataConventionModelBuilder oDataModelBuilder)
        {
            var entityConfig = oDataModelBuilder.EntitySet<CntClientes>(nameof(CntClientes));

            var entity = entityConfig.EntityType;

            // PrimaryKey
            entity.HasKey(c => new { c.ClienteId });


            ////Ignored properties for oData
            // entityConfig.EntityType.Ignore(x => x.Summary);
        }		
        #endregion
    }
}
