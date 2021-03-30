using Microsoft.EntityFrameworkCore.Migrations;

namespace Test81b.Migrations
{
    public partial class AddDepartamentosFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Departamentos_DepartamentoCodigo",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_DepartamentoCodigo",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "DepartamentoCodigo",
                table: "Usuarios");

            migrationBuilder.AlterColumn<string>(
                name: "Nombres",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Genero",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Apellidos",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdDepartamento",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IdDepartamento",
                table: "Usuarios",
                column: "IdDepartamento");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Departamentos_IdDepartamento",
                table: "Usuarios",
                column: "IdDepartamento",
                principalTable: "Departamentos",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Departamentos_IdDepartamento",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_IdDepartamento",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "IdDepartamento",
                table: "Usuarios");

            migrationBuilder.AlterColumn<string>(
                name: "Nombres",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Genero",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Apellidos",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "DepartamentoCodigo",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_DepartamentoCodigo",
                table: "Usuarios",
                column: "DepartamentoCodigo");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Departamentos_DepartamentoCodigo",
                table: "Usuarios",
                column: "DepartamentoCodigo",
                principalTable: "Departamentos",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
