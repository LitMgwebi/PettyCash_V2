using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PettyCashPrototype.Migrations
{
    /// <inheritdoc />
    public partial class AddingNeedsMigrationToRequisition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "NeedsMotivation",
                table: "Requisition",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NeedsMotivation",
                table: "Requisition");
        }
    }
}
