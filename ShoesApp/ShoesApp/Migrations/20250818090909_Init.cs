using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShoesApp.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shoes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Shoes",
                columns: new[] { "Id", "Brand", "Category", "Color", "ImageUrl", "Model", "Price", "Size" },
                values: new object[,]
                {
                    { 1, "Nike", "Running", "Black/White", "/images/shoes/nike-airmax270.jpg", "Air Max 270", 120.99m, 42 },
                    { 2, "Adidas", "Running", "Core Black", "/images/shoes/adidas-ultraboost21.jpg", "Ultraboost 21", 150.50m, 43 },
                    { 3, "Puma", "Casual", "White/Blue", "/images/shoes/puma-rsx.jpg", "RS-X", 95.00m, 41 },
                    { 4, "Converse", "Casual", "Red", "/images/shoes/converse-chucktaylor.jpg", "Chuck Taylor All Star", 60.00m, 44 },
                    { 5, "Clarks", "Formal", "Brown", "/images/shoes/clarks-tilden.jpg", "Tilden Cap", 80.00m, 42 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shoes");
        }
    }
}
