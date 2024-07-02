using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PettyCashPrototype.Migrations
{
    /// <inheritdoc />
    public partial class ExplicitCastForTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "16ea7aa2-f170-4433-bb6a-08266ada6029");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b3146f8-9aba-4770-83de-c538e5cae3a7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "40323865-3ca6-47a9-be1f-b81a6c4d5f1b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a3e14ec-b870-4534-90dc-0e5d72bf622a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e58e31f-3bc5-4bc1-97f8-a74832efb73f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e1e28d6-da03-401e-b558-00ed0eea805f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d64c097-8c33-4e33-8986-0432a2cbac55");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6f17444f-e17b-4576-aedf-411c68912ed4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "765bcc05-9271-435b-9db7-0f8443b3164f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7776b4d0-9a3e-42eb-8730-f6f987bd9c62");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9ecceff9-7fb0-4d0c-9597-884d8e4957d7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aa44333f-aa07-4491-a851-b043ba55b34d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fdb012f2-c43d-4cc0-b4c2-52ad400ef930");

            migrationBuilder.RenameColumn(
                name: "isActive",
                table: "Department",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "DepartmentID",
                table: "Department",
                newName: "DepartmentId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "00fc42b1-b25c-44b3-8689-59d5a893a05b", null, "SCM_Admin", null },
                    { "1aca897d-e5db-46f4-afd3-32ff033546e9", null, "SRM_Admin", null },
                    { "3aa62c0f-282c-453e-abfb-c10afc74fa6c", null, "CEO_Admin", null },
                    { "4509c03a-c880-47a3-82c4-6075ff5f51c9", null, "PA_Admin", null },
                    { "4ebc1e4e-1bbe-4c5e-a10f-d8c2576bc56c", null, "Super_User", null },
                    { "6a3acecc-9dc1-4758-b8f8-a6c88dafe0ca", null, "Employee", null },
                    { "746845b6-afbb-4fbc-9867-e02b8e2d9ddb", null, "Manager", null },
                    { "7ab1ebac-99dd-435a-998b-223c1880eeb3", null, "ICT_Admin", null },
                    { "7f7296a2-a0c9-4bdf-87c3-d8f1b5a00291", null, "Cashier", null },
                    { "7fcde37f-4e14-4513-9915-7921678ae767", null, "DEEC_Admin", null },
                    { "8b644366-951f-44d7-a4d5-c0c249efb78a", null, "GM_Manager", null },
                    { "91219f32-6d44-4ec8-b3b1-81cc9ae5d63c", null, "Finance_Admin", null },
                    { "969bbd06-53f5-4fe9-aa00-3b81f5229db2", null, "HR_Admin", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00fc42b1-b25c-44b3-8689-59d5a893a05b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1aca897d-e5db-46f4-afd3-32ff033546e9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3aa62c0f-282c-453e-abfb-c10afc74fa6c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4509c03a-c880-47a3-82c4-6075ff5f51c9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4ebc1e4e-1bbe-4c5e-a10f-d8c2576bc56c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a3acecc-9dc1-4758-b8f8-a6c88dafe0ca");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "746845b6-afbb-4fbc-9867-e02b8e2d9ddb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7ab1ebac-99dd-435a-998b-223c1880eeb3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7f7296a2-a0c9-4bdf-87c3-d8f1b5a00291");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7fcde37f-4e14-4513-9915-7921678ae767");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8b644366-951f-44d7-a4d5-c0c249efb78a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "91219f32-6d44-4ec8-b3b1-81cc9ae5d63c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "969bbd06-53f5-4fe9-aa00-3b81f5229db2");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Department",
                newName: "isActive");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Department",
                newName: "DepartmentID");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "16ea7aa2-f170-4433-bb6a-08266ada6029", null, "CEO_Admin", null },
                    { "3b3146f8-9aba-4770-83de-c538e5cae3a7", null, "DEEC_Admin", null },
                    { "40323865-3ca6-47a9-be1f-b81a6c4d5f1b", null, "SCM_Admin", null },
                    { "4a3e14ec-b870-4534-90dc-0e5d72bf622a", null, "PA_Admin", null },
                    { "4e58e31f-3bc5-4bc1-97f8-a74832efb73f", null, "Manager", null },
                    { "5e1e28d6-da03-401e-b558-00ed0eea805f", null, "Super_User", null },
                    { "6d64c097-8c33-4e33-8986-0432a2cbac55", null, "Finance_Admin", null },
                    { "6f17444f-e17b-4576-aedf-411c68912ed4", null, "HR_Admin", null },
                    { "765bcc05-9271-435b-9db7-0f8443b3164f", null, "Employee", null },
                    { "7776b4d0-9a3e-42eb-8730-f6f987bd9c62", null, "ICT_Admin", null },
                    { "9ecceff9-7fb0-4d0c-9597-884d8e4957d7", null, "Cashier", null },
                    { "aa44333f-aa07-4491-a851-b043ba55b34d", null, "GM_Manager", null },
                    { "fdb012f2-c43d-4cc0-b4c2-52ad400ef930", null, "SRM_Admin", null }
                });
        }
    }
}
