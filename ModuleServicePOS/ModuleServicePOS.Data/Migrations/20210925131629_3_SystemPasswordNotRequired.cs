using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ModuleServicePOS.Data.Migrations
{
    public partial class _3_SystemPasswordNotRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SystemPassword",
                table: "OrderDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2021, 9, 25, 13, 16, 29, 189, DateTimeKind.Utc).AddTicks(9586));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2021, 9, 25, 13, 16, 29, 190, DateTimeKind.Utc).AddTicks(249));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SystemPassword",
                table: "OrderDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2021, 9, 25, 4, 44, 4, 875, DateTimeKind.Utc).AddTicks(4204));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2021, 9, 25, 4, 44, 4, 875, DateTimeKind.Utc).AddTicks(4921));
        }
    }
}
