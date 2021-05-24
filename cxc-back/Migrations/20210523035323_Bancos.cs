using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace cxc_back.Migrations
{
    public partial class Bancos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "CNT");

            migrationBuilder.CreateTable(
                name: "Bancos",
                schema: "CNT",
                columns: table => new
                {
                    BancoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BancoNombre = table.Column<string>(type: "nvarchar(22)", maxLength: 22, nullable: true),
                    BancoLongitud = table.Column<int>(type: "int", nullable: false),
                    Fecha_Computador = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getdate()"),
                    Fecha_Impresion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Fecha_Reimpresion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Fuente = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true, defaultValue: "CP3121"),
                    FuenteImport = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    Proceso = table.Column<int>(type: "int", nullable: true),
                    Usuario = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "CURRENT_USER")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bancos", x => x.BancoId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bancos",
                schema: "CNT");
        }
    }
}
