using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PettyCashPrototype.Migrations
{
    /// <inheritdoc />
    public partial class MainAccountSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MainAccount",
                columns: new[] { "MainAccountID", "AccountNumber", "Description", "isActive", "Name" },
                values: new object[,]
                {
                    { 1, 2013, null, true, "Insurance" },
                    { 2, 2013, null, true, "Insurance" },
                    { 3, 2007, null, true, "Domestic Travel" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MainAccount",
                keyColumn: "MainAccountID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MainAccount",
                keyColumn: "MainAccountID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MainAccount",
                keyColumn: "MainAccountID",
                keyValue: 3);
        }
    }
}
