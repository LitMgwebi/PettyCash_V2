using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PettyCashPrototype.Migrations
{
    /// <inheritdoc />
    public partial class EditsToState : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Requisition");

            migrationBuilder.AddColumn<bool>(
                name: "IsState",
                table: "Status",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "StateId",
                table: "Requisition",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusID",
                keyValue: 1,
                column: "IsState",
                value: false);

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusID",
                keyValue: 2,
                column: "IsState",
                value: false);

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusID",
                keyValue: 3,
                column: "IsState",
                value: false);

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusID",
                keyValue: 4,
                column: "IsState",
                value: false);

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "StatusID", "Description", "isActive", "IsApproved", "IsRecommended", "IsState", "Option" },
                values: new object[,]
                {
                    { 5, "In Process", true, false, false, true, "Process" },
                    { 6, "Open", true, false, false, true, "Open" },
                    { 7, "Closed", true, false, false, true, "Close" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Requisition_StateId",
                table: "Requisition",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requisition_Status2",
                table: "Requisition",
                column: "StateId",
                principalTable: "Status",
                principalColumn: "StatusID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requisition_Status2",
                table: "Requisition");

            migrationBuilder.DropIndex(
                name: "IX_Requisition_StateId",
                table: "Requisition");

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "StatusID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "StatusID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "StatusID",
                keyValue: 7);

            migrationBuilder.DropColumn(
                name: "IsState",
                table: "Status");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "Requisition");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Requisition",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
