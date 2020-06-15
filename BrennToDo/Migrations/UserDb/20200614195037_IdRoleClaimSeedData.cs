using Microsoft.EntityFrameworkCore.Migrations;

namespace BrennToDo.Migrations.UserDb
{
    public partial class IdRoleClaimSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { 1, "Permissions", "delete", "admin" },
                    { 2, "Permissions", "create", "admin" },
                    { 3, "Permissions", "update", "admin" },
                    { 4, "Permissions", "update", "editor" },
                    { 5, "Permissions", "create", "user" },
                    { 6, "Permissions", "update", "user" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bproorda",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2c809159-1113-4287-9fae-53b1e17c5a36", "4604f576-27ac-47bd-9f9f-c7a222bd117a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bproorda",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "390a1df5-62f1-45f3-95a1-5cf2ee2eca52", "4f6eee8e-f30c-407c-9084-2367b496d79c" });
        }
    }
}
