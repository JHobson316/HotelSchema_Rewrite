using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelSchemaRewrite.Migrations
{
    /// <inheritdoc />
    public partial class NewHotelRoom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "HotelRooms",
                columns: new[] { "ID", "HotelID", "PetFriendly", "Rate", "RoomNumber" },
                values: new object[] { 626, 2, false, 59.99m, 205 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HotelRooms",
                keyColumn: "ID",
                keyValue: 626);
        }
    }
}
