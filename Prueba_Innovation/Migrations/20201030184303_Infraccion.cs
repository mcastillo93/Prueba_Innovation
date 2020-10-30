using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Prueba_Innovation.Migrations
{
    public partial class Infraccion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha",
                table: "Infracciones",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Hora",
                table: "Infracciones",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fecha",
                table: "Infracciones");

            migrationBuilder.DropColumn(
                name: "Hora",
                table: "Infracciones");
        }
    }
}
