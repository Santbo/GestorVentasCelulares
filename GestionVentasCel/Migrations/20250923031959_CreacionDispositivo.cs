using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionVentasCel.Migrations
{
    /// <inheritdoc />
    public partial class CreacionDispositivo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dispositivo_Clientes_ClienteId",
                table: "Dispositivo");

            migrationBuilder.DropForeignKey(
                name: "FK_Reparaciones_Dispositivo_DispositivoId",
                table: "Reparaciones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dispositivo",
                table: "Dispositivo");

            migrationBuilder.RenameTable(
                name: "Dispositivo",
                newName: "Dispositivos");

            migrationBuilder.RenameIndex(
                name: "IX_Dispositivo_ClienteId",
                table: "Dispositivos",
                newName: "IX_Dispositivos_ClienteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dispositivos",
                table: "Dispositivos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dispositivos_Clientes_ClienteId",
                table: "Dispositivos",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reparaciones_Dispositivos_DispositivoId",
                table: "Reparaciones",
                column: "DispositivoId",
                principalTable: "Dispositivos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dispositivos_Clientes_ClienteId",
                table: "Dispositivos");

            migrationBuilder.DropForeignKey(
                name: "FK_Reparaciones_Dispositivos_DispositivoId",
                table: "Reparaciones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dispositivos",
                table: "Dispositivos");

            migrationBuilder.RenameTable(
                name: "Dispositivos",
                newName: "Dispositivo");

            migrationBuilder.RenameIndex(
                name: "IX_Dispositivos_ClienteId",
                table: "Dispositivo",
                newName: "IX_Dispositivo_ClienteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dispositivo",
                table: "Dispositivo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dispositivo_Clientes_ClienteId",
                table: "Dispositivo",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reparaciones_Dispositivo_DispositivoId",
                table: "Reparaciones",
                column: "DispositivoId",
                principalTable: "Dispositivo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
