using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PettyCashPrototype.Migrations
{
    /// <inheritdoc />
    public partial class UpdateoTransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Requisition_RequisitionId",
                table: "Transaction");

            migrationBuilder.AlterColumn<int>(
                name: "RequisitionId",
                table: "Transaction",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Requisition_RequisitionId",
                table: "Transaction",
                column: "RequisitionId",
                principalTable: "Requisition",
                principalColumn: "RequisitionID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Requisition_RequisitionId",
                table: "Transaction");

            migrationBuilder.AlterColumn<int>(
                name: "RequisitionId",
                table: "Transaction",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Requisition_RequisitionId",
                table: "Transaction",
                column: "RequisitionId",
                principalTable: "Requisition",
                principalColumn: "RequisitionID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
