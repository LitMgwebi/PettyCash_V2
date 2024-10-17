using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PettyCashPrototype.Migrations
{
    /// <inheritdoc />
    public partial class MoreJobTitles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "JobTitle",
                columns: new[] { "JobTitleId", "Description", "IsActive" },
                values: new object[,]
                {
                    { 14, "Accountant", true },
                    { 15, "Bookkeeper", true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "JobTitle",
                keyColumn: "JobTitleId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "JobTitle",
                keyColumn: "JobTitleId",
                keyValue: 15);
        }
    }
}
