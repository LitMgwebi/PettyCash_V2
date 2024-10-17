using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PettyCashPrototype.Migrations
{
    /// <inheritdoc />
    public partial class EditDocumentRequisitionRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Document_Requisition_Receipt_RequisitionId1",
                table: "Document");

            migrationBuilder.DropForeignKey(
                name: "FK_Document_Requisition_RequisitionId1",
                table: "Document");

            migrationBuilder.DropIndex(
                name: "IX_Document_Receipt_RequisitionId1",
                table: "Document");

            migrationBuilder.DropIndex(
                name: "IX_Document_RequisitionId1",
                table: "Document");

            migrationBuilder.DropColumn(
                name: "Receipt_RequisitionId1",
                table: "Document");

            migrationBuilder.DropColumn(
                name: "RequisitionId1",
                table: "Document");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Receipt_RequisitionId1",
                table: "Document",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RequisitionId1",
                table: "Document",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Document_Receipt_RequisitionId1",
                table: "Document",
                column: "Receipt_RequisitionId1");

            migrationBuilder.CreateIndex(
                name: "IX_Document_RequisitionId1",
                table: "Document",
                column: "RequisitionId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Document_Requisition_Receipt_RequisitionId1",
                table: "Document",
                column: "Receipt_RequisitionId1",
                principalTable: "Requisition",
                principalColumn: "RequisitionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Document_Requisition_RequisitionId1",
                table: "Document",
                column: "RequisitionId1",
                principalTable: "Requisition",
                principalColumn: "RequisitionID");
        }
    }
}
