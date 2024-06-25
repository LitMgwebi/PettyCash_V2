using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PettyCashPrototype.Migrations
{
    /// <inheritdoc />
    public partial class GettingRidOfUserRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_AspNetUserRoles_AspNetRoles_RoleId1",
            //    table: "AspNetUserRoles");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_AspNetUserRoles_AspNetUsers_UserId1",
            //    table: "AspNetUserRoles");

            //migrationBuilder.DropIndex(
            //    name: "IX_AspNetUserRoles_RoleId1",
            //    table: "AspNetUserRoles");

            //migrationBuilder.DropIndex(
            //    name: "IX_AspNetUserRoles_UserId1",
            //    table: "AspNetUserRoles");

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

            //migrationBuilder.DropColumn(
            //    name: "RoleId1",
            //    table: "AspNetUserRoles");

            //migrationBuilder.DropColumn(
            //    name: "UserId1",
            //    table: "AspNetUserRoles");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            //migrationBuilder.AddColumn<string>(
            //    name: "RoleId1",
            //    table: "AspNetUserRoles",
            //    type: "nvarchar(450)",
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "UserId1",
            //    table: "AspNetUserRoles",
            //    type: "nvarchar(450)",
            //    nullable: true);

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

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUserRoles_RoleId1",
            //    table: "AspNetUserRoles",
            //    column: "RoleId1");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUserRoles_UserId1",
            //    table: "AspNetUserRoles",
            //    column: "UserId1");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_AspNetUserRoles_AspNetRoles_RoleId1",
            //    table: "AspNetUserRoles",
            //    column: "RoleId1",
            //    principalTable: "AspNetRoles",
            //    principalColumn: "Id");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_AspNetUserRoles_AspNetUsers_UserId1",
            //    table: "AspNetUserRoles",
            //    column: "UserId1",
            //    principalTable: "AspNetUsers",
            //    principalColumn: "Id");
        }
    }
}
