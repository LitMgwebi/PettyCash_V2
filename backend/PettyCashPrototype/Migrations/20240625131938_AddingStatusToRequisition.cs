using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PettyCashPrototype.Migrations
{
    /// <inheritdoc />
    public partial class AddingStatusToRequisition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b6530f90-65ee-4b8c-81e5-f282b6c469a8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df99e842-7c2b-4da4-95e1-65a833a0c29a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e109d0eb-6725-4f9a-a8f7-c86a216e22a0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f3fee0e5-871e-4773-879d-dc9683d4e1f0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fa553eee-5c85-4c4e-b474-df99300440e6");

            migrationBuilder.AddColumn<int>(
                name: "StatusID",
                table: "Requisition",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Requisition_StatusID",
                table: "Requisition",
                column: "StatusID");

            migrationBuilder.AddForeignKey(
                name: "FK_Requisition_TripStatus2",
                table: "Requisition",
                column: "StatusID",
                principalTable: "TripStatus",
                principalColumn: "TripStatusID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requisition_TripStatus2",
                table: "Requisition");

            migrationBuilder.DropIndex(
                name: "IX_Requisition_StatusID",
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

            migrationBuilder.DropColumn(
                name: "StatusID",
                table: "Requisition");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b6530f90-65ee-4b8c-81e5-f282b6c469a8", null, "Finance Manager", null },
                    { "df99e842-7c2b-4da4-95e1-65a833a0c29a", null, "ICT Manager", null },
                    { "e109d0eb-6725-4f9a-a8f7-c86a216e22a0", null, "ICT Officer", null },
                    { "f3fee0e5-871e-4773-879d-dc9683d4e1f0", null, "Admin", null },
                    { "fa553eee-5c85-4c4e-b474-df99300440e6", null, "Finance Officer", null }
                });
        }
    }
}
