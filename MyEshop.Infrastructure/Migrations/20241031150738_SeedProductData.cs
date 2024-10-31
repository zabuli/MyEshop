using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyEshop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedProductData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImgUri", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Description for Product 01", "www.images.com/product01", "Product 01", 10.99m },
                    { 2, "Description for Product 02", "www.images.com/product02", "Product 02", 19.99m },
                    { 3, null, "www.images.com/product03", "Product 03", 29.99m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
