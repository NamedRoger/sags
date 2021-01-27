using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace sags_api.Data.Migrations
{
    public partial class AddUsertoalumno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IdUsuario",
                table: "alumnos",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioId",
                table: "alumnos",
                type: "char(36)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_alumnos_UsuarioId",
                table: "alumnos",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_alumnos_AspNetUsers_UsuarioId",
                table: "alumnos",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_alumnos_AspNetUsers_UsuarioId",
                table: "alumnos");

            migrationBuilder.DropIndex(
                name: "IX_alumnos_UsuarioId",
                table: "alumnos");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "alumnos");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "alumnos");
        }
    }
}
