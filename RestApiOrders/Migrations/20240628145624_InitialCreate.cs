using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestApiOrders.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    IdCategory = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.IdCategory);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    IdClient = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.IdClient);
                });

            migrationBuilder.CreateTable(
                name: "UnitOfMeasurement",
                columns: table => new
                {
                    IdUnitOfMeasurement = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitOfMeasurement", x => x.IdUnitOfMeasurement);
                });

            migrationBuilder.CreateTable(
                name: "Worker",
                columns: table => new
                {
                    IdWorker = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Worker", x => x.IdWorker);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    IdItem = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdCategory = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    FotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdUnitOfMeasurement = table.Column<int>(type: "int", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.IdItem);
                    table.ForeignKey(
                        name: "FK_Item_Category",
                        column: x => x.IdCategory,
                        principalTable: "Category",
                        principalColumn: "IdCategory");
                    table.ForeignKey(
                        name: "FK_Item_UnitOfMeasurement",
                        column: x => x.IdUnitOfMeasurement,
                        principalTable: "UnitOfMeasurement",
                        principalColumn: "IdUnitOfMeasurement");
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    IdOrder = table.Column<int>(type: "int", nullable: false),
                    DataOrder = table.Column<DateTime>(type: "datetime", nullable: true),
                    IdClient = table.Column<int>(type: "int", nullable: true),
                    IdWorker = table.Column<int>(type: "int", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Order__C38F300946897B18", x => x.IdOrder);
                    table.ForeignKey(
                        name: "FK_Order_Client",
                        column: x => x.IdClient,
                        principalTable: "Client",
                        principalColumn: "IdClient");
                    table.ForeignKey(
                        name: "FK_Order_Worker",
                        column: x => x.IdWorker,
                        principalTable: "Worker",
                        principalColumn: "IdWorker");
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    IdOrderItem = table.Column<int>(type: "int", nullable: false),
                    IdOrder = table.Column<int>(type: "int", nullable: false),
                    IdItem = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.IdOrderItem);
                    table.ForeignKey(
                        name: "FK_OrderItem_Item",
                        column: x => x.IdItem,
                        principalTable: "Item",
                        principalColumn: "IdItem");
                    table.ForeignKey(
                        name: "FK_OrderItem_Order",
                        column: x => x.IdOrder,
                        principalTable: "Order",
                        principalColumn: "IdOrder");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Item_IdCategory",
                table: "Item",
                column: "IdCategory");

            migrationBuilder.CreateIndex(
                name: "IX_Item_IdUnitOfMeasurement",
                table: "Item",
                column: "IdUnitOfMeasurement");

            migrationBuilder.CreateIndex(
                name: "IX_Order_IdClient",
                table: "Order",
                column: "IdClient");

            migrationBuilder.CreateIndex(
                name: "IX_Order_IdWorker",
                table: "Order",
                column: "IdWorker");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_IdItem",
                table: "OrderItem",
                column: "IdItem");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_IdOrder",
                table: "OrderItem",
                column: "IdOrder");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "UnitOfMeasurement");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Worker");
        }
    }
}
