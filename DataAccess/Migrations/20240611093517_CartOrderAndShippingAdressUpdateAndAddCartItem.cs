using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CartOrderAndShippingAdressUpdateAndAddCartItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Cycles_CycleId",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_ShippingAdresses_UserId",
                table: "ShippingAdresses");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ShippingAdressId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Carts_CycleId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "CycleId",
                table: "Carts");

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1000, 1"),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    CycleId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)1),
                    Deleted = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Cycles_CycleId",
                        column: x => x.CycleId,
                        principalTable: "Cycles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShippingAdresses_UserId",
                table: "ShippingAdresses",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShippingAdressId",
                table: "Orders",
                column: "ShippingAdressId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CycleId",
                table: "CartItems",
                column: "CycleId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropIndex(
                name: "IX_ShippingAdresses_UserId",
                table: "ShippingAdresses");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ShippingAdressId",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "CycleId",
                table: "Carts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ShippingAdresses_UserId",
                table: "ShippingAdresses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShippingAdressId",
                table: "Orders",
                column: "ShippingAdressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Carts_CycleId",
                table: "Carts",
                column: "CycleId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Cycles_CycleId",
                table: "Carts",
                column: "CycleId",
                principalTable: "Cycles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
