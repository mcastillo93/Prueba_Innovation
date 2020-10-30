using Microsoft.EntityFrameworkCore.Migrations;

namespace Prueba_Innovation.Migrations
{
    public partial class One : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conductores",
                columns: table => new
                {
                    DNI = table.Column<string>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Apellidos = table.Column<string>(nullable: true),
                    Puntos = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conductores", x => x.DNI);
                });

            migrationBuilder.CreateTable(
                name: "Infracciones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(nullable: true),
                    Puntos = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Infracciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehiculos",
                columns: table => new
                {
                    Matricula = table.Column<string>(nullable: false),
                    Marca = table.Column<string>(nullable: true),
                    Modelo = table.Column<string>(nullable: true),
                    DNI_Conductor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculos", x => x.Matricula);
                    table.ForeignKey(
                        name: "FK_Vehiculos_Conductores_DNI_Conductor",
                        column: x => x.DNI_Conductor,
                        principalTable: "Conductores",
                        principalColumn: "DNI",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Conductores_DNI",
                table: "Conductores",
                column: "DNI",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_DNI_Conductor",
                table: "Vehiculos",
                column: "DNI_Conductor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Infracciones");

            migrationBuilder.DropTable(
                name: "Vehiculos");

            migrationBuilder.DropTable(
                name: "Conductores");
        }
    }
}
