using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PettyCashPrototype.Migrations
{
    /// <inheritdoc />
    public partial class AddingDocument : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Motivation_Requisition_RequisitionId",
                table: "Motivation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Motivation",
                table: "Motivation");

            migrationBuilder.RenameTable(
                name: "Motivation",
                newName: "Document");

            migrationBuilder.RenameColumn(
                name: "MotivationId",
                table: "Document",
                newName: "DocumentId");

            migrationBuilder.RenameIndex(
                name: "IX_Motivation_RequisitionId",
                table: "Document",
                newName: "IX_Document_RequisitionId");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Document",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_Document",
                table: "Document",
                column: "DocumentId");

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
                name: "FK_Document_Requisition_RequisitionId",
                table: "Document",
                column: "RequisitionId",
                principalTable: "Requisition",
                principalColumn: "RequisitionID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Document_Requisition_RequisitionId1",
                table: "Document",
                column: "RequisitionId1",
                principalTable: "Requisition",
                principalColumn: "RequisitionID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Document_Requisition_Receipt_RequisitionId1",
                table: "Document");

            migrationBuilder.DropForeignKey(
                name: "FK_Document_Requisition_RequisitionId",
                table: "Document");

            migrationBuilder.DropForeignKey(
                name: "FK_Document_Requisition_RequisitionId1",
                table: "Document");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Document",
                table: "Document");

            migrationBuilder.DropIndex(
                name: "IX_Document_Receipt_RequisitionId1",
                table: "Document");

            migrationBuilder.DropIndex(
                name: "IX_Document_RequisitionId1",
                table: "Document");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Document");

            migrationBuilder.DropColumn(
                name: "Receipt_RequisitionId1",
                table: "Document");

            migrationBuilder.DropColumn(
                name: "RequisitionId1",
                table: "Document");

            migrationBuilder.RenameTable(
                name: "Document",
                newName: "Motivation");

            migrationBuilder.RenameColumn(
                name: "DocumentId",
                table: "Motivation",
                newName: "MotivationId");

            migrationBuilder.RenameIndex(
                name: "IX_Document_RequisitionId",
                table: "Motivation",
                newName: "IX_Motivation_RequisitionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Motivation",
                table: "Motivation",
                column: "MotivationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Motivation_Requisition_RequisitionId",
                table: "Motivation",
                column: "RequisitionId",
                principalTable: "Requisition",
                principalColumn: "RequisitionID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
