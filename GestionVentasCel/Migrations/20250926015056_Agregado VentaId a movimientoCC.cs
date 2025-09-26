using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionVentasCel.Migrations
{
    /// <inheritdoc />
    public partial class AgregadoVentaIdamovimientoCC : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VentaId",
                table: "MovimientosCuentasCorrientes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MovimientosCuentasCorrientes_VentaId",
                table: "MovimientosCuentasCorrientes",
                column: "VentaId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovimientosCuentasCorrientes_Ventas_VentaId",
                table: "MovimientosCuentasCorrientes",
                column: "VentaId",
                principalTable: "Ventas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovimientosCuentasCorrientes_Ventas_VentaId",
                table: "MovimientosCuentasCorrientes");

            migrationBuilder.DropIndex(
                name: "IX_MovimientosCuentasCorrientes_VentaId",
                table: "MovimientosCuentasCorrientes");

            migrationBuilder.DropColumn(
                name: "VentaId",
                table: "MovimientosCuentasCorrientes");
        }
    }
}
