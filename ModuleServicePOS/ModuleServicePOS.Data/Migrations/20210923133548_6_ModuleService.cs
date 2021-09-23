using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ModuleServicePOS.Data.Migrations
{
    public partial class _6_ModuleService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SummaryOfReceiveds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_summaryOfReceivedMasters",
                table: "summaryOfReceivedMasters");

            migrationBuilder.RenameTable(
                name: "summaryOfReceivedMasters",
                newName: "SummaryOfReceivedMasters");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SummaryOfReceivedMasters",
                table: "SummaryOfReceivedMasters",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "SummaryOfReceivedOrderDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDetailId = table.Column<long>(type: "bigint", nullable: false),
                    SummaryOfReceivedMasterId = table.Column<long>(type: "bigint", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModelNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SummaryOfReceivedOrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SummaryOfReceivedOrderDetails_OrderDetails_OrderDetailId",
                        column: x => x.OrderDetailId,
                        principalTable: "OrderDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SummaryOfReceivedOrderDetails_SummaryOfReceivedMasters_SummaryOfReceivedMasterId",
                        column: x => x.SummaryOfReceivedMasterId,
                        principalTable: "SummaryOfReceivedMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2021, 9, 23, 13, 35, 44, 749, DateTimeKind.Utc).AddTicks(2092));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2021, 9, 23, 13, 35, 44, 749, DateTimeKind.Utc).AddTicks(2823));

            migrationBuilder.CreateIndex(
                name: "IX_SummaryOfReceivedOrderDetails_OrderDetailId",
                table: "SummaryOfReceivedOrderDetails",
                column: "OrderDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_SummaryOfReceivedOrderDetails_SummaryOfReceivedMasterId",
                table: "SummaryOfReceivedOrderDetails",
                column: "SummaryOfReceivedMasterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SummaryOfReceivedOrderDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SummaryOfReceivedMasters",
                table: "SummaryOfReceivedMasters");

            migrationBuilder.RenameTable(
                name: "SummaryOfReceivedMasters",
                newName: "summaryOfReceivedMasters");

            migrationBuilder.AddPrimaryKey(
                name: "PK_summaryOfReceivedMasters",
                table: "summaryOfReceivedMasters",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "SummaryOfReceiveds",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OrderDetailId = table.Column<long>(type: "bigint", nullable: false),
                    OrderDetailsId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SummaryOfReceiveds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SummaryOfReceiveds_OrderDetails_OrderDetailsId",
                        column: x => x.OrderDetailsId,
                        principalTable: "OrderDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2021, 9, 22, 7, 18, 15, 80, DateTimeKind.Utc).AddTicks(2588));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2021, 9, 22, 7, 18, 15, 80, DateTimeKind.Utc).AddTicks(3303));

            migrationBuilder.CreateIndex(
                name: "IX_SummaryOfReceiveds_OrderDetailsId",
                table: "SummaryOfReceiveds",
                column: "OrderDetailsId");
        }
    }
}
