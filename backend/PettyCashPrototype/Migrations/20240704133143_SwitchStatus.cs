using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PettyCashPrototype.Migrations
{
    /// <inheritdoc />
    public partial class SwitchStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requisition_TripStatus",
                table: "Requisition");

            migrationBuilder.DropForeignKey(
                name: "FK_Requisition_TripStatus1",
                table: "Requisition");

            migrationBuilder.DropTable(
                name: "TripStatus");

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    StatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    IsRecommended = table.Column<bool>(type: "bit", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.StatusID);
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "StatusID", "Description", "isActive", "IsApproved", "IsRecommended" },
                values: new object[,]
                {
                    { 1, "Approved", true, true, false },
                    { 2, "Declined", true, true, false },
                    { 3, "Recommended", true, false, true },
                    { 4, "Not Recommended", true, false, true }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Requisition_Status",
                table: "Requisition",
                column: "ManagerApprovalID",
                principalTable: "Status",
                principalColumn: "StatusID");

            migrationBuilder.AddForeignKey(
                name: "FK_Requisition_Status1",
                table: "Requisition",
                column: "FinanceApprovalID",
                principalTable: "Status",
                principalColumn: "StatusID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requisition_Status",
                table: "Requisition");

            migrationBuilder.DropForeignKey(
                name: "FK_Requisition_Status1",
                table: "Requisition");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.CreateTable(
                name: "TripStatus",
                columns: table => new
                {
                    TripStatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    IsRecommended = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripStatus", x => x.TripStatusID);
                });

            migrationBuilder.InsertData(
                table: "TripStatus",
                columns: new[] { "TripStatusID", "Description", "isActive", "IsApproved", "IsRecommended" },
                values: new object[,]
                {
                    { 1, "Approved", true, true, false },
                    { 2, "Declined", true, true, false },
                    { 3, "Recommended", true, false, true },
                    { 4, "Not Recommended", true, false, true }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Requisition_TripStatus",
                table: "Requisition",
                column: "ManagerApprovalID",
                principalTable: "TripStatus",
                principalColumn: "TripStatusID");

            migrationBuilder.AddForeignKey(
                name: "FK_Requisition_TripStatus1",
                table: "Requisition",
                column: "FinanceApprovalID",
                principalTable: "TripStatus",
                principalColumn: "TripStatusID");
        }
    }
}
