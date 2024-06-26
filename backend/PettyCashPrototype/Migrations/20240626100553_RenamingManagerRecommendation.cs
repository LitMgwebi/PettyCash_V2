using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PettyCashPrototype.Migrations
{
    /// <inheritdoc />
    public partial class RenamingManagerRecommendation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
