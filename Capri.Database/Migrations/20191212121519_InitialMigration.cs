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
                    PromoterId = table.Column<Guid>(nullable: false)
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
                    { new Guid("d365e494-ece6-4800-a465-3e08e5e28804"), "ae4f1d2d-ae4a-4ba4-baa0-5fb4ce306f8a", "admin", "admin" },
                    { new Guid("d077fd49-f515-4546-8f48-af21b4994064"), "7d5811cf-5777-4ba7-a1fa-6df61801d887", "dean", "dean" },
                    { new Guid("e5a38120-5ef8-4909-98cd-7809bb50f0cc"), "1cefb333-7913-4af7-9d66-7268900a40c2", "student", "student" },
                    { new Guid("fe4e4f38-27c2-424d-8d3f-5b389d1aba3a"), "f4149815-a7ee-4470-bc06-d5c82e4e89c4", "promoter", "promoter" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("62a63d15-c5d6-4b76-a395-5e9d187c8c8c"), new Guid("fe4e4f38-27c2-424d-8d3f-5b389d1aba3a"), new Guid("df037dae-d01e-4c2f-9942-a1790ccbbf52") },
                    { new Guid("9d33cf0c-a581-4306-a8a9-5c75c267b666"), new Guid("fe4e4f38-27c2-424d-8d3f-5b389d1aba3a"), new Guid("3d2d4472-d245-461a-89d8-07de0fdc676d") },
                    { new Guid("4b37d2b6-ed42-44d9-ad11-fe4d9d4b5799"), new Guid("e5a38120-5ef8-4909-98cd-7809bb50f0cc"), new Guid("bf63b4fc-59b2-4d94-ae15-d6d4ac46a8e3") },
                    { new Guid("d0852eee-87b3-4bd6-b0da-fa624d9dabb5"), new Guid("e5a38120-5ef8-4909-98cd-7809bb50f0cc"), new Guid("4a8e4fa6-1dde-4c71-ae9f-05f8ea16b9fb") },
                    { new Guid("c4d33a3d-be94-435e-b8c9-7ba882de1f80"), new Guid("e5a38120-5ef8-4909-98cd-7809bb50f0cc"), new Guid("0422a146-1a1c-4261-8c8b-0fe88dc969f1") },
                    { new Guid("3d865404-8415-44ba-9a57-6c8dc2464cba"), new Guid("e5a38120-5ef8-4909-98cd-7809bb50f0cc"), new Guid("1d819e4a-462e-43f2-bbce-f926183c3515") },
                    { new Guid("22ac1cee-2bab-4d19-8706-f43a4e801988"), new Guid("e5a38120-5ef8-4909-98cd-7809bb50f0cc"), new Guid("289340a0-0676-4389-865d-2fd7509edd36") },
                    { new Guid("db0d915b-3446-47f9-b2bc-cc3910f6d36a"), new Guid("e5a38120-5ef8-4909-98cd-7809bb50f0cc"), new Guid("776909ab-347d-4d47-a7f7-0fdd85635ad4") },
                    { new Guid("6888a8d3-fe6e-48f3-b8a2-eecd8286cb9d"), new Guid("e5a38120-5ef8-4909-98cd-7809bb50f0cc"), new Guid("efdd998c-f24e-4835-aa9c-776c5b2206e7") },
                    { new Guid("151b6bfd-3617-47e0-99b1-c1d18357d383"), new Guid("d077fd49-f515-4546-8f48-af21b4994064"), new Guid("c278c323-0483-48a6-acd2-d7efc9703efc") },
                    { new Guid("8b200460-8330-4f3e-bf65-f2d8afa5919c"), new Guid("d077fd49-f515-4546-8f48-af21b4994064"), new Guid("194a6db4-0889-4b19-b6ab-3e751a882fd8") },
                    { new Guid("acba1c26-b762-4147-97c5-e63508cff76c"), new Guid("d365e494-ece6-4800-a465-3e08e5e28804"), new Guid("9b9fc161-6826-41da-a853-9dabac54c874") },
                    { new Guid("43df8603-05e4-45f3-b3e5-d99026f56218"), new Guid("e5a38120-5ef8-4909-98cd-7809bb50f0cc"), new Guid("00e20a92-7fb9-42a4-8e60-5f60b775083f") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("289340a0-0676-4389-865d-2fd7509edd36"), 0, "19b60ae1-8e59-4006-b69d-b7a214c40573", "student8@gmail.com", true, false, null, "student8@gmail.com", "student8@gmail.com", "AQAAAAEAACcQAAAAEKDZnSW0NiawUp7Fc3ZXPkqjV0OQtm7vPqoCGxj8b7NVMu0XQgy6VYQsR0mvagTnRg==", null, false, "", false, "student8@gmail.com" },
                    { new Guid("bf63b4fc-59b2-4d94-ae15-d6d4ac46a8e3"), 0, "3383e2fe-fd58-497d-b390-9697094cffb8", "student7@gmail.com", true, false, null, "student7@gmail.com", "student7@gmail.com", "AQAAAAEAACcQAAAAEBUvKMu9JhJGvByo+0vBDTi+fcojWeg/lxt1S82kk+CC9nXTY4KnGz4vfqS3x3o4Vg==", null, false, "", false, "student7@gmail.com" },
                    { new Guid("4a8e4fa6-1dde-4c71-ae9f-05f8ea16b9fb"), 0, "3ddbfca2-dff8-44a8-af0b-dedd9a11bd6e", "student6@gmail.com", true, false, null, "student6@gmail.com", "student6@gmail.com", "AQAAAAEAACcQAAAAEDCMWzPOTh2MT35amDqRB4npFkK4UQWmw0xmbA0C17zlCkWg2XTcFLmDsWyRDrY3IQ==", null, false, "", false, "student6@gmail.com" },
                    { new Guid("0422a146-1a1c-4261-8c8b-0fe88dc969f1"), 0, "a25a1c49-7731-4788-b378-5d5784716ebe", "student5@gmail.com", true, false, null, "student5@gmail.com", "student5@gmail.com", "AQAAAAEAACcQAAAAEODDbfpqhRXzVkDa7BRqgeWOQZrWPT51xfnCBtIrXt1m2mMJS7PTygrqOjOosppy+A==", null, false, "", false, "student5@gmail.com" },
                    { new Guid("1d819e4a-462e-43f2-bbce-f926183c3515"), 0, "6726f920-b441-41cb-8080-ecb2e10fab02", "student4@gmail.com", true, false, null, "student4@gmail.com", "student4@gmail.com", "AQAAAAEAACcQAAAAEKHE7j+7ipCJLL2xbsqEXeCab/zat+ooXhsXJCCM+FzlPRfI9Q5kBparwJuVcqQ/1A==", null, false, "", false, "student4@gmail.com" },
                    { new Guid("efdd998c-f24e-4835-aa9c-776c5b2206e7"), 0, "bc8b6333-fa92-4136-81eb-ababb70565ed", "student1@gmail.com", true, false, null, "student1@gmail.com", "student1@gmail.com", "AQAAAAEAACcQAAAAENuImskLziCMTzVb9Gt0HE2c8Y1stR6O18D/rWI2EwfEjg39MOJBjafawKeMQgRFoA==", null, false, "", false, "student1@gmail.com" },
                    { new Guid("776909ab-347d-4d47-a7f7-0fdd85635ad4"), 0, "08e6ab46-55e3-4b22-9560-d7c5d7fe54d9", "student2@gmail.com", true, false, null, "student2@gmail.com", "student2@gmail.com", "AQAAAAEAACcQAAAAEHzGUTq4hZFC8alMzES3SEX2t9MpZp/RvFXSjBSW0HEqpkB2ZKeDICSGzW0w8tqgpg==", null, false, "", false, "student2@gmail.com" },
                    { new Guid("c278c323-0483-48a6-acd2-d7efc9703efc"), 0, "f0600daf-17a2-4b06-bd03-ce46c0d62164", "dean2@gmail.com", true, false, null, "dean2@gmail.com", "dean2@gmail.com", "AQAAAAEAACcQAAAAEBIlFKXuBmjlQ3idWwPgcFFmdljoWMwzgElCkTNIl1YpiOwis/KsPAssypAiNYtl8Q==", null, false, "", false, "dean2@gmail.com" },
                    { new Guid("194a6db4-0889-4b19-b6ab-3e751a882fd8"), 0, "67687291-c706-4cdb-a892-ea5ce0c9b65b", "dean1@gmail.com", true, false, null, "dean1@gmail.com", "dean1@gmail.com", "AQAAAAEAACcQAAAAEKc9ZnN6uvOqRMn/IYVMuZvfMmZGgAq8Rm4ItSF2eW/rrvLIO1u2wCtPrz8XjA8Q6Q==", null, false, "", false, "dean1@gmail.com" },
                    { new Guid("9b9fc161-6826-41da-a853-9dabac54c874"), 0, "8e66cc28-4ba9-4c93-9971-219228271b77", "admin1@gmail.com", true, false, null, "admin1@gmail.com", "admin1@gmail.com", "AQAAAAEAACcQAAAAEEG62dIYLBfZ7xu6XDAwpoY6KTplgFL/HgUw5mojgfhwTmnUrV8OFODLIXjkK5JDGw==", null, false, "", false, "admin1@gmail.com" },
                    { new Guid("3d2d4472-d245-461a-89d8-07de0fdc676d"), 0, "693cc644-361b-46cf-9d89-0c8ddf71adb0", "promoter1@gmail.com", true, false, null, "promoter1@gmail.com", "promoter1@gmail.com", "AQAAAAEAACcQAAAAEPux4qFLYsWD2AK8J77dw/BmaWbVJ/S7BQAbTAHXVdlRxGQOUoCllxLun+RlTtjXow==", null, false, "", false, "promoter1@gmail.com" },
                    { new Guid("00e20a92-7fb9-42a4-8e60-5f60b775083f"), 0, "109ceaab-bc04-4027-8387-ead23e956e3b", "student3@gmail.com", true, false, null, "student3@gmail.com", "student3@gmail.com", "AQAAAAEAACcQAAAAEPDako1kL4Z37dW96ifhpIFQ/RrCroIxuZ0PEBP0g1kFAR4jHfduHI61G/F8F/PRoQ==", null, false, "", false, "student3@gmail.com" },
                    { new Guid("df037dae-d01e-4c2f-9942-a1790ccbbf52"), 0, "67f88592-e4f5-4f7c-9030-6963acfc1b6a", "promoter2@gmail.com", true, false, null, "promoter2@gmail.com", "promoter2@gmail.com", "AQAAAAEAACcQAAAAEBHbu5QUSaLVSG6ZafyF59ZSCq5Yo3mSn99LnjuyCaq7t7XJ8FD4862FbukXXRuTFg==", null, false, "", false, "promoter2@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Promoters",
                columns: new[] { "Id", "ExpectedNumberOfBachelorProposals", "ExpectedNumberOfMasterProposals", "FirstName", "LastName", "UserId" },
                values: new object[,]
                {
                    { new Guid("7ce9b5c1-290b-4f2d-8005-1bd98645e00d"), 3, 4, "Jan", "Kowalski", new Guid("3d2d4472-d245-461a-89d8-07de0fdc676d") },
                    { new Guid("510ffa86-84e2-4173-94c8-4b0bbf34e326"), 3, 4, "Jan", "Kowalski", new Guid("df037dae-d01e-4c2f-9942-a1790ccbbf52") }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ProposalId", "UserId" },
                values: new object[,]
                {
                    { new Guid("8b0d8a7c-8233-42e1-879b-acf5ea4bc78c"), null, new Guid("efdd998c-f24e-4835-aa9c-776c5b2206e7") },
                    { new Guid("5354aa06-1f90-4630-b3d2-8d92186c412c"), null, new Guid("776909ab-347d-4d47-a7f7-0fdd85635ad4") },
                    { new Guid("b2341b28-f647-412c-99e0-5ff0db037a65"), null, new Guid("00e20a92-7fb9-42a4-8e60-5f60b775083f") },
                    { new Guid("2c2831db-f3cd-4d21-8ba2-a05e2449d959"), null, new Guid("1d819e4a-462e-43f2-bbce-f926183c3515") },
                    { new Guid("1793c485-c38a-41f6-8131-a352d6b62265"), null, new Guid("0422a146-1a1c-4261-8c8b-0fe88dc969f1") },
                    { new Guid("ade7ff39-183a-4513-bd42-7aa7b7e856ab"), null, new Guid("4a8e4fa6-1dde-4c71-ae9f-05f8ea16b9fb") },
                    { new Guid("8d9ec519-77f9-4942-b5de-4350acdb1b6b"), null, new Guid("bf63b4fc-59b2-4d94-ae15-d6d4ac46a8e3") },
                    { new Guid("87cad4a9-a374-4719-a0af-d8b7faabd364"), null, new Guid("289340a0-0676-4389-865d-2fd7509edd36") }
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
