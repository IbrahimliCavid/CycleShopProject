using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CgangedCycleConfigurationHasIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Cycles_Model_Deleted",
                table: "Cycles");

            migrationBuilder.CreateIndex(
                name: "IX_Cycles_Model_CategoryId_Deleted",
                table: "Cycles",
                columns: new[] { "Model", "CategoryId", "Deleted" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Cycles_Model_CategoryId_Deleted",
                table: "Cycles");

            migrationBuilder.CreateIndex(
                name: "IX_Cycles_Model_Deleted",
                table: "Cycles",
                columns: new[] { "Model", "Deleted" },
                unique: true);
        }
    }
}
