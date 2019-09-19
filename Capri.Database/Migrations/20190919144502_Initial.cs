using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Capri.Database.Migrations
{
    public partial class Initial : Migration
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
                name: "User",
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
                    table.PrimaryKey("PK_User", x => x.Id);
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
                    CanSubmitBachelorProposals = table.Column<bool>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promoters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Promoters_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
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
                    Type = table.Column<int>(nullable: false),
                    PromoterId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proposals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proposals_Promoters_PromoterId",
                        column: x => x.PromoterId,
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
                        name: "FK_Students_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("63ba5516-ce32-4a60-9f09-ccb8ffeefcc3"), "167e1587-283e-412e-84d5-84fcb0104a95", "admin", "admin" },
                    { new Guid("9d1f9621-5a09-486e-bd86-ada835b97540"), "64a580a2-31a1-4103-abe1-436dc3d7ae1a", "dean", "dean" },
                    { new Guid("8e6c8850-5492-4754-adb7-cf27d2b54118"), "5105ecf1-ae62-4b3c-b46d-017b0bd52488", "student", "student" },
                    { new Guid("441e8f47-4415-48bc-b9ec-373d8aeaadb9"), "99ddfd52-d3d0-4fe1-89dc-8000d658a98c", "promoter", "promoter" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("438207f9-7e92-4575-b18d-7e190b2546e7"), 0, "c4edf95c-3cb8-41c7-961a-e20f14e425d6", "student8@gmail.com", true, false, null, "student8@gmail.com", "student8@gmail.com", "AQAAAAEAACcQAAAAEAOlezAq7KyyLVNQs4skgu2Twnj1YQZerbx+/Eu+S5Fg+Z2/EMZoRK5/rb2flW8a/A==", null, false, "", false, "student8@gmail.com" },
                    { new Guid("77a91bc5-25f6-4fa8-8cc9-f6ceb1a8218c"), 0, "e8cbc61f-bcc5-446e-9571-b41933ba5e83", "student7@gmail.com", true, false, null, "student7@gmail.com", "student7@gmail.com", "AQAAAAEAACcQAAAAEBlnka+nYIfHijAmf3z5hiaLlEeSP8PM2xgObwrjCa96ewao/3g2/hmfMvcltGWejw==", null, false, "", false, "student7@gmail.com" },
                    { new Guid("7affd49b-4170-497f-837e-7a52e72f7166"), 0, "e74c7275-4140-47bd-ab4c-09040933f8d5", "student6@gmail.com", true, false, null, "student6@gmail.com", "student6@gmail.com", "AQAAAAEAACcQAAAAEMPGm8oPPW5Mn2g9c9A0AEZROMys25tNpc7M9/U+4y2tGDguebC1mIWo7Wj/xVnlbg==", null, false, "", false, "student6@gmail.com" },
                    { new Guid("11b74f9d-1545-49fc-b901-a001c4819958"), 0, "8e8a76b1-b2b5-4975-a22c-ffb5cf8c4e22", "student5@gmail.com", true, false, null, "student5@gmail.com", "student5@gmail.com", "AQAAAAEAACcQAAAAENSGEz3OToTJbck+c+By+gmDAtUrpW/V4Q5dr1qSybHdKAQvuoKq5YdXPqhlIZASsQ==", null, false, "", false, "student5@gmail.com" },
                    { new Guid("bb5effe8-b3d8-46ea-886d-27ef819a2d8f"), 0, "317ec841-7994-48ae-a8d9-0114600f1c04", "student4@gmail.com", true, false, null, "student4@gmail.com", "student4@gmail.com", "AQAAAAEAACcQAAAAEP3Fn4OnQ2vZ8GazaZ5ODti+IPQMSCRxqS2q/RRIc+pnGTJgYvbxr2P6CglueRdNxw==", null, false, "", false, "student4@gmail.com" },
                    { new Guid("644958e8-8909-4848-a681-260007bc3c08"), 0, "0ac8e323-99a2-45e3-b35c-1232b3f7445b", "student3@gmail.com", true, false, null, "student3@gmail.com", "student3@gmail.com", "AQAAAAEAACcQAAAAENXBBNx8niqyDM+Qy2ikP0pohZ2izPgNGg7UPRhXQ+QQixvtSdQDmuiYm4x/qVJu8A==", null, false, "", false, "student3@gmail.com" },
                    { new Guid("16566408-d710-4451-b234-1d1373f4be89"), 0, "23eaa483-3fdd-44f3-b37e-4b67c0cf6bf2", "student2@gmail.com", true, false, null, "student2@gmail.com", "student2@gmail.com", "AQAAAAEAACcQAAAAEPXctEzZcW9qpB64b7NcDfROw4ZyxazWtznH4nkEUIXoHAodJ2r+NDGQbbkJ0qI2VQ==", null, false, "", false, "student2@gmail.com" },
                    { new Guid("1ee9ebd4-483b-4403-9fca-d9558ac669c3"), 0, "5f4ff327-4330-4523-8ec6-a10d49dc6c4b", "student1@gmail.com", true, false, null, "student1@gmail.com", "student1@gmail.com", "AQAAAAEAACcQAAAAEPaodSOw1SfJ7sfWt//Lbhli0qwSU577dybX10cn3/2Gg71WFUlNRaREkNM+NhyQxg==", null, false, "", false, "student1@gmail.com" },
                    { new Guid("1a2363fe-86ad-4ad7-9903-35ba802afef3"), 0, "99c7f683-4887-4e76-a5dd-5ad3c381a980", "dean2@gmail.com", true, false, null, "dean2@gmail.com", "dean2@gmail.com", "AQAAAAEAACcQAAAAEEAOGhTH+L9gSSVUFT7DdXooN+EvdBkIDaBi+gdnFnuqBOw464jzog/dxq2LscUmqg==", null, false, "", false, "dean2@gmail.com" },
                    { new Guid("f3400473-7ddd-4815-a765-4240fbf38a92"), 0, "e82f0074-a888-4e80-a821-74fcba5b2b22", "dean1@gmail.com", true, false, null, "dean1@gmail.com", "dean1@gmail.com", "AQAAAAEAACcQAAAAEMHyAWibcosURXqCd2cqd6bNIACZvsNgNn3sCGXrSLb4Qf1ac7RtBnOS5uVPgPfYGg==", null, false, "", false, "dean1@gmail.com" },
                    { new Guid("e6a82f22-11f8-4b0c-9ab5-7cbfe38e7d04"), 0, "5cafd65d-7593-4614-82b8-3f53bb9e0d5e", "admin1@gmail.com", true, false, null, "admin1@gmail.com", "admin1@gmail.com", "AQAAAAEAACcQAAAAEEDmT5OuGpxhWnoox3av6+eHiV1b5S9GaLp5V+OogvJPNIXlzhBeDHdw2FCp13bBxA==", null, false, "", false, "admin1@gmail.com" },
                    { new Guid("62688498-9e57-4d46-be80-2772f27a6b2e"), 0, "65717c1d-53cd-4ce3-9d5f-801ce369931e", "promoter2@gmail.com", true, false, null, "promoter2@gmail.com", "promoter2@gmail.com", "AQAAAAEAACcQAAAAEHh3Gokjbx7umrKcF6aE11/Al1JmGjHhrNLjr1vvSYgIIt7H62W4tq82NtgxViBM9Q==", null, false, "", false, "promoter2@gmail.com" },
                    { new Guid("8447358b-d1d6-40bc-bc60-6fd54f361a26"), 0, "0f27959f-6e07-42a0-93a8-8c875fd1e32b", "promoter1@gmail.com", true, false, null, "promoter1@gmail.com", "promoter1@gmail.com", "AQAAAAEAACcQAAAAEBtcpX17ENc5pZ1aYXuYgXrCw75SqRgks5ki6Z8AffslmvqDM+mm7rQlmbe07bMKMw==", null, false, "", false, "promoter1@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("6e552efc-c2c4-4f52-a3dc-92a548860000"), new Guid("441e8f47-4415-48bc-b9ec-373d8aeaadb9"), new Guid("62688498-9e57-4d46-be80-2772f27a6b2e") },
                    { new Guid("d45b3b32-4b50-4381-ade0-314bb7a51719"), new Guid("8e6c8850-5492-4754-adb7-cf27d2b54118"), new Guid("77a91bc5-25f6-4fa8-8cc9-f6ceb1a8218c") },
                    { new Guid("70663607-9186-4f5b-a93b-6c5802db0dde"), new Guid("8e6c8850-5492-4754-adb7-cf27d2b54118"), new Guid("7affd49b-4170-497f-837e-7a52e72f7166") },
                    { new Guid("2850c1b8-9c0d-4b4f-be0b-3ee9c05a9fef"), new Guid("8e6c8850-5492-4754-adb7-cf27d2b54118"), new Guid("11b74f9d-1545-49fc-b901-a001c4819958") },
                    { new Guid("f97a4a84-fde1-41e2-aaf6-2fe138c15077"), new Guid("8e6c8850-5492-4754-adb7-cf27d2b54118"), new Guid("bb5effe8-b3d8-46ea-886d-27ef819a2d8f") },
                    { new Guid("14e50931-c524-4b93-af0d-fb99d8131c6f"), new Guid("8e6c8850-5492-4754-adb7-cf27d2b54118"), new Guid("644958e8-8909-4848-a681-260007bc3c08") },
                    { new Guid("850ba913-7fc7-4470-857a-536d6bb7fa74"), new Guid("8e6c8850-5492-4754-adb7-cf27d2b54118"), new Guid("16566408-d710-4451-b234-1d1373f4be89") },
                    { new Guid("d838e11f-50e0-4889-91c3-cf52266e55c9"), new Guid("8e6c8850-5492-4754-adb7-cf27d2b54118"), new Guid("1ee9ebd4-483b-4403-9fca-d9558ac669c3") },
                    { new Guid("92260bd3-0b75-4d38-96b9-754160761c5d"), new Guid("9d1f9621-5a09-486e-bd86-ada835b97540"), new Guid("1a2363fe-86ad-4ad7-9903-35ba802afef3") },
                    { new Guid("cffdbbaf-0aae-41a4-9fd7-b051e521df15"), new Guid("9d1f9621-5a09-486e-bd86-ada835b97540"), new Guid("f3400473-7ddd-4815-a765-4240fbf38a92") },
                    { new Guid("e9a1c4fb-25d0-467f-b443-1ddf47f61957"), new Guid("63ba5516-ce32-4a60-9f09-ccb8ffeefcc3"), new Guid("e6a82f22-11f8-4b0c-9ab5-7cbfe38e7d04") },
                    { new Guid("dfa12f77-a4cb-4cee-bcd1-c2c97c642f48"), new Guid("441e8f47-4415-48bc-b9ec-373d8aeaadb9"), new Guid("8447358b-d1d6-40bc-bc60-6fd54f361a26") },
                    { new Guid("bfe4023b-86c1-4433-8fb8-36a99c112f9d"), new Guid("8e6c8850-5492-4754-adb7-cf27d2b54118"), new Guid("438207f9-7e92-4575-b18d-7e190b2546e7") }
                });

            migrationBuilder.InsertData(
                table: "Promoters",
                columns: new[] { "Id", "CanSubmitBachelorProposals", "UserId" },
                values: new object[,]
                {
                    { new Guid("4d7721f7-1ebe-4107-b924-441791a700bc"), true, new Guid("8447358b-d1d6-40bc-bc60-6fd54f361a26") },
                    { new Guid("b618eee2-f098-4b87-9a74-78d74ead2fdc"), true, new Guid("62688498-9e57-4d46-be80-2772f27a6b2e") }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ProposalId", "UserId" },
                values: new object[,]
                {
                    { new Guid("5544ea0e-9136-4cdd-9eca-f84c0311d022"), null, new Guid("1ee9ebd4-483b-4403-9fca-d9558ac669c3") },
                    { new Guid("e71e783c-225c-44aa-92dc-95c281e931b5"), null, new Guid("16566408-d710-4451-b234-1d1373f4be89") },
                    { new Guid("ae23e217-7e06-4017-896b-78b156c48352"), null, new Guid("644958e8-8909-4848-a681-260007bc3c08") },
                    { new Guid("49895d97-953f-4c84-b532-5b25dcee8b7b"), null, new Guid("bb5effe8-b3d8-46ea-886d-27ef819a2d8f") },
                    { new Guid("be612387-0a47-40b0-86bd-cbf7d5e4102b"), null, new Guid("11b74f9d-1545-49fc-b901-a001c4819958") },
                    { new Guid("6c64bf5b-fd96-4086-8d91-fd383b764580"), null, new Guid("7affd49b-4170-497f-837e-7a52e72f7166") },
                    { new Guid("76c1cde6-f096-4cc6-b522-96570ec4586f"), null, new Guid("77a91bc5-25f6-4fa8-8cc9-f6ceb1a8218c") },
                    { new Guid("fdcfc8aa-3166-4e2a-8086-ad355845a4e3"), null, new Guid("438207f9-7e92-4575-b18d-7e190b2546e7") }
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
                name: "User");
        }
    }
}
