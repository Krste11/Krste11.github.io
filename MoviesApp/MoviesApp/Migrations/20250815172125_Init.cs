using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MoviesApp.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Genre", "Title", "Year" },
                values: new object[,]
                {
                    { 1, "A skilled thief is offered a chance to have his past crimes forgiven if he can implant an idea into a target's subconscious.", "Science Fiction", "Inception", new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Two imprisoned men form a deep bond over years, finding solace and eventual redemption through acts of decency.", "Drama", "The Shawshank Redemption", new DateTime(1994, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Batman faces his greatest psychological and physical tests when he goes up against the Joker.", "Drama", "The Dark Knight", new DateTime(2008, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "A team of explorers travels through a wormhole in space in an attempt to ensure humanity's survival.", "Adventure", "Interstellar", new DateTime(2014, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Greed and class discrimination threaten the newly formed symbiotic relationship between a wealthy family and a destitute clan.", "Thriller", "Parasite", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
