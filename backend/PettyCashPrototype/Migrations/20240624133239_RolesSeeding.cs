using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PettyCashPrototype.Migrations
{
    /// <inheritdoc />
    public partial class RolesSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8e8df257-54a0-4cdf-97b1-3a9e0e741f4c", null, "Admin", null },
                    { "8f2229c2-4a3e-485e-b134-e4cef0514156", null, "Finance Officer", null },
                    { "9a1de92b-0472-4886-8be3-94390a149dbb", null, "ICT Officer", null },
                    { "bd5577a0-6377-4605-a33c-e1529809aec5", null, "ICT Manager", null },
                    { "d8a04f4a-11c2-4f28-9b08-05dbda455554", null, "Finance Manager", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e8df257-54a0-4cdf-97b1-3a9e0e741f4c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f2229c2-4a3e-485e-b134-e4cef0514156");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a1de92b-0472-4886-8be3-94390a149dbb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd5577a0-6377-4605-a33c-e1529809aec5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d8a04f4a-11c2-4f28-9b08-05dbda455554");
        }
    }
}
