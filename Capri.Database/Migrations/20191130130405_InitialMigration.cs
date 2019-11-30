using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Capri.Database.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NormalizedName = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: true),
                    ProviderKey = table.Column<string>(nullable: true),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false),
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Promoters",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    ExpectedNumberOfBachelorProposals = table.Column<int>(nullable: false),
                    ExpectedNumberOfMasterProposals = table.Column<int>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promoters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Promoters_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Proposals",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Topic = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    Mode = table.Column<int>(nullable: false),
                    PromoterId = table.Column<Guid>(nullable: false),
                    PromoterId1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proposals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proposals_Promoters_PromoterId",
                        column: x => x.PromoterId,
                        principalTable: "Promoters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Proposals_Promoters_PromoterId1",
                        column: x => x.PromoterId1,
                        principalTable: "Promoters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    ProposalId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Proposals_ProposalId",
                        column: x => x.ProposalId,
                        principalTable: "Proposals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Students_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("e65f3879-1f2b-4763-9a25-194d7fb3638a"), "bb5c458c-a750-4ef1-95ae-5a4837a224a3", "admin", "admin" },
                    { new Guid("0cb092a1-5c4f-4b8e-ba25-c3d99f50de9b"), "9ec2dd60-de30-4bd3-bd68-6d113f99f2e4", "dean", "dean" },
                    { new Guid("408bdace-1a83-469d-a4cf-d56a50f049d6"), "0882bd75-046e-4698-9c3c-dc5cfdcfa725", "student", "student" },
                    { new Guid("b56e04d1-53c5-4267-aec6-976bf8b0e634"), "8ba679c3-1cd8-4f66-a6e4-b08fa101f7c9", "promoter", "promoter" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("d265ec44-d0c4-4c0d-a6ae-87ab42768f2c"), new Guid("b56e04d1-53c5-4267-aec6-976bf8b0e634"), new Guid("2c53d2da-3768-474d-96bd-5679e9a0d7e8") },
                    { new Guid("e14e2d2a-9999-46d3-9eb3-752ba1fd6aef"), new Guid("b56e04d1-53c5-4267-aec6-976bf8b0e634"), new Guid("9084eace-f922-4535-8a61-f5a35e4961cf") },
                    { new Guid("a3b30858-0bd8-4a8a-9ae8-a8fdd52ccae9"), new Guid("408bdace-1a83-469d-a4cf-d56a50f049d6"), new Guid("43a425e9-6414-4d98-b680-ce4fede9f2e5") },
                    { new Guid("b87698e9-fe31-4c49-a40d-1d7afa09743d"), new Guid("408bdace-1a83-469d-a4cf-d56a50f049d6"), new Guid("73c8c86a-d56d-4068-959d-513cf9f1c424") },
                    { new Guid("aedab341-6df2-4ab8-8bdf-a9fd8dd9a685"), new Guid("408bdace-1a83-469d-a4cf-d56a50f049d6"), new Guid("2a427475-0cdd-40e4-bfc2-2cbcf7e95285") },
                    { new Guid("b1a3e351-dc57-4813-9d28-8e5e957b276b"), new Guid("408bdace-1a83-469d-a4cf-d56a50f049d6"), new Guid("b8a0fca9-398f-4c49-b49d-2bd39c1b22a6") },
                    { new Guid("5daac56a-c8b1-4977-a234-008740af1161"), new Guid("408bdace-1a83-469d-a4cf-d56a50f049d6"), new Guid("8e68c684-5cc2-4182-a57f-f2d375f23428") },
                    { new Guid("6808798d-4c4b-416f-bb35-5e68d0a9b9d9"), new Guid("408bdace-1a83-469d-a4cf-d56a50f049d6"), new Guid("b8b1bdbe-c702-469c-a879-7dadd1abb0e5") },
                    { new Guid("1d38f2ee-a463-4fd0-83b8-564826a917d9"), new Guid("408bdace-1a83-469d-a4cf-d56a50f049d6"), new Guid("c457081f-c65c-4cf8-a0e3-63d1fbf8e2da") },
                    { new Guid("2ebf76e1-5ba7-412a-9f60-a273147808fb"), new Guid("0cb092a1-5c4f-4b8e-ba25-c3d99f50de9b"), new Guid("2d85d330-f373-42e8-ae7f-c11e308e510b") },
                    { new Guid("f7ec4f3d-9ea2-47b4-b8ee-bfb263eadc81"), new Guid("0cb092a1-5c4f-4b8e-ba25-c3d99f50de9b"), new Guid("f6fbb01f-b930-4760-ab8f-aff9cb84d589") },
                    { new Guid("297439d3-588b-4a4e-b350-11fcb36660b6"), new Guid("e65f3879-1f2b-4763-9a25-194d7fb3638a"), new Guid("90ef2b99-c3a3-486b-8758-4457a6f11b23") },
                    { new Guid("6e360001-132a-4f7c-8409-5d4877607c63"), new Guid("408bdace-1a83-469d-a4cf-d56a50f049d6"), new Guid("b4d0c06e-2733-4dab-81b8-49e2e641c898") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("8e68c684-5cc2-4182-a57f-f2d375f23428"), 0, "7167c6fe-fbd0-4926-9385-dfda0d6ed85f", "student8@gmail.com", true, false, null, "student8@gmail.com", "student8@gmail.com", "AQAAAAEAACcQAAAAEFjuqB9tdUW9yKmUHwZejCxbMU4ILEoQskJPhGvJ5RFuKdcqgJtczySb/hCT0ZAp2g==", null, false, "", false, "student8@gmail.com" },
                    { new Guid("43a425e9-6414-4d98-b680-ce4fede9f2e5"), 0, "670eb05a-6faa-4c3f-84c6-dbc5d4af1ef0", "student7@gmail.com", true, false, null, "student7@gmail.com", "student7@gmail.com", "AQAAAAEAACcQAAAAEFidcwIdwYuvif5wb/IT0cp21XZ+CpytEmwHYLDDRVTP/jfTRhqsfnche36wRvkLLA==", null, false, "", false, "student7@gmail.com" },
                    { new Guid("73c8c86a-d56d-4068-959d-513cf9f1c424"), 0, "d148e1d2-c54d-4c9b-83ff-ef7cc35ec0ee", "student6@gmail.com", true, false, null, "student6@gmail.com", "student6@gmail.com", "AQAAAAEAACcQAAAAEOCCMbuj/OV3kaT1ebh6KUjJSsb3H7h4r7ENpBYqbRR4CRYcdcGL3iPNrRItDy9raw==", null, false, "", false, "student6@gmail.com" },
                    { new Guid("2a427475-0cdd-40e4-bfc2-2cbcf7e95285"), 0, "69e32f1a-b5a8-4b6f-8d5c-9edc3282f29c", "student5@gmail.com", true, false, null, "student5@gmail.com", "student5@gmail.com", "AQAAAAEAACcQAAAAEPlIkR6KQSyheTbxS0Vsj3IcKirP0x3hrIHSPn0qZdQA1ZYGTTeWD0vlvb8TGjCB1Q==", null, false, "", false, "student5@gmail.com" },
                    { new Guid("b8a0fca9-398f-4c49-b49d-2bd39c1b22a6"), 0, "4c260287-51f3-4e06-b90b-0aa34b232e18", "student4@gmail.com", true, false, null, "student4@gmail.com", "student4@gmail.com", "AQAAAAEAACcQAAAAEKINWdGFJs0W8ZpQ++YIc9uUKH7GZsObHkDTck/MbZYUGYUNWWCy3emHgeLNIB29Uw==", null, false, "", false, "student4@gmail.com" },
                    { new Guid("c457081f-c65c-4cf8-a0e3-63d1fbf8e2da"), 0, "7ac6e6ca-1d5e-419e-8336-02dfd55cb0ec", "student1@gmail.com", true, false, null, "student1@gmail.com", "student1@gmail.com", "AQAAAAEAACcQAAAAEPUHoiLVvoivlUZk5At2h+g2jWqLE2TMC3WQkV3Prj04QV/QCNOKyH1d8dim6A6wBg==", null, false, "", false, "student1@gmail.com" },
                    { new Guid("b8b1bdbe-c702-469c-a879-7dadd1abb0e5"), 0, "fb7ad85b-36e4-4d21-a93e-8cf18952252a", "student2@gmail.com", true, false, null, "student2@gmail.com", "student2@gmail.com", "AQAAAAEAACcQAAAAELO9lkGSFeuwIG/nmb6KNZ/qQ6ETHeJ4DE7B9MwXqe+ZlHHGfmGJiSuPfXLR1t10mA==", null, false, "", false, "student2@gmail.com" },
                    { new Guid("2d85d330-f373-42e8-ae7f-c11e308e510b"), 0, "e73a964c-e8c5-4f12-9e5a-a459e468faa8", "dean2@gmail.com", true, false, null, "dean2@gmail.com", "dean2@gmail.com", "AQAAAAEAACcQAAAAEIQ1TbBD9IGAY647XG0pQXPZClFgplfVNNyyRuOO/86KDUZ6Lp0K8FHHWCikW2ZSiA==", null, false, "", false, "dean2@gmail.com" },
                    { new Guid("f6fbb01f-b930-4760-ab8f-aff9cb84d589"), 0, "e3459626-3e50-45fe-ba9d-e32a400c03fa", "dean1@gmail.com", true, false, null, "dean1@gmail.com", "dean1@gmail.com", "AQAAAAEAACcQAAAAEFllNiAdaciszlIIRbzshegxSu8x3VvmIlGxfx/NBbmSMwvDQfqOUDegZwp74wBaFA==", null, false, "", false, "dean1@gmail.com" },
                    { new Guid("90ef2b99-c3a3-486b-8758-4457a6f11b23"), 0, "bdc90121-6b92-4012-84fd-136e9f97bc1b", "admin1@gmail.com", true, false, null, "admin1@gmail.com", "admin1@gmail.com", "AQAAAAEAACcQAAAAEHRuZHPPD2g/pX3zoSbekqHV9HA6dgSUACV5PbD11aKcnPhcRQrbaOuOlfSmuxzPdg==", null, false, "", false, "admin1@gmail.com" },
                    { new Guid("9084eace-f922-4535-8a61-f5a35e4961cf"), 0, "586b8180-a253-4edc-a555-59c05cf41e6e", "promoter1@gmail.com", true, false, null, "promoter1@gmail.com", "promoter1@gmail.com", "AQAAAAEAACcQAAAAECoy6ngFpNf87YsZzwVd7lf2y81+sBUq5fHM7kftUFNOSbxBPrpvinGf4ye1kHJGcA==", null, false, "", false, "promoter1@gmail.com" },
                    { new Guid("b4d0c06e-2733-4dab-81b8-49e2e641c898"), 0, "7bb9fa61-fc3c-4daa-9298-fd3099afbc1e", "student3@gmail.com", true, false, null, "student3@gmail.com", "student3@gmail.com", "AQAAAAEAACcQAAAAEJCrywqCO0ztykDU5/yJvn0PV5hoh0YCC9S8QLBInsEijQJECe63FJYPbsmCT6pt3Q==", null, false, "", false, "student3@gmail.com" },
                    { new Guid("2c53d2da-3768-474d-96bd-5679e9a0d7e8"), 0, "8a323ccc-3bac-470d-a899-d518079fee46", "promoter2@gmail.com", true, false, null, "promoter2@gmail.com", "promoter2@gmail.com", "AQAAAAEAACcQAAAAEBineG1YeSN3b7vncWPRGyCBLi+OgduJVGEF2lNIV62zsJaHkoeNL87Y63ELkeRvGw==", null, false, "", false, "promoter2@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Promoters",
                columns: new[] { "Id", "ExpectedNumberOfBachelorProposals", "ExpectedNumberOfMasterProposals", "FirstName", "LastName", "UserId" },
                values: new object[,]
                {
                    { new Guid("2121dd7d-a183-4bff-9693-1fbf663b7d3f"), 3, 4, "Jan", "Kowalski", new Guid("9084eace-f922-4535-8a61-f5a35e4961cf") },
                    { new Guid("a0f34749-02e6-451d-8439-04d3da7db1a2"), 3, 4, "Jan", "Kowalski", new Guid("2c53d2da-3768-474d-96bd-5679e9a0d7e8") }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ProposalId", "UserId" },
                values: new object[,]
                {
                    { new Guid("d09cb633-a214-46e6-bb31-c95e5eb7bdb0"), null, new Guid("c457081f-c65c-4cf8-a0e3-63d1fbf8e2da") },
                    { new Guid("b3f81ef2-3cf2-46aa-864a-90aba805120a"), null, new Guid("b8b1bdbe-c702-469c-a879-7dadd1abb0e5") },
                    { new Guid("aa3c3d67-1eb2-4408-8b24-1b3573f1d65f"), null, new Guid("b4d0c06e-2733-4dab-81b8-49e2e641c898") },
                    { new Guid("efe953b0-3385-4517-96f4-530623f7e1f1"), null, new Guid("b8a0fca9-398f-4c49-b49d-2bd39c1b22a6") },
                    { new Guid("3e037427-1fb7-4a97-a1bf-bbb4aaa48235"), null, new Guid("2a427475-0cdd-40e4-bfc2-2cbcf7e95285") },
                    { new Guid("7159e7c0-dd04-40be-b742-1a538ad08f0b"), null, new Guid("73c8c86a-d56d-4068-959d-513cf9f1c424") },
                    { new Guid("87a3d54f-bde9-42ac-849f-160fa210a77a"), null, new Guid("43a425e9-6414-4d98-b680-ce4fede9f2e5") },
                    { new Guid("fd962aff-edcc-4af2-82d5-84f823e02865"), null, new Guid("8e68c684-5cc2-4182-a57f-f2d375f23428") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Promoters_UserId",
                table: "Promoters",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Proposals_PromoterId",
                table: "Proposals",
                column: "PromoterId");

            migrationBuilder.CreateIndex(
                name: "IX_Proposals_PromoterId1",
                table: "Proposals",
                column: "PromoterId1");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ProposalId",
                table: "Students",
                column: "ProposalId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserId",
                table: "Students",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Proposals");

            migrationBuilder.DropTable(
                name: "Promoters");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
