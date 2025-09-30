using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionVentasCel.Migrations
{
    /// <inheritdoc />
    public partial class AgregadoReparacionServicios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReparacionServicio_Reparaciones_ReparacionId",
                table: "ReparacionServicio");

            migrationBuilder.DropForeignKey(
                name: "FK_ReparacionServicio_Servicios_ServicioId",
                table: "ReparacionServicio");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReparacionServicio",
                table: "ReparacionServicio");

            migrationBuilder.RenameTable(
                name: "ReparacionServicio",
                newName: "ReparacionServicios");

            migrationBuilder.RenameIndex(
                name: "IX_ReparacionServicio_ServicioId",
                table: "ReparacionServicios",
                newName: "IX_ReparacionServicios_ServicioId");

            migrationBuilder.RenameIndex(
                name: "IX_ReparacionServicio_ReparacionId",
                table: "ReparacionServicios",
                newName: "IX_ReparacionServicios_ReparacionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReparacionServicios",
                table: "ReparacionServicios",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReparacionServicios_Reparaciones_ReparacionId",
                table: "ReparacionServicios",
                column: "ReparacionId",
                principalTable: "Reparaciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReparacionServicios_Servicios_ServicioId",
                table: "ReparacionServicios",
                column: "ServicioId",
                principalTable: "Servicios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReparacionServicios_Reparaciones_ReparacionId",
                table: "ReparacionServicios");

            migrationBuilder.DropForeignKey(
                name: "FK_ReparacionServicios_Servicios_ServicioId",
                table: "ReparacionServicios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReparacionServicios",
                table: "ReparacionServicios");

            migrationBuilder.RenameTable(
                name: "ReparacionServicios",
                newName: "ReparacionServicio");

            migrationBuilder.RenameIndex(
                name: "IX_ReparacionServicios_ServicioId",
                table: "ReparacionServicio",
                newName: "IX_ReparacionServicio_ServicioId");

            migrationBuilder.RenameIndex(
                name: "IX_ReparacionServicios_ReparacionId",
                table: "ReparacionServicio",
                newName: "IX_ReparacionServicio_ReparacionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReparacionServicio",
                table: "ReparacionServicio",
                column: "Id");

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
    }
}
