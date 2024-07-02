using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PettyCashPrototype.Migrations
{
    /// <inheritdoc />
    public partial class RolesSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "02e9c964-6bf1-4c8a-bc48-639812e4e2c3", null, "Finance_Admin", "Finance_Admin" },
                    { "23357a53-b098-440b-a204-35133941992a", null, "SCM_Admin", "SCM_Admin" },
                    { "2d2a9a13-9dd0-49d0-9b56-a05b59ec4180", null, "PA_Admin", "PA_Admin" },
                    { "514f32b0-aa72-4699-8291-3bec23225a01", null, "Super_User", "Super_User" },
                    { "7613f8fc-eec0-42db-82bf-6e8bb4de5166", null, "SRM_Admin", "SRM_Admin" },
                    { "91e1a5f7-327b-4a34-9076-142913d06a9d", null, "DEEC_Admin", "DEEC_Admin" },
                    { "a06601dd-7649-4353-8b7b-aa5a67dbe299", null, "Cashier", "Cashier" },
                    { "d24ec523-d9c7-4591-b223-33df7747180c", null, "ICT_Admin", "ICT_Admin" },
                    { "dc83af92-56de-48fa-94a5-96e2202676b4", null, "CEO_Admin", "CEO_Admin" },
                    { "dcad8123-09d6-4fdb-a049-9aeb918b056f", null, "Manager", "Manager" },
                    { "de7cce33-2713-4315-9fb7-277dff5cec3e", null, "HR_Admin", "HR_Admin" },
                    { "e336aaf5-07b2-4572-803c-963dffe74028", null, "GM_Manager", "GM_Manager" },
                    { "f38bc1c8-23cc-46aa-9a9d-8301ec2d067b", null, "Employee", "Employee" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "02e9c964-6bf1-4c8a-bc48-639812e4e2c3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "23357a53-b098-440b-a204-35133941992a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d2a9a13-9dd0-49d0-9b56-a05b59ec4180");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "514f32b0-aa72-4699-8291-3bec23225a01");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7613f8fc-eec0-42db-82bf-6e8bb4de5166");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "91e1a5f7-327b-4a34-9076-142913d06a9d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a06601dd-7649-4353-8b7b-aa5a67dbe299");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d24ec523-d9c7-4591-b223-33df7747180c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dc83af92-56de-48fa-94a5-96e2202676b4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dcad8123-09d6-4fdb-a049-9aeb918b056f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "de7cce33-2713-4315-9fb7-277dff5cec3e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e336aaf5-07b2-4572-803c-963dffe74028");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f38bc1c8-23cc-46aa-9a9d-8301ec2d067b");
        }
    }
}
