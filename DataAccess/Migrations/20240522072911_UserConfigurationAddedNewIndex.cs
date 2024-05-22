using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UserConfigurationAddedNewIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Email_UserName_Deleted",
                table: "Users");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email_Deleted",
                table: "Users",
                columns: new[] { "Email", "Deleted" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName_Deleted",
                table: "Users",
                columns: new[] { "UserName", "Deleted" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Email_Deleted",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserName_Deleted",
                table: "Users");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email_UserName_Deleted",
                table: "Users",
                columns: new[] { "Email", "UserName", "Deleted" },
                unique: true);
        }
    }
}
