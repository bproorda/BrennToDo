using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BrennToDo.Migrations
{
    public partial class SetUpToDoTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ToDo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    DueDate = table.Column<DateTime>(nullable: false),
                    Assignee = table.Column<string>(nullable: true),
                    Difficulty = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDo", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ToDo",
                columns: new[] { "Id", "Assignee", "Difficulty", "DueDate", "Title" },
                values: new object[] { 1L, "Brenn", 3, new DateTime(2020, 7, 10, 5, 0, 0, 0, DateTimeKind.Utc), "Walk The Dog" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToDo");
        }
    }
}
