using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Module4HW5.Migrations
{
    /// <inheritdoc />
    public partial class SeedProjectsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "ProjectId", "Budget", "ClientId", "Name", "StartedDate" },
                values: new object[,]
                {
                    { 1, 1m, 2, "Project", new DateTime(2023, 1, 8, 17, 9, 7, 304, DateTimeKind.Local).AddTicks(6812) },
                    { 2, 1m, 2, "Project", new DateTime(2023, 1, 8, 17, 9, 7, 304, DateTimeKind.Local).AddTicks(6850) },
                    { 3, 1m, 3, "Project", new DateTime(2023, 1, 8, 17, 9, 7, 304, DateTimeKind.Local).AddTicks(6853) },
                    { 4, 1m, 4, "Project", new DateTime(2023, 1, 8, 17, 9, 7, 304, DateTimeKind.Local).AddTicks(6855) },
                    { 5, 1m, 5, "Project", new DateTime(2023, 1, 8, 17, 9, 7, 304, DateTimeKind.Local).AddTicks(6857) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "ProjectId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "ProjectId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "ProjectId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "ProjectId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "ProjectId",
                keyValue: 5);
        }
    }
}
