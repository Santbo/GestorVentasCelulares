using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionVentasCel.Migrations
{
    /// <inheritdoc />
    public partial class arregloErrores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReparacionServicio_Reparaciones_ServicioId",
                table: "ReparacionServicio");

            migrationBuilder.DropForeignKey(
                name: "FK_ReparacionServicio_Servicios_ServicioId1",
                table: "ReparacionServicio");

            migrationBuilder.DropIndex(
                name: "IX_ReparacionServicio_ServicioId1",
                table: "ReparacionServicio");

            migrationBuilder.DropColumn(
                name: "ServicioId1",
                table: "ReparacionServicio");

            migrationBuilder.CreateIndex(
                name: "IX_ReparacionServicio_ReparacionId",
                table: "ReparacionServicio",
                column: "ReparacionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReparacionServicio_Reparaciones_ReparacionId",
                table: "ReparacionServicio",
                column: "ReparacionId",
                principalTable: "Reparaciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReparacionServicio_Servicios_ServicioId",
                table: "ReparacionServicio",
                column: "ServicioId",
                principalTable: "Servicios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReparacionServicio_Reparaciones_ReparacionId",
                table: "ReparacionServicio");

            migrationBuilder.DropForeignKey(
                name: "FK_ReparacionServicio_Servicios_ServicioId",
                table: "ReparacionServicio");

            migrationBuilder.DropIndex(
                name: "IX_ReparacionServicio_ReparacionId",
                table: "ReparacionServicio");

            migrationBuilder.AddColumn<int>(
                name: "ServicioId1",
                table: "ReparacionServicio",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ReparacionServicio_ServicioId1",
                table: "ReparacionServicio",
                column: "ServicioId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ReparacionServicio_Reparaciones_ServicioId",
                table: "ReparacionServicio",
                column: "ServicioId",
                principalTable: "Reparaciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReparacionServicio_Servicios_ServicioId1",
                table: "ReparacionServicio",
                column: "ServicioId1",
                principalTable: "Servicios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
