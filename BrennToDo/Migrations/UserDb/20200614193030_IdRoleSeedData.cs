using Microsoft.EntityFrameworkCore.Migrations;

namespace BrennToDo.Migrations.UserDb
{
    public partial class IdRoleSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "admin", "17722115-21fd-4451-8db4-e99f5c602421", "Administrator", "ADMINISTRATOR" },
                    { "editor", "79b16ad0-71fc-4d45-851a-c8c0544adf1d", "Editor", "EDITOR" },
                    { "user", "79b76ad0-79fc-4d46-852a-c8c05a4adf1d", "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bproorda",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "390a1df5-62f1-45f3-95a1-5cf2ee2eca52", "4f6eee8e-f30c-407c-9084-2367b496d79c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "editor");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "user");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bproorda",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "7da56311-986d-49bd-aa0d-ad8f92270a50", "00bc4767-d6d6-43e2-a5fb-d8a2594e3621" });
        }
    }
}
