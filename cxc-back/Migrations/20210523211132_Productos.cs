using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace cxc_back.Migrations
{
    public partial class Productos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "inv");

            migrationBuilder.CreateTable(
                name: "Productos",
                schema: "inv",
                columns: table => new
                {
                    ProductoLinea = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    ProductoDescripcion = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    ProductoSaldo = table.Column<decimal>(type: "decimal(6,2)", nullable: true),
                    ProductoCosto = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ProductoPrecio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Productoiva = table.Column<decimal>(type: "decimal(8,4)", nullable: false),
                    ProductoUnidad = table.Column<int>(type: "int", nullable: false),
                    ProductoCodigoBarra = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    ProductoCantidadMinima = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    ProductoCantidadMaxima = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    ProductoUbicacion = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ProductoTipo = table.Column<int>(type: "int", nullable: false),
                    ProductoControlSaldo = table.Column<bool>(type: "bit", nullable: false),
                    ProductoObservaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecha_Computador = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getdate()"),
                    Fecha_Impresion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Fecha_Reimpresion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Fuente = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true, defaultValue: "CP4124"),
                    FuenteImport = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    Proceso = table.Column<int>(type: "int", nullable: true),
                    Usuario = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "CURRENT_USER")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.ProductoLinea);
                });

            migrationBuilder.CreateTable(
                name: "Saldos",
                schema: "inv",
                columns: table => new
                {
                    ProductoLinea = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    PeriodoDescripcionx = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    invComp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvSaldosCantidad = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    InvSaldosValor = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    InvSaldosTotal = table.Column<decimal>(type: "decimal(7,2)", nullable: true),
                    InvSaldosValorPromedio = table.Column<decimal>(type: "decimal(6,2)", nullable: true),
                    InvSaldosUltimoValor = table.Column<decimal>(type: "decimal(6,2)", nullable: true),
                    InvSaldosMaximoValor = table.Column<decimal>(type: "decimal(6,2)", nullable: true),
                    Fecha_Computador = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getdate()"),
                    Fuente = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true, defaultValue: "CP4124"),
                    FuenteImport = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    Proceso = table.Column<int>(type: "int", nullable: true),
                    Usuario = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "CURRENT_USER")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saldos", x => new { x.ProductoLinea, x.PeriodoDescripcionx });
                    table.ForeignKey(
                        name: "FK_Saldos_Productos_ProductoLinea",
                        column: x => x.ProductoLinea,
                        principalSchema: "inv",
                        principalTable: "Productos",
                        principalColumn: "ProductoLinea",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Saldos",
                schema: "inv");

            migrationBuilder.DropTable(
                name: "Productos",
                schema: "inv");
        }
    }
}
