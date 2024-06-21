using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PettyCashPrototype.Migrations
{
    /// <inheritdoc />
    public partial class ChangingGLConnection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Department_DepartmentId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Office_OfficeId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DepartmentId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_OfficeId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "OfficeId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "GLAccount",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OfficeId",
                table: "GLAccount",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_GLAccount_DepartmentId",
                table: "GLAccount",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_GLAccount_OfficeId",
                table: "GLAccount",
                column: "OfficeId");

            migrationBuilder.AddForeignKey(
                name: "FK_GLAccount_Department_DepartmentId",
                table: "GLAccount",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "DepartmentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GLAccount_Office_OfficeId",
                table: "GLAccount",
                column: "OfficeId",
                principalTable: "Office",
                principalColumn: "OfficeID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GLAccount_Department_DepartmentId",
                table: "GLAccount");

            migrationBuilder.DropForeignKey(
                name: "FK_GLAccount_Office_OfficeId",
                table: "GLAccount");

            migrationBuilder.DropIndex(
                name: "IX_GLAccount_DepartmentId",
                table: "GLAccount");

            migrationBuilder.DropIndex(
                name: "IX_GLAccount_OfficeId",
                table: "GLAccount");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "GLAccount");

            migrationBuilder.DropColumn(
                name: "OfficeId",
                table: "GLAccount");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OfficeId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DepartmentId",
                table: "AspNetUsers",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_OfficeId",
                table: "AspNetUsers",
                column: "OfficeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Department_DepartmentId",
                table: "AspNetUsers",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "DepartmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Office_OfficeId",
                table: "AspNetUsers",
                column: "OfficeId",
                principalTable: "Office",
                principalColumn: "OfficeID");
        }
    }
}
