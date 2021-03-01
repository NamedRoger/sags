using Microsoft.EntityFrameworkCore.Migrations;

namespace sags_api.Data.Migrations
{
    public partial class calififacionesparcieales : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrimerParcial",
                table: "clases");

            migrationBuilder.DropColumn(
                name: "SegundoParcial",
                table: "clases");

            migrationBuilder.DropColumn(
                name: "TercerPacrial",
                table: "clases");

            migrationBuilder.AddColumn<double>(
                name: "PrimerParcial",
                table: "AlumnoClases",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "SegundoParcial",
                table: "AlumnoClases",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TercerPacrial",
                table: "AlumnoClases",
                type: "double",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrimerParcial",
                table: "AlumnoClases");

            migrationBuilder.DropColumn(
                name: "SegundoParcial",
                table: "AlumnoClases");

            migrationBuilder.DropColumn(
                name: "TercerPacrial",
                table: "AlumnoClases");

            migrationBuilder.AddColumn<double>(
                name: "PrimerParcial",
                table: "clases",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "SegundoParcial",
                table: "clases",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TercerPacrial",
                table: "clases",
                type: "double",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
