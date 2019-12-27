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
                name: "Faculties",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Institutes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institutes", x => x.Id);
                });

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
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    FacultyId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Promoters",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TitlePrefix = table.Column<string>(nullable: false),
                    TitlePostfix = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    ExpectedNumberOfBachelorProposals = table.Column<int>(nullable: false),
                    ExpectedNumberOfMasterProposals = table.Column<int>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    InstituteId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promoters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Promoters_Institutes_InstituteId",
                        column: x => x.InstituteId,
                        principalTable: "Institutes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    TopicPolish = table.Column<string>(nullable: false),
                    TopicEnglish = table.Column<string>(nullable: false),
                    StartingDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Specialization = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    StudyProfile = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    Mode = table.Column<int>(nullable: false),
                    PromoterId = table.Column<Guid>(nullable: false),
                    CourseId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proposals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proposals_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                table: "Faculties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("08c4fc6e-009a-43c5-967c-aa63a58c51ba"), "Wydział Architektury" },
                    { new Guid("04ef3da7-3b4a-4062-97b2-d0b763803522"), "Wydział Inżynierii Zarządzania" },
                    { new Guid("734e1a76-2409-4ca7-bbe8-8611faa17a09"), "Wydział Inżynierii Transportu" },
                    { new Guid("e5d3cc8f-517c-4ca9-b99d-d59e4d113955"), "Wydział Informatyki" },
                    { new Guid("ccb5ef4b-9941-4160-8566-9abfc63fb79a"), "Wydział Fizyki Technicznej" },
                    { new Guid("f9e99240-26f1-454e-8d49-8ad990538cb7"), "Wydział Technologii Chemicznej" },
                    { new Guid("c2faabfb-f0e9-48ce-b426-7053ae2ce515"), "Wydział Elektroniki i Telekomunikacji" },
                    { new Guid("af012788-dec9-4251-900f-502390ee325e"), "Wydział Budowy Maszyn i Zarządzania" },
                    { new Guid("1f25c304-5861-4906-a573-a4d79d1b4c8c"), "Wydział Budownictwa i Inżynierii Środowiska" },
                    { new Guid("222c0860-2013-4758-b337-419d2ab1b58a"), "Wydział Elektryczny" }
                });

            migrationBuilder.InsertData(
                table: "Institutes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("538c5043-ff3a-458d-8229-0134e6f5495e"), "Instytut Informatyki" },
                    { new Guid("da42bd0c-e0d8-4aac-9adc-b831a600afc5"), "Instytut Mechaniki Stosowanej" },
                    { new Guid("ae727cd0-a500-408d-9306-9c8b01755594"), "Instytut Elektrotechniki i Elektroniki Przemysłowej" },
                    { new Guid("a2b033ab-efe0-4477-bc84-bca991d77aea"), "Instytut Chemii i Elektrochemii Technicznej" },
                    { new Guid("f8faf28c-ed29-4ea8-91ea-58a7056b0755"), "Instytut Inżynierii Środowiska" },
                    { new Guid("c324803d-de2d-4e58-9e5e-e31914fba986"), "Instytut Inżynierii Lądowej" },
                    { new Guid("e5eabff5-b12f-4ec0-8bfd-66f0040575d2"), "Instytut Technologii Materiałów" },
                    { new Guid("148c87f5-b37a-471e-922f-3d223b056eca"), "Instytut Matematyki" },
                    { new Guid("077e0480-8d05-466c-acd1-e9eed3655cd6"), "Instytut Technologii Mechanicznej" },
                    { new Guid("ca22d5ff-1c94-4686-b928-cf45fbc1e7a8"), "Instytut Technologii i Inżynierii Chemicznej" },
                    { new Guid("df13cc18-7420-4ebe-8183-efe1eb085b7d"), "Instytut Architektury i Planowania Przestrzennego" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("d5379a22-663c-4134-aba3-60d2cc79f3a5"), "5a946d29-96d8-43eb-b3ae-5f3aefabafdd", "dean", "dean" },
                    { new Guid("67a4cf40-1e13-4877-bbd3-3670e183a778"), "dd7a5e9c-a136-4233-bb1f-80f8bf8419f2", "student", "student" },
                    { new Guid("a91a3f43-9477-4f0a-8498-c8672923f138"), "702d1852-2864-4232-9fa7-3231f5bc076a", "promoter", "promoter" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("fa055ee1-4fe9-4d2a-8742-f5d58ea0629e"), new Guid("a91a3f43-9477-4f0a-8498-c8672923f138"), new Guid("4628dbfc-d432-4420-9100-4270e4df9775") },
                    { new Guid("02029c65-f97d-4ba7-b16f-7e8d774a0e18"), new Guid("d5379a22-663c-4134-aba3-60d2cc79f3a5"), new Guid("d702bd1f-459f-4140-95b4-a29d4ba0dde5") },
                    { new Guid("3e51c688-1f21-43f4-81c3-abb582b646c3"), new Guid("d5379a22-663c-4134-aba3-60d2cc79f3a5"), new Guid("fda9e2ea-6b1c-4bca-944c-49e74c819b65") },
                    { new Guid("5fba2b9f-12c5-4fba-a314-a232d551f651"), new Guid("d5379a22-663c-4134-aba3-60d2cc79f3a5"), new Guid("f2fd7508-2248-4391-a0fb-59234e9c4337") },
                    { new Guid("c0a8786a-c67a-43ba-a11b-07592b26ac6e"), new Guid("d5379a22-663c-4134-aba3-60d2cc79f3a5"), new Guid("403d6b6d-d8ef-4430-8fd9-5d292f7addcb") },
                    { new Guid("62dca98b-be35-4664-b573-8804e59b677f"), new Guid("67a4cf40-1e13-4877-bbd3-3670e183a778"), new Guid("fb98b6f6-24be-4078-ba22-b32e3dfb1b68") },
                    { new Guid("b432d759-20de-4c76-8b27-ff63eb580712"), new Guid("67a4cf40-1e13-4877-bbd3-3670e183a778"), new Guid("0da38c85-8000-419e-98e3-3cdf7617aaab") },
                    { new Guid("fdcf21d8-d2da-40b0-8247-72d9e767216c"), new Guid("67a4cf40-1e13-4877-bbd3-3670e183a778"), new Guid("0d1bc62c-872f-4e02-9c0a-a6ec4d8d809c") },
                    { new Guid("df9c9f1b-3cf1-4bff-812b-c25a87454b6d"), new Guid("a91a3f43-9477-4f0a-8498-c8672923f138"), new Guid("1412a329-f80f-497b-81bd-c9853bd4ce23") },
                    { new Guid("8d568f39-018b-49de-9cb2-659ffd89cfd9"), new Guid("a91a3f43-9477-4f0a-8498-c8672923f138"), new Guid("1a9932c1-4206-4a4c-a8d2-8b33b5c9ae6a") },
                    { new Guid("d9831fa6-f646-4c2a-b09d-ec2657768eaf"), new Guid("a91a3f43-9477-4f0a-8498-c8672923f138"), new Guid("201143b3-3b2d-410e-aa3e-440fbd8b27a9") },
                    { new Guid("8865ec19-2d00-408d-b031-4876d0f6ee1f"), new Guid("67a4cf40-1e13-4877-bbd3-3670e183a778"), new Guid("2c91f190-878d-41a1-9f9a-9e7bd5ed1452") },
                    { new Guid("89d8a495-911e-4053-9fd5-9595934387f9"), new Guid("a91a3f43-9477-4f0a-8498-c8672923f138"), new Guid("0213fb55-b8a9-467d-bfc4-3fac8729a478") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("0d1bc62c-872f-4e02-9c0a-a6ec4d8d809c"), 0, "868995bd-86fa-47e2-8a52-1b4406115d91", "student4@gmail.com", true, false, null, "STUDENT4@GMAIL.COM", "STUDENT4@GMAIL.COM", "AQAAAAEAACcQAAAAEB9hX3kEXwvav2tNKQJpLgcIxCJQM0p1gaE/6XpqtFBjAS9PYXbJXhmlARElhamTFg==", null, false, "", false, "student4@gmail.com" },
                    { new Guid("d702bd1f-459f-4140-95b4-a29d4ba0dde5"), 0, "4eb767a9-baeb-4dce-8879-b908edbccd87", "dean1@gmail.com", true, false, null, "DEAN1@GMAIL.COM", "DEAN1@GMAIL.COM", "AQAAAAEAACcQAAAAEMq2v2n0lyU1A1judr8wqKKYIp8hFJCKrAvhwsEeV/aR9RzRHJWrPHCUFrhnHgaUnw==", null, false, "", false, "dean1@gmail.com" },
                    { new Guid("fda9e2ea-6b1c-4bca-944c-49e74c819b65"), 0, "15558786-4753-446f-9ee7-541390ca511a", "dean2@gmail.com", true, false, null, "DEAN2@GMAIL.COM", "DEAN2@GMAIL.COM", "AQAAAAEAACcQAAAAENLRhhHeHOHoOwXoidys/7V8dX4d3HoL24Nr8IzJ6gwmfGR16ZcFYZoYD4rTP4ZR8g==", null, false, "", false, "dean2@gmail.com" },
                    { new Guid("2c91f190-878d-41a1-9f9a-9e7bd5ed1452"), 0, "56fdc065-4662-4cac-95e7-fbcf201ad542", "student3@gmail.com", true, false, null, "STUDENT3@GMAIL.COM", "STUDENT3@GMAIL.COM", "AQAAAAEAACcQAAAAEJPSYeRUFKX7wXbPXF4JhVYhSp9uX95Qe12dY3hoDbj1RNWMNW2/bcnFZISQ3dw04Q==", null, false, "", false, "student3@gmail.com" },
                    { new Guid("f2fd7508-2248-4391-a0fb-59234e9c4337"), 0, "033d2f19-561f-4d6d-a3e4-14e12221041e", "dean3@gmail.com", true, false, null, "DEAN3@GMAIL.COM", "DEAN3@GMAIL.COM", "AQAAAAEAACcQAAAAEJldpEoRmMM5ld7XoEPS7NRVJwesT+ikoY0wMlS+obTYLUvR4D4TgU8oZgHeavoNmg==", null, false, "", false, "dean3@gmail.com" },
                    { new Guid("fb98b6f6-24be-4078-ba22-b32e3dfb1b68"), 0, "6d5676a5-4393-4a00-883f-0d2853e92258", "student1@gmail.com", true, false, null, "STUDENT1@GMAIL.COM", "STUDENT1@GMAIL.COM", "AQAAAAEAACcQAAAAEAZ+PYCqsrdvSdmniq0Q6GqiqDJMvmm0aeeO/367BMZ3FlADkhWSHLs6P56ZAUCd7g==", null, false, "", false, "student1@gmail.com" },
                    { new Guid("0213fb55-b8a9-467d-bfc4-3fac8729a478"), 0, "0410d47d-6363-4ecf-80a7-82b4ec4cf171", "jerzy.nawrocki@put.poznan.pl", true, false, null, "JERZY.NAWROCKI@PUT.POZNAN.PL", "JERZY.NAWROCKI@PUT.POZNAN.PL", "AQAAAAEAACcQAAAAEJor0zXZaCsR2s332qb9Ky09QWH/yVIlrifjJzzpXFIuFy0ll1I999ZBwvjOYID2Mg==", null, false, "", false, "jerzy.nawrocki@put.poznan.pl" },
                    { new Guid("1412a329-f80f-497b-81bd-c9853bd4ce23"), 0, "55c00089-cf92-42d0-8cd0-98a28dc32964", "wojciech.kotlowski@put.poznan.pl", true, false, null, "WOJCIECH.KOTLOWSKI@PUT.POZNAN.PL", "WOJCIECH.KOTLOWSKI@PUT.POZNAN.PL", "AQAAAAEAACcQAAAAEP6NDfclRCigk1hIh6uiQ+56Y5cudXyXIATye3aOpMRYsud1u421TeFme0+g/Y/iVg==", null, false, "", false, "wojciech.kotlowski@put.poznan.pl" },
                    { new Guid("201143b3-3b2d-410e-aa3e-440fbd8b27a9"), 0, "592d0537-cd2f-4d1d-8f50-41c902a0c418", "milosz.kadzinski@put.poznan.pl", true, false, null, "MILOSZ.KADZINSKI@PUT.POZNAN.PL", "MILOSZ.KADZINSKI@PUT.POZNAN.PL", "AQAAAAEAACcQAAAAEGDQDuPmuRpwuON3X85PJWk+YWQfEcsjQCfm6c9Ai5QneZQndy+5mnA3R0/Z6/HM0Q==", null, false, "", false, "milosz.kadzinski@put.poznan.pl" },
                    { new Guid("0da38c85-8000-419e-98e3-3cdf7617aaab"), 0, "927a83ff-7034-455f-8e7a-a820fac2412d", "student2@gmail.com", true, false, null, "STUDENT2@GMAIL.COM", "STUDENT2@GMAIL.COM", "AQAAAAEAACcQAAAAEAh2kESQSTj9gINVW1FHtCrrBpUUZrX9q3lZjpBLBadXkKkzHtrD5G5bpfMw/x4ZBQ==", null, false, "", false, "student2@gmail.com" },
                    { new Guid("4628dbfc-d432-4420-9100-4270e4df9775"), 0, "32196c2c-f1d8-4b3b-99ea-3c7f5c3dae31", "irmina.maslowska@put.poznan.pl", true, false, null, "IRMINA.MASLOWSKA@PUT.POZNAN.PL", "IRMINA.MASLOWSKA@PUT.POZNAN.PL", "AQAAAAEAACcQAAAAEJPs/WIq+MjesWqNFuKqc790pDZxSaLEFayqKwac6kWUccrEu9abFgpKvxehvIK5Ww==", null, false, "", false, "irmina.maslowska@put.poznan.pl" },
                    { new Guid("403d6b6d-d8ef-4430-8fd9-5d292f7addcb"), 0, "7123a768-8e16-4b3f-92ee-dbe8be359cde", "dean4@gmail.com", true, false, null, "DEAN4@GMAIL.COM", "DEAN4@GMAIL.COM", "AQAAAAEAACcQAAAAECZ6/wiwQX2LPtotaHKqzo7TGIo49cA0tqZvGeJKAOG54bGeit9khDUIJq1uhNhBTA==", null, false, "", false, "dean4@gmail.com" },
                    { new Guid("1a9932c1-4206-4a4c-a8d2-8b33b5c9ae6a"), 0, "77929642-bd0e-4357-b3d6-e41efe073d19", "bartlomiej.predki@put.poznan.pl", true, false, null, "BARTLOMIEJ.PREDKI@PUT.POZNAN.PL", "BARTLOMIEJ.PREDKI@PUT.POZNAN.PL", "AQAAAAEAACcQAAAAEOK6M28j86w1pVzF3SLOSu56Iw0iEpOnfJCFLIIMMXJgNpIT98XrVp0KzIQSCyZD/g==", null, false, "", false, "bartlomiej.predki@put.poznan.pl" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "FacultyId", "Name" },
                values: new object[,]
                {
                    { new Guid("f667b3b0-fd83-401d-a868-e07363e3ed79"), new Guid("08c4fc6e-009a-43c5-967c-aa63a58c51ba"), "Architektura" },
                    { new Guid("30dfd993-b959-475b-887d-274fcfeaf35a"), new Guid("f9e99240-26f1-454e-8d49-8ad990538cb7"), "Inżynieria Farmaceutyczna" },
                    { new Guid("3500583d-003a-46fa-abd3-2d3bd9b3ac66"), new Guid("f9e99240-26f1-454e-8d49-8ad990538cb7"), "Technologie Ochrony Środowiska" },
                    { new Guid("a7c260bd-06a6-48f7-9eff-ee594eded52b"), new Guid("f9e99240-26f1-454e-8d49-8ad990538cb7"), "Technologia Chemiczna / Chemical Technology" },
                    { new Guid("2b72c800-0a7f-43b1-8513-0e5ea6f56c0c"), new Guid("f9e99240-26f1-454e-8d49-8ad990538cb7"), "Inżynieria Chemiczna i Procesowa" },
                    { new Guid("75cb1d38-c2cb-434b-9f34-6e89dc9dd7e9"), new Guid("04ef3da7-3b4a-4062-97b2-d0b763803522"), "Inżynieria Bezpieczeństwa" },
                    { new Guid("cb275131-0c84-4e4d-bb13-b4c9206f3bb3"), new Guid("04ef3da7-3b4a-4062-97b2-d0b763803522"), "Inżynieria Zarządzania" },
                    { new Guid("3c994822-9d1a-4c65-aa70-86abfc7baca6"), new Guid("04ef3da7-3b4a-4062-97b2-d0b763803522"), "Logistyka" },
                    { new Guid("248191f4-c042-4f1e-9390-c7e4c3db58be"), new Guid("734e1a76-2409-4ca7-bbe8-8611faa17a09"), "Lotnictwo i Kosmonautyka" },
                    { new Guid("c2854f15-6b4b-47c3-91db-8c8f643d1f14"), new Guid("734e1a76-2409-4ca7-bbe8-8611faa17a09"), "Transport" },
                    { new Guid("4b564ad5-10c5-40f1-a4d5-9ef07ac78e5f"), new Guid("734e1a76-2409-4ca7-bbe8-8611faa17a09"), "Konstrukcja i Eksploatacja Środków Transportu" },
                    { new Guid("52fc1d5d-3c24-4237-9396-45f6ede230fb"), new Guid("e5d3cc8f-517c-4ca9-b99d-d59e4d113955"), "Bioinformatyka" },
                    { new Guid("2c3ac708-2872-471b-96ae-35bc1e2711cf"), new Guid("e5d3cc8f-517c-4ca9-b99d-d59e4d113955"), "Informatyka" },
                    { new Guid("7a7f0267-baa3-48f0-ac18-9f7543c5805a"), new Guid("ccb5ef4b-9941-4160-8566-9abfc63fb79a"), "Fizyka Techniczna" },
                    { new Guid("556bb8e1-a17c-4525-a5d0-193df7260959"), new Guid("ccb5ef4b-9941-4160-8566-9abfc63fb79a"), "Edukacja Techniczno-Informatyczna" },
                    { new Guid("38346cf9-1872-472a-9da6-9cc4b9710e3c"), new Guid("e5d3cc8f-517c-4ca9-b99d-d59e4d113955"), "Sztuczna Inteligencja / Artificial Intelligence" },
                    { new Guid("dd511ef9-e1bd-4fde-85cf-e4981e40b7eb"), new Guid("222c0860-2013-4758-b337-419d2ab1b58a"), "Energetyka" },
                    { new Guid("9a9339f5-ba21-417f-8ed4-201335b7cdcf"), new Guid("08c4fc6e-009a-43c5-967c-aa63a58c51ba"), "Architektura Wnętrz" },
                    { new Guid("25c7d418-9299-4fbd-995f-364a8dd21de2"), new Guid("1f25c304-5861-4906-a573-a4d79d1b4c8c"), "Budownictwo" },
                    { new Guid("a9d25e73-dee9-4f94-9e17-ed1461bb361d"), new Guid("222c0860-2013-4758-b337-419d2ab1b58a"), "Matematyka w Technice" },
                    { new Guid("44679f4f-7285-4f7c-a237-2e5e50783685"), new Guid("af012788-dec9-4251-900f-502390ee325e"), "Inżynieria Biomedyczna" },
                    { new Guid("6cb21264-81b0-4b9a-8ad9-d118e735c200"), new Guid("af012788-dec9-4251-900f-502390ee325e"), "Inżynieria Materiałowa" },
                    { new Guid("22964b3f-e956-4046-b1b8-0c8cd735424d"), new Guid("af012788-dec9-4251-900f-502390ee325e"), "Mechanika i Budowa Maszyn" },
                    { new Guid("b22dda08-5caa-4ad3-bb17-68921f9008ee"), new Guid("1f25c304-5861-4906-a573-a4d79d1b4c8c"), "Inżynieria Środowiska" },
                    { new Guid("e62339b2-44d8-4c98-86ae-4a6b2fe95840"), new Guid("af012788-dec9-4251-900f-502390ee325e"), "Zarządzanie i Inżynieria Produkcji" },
                    { new Guid("ab62cefa-0337-4a22-a9c6-d26e6f8e1241"), new Guid("c2faabfb-f0e9-48ce-b426-7053ae2ce515"), "Elektronika i Telekomunikacja" },
                    { new Guid("b1ca3916-a120-4ab3-b2ad-22cc87f58350"), new Guid("c2faabfb-f0e9-48ce-b426-7053ae2ce515"), "Teleinformatyka" },
                    { new Guid("82969fdd-0193-4a52-a807-83bdeabcfd54"), new Guid("222c0860-2013-4758-b337-419d2ab1b58a"), "Automatyka i Robotyka" },
                    { new Guid("1acf338b-c695-490d-85dd-c9475c4492bd"), new Guid("222c0860-2013-4758-b337-419d2ab1b58a"), "Elektrotechnika" },
                    { new Guid("ec19e11d-e175-49df-a6d8-5dcd03578e5f"), new Guid("af012788-dec9-4251-900f-502390ee325e"), "Mechatronika" }
                });

            migrationBuilder.InsertData(
                table: "Promoters",
                columns: new[] { "Id", "ExpectedNumberOfBachelorProposals", "ExpectedNumberOfMasterProposals", "FirstName", "InstituteId", "LastName", "TitlePostfix", "TitlePrefix", "UserId" },
                values: new object[,]
                {
                    { new Guid("9aabdabd-8d1b-4c38-a2d0-0f88dca17533"), 2, 1, "Wojciech", new Guid("538c5043-ff3a-458d-8229-0134e6f5495e"), "Kotłowski", "", "dr hab. inż.", new Guid("1412a329-f80f-497b-81bd-c9853bd4ce23") },
                    { new Guid("2a21d8e5-575a-41d9-99ed-fbb5c06a3db9"), 2, 1, "Irmina", new Guid("538c5043-ff3a-458d-8229-0134e6f5495e"), "Masłowska", "", "dr inż.", new Guid("4628dbfc-d432-4420-9100-4270e4df9775") },
                    { new Guid("d979fc9c-94d3-419a-a4e9-014e5664b73c"), 2, 1, "Bartłomiej", new Guid("538c5043-ff3a-458d-8229-0134e6f5495e"), "Prędki", "", "dr inż.", new Guid("1a9932c1-4206-4a4c-a8d2-8b33b5c9ae6a") },
                    { new Guid("4ae4e691-dcff-4236-94ca-c97c102bc66c"), 2, 1, "Miłosz", new Guid("538c5043-ff3a-458d-8229-0134e6f5495e"), "Kadziński", "", "dr hab. inż.", new Guid("201143b3-3b2d-410e-aa3e-440fbd8b27a9") },
                    { new Guid("48aea09b-4be3-4372-88bc-d46d78a1552b"), 2, 1, "Jerzy", new Guid("538c5043-ff3a-458d-8229-0134e6f5495e"), "Nawrocki", "prof. PP", "dr hab inż.", new Guid("0213fb55-b8a9-467d-bfc4-3fac8729a478") }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ProposalId", "UserId" },
                values: new object[,]
                {
                    { new Guid("7db0688d-fc48-400a-9b8b-c1fc4ed648f2"), null, new Guid("fb98b6f6-24be-4078-ba22-b32e3dfb1b68") },
                    { new Guid("b97bdc29-661f-4c86-9aa5-663af9df34cf"), null, new Guid("0da38c85-8000-419e-98e3-3cdf7617aaab") },
                    { new Guid("ba8b5281-0a1d-42f7-9dea-b99f978c8680"), null, new Guid("2c91f190-878d-41a1-9f9a-9e7bd5ed1452") },
                    { new Guid("5c3507a8-c29e-450c-8dfc-9c160d205bcb"), null, new Guid("0d1bc62c-872f-4e02-9c0a-a6ec4d8d809c") }
                });

            migrationBuilder.InsertData(
                table: "Proposals",
                columns: new[] { "Id", "CourseId", "Description", "Level", "Mode", "PromoterId", "Specialization", "StartingDate", "Status", "StudyProfile", "TopicEnglish", "TopicPolish" },
                values: new object[,]
                {
                    { new Guid("f1786112-584c-4e3a-ab29-3869d52c9b93"), new Guid("2c3ac708-2872-471b-96ae-35bc1e2711cf"), "Celem pracy jest zaimplementowanie metod Electre 1s i Electre TRI jako aplikacji desktopowych.....", 0, 0, new Guid("2a21d8e5-575a-41d9-99ed-fbb5c06a3db9"), "....................................", new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "Implementation of chosen methods from Electre family", "Implementacja wybranych metod z rodziny Electre" },
                    { new Guid("4e088708-d738-4430-9fa2-815f6c2b3add"), new Guid("2c3ac708-2872-471b-96ae-35bc1e2711cf"), "Opis.....", 0, 0, new Guid("d979fc9c-94d3-419a-a4e9-014e5664b73c"), "Opis.......", new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "Implementation of decision support methods based on utility function (UTA, Assess)", "Implementacja metod wspomagania decyzji opartych na funkcji użyteczności (UTA, Assess)" },
                    { new Guid("5a219471-18ca-4145-b58d-fea3f5b2e610"), new Guid("2c3ac708-2872-471b-96ae-35bc1e2711cf"), "Opis.....", 0, 0, new Guid("4ae4e691-dcff-4236-94ca-c97c102bc66c"), "Opis.......", new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "Extension of diviz platform", "Rozszerzenie platformy diviz o metody wielokryterialnego wspomagania decyzji oparte na różnych modelach preferencji" },
                    { new Guid("99b1e5ac-c32b-422d-a46d-41b091b38f41"), new Guid("2c3ac708-2872-471b-96ae-35bc1e2711cf"), "Opis.....", 0, 0, new Guid("9aabdabd-8d1b-4c38-a2d0-0f88dca17533"), "Opis.......", new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "Style transfering using a neural network", "Transfer stylu przy użyciu sieci neuronowej" },
                    { new Guid("ded94cc1-ced9-4f36-b7a5-fa4ff57e32d2"), new Guid("2c3ac708-2872-471b-96ae-35bc1e2711cf"), "Opis.....", 0, 0, new Guid("48aea09b-4be3-4372-88bc-d46d78a1552b"), "Opis.......", new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "Capri 2 - system for managing diploma topic cards", "Capri 2 - system do zarządzania kartami tematów prac dyplomowych" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_FacultyId",
                table: "Courses",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Promoters_InstituteId",
                table: "Promoters",
                column: "InstituteId");

            migrationBuilder.CreateIndex(
                name: "IX_Promoters_UserId",
                table: "Promoters",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Proposals_CourseId",
                table: "Proposals",
                column: "CourseId");

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
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Promoters");

            migrationBuilder.DropTable(
                name: "Faculties");

            migrationBuilder.DropTable(
                name: "Institutes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
