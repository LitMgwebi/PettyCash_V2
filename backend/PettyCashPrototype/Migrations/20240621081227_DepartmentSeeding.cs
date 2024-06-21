using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PettyCashPrototype.Migrations
{
    /// <inheritdoc />
    public partial class DepartmentSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Purpose",
                keyColumn: "PurposeID",
                keyValue: 5);

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "DepartmentID", "Description", "isActive", "Name" },
                values: new object[,]
                {
                    { 1, "Inspectorate", true, "INS" },
                    { 2, "Information Communication Technology", true, "ICT" },
                    { 3, "Legal", true, "LEG" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "DepartmentID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "DepartmentID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "DepartmentID",
                keyValue: 3);

            migrationBuilder.InsertData(
                table: "Purpose",
                columns: new[] { "PurposeID", "Description", "isActive", "Name" },
                values: new object[] { 5, "Test", true, "TST" });
        }
    }
}
