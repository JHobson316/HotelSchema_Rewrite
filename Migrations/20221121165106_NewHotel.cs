using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelSchemaRewrite.Migrations
{
    /// <inheritdoc />
    public partial class NewHotel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "ID", "City", "Country", "Name", "Phone", "State", "streetAddress" },
                values: new object[] { 2, "San Francisco", "USA", "Arcadian Suites", "675-555-2603", "CA", "2648 Plusolder Lane" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "ID",
                keyValue: 2);
        }
    }
}
