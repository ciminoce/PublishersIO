using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PublisherIO.Data.Migrations
{
    /// <inheritdoc />
    public partial class AgregarRegistroEnTablaAuthors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "FirstName", "LastName" },
                values: new object[] { 1, "Isaac", "Asimov" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 1);
        }
    }
}
