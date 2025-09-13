﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionVentasCel.Migrations
{
    /// <inheritdoc />
    public partial class DescripcionenMovimientoCCnullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "MovimientosCuentasCorrientes",
                type: "varchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MovimientosCuentasCorrientes",
                keyColumn: "Descripcion",
                keyValue: null,
                column: "Descripcion",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "MovimientosCuentasCorrientes",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
