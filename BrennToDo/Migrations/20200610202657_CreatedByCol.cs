using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BrennToDo.Migrations
{
    public partial class CreatedByCol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserId",
                table: "ToDo",
                nullable: true);

            migrationBuilder.InsertData(
                table: "ToDo",
                columns: new[] { "Id", "Assignee", "CreatedByUserId", "Difficulty", "DueDate", "Title" },
                values: new object[] { 2L, "Graeme", "7304a689-e2ff-4b12-a49c-103675becb39", 5, new DateTime(2020, 7, 10, 5, 0, 0, 0, DateTimeKind.Utc), "Clean up after Dog" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ToDo",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "ToDo");
        }
    }
}
