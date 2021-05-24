using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace cxc_back.Migrations
{
    public partial class CodigosCiiu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CodigosCiiu",
                schema: "CNT",
                columns: table => new
                {
                    CodigoCiiuId = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    CodigoCiiuDescripcion = table.Column<string>(type: "nvarchar(246)", maxLength: 246, nullable: true),
                    CodigoCiiuclase = table.Column<bool>(type: "bit", nullable: false),
                    CodigoCiiugrupo = table.Column<bool>(type: "bit", nullable: false),
                    CodigoCiiudivision = table.Column<bool>(type: "bit", nullable: false),
                    CodigoCiiuBloqueo = table.Column<bool>(type: "bit", nullable: false),
                    Fecha_Computador = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getdate()"),
                    Fecha_Impresion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Fecha_Reimpresion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Fuente = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true, defaultValue: "CP3000"),
                    FuenteImport = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    Proceso = table.Column<int>(type: "int", nullable: true),
                    Usuario = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "CURRENT_USER")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodigosCiiu", x => x.CodigoCiiuId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CodigosCiiu",
                schema: "CNT");
        }
    }
}
