using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PettyCashPrototype.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Division",
                columns: new[] { "DivisionId", "DepartmentId", "Description", "IsActive", "Name" },
                values: new object[] { 6, 5, "Finance", true, "FIN" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Division",
                keyColumn: "DivisionId",
                keyValue: 6);
        }
    }
}
