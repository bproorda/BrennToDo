using Microsoft.EntityFrameworkCore.Migrations;

namespace BrennToDo.Migrations.UserDb
{
    public partial class DidIForgetSomething : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bproorda",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "7da56311-986d-49bd-aa0d-ad8f92270a50", "00bc4767-d6d6-43e2-a5fb-d8a2594e3621" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bproorda",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "14cacbd7-ddfb-41d7-ba89-f5850d683372", "62698e97-2285-4eee-9999-580282eac930" });
        }
    }
}
