using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace todolist_api.Migrations
{
    /// <inheritdoc />
    public partial class populateTasks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CreatedAt", "Description", "Status", "UpdateAt" },
                values: new object[] { 1, new DateTime(2024, 9, 28, 18, 6, 29, 953, DateTimeKind.Local).AddTicks(5638), "Grab some Pizza", 1, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
