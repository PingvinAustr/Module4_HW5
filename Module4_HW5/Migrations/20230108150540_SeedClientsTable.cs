using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Module4HW5.Migrations
{
    /// <inheritdoc />
    public partial class SeedClientsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Client",
                keyColumn: "ClientId",
                keyValue: 1,
                columns: new[] { "ClientCompany", "ClientEmail", "ClientName", "ClientSurname" },
                values: new object[] { "Company", "Email", "Client", "Client" });

            migrationBuilder.InsertData(
                table: "Client",
                columns: new[] { "ClientId", "ClientCompany", "ClientEmail", "ClientName", "ClientSurname" },
                values: new object[,]
                {
                    { 2, "Company", "Email", "Client", "Client" },
                    { 3, "Company", "Email", "Client", "Client" },
                    { 4, "Company", "Email", "Client", "Client" },
                    { 5, "Company", "Email", "Client", "Client" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Client",
                keyColumn: "ClientId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Client",
                keyColumn: "ClientId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Client",
                keyColumn: "ClientId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Client",
                keyColumn: "ClientId",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Client",
                keyColumn: "ClientId",
                keyValue: 1,
                columns: new[] { "ClientCompany", "ClientEmail", "ClientName", "ClientSurname" },
                values: new object[] { "Acme Inc.", "john.doe@acme.com", "Jaoe", "Doe" });
        }
    }
}
