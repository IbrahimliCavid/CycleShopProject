using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ShippingAdressConfigurationUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ShippingAdresses_Email_Deleted",
                table: "ShippingAdresses");

            migrationBuilder.DropIndex(
                name: "IX_ShippingAdresses_PhoneNumber_Deleted",
                table: "ShippingAdresses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ShippingAdresses_Email_Deleted",
                table: "ShippingAdresses",
                columns: new[] { "Email", "Deleted" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShippingAdresses_PhoneNumber_Deleted",
                table: "ShippingAdresses",
                columns: new[] { "PhoneNumber", "Deleted" },
                unique: true);
        }
    }
}
