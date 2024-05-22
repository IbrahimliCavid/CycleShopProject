using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SomeConfigurationAddedNewIndexs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ShippingAdresses_PhoneNumber_Email_Deleted",
                table: "ShippingAdresses");

            migrationBuilder.DropIndex(
                name: "IX_Services_ImgUrl_Deleted",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Cycles_Name_ImgUrl_Deleted",
                table: "Cycles");

            migrationBuilder.DropIndex(
                name: "IX_BigSales_ImgUrl_Deleted",
                table: "BigSales");

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

            migrationBuilder.CreateIndex(
                name: "IX_Cycles_Name_Deleted",
                table: "Cycles",
                columns: new[] { "Name", "Deleted" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ShippingAdresses_Email_Deleted",
                table: "ShippingAdresses");

            migrationBuilder.DropIndex(
                name: "IX_ShippingAdresses_PhoneNumber_Deleted",
                table: "ShippingAdresses");

            migrationBuilder.DropIndex(
                name: "IX_Cycles_Name_Deleted",
                table: "Cycles");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingAdresses_PhoneNumber_Email_Deleted",
                table: "ShippingAdresses",
                columns: new[] { "PhoneNumber", "Email", "Deleted" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Services_ImgUrl_Deleted",
                table: "Services",
                columns: new[] { "ImgUrl", "Deleted" });

            migrationBuilder.CreateIndex(
                name: "IX_Cycles_Name_ImgUrl_Deleted",
                table: "Cycles",
                columns: new[] { "Name", "ImgUrl", "Deleted" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BigSales_ImgUrl_Deleted",
                table: "BigSales",
                columns: new[] { "ImgUrl", "Deleted" });
        }
    }
}
