using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PettyCashPrototype.Migrations
{
    /// <inheritdoc />
    public partial class AddingStageToRequisitions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Stage",
                table: "Requisition",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Stage",
                table: "Requisition");
        }
    }
}
