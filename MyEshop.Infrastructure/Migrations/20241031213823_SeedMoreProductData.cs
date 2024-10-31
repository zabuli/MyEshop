using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyEshop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedMoreProductData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImgUri", "Name", "Price" },
                values: new object[,]
                {
                    { 4, null, "www.images.com/product04", "Product 04", 24.99m },
                    { 5, null, "www.images.com/product05", "Product 05", 25.99m },
                    { 6, null, "www.images.com/product06", "Product 06", 26.99m },
                    { 7, null, "www.images.com/product07", "Product 07", 27.99m },
                    { 8, null, "www.images.com/product08", "Product 08", 28.99m },
                    { 9, null, "www.images.com/product09", "Product 09", 29.99m },
                    { 10, null, "www.images.com/product10", "Product 10", 10.99m },
                    { 11, null, "www.images.com/product11", "Product 11", 11.99m },
                    { 12, null, "www.images.com/product12", "Product 12", 12.99m },
                    { 13, null, "www.images.com/product13", "Product 13", 13.99m },
                    { 14, null, "www.images.com/product14", "Product 14", 14.99m },
                    { 15, null, "www.images.com/product15", "Product 15", 15.99m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);
        }
    }
}
