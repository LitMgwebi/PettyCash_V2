using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PettyCashPrototype.Migrations
{
    /// <inheritdoc />
    public partial class AddStatusOptions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Option",
                table: "Status",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusID",
                keyValue: 1,
                column: "Option",
                value: "Approve");

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusID",
                keyValue: 2,
                column: "Option",
                value: "Decline");

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusID",
                keyValue: 3,
                column: "Option",
                value: "Recommend");

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusID",
                keyValue: 4,
                columns: new[] { "Description", "Option" },
                values: new object[] { "Rejected", "Reject" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Option",
                table: "Status");

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusID",
                keyValue: 4,
                column: "Description",
                value: "Not Recommended");
        }
    }
}
