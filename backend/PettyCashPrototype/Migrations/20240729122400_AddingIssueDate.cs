using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PettyCashPrototype.Migrations
{
    /// <inheritdoc />
    public partial class AddingIssueDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "IssueDate",
                table: "Requisition",
                type: "datetime2",
                nullable: true);

            migrationBuilder.InsertData(
                table: "JobTitle",
                columns: new[] { "JobTitleId", "Description", "IsActive" },
                values: new object[] { 16, "Accounts Payable", true });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "JobTitle",
                keyColumn: "JobTitleId",
                keyValue: 16);

            migrationBuilder.DropColumn(
                name: "IssueDate",
                table: "Requisition");
        }
    }
}
