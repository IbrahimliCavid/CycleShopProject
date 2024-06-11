using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CartUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartCycles");

            migrationBuilder.AddColumn<int>(
                name: "CycleId",
                table: "Carts",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Cycles_CycleId",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_CycleId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "CycleId",
                table: "Carts");

            migrationBuilder.CreateTable(
                name: "CartCycles",
                columns: table => new
                {
                    CartsId = table.Column<int>(type: "int", nullable: false),
                    CyclesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartCycles", x => new { x.CartsId, x.CyclesId });
                    table.ForeignKey(
                        name: "FK_CartCycles_Carts_CartsId",
                        column: x => x.CartsId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartCycles_Cycles_CyclesId",
                        column: x => x.CyclesId,
                        principalTable: "Cycles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartCycles_CyclesId",
                table: "CartCycles",
                column: "CyclesId");
        }
    }
}
