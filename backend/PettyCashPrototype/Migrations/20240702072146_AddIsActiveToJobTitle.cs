using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PettyCashPrototype.Migrations
{
    /// <inheritdoc />
    public partial class AddIsActiveToJobTitle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "JobTitle",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "JobTitle",
                keyColumn: "JobTitleId",
                keyValue: 1,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "JobTitle",
                keyColumn: "JobTitleId",
                keyValue: 2,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "JobTitle",
                keyColumn: "JobTitleId",
                keyValue: 3,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "JobTitle",
                keyColumn: "JobTitleId",
                keyValue: 4,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "JobTitle",
                keyColumn: "JobTitleId",
                keyValue: 5,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "JobTitle",
                keyColumn: "JobTitleId",
                keyValue: 6,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "JobTitle",
                keyColumn: "JobTitleId",
                keyValue: 7,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "JobTitle",
                keyColumn: "JobTitleId",
                keyValue: 8,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "JobTitle",
                keyColumn: "JobTitleId",
                keyValue: 9,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "JobTitle",
                keyColumn: "JobTitleId",
                keyValue: 10,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "JobTitle",
                keyColumn: "JobTitleId",
                keyValue: 11,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "JobTitle",
                keyColumn: "JobTitleId",
                keyValue: 12,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "JobTitle",
                keyColumn: "JobTitleId",
                keyValue: 13,
                column: "IsActive",
                value: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "JobTitle");

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
        }
    }
}
