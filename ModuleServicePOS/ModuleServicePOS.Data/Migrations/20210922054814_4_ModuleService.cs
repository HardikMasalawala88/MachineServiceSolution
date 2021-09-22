using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ModuleServicePOS.Data.Migrations
{
    public partial class _4_ModuleService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SystemPassword",
                table: "OrderDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2021, 9, 22, 5, 48, 13, 482, DateTimeKind.Utc).AddTicks(8383));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2021, 9, 22, 5, 48, 13, 482, DateTimeKind.Utc).AddTicks(9112));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SystemPassword",
                table: "OrderDetails");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2021, 9, 17, 10, 23, 36, 889, DateTimeKind.Utc).AddTicks(6113));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2021, 9, 17, 10, 23, 36, 889, DateTimeKind.Utc).AddTicks(6835));
        }
    }
}
