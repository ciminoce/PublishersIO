using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PublisherIO.Data.Migrations
{
    /// <inheritdoc />
    public partial class AgregarLibrosEnTablaBooks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "AuthorId", "Price", "PublishDate", "Title" },
                values: new object[,]
                {
                    { 1, 1, 15m, new DateOnly(1972, 5, 27), "I, Robot" },
                    { 2, 5, 10m, new DateOnly(1960, 10, 1), "The Tombs Of Atuan" },
                    { 3, 5, 10m, new DateOnly(1980, 12, 25), "A Whizard Of Earthsea" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 3);
        }
    }
}
