using Microsoft.EntityFrameworkCore.Migrations;

namespace web.Migrations
{
    public partial class Fix1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "İlce",
                table: "AspNetUsers",
                newName: "Ilce");

            migrationBuilder.AlterColumn<int>(
                name: "KanGrubu",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ilce",
                table: "AspNetUsers",
                newName: "İlce");

            migrationBuilder.AlterColumn<string>(
                name: "KanGrubu",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
