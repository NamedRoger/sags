using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace sags_api.Data.Migrations
{
    public partial class addruleusertoalumno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_alumnos_AspNetUsers_UsuarioId",
                table: "alumnos");

            migrationBuilder.DropIndex(
                name: "IX_alumnos_UsuarioId",
                table: "alumnos");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "alumnos");

            migrationBuilder.CreateIndex(
                name: "IX_alumnos_IdUsuario",
                table: "alumnos",
                column: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_alumnos_AspNetUsers_IdUsuario",
                table: "alumnos",
                column: "IdUsuario",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_alumnos_AspNetUsers_IdUsuario",
                table: "alumnos");

            migrationBuilder.DropIndex(
                name: "IX_alumnos_IdUsuario",
                table: "alumnos");

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
    }
}
