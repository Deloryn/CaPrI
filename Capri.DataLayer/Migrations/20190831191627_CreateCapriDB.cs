using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Capri.DataLayer.Migrations
{
    public partial class CreateCapriDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: false),
                    Token = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    CanSubmitBachelorProposals = table.Column<bool>(nullable: true),
                    ProposalID = table.Column<int>(nullable: true),
                    ProposalID1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Proposals",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Topic = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    PromoterID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proposals", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Proposals_Users_PromoterID",
                        column: x => x.PromoterID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Discriminator", "Email", "Name", "PasswordHash", "Token", "CanSubmitBachelorProposals" },
                values: new object[] { 1, "Promoter", "john.smith@gmail.com", "John Smith", "AQAAAAEAACcQAAAAEGMbDNer35Vct94F53MhibQzZrhrut1VD0/G4w2uAvwZ8eLjI82JtvsOEwNdKHxA2A==", null, true });

            migrationBuilder.CreateIndex(
                name: "IX_Proposals_PromoterID",
                table: "Proposals",
                column: "PromoterID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ProposalID",
                table: "Users",
                column: "ProposalID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ProposalID1",
                table: "Users",
                column: "ProposalID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Proposals_ProposalID",
                table: "Users",
                column: "ProposalID",
                principalTable: "Proposals",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Proposals_ProposalID1",
                table: "Users",
                column: "ProposalID1",
                principalTable: "Proposals",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proposals_Users_PromoterID",
                table: "Proposals");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Proposals");
        }
    }
}
