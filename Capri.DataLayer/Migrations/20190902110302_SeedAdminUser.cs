using Microsoft.EntityFrameworkCore.Migrations;

namespace Capri.DataLayer.Migrations
{
    public partial class SeedAdminUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 1,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEC87thx7Ap3bha2GAZESLYFJg2rmuVIBXJcR+UiQPkguNggRCJiCYb5MLccfR5x6zQ==");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Discriminator", "Email", "Name", "PasswordHash", "Token" },
                values: new object[] { 2, "DeanEmployee", "admin@gmail.com", "Admin", "AQAAAAEAACcQAAAAEFEi3ENOvfrddNbHhAukGm/C6Zcp4Bv0ucVcrldi1IQT+AHV1bwa+aScbwjxk7GZUg==", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 1,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAECQH43qd6xbhBPYawtYycnz86oIuOEONDLUdnNucFchxnDE/N+LqED54q8X1tz5vLw==");
        }
    }
}
