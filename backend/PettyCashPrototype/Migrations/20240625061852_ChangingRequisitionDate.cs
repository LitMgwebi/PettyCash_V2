using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PettyCashPrototype.Migrations
{
    /// <inheritdoc />
    public partial class ChangingRequisitionDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e8df257-54a0-4cdf-97b1-3a9e0e741f4c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f2229c2-4a3e-485e-b134-e4cef0514156");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a1de92b-0472-4886-8be3-94390a149dbb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd5577a0-6377-4605-a33c-e1529809aec5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d8a04f4a-11c2-4f28-9b08-05dbda455554");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Requisition",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CloseDate",
                table: "Requisition",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3fe0a728-fab6-4fbd-b2af-2ec90ee1d5e8", null, "Finance Officer", null },
                    { "65907695-03f1-42fc-a41c-a5c0a2e30106", null, "Admin", null },
                    { "95422b69-93e3-4e82-b6fc-69f114467566", null, "ICT Officer", null },
                    { "ba545bc9-81ac-4e2d-8772-9d3b63a169ab", null, "Finance Manager", null },
                    { "c0e36a16-8c44-4256-8047-e9dc8ecb5ceb", null, "ICT Manager", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3fe0a728-fab6-4fbd-b2af-2ec90ee1d5e8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65907695-03f1-42fc-a41c-a5c0a2e30106");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95422b69-93e3-4e82-b6fc-69f114467566");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba545bc9-81ac-4e2d-8772-9d3b63a169ab");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c0e36a16-8c44-4256-8047-e9dc8ecb5ceb");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "StartDate",
                table: "Requisition",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "CloseDate",
                table: "Requisition",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8e8df257-54a0-4cdf-97b1-3a9e0e741f4c", null, "Admin", null },
                    { "8f2229c2-4a3e-485e-b134-e4cef0514156", null, "Finance Officer", null },
                    { "9a1de92b-0472-4886-8be3-94390a149dbb", null, "ICT Officer", null },
                    { "bd5577a0-6377-4605-a33c-e1529809aec5", null, "ICT Manager", null },
                    { "d8a04f4a-11c2-4f28-9b08-05dbda455554", null, "Finance Manager", null }
                });
        }
    }
}
