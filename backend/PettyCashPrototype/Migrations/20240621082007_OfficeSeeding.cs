using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PettyCashPrototype.Migrations
{
    /// <inheritdoc />
    public partial class OfficeSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Office",
                columns: new[] { "OfficeID", "Description", "isActive", "Name" },
                values: new object[,]
                {
                    { 1, "Johannesburg", true, "JHB" },
                    { 2, "Kimberely", true, "KIM" },
                    { 3, "Cape Town", true, "CPT" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Office",
                keyColumn: "OfficeID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Office",
                keyColumn: "OfficeID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Office",
                keyColumn: "OfficeID",
                keyValue: 3);
        }
    }
}
