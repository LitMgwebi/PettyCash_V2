using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PettyCashPrototype.Migrations
{
    /// <inheritdoc />
    public partial class purposeSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Purpose",
                columns: new[] { "PurposeID", "Description", "isActive", "Name" },
                values: new object[,]
                {
                    { 1, "Administration", true, "ADM" },
                    { 2, "Regulatory Compliance", true, "RGC" },
                    { 3, "Diamond Trade", true, "DMT" },
                    { 4, null, true, "ZZZ" },
                    { 5, "Test", true, "TST" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Purpose",
                keyColumn: "PurposeID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Purpose",
                keyColumn: "PurposeID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Purpose",
                keyColumn: "PurposeID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Purpose",
                keyColumn: "PurposeID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Purpose",
                keyColumn: "PurposeID",
                keyValue: 5);
        }
    }
}
