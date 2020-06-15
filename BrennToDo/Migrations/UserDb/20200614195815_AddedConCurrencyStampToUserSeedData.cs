using Microsoft.EntityFrameworkCore.Migrations;

namespace BrennToDo.Migrations.UserDb
{
    public partial class AddedConCurrencyStampToUserSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bproorda",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "79b76ad0-79fc-4d46-952a-c8c15a4adf1d", "17413f66-d5fe-413d-a8fd-53c75b1c21e3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bproorda",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2c809159-1113-4287-9fae-53b1e17c5a36", "4604f576-27ac-47bd-9f9f-c7a222bd117a" });
        }
    }
}
