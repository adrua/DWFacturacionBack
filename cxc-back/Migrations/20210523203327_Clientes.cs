using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace cxc_back.Migrations
{
    public partial class Clientes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ciudades",
                schema: "CNT",
                columns: table => new
                {
                    CiudadDepartamentoId = table.Column<int>(type: "int", nullable: false),
                    Ciudadid = table.Column<int>(type: "int", nullable: false),
                    CntComp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CiudadCodigoPoblado = table.Column<decimal>(type: "decimal(8,0)", nullable: false),
                    CiudadNombreDepartamento = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    CiudadNombreCiudad = table.Column<string>(type: "nvarchar(68)", maxLength: 68, nullable: true),
                    CiudadNombrePoblado = table.Column<string>(type: "nvarchar(68)", maxLength: 68, nullable: true),
                    CiudadTipoMunicipio = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Fecha_Computador = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getdate()"),
                    Fecha_Impresion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Fecha_Reimpresion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Fuente = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true, defaultValue: "CP3110"),
                    FuenteImport = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    Proceso = table.Column<int>(type: "int", nullable: true),
                    Usuario = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "CURRENT_USER")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudades", x => new { x.CiudadDepartamentoId, x.Ciudadid });
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                schema: "CNT",
                columns: table => new
                {
                    ClienteId = table.Column<decimal>(type: "decimal(6,0)", nullable: false),
                    ClienteClasificacion = table.Column<int>(type: "int", nullable: false),
                    ClienteTipoID = table.Column<int>(type: "int", nullable: false),
                    ClienteNit = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CodigoCiiuId = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    ClienteEstado = table.Column<int>(type: "int", nullable: false),
                    ClienteRazonSocial = table.Column<string>(type: "nvarchar(111)", maxLength: 111, nullable: true),
                    ClienteDireccion = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: true),
                    CiudadDepartamentoId = table.Column<int>(type: "int", nullable: false),
                    Ciudadid = table.Column<int>(type: "int", nullable: false),
                    CntComp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClienteTelefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ClienteCelular = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: true),
                    ClienteEmail = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ClienteContacto = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    ClienteTelefonoContacto = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ClienteEmailContacto = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Fecha_Computador = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getdate()"),
                    Fecha_Impresion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Fecha_Reimpresion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Fuente = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true, defaultValue: "CP3024"),
                    FuenteImport = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    Proceso = table.Column<int>(type: "int", nullable: true),
                    Usuario = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "CURRENT_USER")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                    table.ForeignKey(
                        name: "FK_Clientes_Ciudades_CiudadDepartamentoId_Ciudadid",
                        columns: x => new { x.CiudadDepartamentoId, x.Ciudadid },
                        principalSchema: "CNT",
                        principalTable: "Ciudades",
                        principalColumns: new[] { "CiudadDepartamentoId", "Ciudadid" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clientes_CodigosCiiu_CodigoCiiuId",
                        column: x => x.CodigoCiiuId,
                        principalSchema: "CNT",
                        principalTable: "CodigosCiiu",
                        principalColumn: "CodigoCiiuId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_CiudadDepartamentoId_Ciudadid",
                schema: "CNT",
                table: "Clientes",
                columns: new[] { "CiudadDepartamentoId", "Ciudadid" });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_CodigoCiiuId",
                schema: "CNT",
                table: "Clientes",
                column: "CodigoCiiuId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes",
                schema: "CNT");

            migrationBuilder.DropTable(
                name: "Ciudades",
                schema: "CNT");
        }
    }
}
