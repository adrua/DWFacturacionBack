using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace cxc_back.Migrations
{
    public partial class Facturas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Facturas",
                schema: "CNT",
                columns: table => new
                {
                    FacturaId = table.Column<int>(type: "int", nullable: false),
                    FacturaSerie = table.Column<int>(type: "int", nullable: false),
                    CntComp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FacturaFecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClienteId = table.Column<decimal>(type: "decimal(6,0)", nullable: false),
                    FacturaValor = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FacturaValorNoGravado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FacturaImpuestos = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FacturaTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Fecha_Computador = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getdate()"),
                    Fecha_Impresion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Fecha_Reimpresion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Fuente = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true, defaultValue: "CP4123"),
                    FuenteImport = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    Proceso = table.Column<int>(type: "int", nullable: true),
                    Usuario = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "CURRENT_USER")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturas", x => new { x.FacturaId, x.FacturaSerie });
                    table.ForeignKey(
                        name: "FK_Facturas_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalSchema: "CNT",
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FacturaMovimientos",
                schema: "CNT",
                columns: table => new
                {
                    FacturaId = table.Column<int>(type: "int", nullable: false),
                    FacturaSerie = table.Column<int>(type: "int", nullable: false),
                    ProductoLinea = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    CntComp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FacturaMovimientoCantidad = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    FacturaMovimientoValorUnidad = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FacturaMovimientoTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Fecha_Computador = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getdate()"),
                    Fuente = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true, defaultValue: "CP4123"),
                    FuenteImport = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    Proceso = table.Column<int>(type: "int", nullable: true),
                    Usuario = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "CURRENT_USER")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacturaMovimientos", x => new { x.FacturaId, x.FacturaSerie, x.ProductoLinea });
                    table.ForeignKey(
                        name: "FK_FacturaMovimientos_Facturas_FacturaId_FacturaSerie",
                        columns: x => new { x.FacturaId, x.FacturaSerie },
                        principalSchema: "CNT",
                        principalTable: "Facturas",
                        principalColumns: new[] { "FacturaId", "FacturaSerie" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacturaMovimientos_Productos_ProductoLinea",
                        column: x => x.ProductoLinea,
                        principalSchema: "inv",
                        principalTable: "Productos",
                        principalColumn: "ProductoLinea",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FacturaMovimientos_ProductoLinea",
                schema: "CNT",
                table: "FacturaMovimientos",
                column: "ProductoLinea");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_ClienteId",
                schema: "CNT",
                table: "Facturas",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FacturaMovimientos",
                schema: "CNT");

            migrationBuilder.DropTable(
                name: "Facturas",
                schema: "CNT");
        }
    }
}
