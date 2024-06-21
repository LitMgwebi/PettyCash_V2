using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PettyCashPrototype.Migrations
{
    /// <inheritdoc />
    public partial class SubAcountSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SubAccount",
                columns: new[] { "SubAccountID", "AccountNumber", "Description", "isActive", "Name" },
                values: new object[,]
                {
                    { 1, 206, null, true, "IT Audit" },
                    { 2, 45, null, true, "Meeting Fees" },
                    { 3, 1, null, true, "Accomodation" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SubAccount",
                keyColumn: "SubAccountID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SubAccount",
                keyColumn: "SubAccountID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SubAccount",
                keyColumn: "SubAccountID",
                keyValue: 3);
        }
    }
}
