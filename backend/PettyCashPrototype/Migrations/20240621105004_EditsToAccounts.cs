using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PettyCashPrototype.Migrations
{
    /// <inheritdoc />
    public partial class EditsToAccounts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AccountNumber",
                table: "SubAccount",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "AccountNumber",
                table: "MainAccount",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "MainAccount",
                keyColumn: "MainAccountID",
                keyValue: 1,
                column: "AccountNumber",
                value: "2013");

            migrationBuilder.UpdateData(
                table: "MainAccount",
                keyColumn: "MainAccountID",
                keyValue: 2,
                columns: new[] { "AccountNumber", "Name" },
                values: new object[] { "2012", "Inspection" });

            migrationBuilder.UpdateData(
                table: "MainAccount",
                keyColumn: "MainAccountID",
                keyValue: 3,
                column: "AccountNumber",
                value: "2007");

            migrationBuilder.UpdateData(
                table: "SubAccount",
                keyColumn: "SubAccountID",
                keyValue: 1,
                column: "AccountNumber",
                value: "0206");

            migrationBuilder.UpdateData(
                table: "SubAccount",
                keyColumn: "SubAccountID",
                keyValue: 2,
                column: "AccountNumber",
                value: "0045");

            migrationBuilder.UpdateData(
                table: "SubAccount",
                keyColumn: "SubAccountID",
                keyValue: 3,
                column: "AccountNumber",
                value: "0001");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AccountNumber",
                table: "SubAccount",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "AccountNumber",
                table: "MainAccount",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "MainAccount",
                keyColumn: "MainAccountID",
                keyValue: 1,
                column: "AccountNumber",
                value: 2013);

            migrationBuilder.UpdateData(
                table: "MainAccount",
                keyColumn: "MainAccountID",
                keyValue: 2,
                columns: new[] { "AccountNumber", "Name" },
                values: new object[] { 2013, "Insurance" });

            migrationBuilder.UpdateData(
                table: "MainAccount",
                keyColumn: "MainAccountID",
                keyValue: 3,
                column: "AccountNumber",
                value: 2007);

            migrationBuilder.UpdateData(
                table: "SubAccount",
                keyColumn: "SubAccountID",
                keyValue: 1,
                column: "AccountNumber",
                value: 206);

            migrationBuilder.UpdateData(
                table: "SubAccount",
                keyColumn: "SubAccountID",
                keyValue: 2,
                column: "AccountNumber",
                value: 45);

            migrationBuilder.UpdateData(
                table: "SubAccount",
                keyColumn: "SubAccountID",
                keyValue: 3,
                column: "AccountNumber",
                value: 1);
        }
    }
}
