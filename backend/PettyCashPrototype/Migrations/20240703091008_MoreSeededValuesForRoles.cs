using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PettyCashPrototype.Migrations
{
    /// <inheritdoc />
    public partial class MoreSeededValuesForRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1a69126a-3658-44b3-9b2b-1732d0ce9e1a", null, "ICT_Admin", "ICT_Admin" },
                    { "24e9d163-c600-42db-92ca-594fdc639e58", null, "Cashier", "Cashier" },
                    { "3531888a-9e52-4f49-aca7-e85fe0705c33", null, "DEEC_Admin", "DEEC_Admin" },
                    { "37ce7a5a-9260-405c-9dd0-b8f4a32156fd", null, "Manager", "Manager" },
                    { "50b0ecd5-fb64-4724-9190-bc9953ccd7b5", null, "SRM_Admin", "SRM_Admin" },
                    { "68d5c727-9ae8-401a-8c2c-1cebb5e78735", null, "GM_Manager", "GM_Manager" },
                    { "6bd427b1-62c9-425b-86ed-a1f69d2d570b", null, "SCM_Admin", "SCM_Admin" },
                    { "b139cc03-eb14-45a2-a560-8415006211a1", null, "PA_Admin", "PA_Admin" },
                    { "b69328a6-ad18-4ae3-bc96-a69816cd3a1d", null, "Employee", "Employee" },
                    { "bd88b1a9-2e95-4167-88d2-7c0d6b204f44", null, "CEO_Admin", "CEO_Admin" },
                    { "c303538f-3fd6-4fc1-974c-d94c07ba1391", null, "Super_User", "Super_User" },
                    { "f50b76c7-3bba-4edb-93d4-eef4af92a9ab", null, "HR_Admin", "HR_Admin" },
                    { "fd1d6d8f-9e0f-49e1-a569-746fc8eaa6f6", null, "Finance_Admin", "Finance_Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a69126a-3658-44b3-9b2b-1732d0ce9e1a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "24e9d163-c600-42db-92ca-594fdc639e58");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3531888a-9e52-4f49-aca7-e85fe0705c33");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37ce7a5a-9260-405c-9dd0-b8f4a32156fd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "50b0ecd5-fb64-4724-9190-bc9953ccd7b5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68d5c727-9ae8-401a-8c2c-1cebb5e78735");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6bd427b1-62c9-425b-86ed-a1f69d2d570b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b139cc03-eb14-45a2-a560-8415006211a1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b69328a6-ad18-4ae3-bc96-a69816cd3a1d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd88b1a9-2e95-4167-88d2-7c0d6b204f44");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c303538f-3fd6-4fc1-974c-d94c07ba1391");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f50b76c7-3bba-4edb-93d4-eef4af92a9ab");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fd1d6d8f-9e0f-49e1-a569-746fc8eaa6f6");
        }
    }
}
