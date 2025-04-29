using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactListAPI.Migrations
{
    /// <inheritdoc />
    public partial class Cleanup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9999);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "HashedPassword", "Name", "Salt" },
                values: new object[] { 9999, "admin@admin.pl", new byte[] { 67, 99, 90, 42, 153, 53, 173, 63, 180, 204, 49, 109, 213, 156, 46, 155, 200, 166, 39, 71, 223, 237, 18, 223, 71, 221, 172, 25, 65, 186, 17, 125 }, "Admin", new byte[] { 200, 99, 208, 214, 126, 253, 48, 161, 57, 56, 155, 232, 211, 189, 182, 77, 66, 16, 19, 64, 24, 122, 141, 84, 142, 240, 4, 150, 190, 150, 209, 38, 45, 19, 147, 40, 22, 253, 243, 150, 53, 121, 12, 154, 168, 20, 125, 39, 175, 174, 86, 71, 215, 23, 219, 26, 28, 229, 117, 69, 92, 162, 136, 122 } });
        }
    }
}
