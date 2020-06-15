using Microsoft.EntityFrameworkCore.Migrations;

namespace BrennToDo.Migrations.UserDb
{
    public partial class AddedRolesToRegisterModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bproorda",
                column: "SecurityStamp",
                value: "78f42dbd-fc67-4dd8-a83b-61212484e35e");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bproorda",
                column: "SecurityStamp",
                value: "17413f66-d5fe-413d-a8fd-53c75b1c21e3");
        }
    }
}
