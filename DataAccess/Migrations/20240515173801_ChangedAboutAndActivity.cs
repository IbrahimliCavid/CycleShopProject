using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangedAboutAndActivity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Abouts_AboutId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_AboutId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "AboutId",
                table: "Activities");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Activities",
                newName: "IsHomePage");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsHomePage",
                table: "Activities",
                newName: "IsActive");

            migrationBuilder.AddColumn<int>(
                name: "AboutId",
                table: "Activities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Activities_AboutId",
                table: "Activities",
                column: "AboutId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Abouts_AboutId",
                table: "Activities",
                column: "AboutId",
                principalTable: "Abouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
