using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PettyCashPrototype.Migrations
{
    /// <inheritdoc />
    public partial class ExplicitCastOfJobTitle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_JobTitles_JobTitleId",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobTitles",
                table: "JobTitles");

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

            migrationBuilder.RenameTable(
                name: "JobTitles",
                newName: "JobTitle");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobTitle",
                table: "JobTitle",
                column: "JobTitleId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2dc52cde-7056-4941-9329-58eb6ac555f7", null, "GM_Manager", null },
                    { "378bdc02-e958-47e4-a306-ecc6b5bd5ab7", null, "SCM_Admin", null },
                    { "639783ab-ec91-4fe8-9da4-70eb08761ac5", null, "Manager", null },
                    { "6bcc1a7b-0483-4680-a620-0a55ce75ba56", null, "Cashier", null },
                    { "71cbe21f-b860-4465-a625-49a920b9eda4", null, "HR_Admin", null },
                    { "8230c2c4-7721-47eb-8583-28b17ad7d5e8", null, "CEO_Admin", null },
                    { "9ac85057-8d09-4f38-aa80-28c8a78ea657", null, "PA_Admin", null },
                    { "9deee18c-f64d-43f4-8d2a-f01075f0e56a", null, "ICT_Admin", null },
                    { "ac1811c8-e9f5-452e-bb19-376e1fe0eb37", null, "Employee", null },
                    { "d314d8af-8d31-4833-879d-68d48c0829b4", null, "DEEC_Admin", null },
                    { "dd83ec06-3bd4-4e38-9719-565ea8e68269", null, "Super_User", null },
                    { "e3175e0c-6af4-4c39-a7ee-8f7e3a1921f8", null, "SRM_Admin", null },
                    { "f0696d41-ff81-4f84-93ab-371d77053e51", null, "Finance_Admin", null }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_JobTitle_JobTitleId",
                table: "AspNetUsers",
                column: "JobTitleId",
                principalTable: "JobTitle",
                principalColumn: "JobTitleId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_JobTitle_JobTitleId",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobTitle",
                table: "JobTitle");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2dc52cde-7056-4941-9329-58eb6ac555f7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "378bdc02-e958-47e4-a306-ecc6b5bd5ab7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "639783ab-ec91-4fe8-9da4-70eb08761ac5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6bcc1a7b-0483-4680-a620-0a55ce75ba56");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "71cbe21f-b860-4465-a625-49a920b9eda4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8230c2c4-7721-47eb-8583-28b17ad7d5e8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9ac85057-8d09-4f38-aa80-28c8a78ea657");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9deee18c-f64d-43f4-8d2a-f01075f0e56a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ac1811c8-e9f5-452e-bb19-376e1fe0eb37");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d314d8af-8d31-4833-879d-68d48c0829b4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dd83ec06-3bd4-4e38-9719-565ea8e68269");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e3175e0c-6af4-4c39-a7ee-8f7e3a1921f8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f0696d41-ff81-4f84-93ab-371d77053e51");

            migrationBuilder.RenameTable(
                name: "JobTitle",
                newName: "JobTitles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobTitles",
                table: "JobTitles",
                column: "JobTitleId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_JobTitles_JobTitleId",
                table: "AspNetUsers",
                column: "JobTitleId",
                principalTable: "JobTitles",
                principalColumn: "JobTitleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
