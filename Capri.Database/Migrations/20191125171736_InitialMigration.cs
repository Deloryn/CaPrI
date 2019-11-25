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
                    Title = table.Column<int>(nullable: false),
                    CanSubmitBachelorProposals = table.Column<bool>(nullable: false),
                    CanSubmitMasterProposals = table.Column<bool>(nullable: false),
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
                    { new Guid("59a2f9f4-2fb3-4aec-86be-129a34230e4e"), "cf35ea79-503f-4ecd-9c49-e6fde7943605", "admin", "admin" },
                    { new Guid("d440ebf7-a97b-45ec-a9d9-b73ac8ba0142"), "327fa64d-4ec8-46c2-8675-1e2fc001f855", "dean", "dean" },
                    { new Guid("44e64359-97d0-433e-8d10-e30a7bcd1890"), "5f1a05e0-c93d-495c-95da-37ad8651fdba", "student", "student" },
                    { new Guid("1b462bb0-b61a-4682-81e5-3dfffc4f94f8"), "5cf16fa0-b514-480a-9f88-c773dcf52efa", "promoter", "promoter" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("5c2f7569-1d53-4d99-b4ca-b84a2f6278e6"), new Guid("1b462bb0-b61a-4682-81e5-3dfffc4f94f8"), new Guid("915b2342-b6c2-4d68-9e66-1c24fdc9aaca") },
                    { new Guid("05330f1d-d536-49a3-86fd-ff013c301955"), new Guid("1b462bb0-b61a-4682-81e5-3dfffc4f94f8"), new Guid("22914922-6813-412c-8397-4ce4147ba4ff") },
                    { new Guid("eb49ccd1-1ead-42cb-bb32-acc6e1a1b94c"), new Guid("44e64359-97d0-433e-8d10-e30a7bcd1890"), new Guid("a7d8c301-a633-4930-91e8-75d5f9723d04") },
                    { new Guid("911f15c1-ce27-43e8-8dfb-87bee6f2994a"), new Guid("44e64359-97d0-433e-8d10-e30a7bcd1890"), new Guid("680efe41-4808-4011-b753-7ac805713c4f") },
                    { new Guid("f8ceca4c-30f4-4364-8785-b2ec24233b6c"), new Guid("44e64359-97d0-433e-8d10-e30a7bcd1890"), new Guid("6e091079-66f0-4122-b511-4ef2cafd640b") },
                    { new Guid("6d2be9b6-00ee-4605-ad65-a28677f18bd3"), new Guid("44e64359-97d0-433e-8d10-e30a7bcd1890"), new Guid("d874bfda-8a1d-4139-b59b-b99b42f467e7") },
                    { new Guid("e3a97e71-d929-438a-998f-da60ebb94447"), new Guid("44e64359-97d0-433e-8d10-e30a7bcd1890"), new Guid("48377af8-66f8-49f7-8df7-47c80435589b") },
                    { new Guid("0ec55dfd-7269-4842-bcae-7fde3df5edf9"), new Guid("44e64359-97d0-433e-8d10-e30a7bcd1890"), new Guid("e3fe30b5-6e61-40ab-ae1f-9e8bb4781f07") },
                    { new Guid("b529a975-91e0-4034-ad6d-58e2d4afffe7"), new Guid("44e64359-97d0-433e-8d10-e30a7bcd1890"), new Guid("e8ca8f6a-b21a-4e3e-a56c-07aec8b901de") },
                    { new Guid("b77ff6e8-7a67-440a-a561-a5c8a3005422"), new Guid("d440ebf7-a97b-45ec-a9d9-b73ac8ba0142"), new Guid("d6066461-717f-4651-a383-e39d6049c7f3") },
                    { new Guid("c4872588-4747-43e3-810c-ac50507bcc29"), new Guid("d440ebf7-a97b-45ec-a9d9-b73ac8ba0142"), new Guid("eb8c5966-34f0-441a-b3a4-f7e87d286960") },
                    { new Guid("f42fe2ce-922b-464b-bf87-aab2194882b4"), new Guid("59a2f9f4-2fb3-4aec-86be-129a34230e4e"), new Guid("942cf427-96cf-4aba-a61d-66a935ccbed9") },
                    { new Guid("bfaf6824-e2be-4830-b7a6-0a3034026595"), new Guid("44e64359-97d0-433e-8d10-e30a7bcd1890"), new Guid("950a0500-1a2f-4a97-b05b-e9d2d71e43ce") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("48377af8-66f8-49f7-8df7-47c80435589b"), 0, "05e2e09d-de44-46ab-8dd9-128d15a35731", "student8@gmail.com", true, false, null, "student8@gmail.com", "student8@gmail.com", "AQAAAAEAACcQAAAAEO8YuZx/uCkjG6oXO7sfOmqZq+ICtY1ZWpkt4AUPpjWAmf7XKt0pZPo1LeAgrS/INA==", null, false, "", false, "student8@gmail.com" },
                    { new Guid("a7d8c301-a633-4930-91e8-75d5f9723d04"), 0, "6fca0db4-315b-436d-b1eb-d984332c18ed", "student7@gmail.com", true, false, null, "student7@gmail.com", "student7@gmail.com", "AQAAAAEAACcQAAAAEHUOoqA1pWqDYQ4dh+9zbJymeNXf1XIQAMJ5+P22L3evkw2gzvWihYZuS6fSogS8Uw==", null, false, "", false, "student7@gmail.com" },
                    { new Guid("680efe41-4808-4011-b753-7ac805713c4f"), 0, "2b624dac-9aed-4404-9ca1-5f3fbb0dc8b5", "student6@gmail.com", true, false, null, "student6@gmail.com", "student6@gmail.com", "AQAAAAEAACcQAAAAEIDlXpkMgE/ybjt2/jD2cKBP/LI3vgVbJGC9rf+gn/zUp8vhAldbFDrSw++pewoYuA==", null, false, "", false, "student6@gmail.com" },
                    { new Guid("6e091079-66f0-4122-b511-4ef2cafd640b"), 0, "ef007129-bf75-44f2-a2dc-4626be88b39f", "student5@gmail.com", true, false, null, "student5@gmail.com", "student5@gmail.com", "AQAAAAEAACcQAAAAEKwzmOgZOtiL3/gGWkguCBDLz6VasSrXwqwxO9Dn2ORcpaFthaIP+DzHOJrnnhxwQQ==", null, false, "", false, "student5@gmail.com" },
                    { new Guid("d874bfda-8a1d-4139-b59b-b99b42f467e7"), 0, "badb17e9-09d9-4c13-9de0-87cd1970c8d2", "student4@gmail.com", true, false, null, "student4@gmail.com", "student4@gmail.com", "AQAAAAEAACcQAAAAEK8TjKa7edbS6vDZT4goDYlmKARCZSGBEn9RM+cwt+B9k5O+ly4AbWhhhhp5amSPpw==", null, false, "", false, "student4@gmail.com" },
                    { new Guid("e8ca8f6a-b21a-4e3e-a56c-07aec8b901de"), 0, "bffa8adf-c45d-458c-8a17-785a108c8951", "student1@gmail.com", true, false, null, "student1@gmail.com", "student1@gmail.com", "AQAAAAEAACcQAAAAEN+TzNgf0Pg6HrwYUNtOF+QYqgjvSKZfQqZ3rlBfOSYqxxOHEvsh3Uus8eadvGTQDA==", null, false, "", false, "student1@gmail.com" },
                    { new Guid("e3fe30b5-6e61-40ab-ae1f-9e8bb4781f07"), 0, "9ee3f14d-2077-41e8-8417-74b8420fe662", "student2@gmail.com", true, false, null, "student2@gmail.com", "student2@gmail.com", "AQAAAAEAACcQAAAAEKHrYmG7D8ew5yVodBZpPzAT78p8PLCN1BKxpRYHQhO5RZ8GTJNJO2DNbGOH0+9JYA==", null, false, "", false, "student2@gmail.com" },
                    { new Guid("d6066461-717f-4651-a383-e39d6049c7f3"), 0, "43187190-b9db-46f1-a810-12b470578294", "dean2@gmail.com", true, false, null, "dean2@gmail.com", "dean2@gmail.com", "AQAAAAEAACcQAAAAEDNehCkUDsoud2h/+RhGQM21Qm/xAUwclCplef8mCeqZ0qrPmMzAzrnRMFBMkLMdKQ==", null, false, "", false, "dean2@gmail.com" },
                    { new Guid("eb8c5966-34f0-441a-b3a4-f7e87d286960"), 0, "791c7efc-0b7e-4cb2-92ea-0b123cc331a8", "dean1@gmail.com", true, false, null, "dean1@gmail.com", "dean1@gmail.com", "AQAAAAEAACcQAAAAEEBrVc9PprDxX85VdNSWwRVuJLTWcK47Q//JrDex6KMHVZIF95j8q2WH/YtJO2SLxQ==", null, false, "", false, "dean1@gmail.com" },
                    { new Guid("942cf427-96cf-4aba-a61d-66a935ccbed9"), 0, "e813262e-e28e-45e1-893a-30ae673e4cdb", "admin1@gmail.com", true, false, null, "admin1@gmail.com", "admin1@gmail.com", "AQAAAAEAACcQAAAAELdn93MpoyFDwk0ZyQWEfOsC1NKHEcuvTsEWR9EwVQXWKJ6el8vfgPjBCHiNL521WQ==", null, false, "", false, "admin1@gmail.com" },
                    { new Guid("22914922-6813-412c-8397-4ce4147ba4ff"), 0, "03af4a7f-6b07-49d8-ab1e-c0520ed9c63f", "promoter1@gmail.com", true, false, null, "promoter1@gmail.com", "promoter1@gmail.com", "AQAAAAEAACcQAAAAENvyloM14XmN6Lej3XBTZlvdS5WR9ouRn8e7upuI8BfneL9lmbsmlWfQaNVHUHW3Cw==", null, false, "", false, "promoter1@gmail.com" },
                    { new Guid("950a0500-1a2f-4a97-b05b-e9d2d71e43ce"), 0, "b403c94d-9ccd-4a49-ae42-08fdf5b404c0", "student3@gmail.com", true, false, null, "student3@gmail.com", "student3@gmail.com", "AQAAAAEAACcQAAAAECAArZ82YJ2h/dAmb+I4SQktsDeaw7S/glmqeJwgMP0O0AkHUvIy36kzCNxNP57/Qw==", null, false, "", false, "student3@gmail.com" },
                    { new Guid("915b2342-b6c2-4d68-9e66-1c24fdc9aaca"), 0, "560770e6-82ec-4722-b6fd-d297f5aec2e5", "promoter2@gmail.com", true, false, null, "promoter2@gmail.com", "promoter2@gmail.com", "AQAAAAEAACcQAAAAEADHsWeJnl3a+fNpshptVxOey61D+dHn/JTWpIPf2vYmQwMgmj1tCxxZcu8ypUZHKQ==", null, false, "", false, "promoter2@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Promoters",
                columns: new[] { "Id", "CanSubmitBachelorProposals", "CanSubmitMasterProposals", "FirstName", "LastName", "Title", "UserId" },
                values: new object[,]
                {
                    { new Guid("471245f0-df2b-40b9-b370-a3423fabedff"), true, true, "Jan", "Kowalski", 0, new Guid("22914922-6813-412c-8397-4ce4147ba4ff") },
                    { new Guid("61e3b68d-0b71-48d6-b25e-3dd5065fc04c"), true, true, "Jan", "Kowalski", 0, new Guid("915b2342-b6c2-4d68-9e66-1c24fdc9aaca") }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ProposalId", "UserId" },
                values: new object[,]
                {
                    { new Guid("b557aa33-4624-4b3d-a437-af30ba8972a4"), null, new Guid("e8ca8f6a-b21a-4e3e-a56c-07aec8b901de") },
                    { new Guid("8484e6ca-6094-43a1-9a9f-3febfa4a3ccd"), null, new Guid("e3fe30b5-6e61-40ab-ae1f-9e8bb4781f07") },
                    { new Guid("23b91fcf-8ea6-494c-805c-33b1d4072334"), null, new Guid("950a0500-1a2f-4a97-b05b-e9d2d71e43ce") },
                    { new Guid("c9ef75ae-a1fe-488a-a4b4-c82af7c57c82"), null, new Guid("d874bfda-8a1d-4139-b59b-b99b42f467e7") },
                    { new Guid("d4b16902-0b12-48d4-8e9d-5ec44f152834"), null, new Guid("6e091079-66f0-4122-b511-4ef2cafd640b") },
                    { new Guid("522760b8-77e3-4838-99b5-03de9058fa86"), null, new Guid("680efe41-4808-4011-b753-7ac805713c4f") },
                    { new Guid("76850ec5-9f71-4a01-92f2-45a355e1956f"), null, new Guid("a7d8c301-a633-4930-91e8-75d5f9723d04") },
                    { new Guid("de23f28f-c9c7-426f-80a2-4569e9475e2b"), null, new Guid("48377af8-66f8-49f7-8df7-47c80435589b") }
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
