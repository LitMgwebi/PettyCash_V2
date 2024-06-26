using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PettyCashPrototype.Migrations
{
    /// <inheritdoc />
    public partial class JobTitle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requisition_TripStatus2",
                table: "Requisition");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12c3c950-bb90-4c8e-bb57-9925bbf9850d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4f239420-b1e1-4953-ac96-34116e4a3ad8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8be0cb29-4215-4dff-8ea2-e39aab1acf5f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a058a161-a496-4cfd-89ac-2cb6ae50f9a5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca490148-543d-4292-8ca5-d921093a29b5");

            migrationBuilder.RenameColumn(
                name: "StatusID",
                table: "Requisition",
                newName: "TripStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Requisition_StatusID",
                table: "Requisition",
                newName: "IX_Requisition_TripStatusId");

            migrationBuilder.AddColumn<int>(
                name: "JobTitleId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "JobTitles",
                columns: table => new
                {
                    JobTitleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTitles", x => x.JobTitleId);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "04c94bda-4a95-4f8e-870c-26317b9b02b7", null, "Finance_Admin", null },
                    { "0eb121bc-88ad-4b4b-aa88-f48cd14e4aca", null, "Manager", null },
                    { "3f741e36-26b9-4586-980e-f85866570bdc", null, "PA_Admin", null },
                    { "4d2caf0c-c3de-433f-a72d-ae5800e240d1", null, "CEO_Admin", null },
                    { "533aeb1a-4593-4d53-8688-69ab8b0cd326", null, "DEEC_Admin", null },
                    { "5ef795b4-59d3-4e9c-9c22-991c7e48c92d", null, "Cashier", null },
                    { "920980f8-7e20-4248-a82e-d3efcdecab2e", null, "ICT_Admin", null },
                    { "928c7507-7684-4f7f-a765-a9be196614cc", null, "SRM_Admin", null },
                    { "99665908-faad-45ef-973c-51f2675080ea", null, "GM_Manager", null },
                    { "99c52fa5-07b2-4cd6-b0ce-c0be3a2d82d3", null, "Super_User", null },
                    { "c4d3b20b-e06c-4c8e-9853-ebb6e95d0bd9", null, "SCM_Admin", null },
                    { "e469e625-46b9-439b-88f0-d705f1751b74", null, "HR_Admin", null },
                    { "f0cd1fd1-4281-462e-a4a5-221ced365206", null, "Employee", null }
                });

            migrationBuilder.InsertData(
                table: "JobTitles",
                columns: new[] { "JobTitleId", "Description" },
                values: new object[,]
                {
                    { 1, "CEO" },
                    { 2, "CFO" },
                    { 3, "GM: Corporate Services" },
                    { 4, "GM: Governance" },
                    { 5, "GM: Regulatory Compliance" },
                    { 6, "GM: Trade" },
                    { 7, "Manager" },
                    { 8, "Staff" },
                    { 9, "Consultant" },
                    { 10, "Chair Person" },
                    { 11, "Board Member" },
                    { 12, "WGM" },
                    { 13, "General Manager" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_JobTitleId",
                table: "AspNetUsers",
                column: "JobTitleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_JobTitles_JobTitleId",
                table: "AspNetUsers",
                column: "JobTitleId",
                principalTable: "JobTitles",
                principalColumn: "JobTitleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requisition_TripStatus_TripStatusId",
                table: "Requisition",
                column: "TripStatusId",
                principalTable: "TripStatus",
                principalColumn: "TripStatusID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_JobTitles_JobTitleId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Requisition_TripStatus_TripStatusId",
                table: "Requisition");

            migrationBuilder.DropTable(
                name: "JobTitles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_JobTitleId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "04c94bda-4a95-4f8e-870c-26317b9b02b7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0eb121bc-88ad-4b4b-aa88-f48cd14e4aca");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f741e36-26b9-4586-980e-f85866570bdc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d2caf0c-c3de-433f-a72d-ae5800e240d1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "533aeb1a-4593-4d53-8688-69ab8b0cd326");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ef795b4-59d3-4e9c-9c22-991c7e48c92d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "920980f8-7e20-4248-a82e-d3efcdecab2e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "928c7507-7684-4f7f-a765-a9be196614cc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99665908-faad-45ef-973c-51f2675080ea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99c52fa5-07b2-4cd6-b0ce-c0be3a2d82d3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c4d3b20b-e06c-4c8e-9853-ebb6e95d0bd9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e469e625-46b9-439b-88f0-d705f1751b74");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f0cd1fd1-4281-462e-a4a5-221ced365206");

            migrationBuilder.DropColumn(
                name: "JobTitleId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "TripStatusId",
                table: "Requisition",
                newName: "StatusID");

            migrationBuilder.RenameIndex(
                name: "IX_Requisition_TripStatusId",
                table: "Requisition",
                newName: "IX_Requisition_StatusID");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "12c3c950-bb90-4c8e-bb57-9925bbf9850d", null, "ICT Manager", null },
                    { "4f239420-b1e1-4953-ac96-34116e4a3ad8", null, "Finance Officer", null },
                    { "8be0cb29-4215-4dff-8ea2-e39aab1acf5f", null, "Admin", null },
                    { "a058a161-a496-4cfd-89ac-2cb6ae50f9a5", null, "ICT Officer", null },
                    { "ca490148-543d-4292-8ca5-d921093a29b5", null, "Finance Manager", null }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Requisition_TripStatus2",
                table: "Requisition",
                column: "StatusID",
                principalTable: "TripStatus",
                principalColumn: "TripStatusID");
        }
    }
}
