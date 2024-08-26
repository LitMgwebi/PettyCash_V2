using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PettyCashPrototype.Migrations
{
    /// <inheritdoc />
    public partial class AddingNewStatusReturned : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusID",
                keyValue: 6,
                columns: new[] { "Description", "Option" },
                values: new object[] { "Open", "Open" });

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusID",
                keyValue: 7,
                columns: new[] { "Description", "Option" },
                values: new object[] { "Issued", "Issue" });

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusID",
                keyValue: 8,
                columns: new[] { "Description", "Option" },
                values: new object[] { "Returned", "Return" });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "StatusID", "Description", "isActive", "IsApproved", "IsRecommended", "IsState", "Option" },
                values: new object[] { 9, "Closed", true, false, false, true, "Close" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "StatusID",
                keyValue: 9);

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusID",
                keyValue: 6,
                columns: new[] { "Description", "Option" },
                values: new object[] { "Issued", "Issue" });

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusID",
                keyValue: 7,
                columns: new[] { "Description", "Option" },
                values: new object[] { "Open", "Open" });

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusID",
                keyValue: 8,
                columns: new[] { "Description", "Option" },
                values: new object[] { "Closed", "Close" });
        }
    }
}
