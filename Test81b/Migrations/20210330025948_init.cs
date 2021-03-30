using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Test81b.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cedula = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartamentoCodigo = table.Column<int>(type: "int", nullable: true),
                    Cargo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupervisorInmediato = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Departamentos_DepartamentoCodigo",
                        column: x => x.DepartamentoCodigo,
                        principalTable: "Departamentos",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Departamentos",
                columns: new[] { "Codigo", "Nombre" },
                values: new object[] { 1, "Recursos Humanos" });

            migrationBuilder.InsertData(
                table: "Departamentos",
                columns: new[] { "Codigo", "Nombre" },
                values: new object[] { 2, "Informatica" });

            migrationBuilder.InsertData(
                table: "Departamentos",
                columns: new[] { "Codigo", "Nombre" },
                values: new object[] { 3, "Contabilidad" });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_DepartamentoCodigo",
                table: "Usuarios",
                column: "DepartamentoCodigo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Departamentos");
        }
    }
}
