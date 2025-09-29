using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionVentasCel.Migrations
{
    /// <inheritdoc />
    public partial class AgregadaReparacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReparacionId",
                table: "Servicios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Dispositivo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dispositivo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dispositivo_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Reparaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FechaIngreso = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaEgreseo = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Diagnostico = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FallasReportadas = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Estado = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DispositivoId = table.Column<int>(type: "int", nullable: false),
                    Activo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reparaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reparaciones_Dispositivo_DispositivoId",
                        column: x => x.DispositivoId,
                        principalTable: "Dispositivo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Servicios_ReparacionId",
                table: "Servicios",
                column: "ReparacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Dispositivo_ClienteId",
                table: "Dispositivo",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Reparaciones_DispositivoId",
                table: "Reparaciones",
                column: "DispositivoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Servicios_Reparaciones_ReparacionId",
                table: "Servicios",
                column: "ReparacionId",
                principalTable: "Reparaciones",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servicios_Reparaciones_ReparacionId",
                table: "Servicios");

            migrationBuilder.DropTable(
                name: "Reparaciones");

            migrationBuilder.DropTable(
                name: "Dispositivo");

            migrationBuilder.DropIndex(
                name: "IX_Servicios_ReparacionId",
                table: "Servicios");

            migrationBuilder.DropColumn(
                name: "ReparacionId",
                table: "Servicios");
        }
    }
}
