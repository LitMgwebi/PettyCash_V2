using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PettyCashPrototype.Migrations
{
    /// <inheritdoc />
    public partial class AddingDescriptionToRequisition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3fe0a728-fab6-4fbd-b2af-2ec90ee1d5e8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65907695-03f1-42fc-a41c-a5c0a2e30106");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95422b69-93e3-4e82-b6fc-69f114467566");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba545bc9-81ac-4e2d-8772-9d3b63a169ab");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c0e36a16-8c44-4256-8047-e9dc8ecb5ceb");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Requisition",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0e8edd1d-b956-439c-91d1-7aa90373a2c9", null, "ICT Officer", null },
                    { "16f956cc-63a7-4af3-b62c-325cc411fb3a", null, "Finance Manager", null },
                    { "213840f7-69d4-44df-88c5-04fac404a171", null, "ICT Manager", null },
                    { "25870eab-bf8b-418b-aee5-9ad8b800d87e", null, "Admin", null },
                    { "675c1605-155e-44f1-bda1-4dace86ee880", null, "Finance Officer", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e8edd1d-b956-439c-91d1-7aa90373a2c9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "16f956cc-63a7-4af3-b62c-325cc411fb3a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "213840f7-69d4-44df-88c5-04fac404a171");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "25870eab-bf8b-418b-aee5-9ad8b800d87e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "675c1605-155e-44f1-bda1-4dace86ee880");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Requisition");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3fe0a728-fab6-4fbd-b2af-2ec90ee1d5e8", null, "Finance Officer", null },
                    { "65907695-03f1-42fc-a41c-a5c0a2e30106", null, "Admin", null },
                    { "95422b69-93e3-4e82-b6fc-69f114467566", null, "ICT Officer", null },
                    { "ba545bc9-81ac-4e2d-8772-9d3b63a169ab", null, "Finance Manager", null },
                    { "c0e36a16-8c44-4256-8047-e9dc8ecb5ceb", null, "ICT Manager", null }
                });
        }
    }
}
