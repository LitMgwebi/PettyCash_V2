using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PettyCashPrototype.Migrations
{
    /// <inheritdoc />
    public partial class LinkUserToTransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DepositorId",
                table: "Transaction",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_DepositorId",
                table: "Transaction",
                column: "DepositorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_AspNetUsers_DepositorId",
                table: "Transaction",
                column: "DepositorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_AspNetUsers_DepositorId",
                table: "Transaction");

            migrationBuilder.DropIndex(
                name: "IX_Transaction_DepositorId",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "DepositorId",
                table: "Transaction");
        }
    }
}
