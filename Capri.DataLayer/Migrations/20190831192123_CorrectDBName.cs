using Microsoft.EntityFrameworkCore.Migrations;

namespace Capri.DataLayer.Migrations
{
    public partial class CorrectDBName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 1,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAECQH43qd6xbhBPYawtYycnz86oIuOEONDLUdnNucFchxnDE/N+LqED54q8X1tz5vLw==");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 1,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEGMbDNer35Vct94F53MhibQzZrhrut1VD0/G4w2uAvwZ8eLjI82JtvsOEwNdKHxA2A==");
        }
    }
}
