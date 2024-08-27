using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PettyCashPrototype.Migrations
{
    /// <inheritdoc />
    public partial class AddingNewStatusDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "StatusID", "Description", "isActive", "IsApproved", "IsRecommended", "IsState", "Option" },
                values: new object[] { 10, "Deleted", true, false, false, true, "Delete" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "StatusID",
                keyValue: 10);
        }
    }
}
