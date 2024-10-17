using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PettyCashPrototype.Migrations
{
    /// <inheritdoc />
    public partial class AddingFinanceComment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Comment",
                table: "Requisition",
                newName: "ManagerComment");

            migrationBuilder.AddColumn<string>(
                name: "FinanceComment",
                table: "Requisition",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinanceComment",
                table: "Requisition");

            migrationBuilder.RenameColumn(
                name: "ManagerComment",
                table: "Requisition",
                newName: "Comment");
        }
    }
}
