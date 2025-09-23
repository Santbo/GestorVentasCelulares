using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionVentasCel.Migrations
{
    /// <inheritdoc />
    public partial class CreacionReparacionServicios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servicios_Reparaciones_ReparacionId",
                table: "Servicios");

            migrationBuilder.DropIndex(
                name: "IX_Servicios_ReparacionId",
                table: "Servicios");

            migrationBuilder.DropColumn(
                name: "ReparacionId",
                table: "Servicios");

            migrationBuilder.AlterColumn<decimal>(
                name: "Total",
                table: "Reparaciones",
                type: "decimal(10,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.CreateTable(
                name: "ReparacionServicio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ReparacionId = table.Column<int>(type: "int", nullable: false),
                    ServicioId1 = table.Column<int>(type: "int", nullable: false),
                    ServicioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReparacionServicio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReparacionServicio_Reparaciones_ServicioId",
                        column: x => x.ServicioId,
                        principalTable: "Reparaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReparacionServicio_Servicios_ServicioId1",
                        column: x => x.ServicioId1,
                        principalTable: "Servicios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ReparacionServicio_ServicioId",
                table: "ReparacionServicio",
                column: "ServicioId");

            migrationBuilder.CreateIndex(
                name: "IX_ReparacionServicio_ServicioId1",
                table: "ReparacionServicio",
                column: "ServicioId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReparacionServicio");

            migrationBuilder.AddColumn<int>(
                name: "ReparacionId",
                table: "Servicios",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Total",
                table: "Reparaciones",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)");

            migrationBuilder.CreateIndex(
                name: "IX_Servicios_ReparacionId",
                table: "Servicios",
                column: "ReparacionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Servicios_Reparaciones_ReparacionId",
                table: "Servicios",
                column: "ReparacionId",
                principalTable: "Reparaciones",
                principalColumn: "Id");
        }
    }
}
