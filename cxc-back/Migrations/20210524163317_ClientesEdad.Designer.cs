﻿// <auto-generated />
using System;
using Cxc.TablasBasicas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace cxc_back.Migrations
{
    [DbContext(typeof(CntContext))]
    [Migration("20210524163317_ClientesEdad")]
    partial class ClientesEdad
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Cxc.Procesos.Models.CntFacturaMovimientos", b =>
                {
                    b.Property<int>("FacturaId")
                        .HasColumnType("int");

                    b.Property<int>("FacturaSerie")
                        .HasColumnType("int");

                    b.Property<string>("ProductoLinea")
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("CntComp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("FacturaMovimientoCantidad")
                        .HasColumnType("decimal(4,2)");

                    b.Property<decimal?>("FacturaMovimientoTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("FacturaMovimientoValorUnidad")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("Fecha_Computador")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Fuente")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)")
                        .HasDefaultValue("CP4123");

                    b.Property<string>("FuenteImport")
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<int?>("Proceso")
                        .HasColumnType("int");

                    b.Property<string>("Usuario")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasDefaultValueSql("CURRENT_USER");

                    b.HasKey("FacturaId", "FacturaSerie", "ProductoLinea");

                    b.HasIndex("ProductoLinea");

                    b.ToTable("FacturaMovimientos", "CNT");
                });

            modelBuilder.Entity("Cxc.Procesos.Models.CntFacturas", b =>
                {
                    b.Property<int>("FacturaId")
                        .HasColumnType("int");

                    b.Property<int>("FacturaSerie")
                        .HasColumnType("int");

                    b.Property<decimal>("ClienteId")
                        .HasColumnType("decimal(6,0)");

                    b.Property<string>("CntComp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FacturaFecha")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("FacturaImpuestos")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("FacturaTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("FacturaValor")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("FacturaValorNoGravado")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("Fecha_Computador")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<DateTime?>("Fecha_Impresion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Fecha_Reimpresion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Fuente")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)")
                        .HasDefaultValue("CP4123");

                    b.Property<string>("FuenteImport")
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<int?>("Proceso")
                        .HasColumnType("int");

                    b.Property<string>("Usuario")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasDefaultValueSql("CURRENT_USER");

                    b.HasKey("FacturaId", "FacturaSerie");

                    b.HasIndex("ClienteId");

                    b.ToTable("Facturas", "CNT");
                });

            modelBuilder.Entity("Cxc.TablasBasicas.Models.CntBancos", b =>
                {
                    b.Property<int>("BancoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BancoLongitud")
                        .HasColumnType("int");

                    b.Property<string>("BancoNombre")
                        .HasMaxLength(22)
                        .HasColumnType("nvarchar(22)");

                    b.Property<DateTime?>("Fecha_Computador")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<DateTime?>("Fecha_Impresion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Fecha_Reimpresion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Fuente")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)")
                        .HasDefaultValue("CP3121");

                    b.Property<string>("FuenteImport")
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<int?>("Proceso")
                        .HasColumnType("int");

                    b.Property<string>("Usuario")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasDefaultValueSql("CURRENT_USER");

                    b.HasKey("BancoId");

                    b.ToTable("Bancos", "CNT");
                });

            modelBuilder.Entity("Cxc.TablasBasicas.Models.CntCiudades", b =>
                {
                    b.Property<int>("CiudadDepartamentoId")
                        .HasColumnType("int");

                    b.Property<int>("Ciudadid")
                        .HasColumnType("int");

                    b.Property<decimal>("CiudadCodigoPoblado")
                        .HasColumnType("decimal(8,0)");

                    b.Property<string>("CiudadNombreCiudad")
                        .HasMaxLength(68)
                        .HasColumnType("nvarchar(68)");

                    b.Property<string>("CiudadNombreDepartamento")
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("CiudadNombrePoblado")
                        .HasMaxLength(68)
                        .HasColumnType("nvarchar(68)");

                    b.Property<string>("CiudadTipoMunicipio")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("CntComp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Fecha_Computador")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<DateTime?>("Fecha_Impresion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Fecha_Reimpresion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Fuente")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)")
                        .HasDefaultValue("CP3110");

                    b.Property<string>("FuenteImport")
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<int?>("Proceso")
                        .HasColumnType("int");

                    b.Property<string>("Usuario")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasDefaultValueSql("CURRENT_USER");

                    b.HasKey("CiudadDepartamentoId", "Ciudadid");

                    b.ToTable("Ciudades", "CNT");
                });

            modelBuilder.Entity("Cxc.TablasBasicas.Models.CntClientes", b =>
                {
                    b.Property<decimal>("ClienteId")
                        .HasColumnType("decimal(6,0)");

                    b.Property<int>("CiudadDepartamentoId")
                        .HasColumnType("int");

                    b.Property<int>("Ciudadid")
                        .HasColumnType("int");

                    b.Property<string>("ClienteCelular")
                        .HasMaxLength(24)
                        .HasColumnType("nvarchar(24)");

                    b.Property<int>("ClienteClasificacion")
                        .HasColumnType("int");

                    b.Property<string>("ClienteContacto")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("ClienteDireccion")
                        .HasMaxLength(90)
                        .HasColumnType("nvarchar(90)");

                    b.Property<int>("ClienteEdad")
                        .HasColumnType("int");

                    b.Property<string>("ClienteEmail")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("ClienteEmailContacto")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("ClienteEstado")
                        .HasColumnType("int");

                    b.Property<string>("ClienteNit")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("ClienteRazonSocial")
                        .HasMaxLength(111)
                        .HasColumnType("nvarchar(111)");

                    b.Property<string>("ClienteTelefono")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("ClienteTelefonoContacto")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("ClienteTipoID")
                        .HasColumnType("int");

                    b.Property<string>("CntComp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CodigoCiiuId")
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<DateTime?>("Fecha_Computador")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<DateTime?>("Fecha_Impresion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Fecha_Reimpresion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Fuente")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)")
                        .HasDefaultValue("CP3024");

                    b.Property<string>("FuenteImport")
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<int?>("Proceso")
                        .HasColumnType("int");

                    b.Property<string>("Usuario")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasDefaultValueSql("CURRENT_USER");

                    b.HasKey("ClienteId");

                    b.HasIndex("CodigoCiiuId");

                    b.HasIndex("CiudadDepartamentoId", "Ciudadid");

                    b.ToTable("Clientes", "CNT");
                });

            modelBuilder.Entity("Cxc.TablasBasicas.Models.CntCodigosCiiu", b =>
                {
                    b.Property<string>("CodigoCiiuId")
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<bool>("CodigoCiiuBloqueo")
                        .HasColumnType("bit");

                    b.Property<string>("CodigoCiiuDescripcion")
                        .HasMaxLength(246)
                        .HasColumnType("nvarchar(246)");

                    b.Property<bool>("CodigoCiiuclase")
                        .HasColumnType("bit");

                    b.Property<bool>("CodigoCiiudivision")
                        .HasColumnType("bit");

                    b.Property<bool>("CodigoCiiugrupo")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Fecha_Computador")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<DateTime?>("Fecha_Impresion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Fecha_Reimpresion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Fuente")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)")
                        .HasDefaultValue("CP3000");

                    b.Property<string>("FuenteImport")
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<int?>("Proceso")
                        .HasColumnType("int");

                    b.Property<string>("Usuario")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasDefaultValueSql("CURRENT_USER");

                    b.HasKey("CodigoCiiuId");

                    b.ToTable("CodigosCiiu", "CNT");
                });

            modelBuilder.Entity("Cxc.TablasBasicas.Models.invProductos", b =>
                {
                    b.Property<string>("ProductoLinea")
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<DateTime?>("Fecha_Computador")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<DateTime?>("Fecha_Impresion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Fecha_Reimpresion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Fuente")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)")
                        .HasDefaultValue("CP4124");

                    b.Property<string>("FuenteImport")
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<int?>("Proceso")
                        .HasColumnType("int");

                    b.Property<decimal>("ProductoCantidadMaxima")
                        .HasColumnType("decimal(6,2)");

                    b.Property<decimal>("ProductoCantidadMinima")
                        .HasColumnType("decimal(6,2)");

                    b.Property<string>("ProductoCodigoBarra")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<bool>("ProductoControlSaldo")
                        .HasColumnType("bit");

                    b.Property<decimal?>("ProductoCosto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductoDescripcion")
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<string>("ProductoObservaciones")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ProductoPrecio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("ProductoSaldo")
                        .HasColumnType("decimal(6,2)");

                    b.Property<int>("ProductoTipo")
                        .HasColumnType("int");

                    b.Property<string>("ProductoUbicacion")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("ProductoUnidad")
                        .HasColumnType("int");

                    b.Property<decimal>("Productoiva")
                        .HasColumnType("decimal(8,4)");

                    b.Property<string>("Usuario")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasDefaultValueSql("CURRENT_USER");

                    b.HasKey("ProductoLinea");

                    b.ToTable("Productos", "inv");
                });

            modelBuilder.Entity("Cxc.TablasBasicas.Models.invSaldos", b =>
                {
                    b.Property<string>("ProductoLinea")
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("PeriodoDescripcionx")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<DateTime?>("Fecha_Computador")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Fuente")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)")
                        .HasDefaultValue("CP4124");

                    b.Property<string>("FuenteImport")
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<decimal>("InvSaldosCantidad")
                        .HasColumnType("decimal(6,2)");

                    b.Property<decimal?>("InvSaldosMaximoValor")
                        .HasColumnType("decimal(6,2)");

                    b.Property<decimal?>("InvSaldosTotal")
                        .HasColumnType("decimal(7,2)");

                    b.Property<decimal?>("InvSaldosUltimoValor")
                        .HasColumnType("decimal(6,2)");

                    b.Property<decimal>("InvSaldosValor")
                        .HasColumnType("decimal(6,2)");

                    b.Property<decimal?>("InvSaldosValorPromedio")
                        .HasColumnType("decimal(6,2)");

                    b.Property<int?>("Proceso")
                        .HasColumnType("int");

                    b.Property<string>("Usuario")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasDefaultValueSql("CURRENT_USER");

                    b.Property<string>("invComp")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductoLinea", "PeriodoDescripcionx");

                    b.ToTable("Saldos", "inv");
                });

            modelBuilder.Entity("Cxc.Procesos.Models.CntFacturaMovimientos", b =>
                {
                    b.HasOne("Cxc.TablasBasicas.Models.invProductos", "invProductos")
                        .WithMany()
                        .HasForeignKey("ProductoLinea")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Cxc.Procesos.Models.CntFacturas", null)
                        .WithMany("CntFacturaMovimientos")
                        .HasForeignKey("FacturaId", "FacturaSerie")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("invProductos");
                });

            modelBuilder.Entity("Cxc.Procesos.Models.CntFacturas", b =>
                {
                    b.HasOne("Cxc.TablasBasicas.Models.CntClientes", "CntClientes")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CntClientes");
                });

            modelBuilder.Entity("Cxc.TablasBasicas.Models.CntClientes", b =>
                {
                    b.HasOne("Cxc.TablasBasicas.Models.CntCodigosCiiu", "CntCodigosCiiu")
                        .WithMany()
                        .HasForeignKey("CodigoCiiuId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Cxc.TablasBasicas.Models.CntCiudades", "CntCiudades")
                        .WithMany()
                        .HasForeignKey("CiudadDepartamentoId", "Ciudadid")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CntCiudades");

                    b.Navigation("CntCodigosCiiu");
                });

            modelBuilder.Entity("Cxc.TablasBasicas.Models.invSaldos", b =>
                {
                    b.HasOne("Cxc.TablasBasicas.Models.invProductos", null)
                        .WithMany("invSaldos")
                        .HasForeignKey("ProductoLinea")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Cxc.Procesos.Models.CntFacturas", b =>
                {
                    b.Navigation("CntFacturaMovimientos");
                });

            modelBuilder.Entity("Cxc.TablasBasicas.Models.invProductos", b =>
                {
                    b.Navigation("invSaldos");
                });
#pragma warning restore 612, 618
        }
    }
}
