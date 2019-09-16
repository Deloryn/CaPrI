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
                    { new Guid("3320f3b2-d22e-4d18-bdc1-8bf8411be231"), "75f0eb09-31c3-41ed-915b-24b33453ca17", "admin", "admin" },
                    { new Guid("2af475c9-03ce-4a1c-bd55-86bf18ece3f6"), "fb7cf5d3-5060-46da-8e25-186543972c9a", "dean", "dean" },
                    { new Guid("a94721dc-5df1-464f-aa30-0cd6c3b2bded"), "7f227860-a7e0-4929-951b-6a9b1ee04c03", "student", "student" },
                    { new Guid("03fd825e-aa55-4d3d-8583-fbce5b83ac18"), "aa049462-d709-40a4-9704-279e3ca89f0e", "promoter", "promoter" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("25b33791-0989-4356-a3c0-62c065de2d6b"), 0, "5a3b7b73-8ec6-4a84-8fce-6759abd17bc3", "student8@gmail.com", true, false, null, "student8@gmail.com", "student8@gmail.com", "AQAAAAEAACcQAAAAEJ92KLnIEwT8JYDYf1XQVFH6//fwSk57h1toKzh28Y9p7CIeapBf24D/O4wM0Qvk2w==", null, false, "", false, "student8@gmail.com" },
                    { new Guid("65a4a37d-c825-4c3a-8dac-0c7be338dd69"), 0, "edf6b308-784b-4e3b-a9bd-9e10eaf17134", "student7@gmail.com", true, false, null, "student7@gmail.com", "student7@gmail.com", "AQAAAAEAACcQAAAAEAQb/8sz9Vs8Sov6RohY9Dqg4YIi83DuhnOd1Sh5s3At/3PZT8pHj8CF8gmM9Zze6w==", null, false, "", false, "student7@gmail.com" },
                    { new Guid("365bd06d-a898-4355-9434-771f1e6ac147"), 0, "f27afaa5-0840-473d-b0b8-ece9a6c0adfd", "student6@gmail.com", true, false, null, "student6@gmail.com", "student6@gmail.com", "AQAAAAEAACcQAAAAEMk9dNvmdBzqg4L3ZB+FTlGl01aV5pzFiWCPzWwvcc7GCbqddR5ycfBTG6NNaN640g==", null, false, "", false, "student6@gmail.com" },
                    { new Guid("8c06eedc-20df-4a7b-a2bb-0f9f07d5cf6a"), 0, "ae248118-f20a-4ff3-b6f8-a4b16eee0fba", "student5@gmail.com", true, false, null, "student5@gmail.com", "student5@gmail.com", "AQAAAAEAACcQAAAAEP7amYjrr56jH9IParZzXf/qEgax7F9GkyGIX+5B1OR7wsW0PKCem32aMdJz/2l3Eg==", null, false, "", false, "student5@gmail.com" },
                    { new Guid("08fcb9cf-f01c-4f86-a771-1656ee2111db"), 0, "bc552325-20e5-4eb3-9540-d2d43d2d91c0", "student4@gmail.com", true, false, null, "student4@gmail.com", "student4@gmail.com", "AQAAAAEAACcQAAAAEASzaHmiIQfsh+fExi8NFH14FDW+fZNOGPiB2CZ0CnVdztJptj2kREKIOJTfxLQK+Q==", null, false, "", false, "student4@gmail.com" },
                    { new Guid("af40789e-e3ec-4567-96f1-4926f084d8d3"), 0, "d94f4a95-8861-4507-be50-274e959ba548", "student3@gmail.com", true, false, null, "student3@gmail.com", "student3@gmail.com", "AQAAAAEAACcQAAAAEFIxRWG6c2mEYk0brexKie2ConpbLUvbWBEixjom90gasw99MLeJOxE0iwx9/JUVsQ==", null, false, "", false, "student3@gmail.com" },
                    { new Guid("55484603-706d-4b4e-986c-5b328442e235"), 0, "f9f6cd2f-acc0-4589-9393-f4ab46dbf965", "student2@gmail.com", true, false, null, "student2@gmail.com", "student2@gmail.com", "AQAAAAEAACcQAAAAEGMj0aSuCcqIzl+HixTKPv0VBBOE6crSfAq+U9/+yOHuL2eGoVxlXotINY3eLoesJA==", null, false, "", false, "student2@gmail.com" },
                    { new Guid("682012ab-eb2b-4859-9dee-9f96c2d6cfe8"), 0, "0103d511-0ca4-47fd-ac36-df505da9df94", "student1@gmail.com", true, false, null, "student1@gmail.com", "student1@gmail.com", "AQAAAAEAACcQAAAAEO5a3b9XP89PhfSkRlzkT+rkoKUfD+S+ryBdTiIidyECAckp2Qty5tNesYirbRo/og==", null, false, "", false, "student1@gmail.com" },
                    { new Guid("ec46f545-78f6-468f-b2b7-a178ecc58f52"), 0, "5819d2c5-9d55-4c27-80ef-8db2e20824c3", "dean2@gmail.com", true, false, null, "dean2@gmail.com", "dean2@gmail.com", "AQAAAAEAACcQAAAAEHpjUW/QyhOZ/XTIgTMEbYm5BPyKDSNtB/ntd33hb/iEDO6ZF7ONEfCWuemPJTJkCw==", null, false, "", false, "dean2@gmail.com" },
                    { new Guid("07f15bd8-ddf3-47ed-b0c8-d852bb26ec26"), 0, "f9ef3a94-fa42-4d69-ad27-c0dd83e2a991", "dean1@gmail.com", true, false, null, "dean1@gmail.com", "dean1@gmail.com", "AQAAAAEAACcQAAAAEIzdDOSzv9UC676nVwzzdAy2zAYqsfM30Yd+SrPOLRbicWA9IH+sefli7TBvs/FHhg==", null, false, "", false, "dean1@gmail.com" },
                    { new Guid("62a89d6a-6575-4788-8066-a016ffbe0a27"), 0, "e0ce0ffd-a882-4f7e-b440-dbb635951f40", "admin1@gmail.com", true, false, null, "admin1@gmail.com", "admin1@gmail.com", "AQAAAAEAACcQAAAAEEUG7jfWDUkAkxhAXhgTbgbg3RwLblENjYwI7INxlMvU6Onh29C06pfoi2k/PjEB5g==", null, false, "", false, "admin1@gmail.com" },
                    { new Guid("ec82c37d-6314-4e3d-ac14-30bea0158549"), 0, "3c8f14b7-7b2c-420b-ae6d-1befb2fbdf49", "promoter2@gmail.com", true, false, null, "promoter2@gmail.com", "promoter2@gmail.com", "AQAAAAEAACcQAAAAELhF7UIUhZdVWbc6mCSM/CjX4FYnB3kq3Ej+DnAJKP0ZaNHrhfzokK1BzzLrqV2CeA==", null, false, "", false, "promoter2@gmail.com" },
                    { new Guid("f7be09ae-a9d6-4084-8496-fbdc48de617b"), 0, "525df277-69de-4be6-bab7-8065e8099128", "promoter1@gmail.com", true, false, null, "promoter1@gmail.com", "promoter1@gmail.com", "AQAAAAEAACcQAAAAEPVTnlBBwymSzVb+vFrWNWW+ayRE/bH+QYZNPF/KIfQAs7F2930qOXIZkgb3sWAjeA==", null, false, "", false, "promoter1@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("840960e9-460a-4b4b-9575-8ec35c54fe5d"), new Guid("03fd825e-aa55-4d3d-8583-fbce5b83ac18"), new Guid("ec82c37d-6314-4e3d-ac14-30bea0158549") },
                    { new Guid("c2239e7a-ef13-4943-9868-da5480728bff"), new Guid("a94721dc-5df1-464f-aa30-0cd6c3b2bded"), new Guid("65a4a37d-c825-4c3a-8dac-0c7be338dd69") },
                    { new Guid("0d58c1b1-7541-4fcc-b411-350e1e562bb2"), new Guid("a94721dc-5df1-464f-aa30-0cd6c3b2bded"), new Guid("365bd06d-a898-4355-9434-771f1e6ac147") },
                    { new Guid("97d00e38-fcb5-4c48-8caa-a40d8ab58a50"), new Guid("a94721dc-5df1-464f-aa30-0cd6c3b2bded"), new Guid("8c06eedc-20df-4a7b-a2bb-0f9f07d5cf6a") },
                    { new Guid("3e2b9c2c-1522-43d7-a435-b2cfb6927f57"), new Guid("a94721dc-5df1-464f-aa30-0cd6c3b2bded"), new Guid("08fcb9cf-f01c-4f86-a771-1656ee2111db") },
                    { new Guid("f8c0ec88-24fa-428d-8c0d-55962f2c9bc3"), new Guid("a94721dc-5df1-464f-aa30-0cd6c3b2bded"), new Guid("af40789e-e3ec-4567-96f1-4926f084d8d3") },
                    { new Guid("e3817af2-a9a9-4e97-9424-c2e1574af0d6"), new Guid("a94721dc-5df1-464f-aa30-0cd6c3b2bded"), new Guid("55484603-706d-4b4e-986c-5b328442e235") },
                    { new Guid("7990a2ba-20a8-49a2-84e0-897972b57d01"), new Guid("a94721dc-5df1-464f-aa30-0cd6c3b2bded"), new Guid("682012ab-eb2b-4859-9dee-9f96c2d6cfe8") },
                    { new Guid("b4a952d2-3532-4346-af37-67e383293519"), new Guid("2af475c9-03ce-4a1c-bd55-86bf18ece3f6"), new Guid("ec46f545-78f6-468f-b2b7-a178ecc58f52") },
                    { new Guid("d3d374fa-6362-4ec3-a3c8-0ed971181846"), new Guid("2af475c9-03ce-4a1c-bd55-86bf18ece3f6"), new Guid("07f15bd8-ddf3-47ed-b0c8-d852bb26ec26") },
                    { new Guid("edea3f4d-b79b-4d83-a172-c94c25550e9e"), new Guid("3320f3b2-d22e-4d18-bdc1-8bf8411be231"), new Guid("62a89d6a-6575-4788-8066-a016ffbe0a27") },
                    { new Guid("f27e76b5-e568-434d-8378-8a73d86a2c57"), new Guid("03fd825e-aa55-4d3d-8583-fbce5b83ac18"), new Guid("f7be09ae-a9d6-4084-8496-fbdc48de617b") },
                    { new Guid("66b20c88-a0a9-45a1-8305-967c80a4e909"), new Guid("a94721dc-5df1-464f-aa30-0cd6c3b2bded"), new Guid("25b33791-0989-4356-a3c0-62c065de2d6b") }
                });

            migrationBuilder.InsertData(
                table: "Promoters",
                columns: new[] { "Id", "CanSubmitBachelorProposals", "UserId" },
                values: new object[,]
                {
                    { new Guid("d91d2f52-29b9-4d27-85d5-83479ff89aa7"), true, new Guid("f7be09ae-a9d6-4084-8496-fbdc48de617b") },
                    { new Guid("0d526f29-f6e7-4131-901c-01197567e0c6"), true, new Guid("ec82c37d-6314-4e3d-ac14-30bea0158549") }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ProposalId", "UserId" },
                values: new object[,]
                {
                    { new Guid("32b1b7df-b45e-427d-bd76-94da0b73b37a"), null, new Guid("682012ab-eb2b-4859-9dee-9f96c2d6cfe8") },
                    { new Guid("22243950-f281-4cca-959e-13ddc00477f4"), null, new Guid("55484603-706d-4b4e-986c-5b328442e235") },
                    { new Guid("5510515f-ec45-4e8a-b28c-c357942c3686"), null, new Guid("af40789e-e3ec-4567-96f1-4926f084d8d3") },
                    { new Guid("319c9c7b-9b9d-412e-b5d9-cefa0fad0153"), null, new Guid("08fcb9cf-f01c-4f86-a771-1656ee2111db") },
                    { new Guid("8721d0c1-4dd7-4863-bd59-6ababd1b9af1"), null, new Guid("8c06eedc-20df-4a7b-a2bb-0f9f07d5cf6a") },
                    { new Guid("eb3666f4-a133-4ed6-ae3d-c064923f414b"), null, new Guid("365bd06d-a898-4355-9434-771f1e6ac147") },
                    { new Guid("ed4470b0-d8ba-41b7-9cf2-836472fe83fd"), null, new Guid("65a4a37d-c825-4c3a-8dac-0c7be338dd69") },
                    { new Guid("9743e7fb-11af-4e36-b1f1-68d4092f66bd"), null, new Guid("25b33791-0989-4356-a3c0-62c065de2d6b") }
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
