using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ModuleServicePOS.Data.Migrations
{
    public partial class _1_ModuleService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreparedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatePrepared = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SystemType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SerialNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TechnicianNote = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SystemPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsClosed = table.Column<bool>(type: "bit", nullable: false),
                    SubTotal = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    GrandTotal = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SummaryOfReceivedMasters",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SummaryOfReceivedMasters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MailId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstimateDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemAddDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SerialNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    OrderDetailId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstimateDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EstimateDetails_OrderDetails_OrderDetailId",
                        column: x => x.OrderDetailId,
                        principalTable: "OrderDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "City", "ContactNumber", "CreatedDate", "Gender", "MailId", "ModifiedDate", "Name", "Password", "UserName" },
                values: new object[] { 1L, 100, "", "", new DateTime(2021, 9, 24, 12, 58, 2, 671, DateTimeKind.Utc).AddTicks(4199), "", "SuperAdmin1@POS.com", null, "SuperAdmin1", "SuperAdmin1", "SuperAdmin1" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "City", "ContactNumber", "CreatedDate", "Gender", "MailId", "ModifiedDate", "Name", "Password", "UserName" },
                values: new object[] { 2L, 100, "", "", new DateTime(2021, 9, 24, 12, 58, 2, 671, DateTimeKind.Utc).AddTicks(4907), "", "SuperAdmin2@POS.com", null, "SuperAdmin2", "SuperAdmin2", "SuperAdmin2" });

            migrationBuilder.CreateIndex(
                name: "IX_EstimateDetails_OrderDetailId",
                table: "EstimateDetails",
                column: "OrderDetailId");

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
                name: "EstimateDetails");

            migrationBuilder.DropTable(
                name: "SummaryOfReceivedOrderDetails");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "SummaryOfReceivedMasters");
        }
    }
}
