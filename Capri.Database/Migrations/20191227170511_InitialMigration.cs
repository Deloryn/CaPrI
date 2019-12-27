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
                    { new Guid("03caae51-44f9-4817-88fc-d275b996907c"), "Wydział Architektury" },
                    { new Guid("6262a945-1e3f-4892-bdda-1d6780f076d3"), "Wydział Inżynierii Zarządzania" },
                    { new Guid("b78c65c8-6225-42b1-be9c-1eb10595102a"), "Wydział Inżynierii Transportu" },
                    { new Guid("e8f510a9-5779-4ad9-acaf-edec5a1850d9"), "Wydział Informatyki" },
                    { new Guid("1852bab2-0286-4a58-a27b-18ef7da226b0"), "Wydział Fizyki Technicznej" },
                    { new Guid("a5ad08cb-4c4d-4111-ad84-7c0f65896fb6"), "Wydział Technologii Chemicznej" },
                    { new Guid("7d09ff81-de85-46eb-b365-bdf45d8ac67a"), "Wydział Elektroniki i Telekomunikacji" },
                    { new Guid("27042c1b-c6fc-4cfe-800b-42c11a8440de"), "Wydział Budowy Maszyn i Zarządzania" },
                    { new Guid("38697f53-c417-41eb-80d7-4ab2cfbe2e5d"), "Wydział Budownictwa i Inżynierii Środowiska" },
                    { new Guid("cc8b2de0-d321-4b63-b2b3-d7458ddfc352"), "Wydział Elektryczny" }
                });

            migrationBuilder.InsertData(
                table: "Institutes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("58235289-a170-4ec4-8b32-ececd6df3095"), "Instytut Informatyki" },
                    { new Guid("64466f1e-14f3-4b3f-a283-1b07554affb6"), "Instytut Mechaniki Stosowanej" },
                    { new Guid("f9839510-63ba-416b-acbf-e0ca4ea53df4"), "Instytut Elektrotechniki i Elektroniki Przemysłowej" },
                    { new Guid("8a5b2984-8578-44db-9edd-18aabbf7797e"), "Instytut Chemii i Elektrochemii Technicznej" },
                    { new Guid("fb2d67da-313a-467b-8676-2f125e857c4c"), "Instytut Inżynierii Środowiska" },
                    { new Guid("4a25f9e8-0eba-40b0-9f09-3075ef303900"), "Instytut Inżynierii Lądowej" },
                    { new Guid("0b713ab7-493a-4151-a7bd-d0616c06f58b"), "Instytut Technologii Materiałów" },
                    { new Guid("3dc7b202-d1aa-4f8b-b45d-783bb5b3747d"), "Instytut Matematyki" },
                    { new Guid("1ebb2a74-51b8-475c-863f-c132e0ed494e"), "Instytut Technologii Mechanicznej" },
                    { new Guid("0b3b05f9-0bc3-4d4d-a297-0cf2f0e8bfd4"), "Instytut Technologii i Inżynierii Chemicznej" },
                    { new Guid("c89e109c-d7ac-4683-8f74-19ee71190c3f"), "Instytut Architektury i Planowania Przestrzennego" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("8327e2eb-55ea-465b-bcac-23d7687d9ebb"), "7ebb26de-48ab-4265-b8ac-a6e317937d39", "dean", "dean" },
                    { new Guid("344b55dd-0a46-41b1-a9cf-384a453d6afe"), "0ce4bc7d-3847-41dd-970a-7d958818ecb9", "student", "student" },
                    { new Guid("79d4e7b4-ad05-403b-a999-916dcece0bf7"), "af2a2706-5151-455d-b0a8-5808e02d8ebf", "promoter", "promoter" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("e4781837-9d7a-4b7a-9566-9933094e4ac8"), new Guid("79d4e7b4-ad05-403b-a999-916dcece0bf7"), new Guid("ed5681f6-8f86-4a2a-962b-71522a6b13bc") },
                    { new Guid("318ae3fc-d446-4a46-8368-7be693bf832d"), new Guid("8327e2eb-55ea-465b-bcac-23d7687d9ebb"), new Guid("651c0b4a-e4e8-4242-93a6-dedfc8db0355") },
                    { new Guid("adf7558a-4611-4a68-b446-459f3fe7e6ac"), new Guid("8327e2eb-55ea-465b-bcac-23d7687d9ebb"), new Guid("cd69fa9f-4dbe-459e-9a0e-46c1dce2f544") },
                    { new Guid("bde5d285-a9e4-4016-8db3-21a03ec34768"), new Guid("8327e2eb-55ea-465b-bcac-23d7687d9ebb"), new Guid("141f2ea1-a922-4fa7-8a0d-e6a3cc609cd0") },
                    { new Guid("ce293fad-2b1f-4691-92e6-cb2831b2e397"), new Guid("8327e2eb-55ea-465b-bcac-23d7687d9ebb"), new Guid("4d9f5b90-a5f3-4773-8e44-1cf0c2bbb744") },
                    { new Guid("e016d875-a123-4a88-9e8d-579c10cf2c97"), new Guid("344b55dd-0a46-41b1-a9cf-384a453d6afe"), new Guid("62fb0785-6255-40ad-8058-d4541cb9e683") },
                    { new Guid("41eb5fc4-bfba-4e63-800e-ff96c948138c"), new Guid("344b55dd-0a46-41b1-a9cf-384a453d6afe"), new Guid("6d14d3b4-8a16-4783-a62e-4cec7464a35b") },
                    { new Guid("567e7278-b03e-4e8b-a196-fff7a170dfbf"), new Guid("344b55dd-0a46-41b1-a9cf-384a453d6afe"), new Guid("ef0fa462-fb88-4880-b5ef-8e946eb93a6a") },
                    { new Guid("b43c3a53-b930-4224-8576-09e326b93fef"), new Guid("79d4e7b4-ad05-403b-a999-916dcece0bf7"), new Guid("ecb47443-bc6c-47cb-a15a-ce7c203e7b1b") },
                    { new Guid("88a1c9a9-8592-4b8a-b257-5684b4f4828a"), new Guid("79d4e7b4-ad05-403b-a999-916dcece0bf7"), new Guid("8897863e-d618-4972-81f4-31a5a585a1c1") },
                    { new Guid("c9a57cbc-3854-415e-a78a-3235e9a7d5e2"), new Guid("79d4e7b4-ad05-403b-a999-916dcece0bf7"), new Guid("a66aac57-ee44-483c-a8c7-ca52b39d5ceb") },
                    { new Guid("e2a06cd4-c26f-442e-992b-7fb158659517"), new Guid("79d4e7b4-ad05-403b-a999-916dcece0bf7"), new Guid("662c19a1-9ffd-45f3-a5bc-683251a5008d") },
                    { new Guid("b57a8802-b643-42bc-a6cb-1adac34f114b"), new Guid("79d4e7b4-ad05-403b-a999-916dcece0bf7"), new Guid("85cfa354-c025-46a0-b0c9-bf97b18bc98d") },
                    { new Guid("43608668-930f-4381-acc9-b84c6293ae73"), new Guid("344b55dd-0a46-41b1-a9cf-384a453d6afe"), new Guid("cda651d3-e5c4-47fb-b1af-584494540e87") },
                    { new Guid("d168d1b7-f388-4d6b-89ce-62dd2123fb33"), new Guid("79d4e7b4-ad05-403b-a999-916dcece0bf7"), new Guid("f2734ade-c745-40d7-9345-143de39447cd") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("6d14d3b4-8a16-4783-a62e-4cec7464a35b"), 0, "e5158d40-6272-42cf-8b82-bbc323fe8724", "student2@gmail.com", true, false, null, "STUDENT2@GMAIL.COM", "STUDENT2@GMAIL.COM", "AQAAAAEAACcQAAAAEBQVbci9+LDQKKxpoI670Eei+7D2kfGtc4T+DttBnTMcMMsPQb77uvJn+G2QvP8PwQ==", null, false, "", false, "student2@gmail.com" },
                    { new Guid("651c0b4a-e4e8-4242-93a6-dedfc8db0355"), 0, "fb656414-91f0-4d80-bdb3-662844fd1299", "dean1@gmail.com", true, false, null, "DEAN1@GMAIL.COM", "DEAN1@GMAIL.COM", "AQAAAAEAACcQAAAAEKkMhSX1lPcAaMuPJXoKrhl2xVyZWJpW/CfYcdSh0lV3xINzgj0IglgN2py/55rkUw==", null, false, "", false, "dean1@gmail.com" },
                    { new Guid("cd69fa9f-4dbe-459e-9a0e-46c1dce2f544"), 0, "12bde8aa-a3ed-43f5-87e2-b2d6da070bd8", "dean2@gmail.com", true, false, null, "DEAN2@GMAIL.COM", "DEAN2@GMAIL.COM", "AQAAAAEAACcQAAAAEHqyxedWMDPp2/lqDcXmflulrcMjgHJXrctDZBBgdOvzhcwjKADT+3g3iIHzSTouPg==", null, false, "", false, "dean2@gmail.com" },
                    { new Guid("62fb0785-6255-40ad-8058-d4541cb9e683"), 0, "ec720e87-665e-4778-83ae-a8fc335eba99", "student1@gmail.com", true, false, null, "STUDENT1@GMAIL.COM", "STUDENT1@GMAIL.COM", "AQAAAAEAACcQAAAAEH+9Wf5ovGF34ATJUuNYQ9T6Ti3M50bqx6KRJlcHcL0VJ0xzDZLiwzCaMfz+xSJAQg==", null, false, "", false, "student1@gmail.com" },
                    { new Guid("141f2ea1-a922-4fa7-8a0d-e6a3cc609cd0"), 0, "a85433fc-2bf8-47aa-a88e-955a27b8084e", "dean3@gmail.com", true, false, null, "DEAN3@GMAIL.COM", "DEAN3@GMAIL.COM", "AQAAAAEAACcQAAAAEHjqrRFWnfFG+kFA8X3mbjM86RpQt/PAZa2iSGAsdi1QrGCs9l1QxKMD2GKJYMKsPw==", null, false, "", false, "dean3@gmail.com" },
                    { new Guid("ecb47443-bc6c-47cb-a15a-ce7c203e7b1b"), 0, "cec03e69-a500-4aaf-b628-a84c195bf4b8", "katarzyna.adamska@put.poznan.pl", true, false, null, "KATARZYNA.ADAMSKA@PUT.POZNAN.PL", "KATARZYNA.ADAMSKA@PUT.POZNAN.PL", "AQAAAAEAACcQAAAAEF+zOGkXTU08WpL22RRnrnGjgWhXXX3aQCdrU8Qzwb9mB1fwIX18+oYmLnFtZ9tSTA==", null, false, "", false, "katarzyna.adamska@put.poznan.pl" },
                    { new Guid("85cfa354-c025-46a0-b0c9-bf97b18bc98d"), 0, "c119e256-be36-48b7-898b-420711b895d3", "jerzy.nawrocki@put.poznan.pl", true, false, null, "JERZY.NAWROCKI@PUT.POZNAN.PL", "JERZY.NAWROCKI@PUT.POZNAN.PL", "AQAAAAEAACcQAAAAEGc4HGgVqn4XkABoRmZEhxdSFqa4oQs466CVf4db8v5hu9/6rSVGzY1QFMwaZqCSqA==", null, false, "", false, "jerzy.nawrocki@put.poznan.pl" },
                    { new Guid("662c19a1-9ffd-45f3-a5bc-683251a5008d"), 0, "6d21cc7b-a08b-480c-a742-f2c5e8286a89", "wojciech.kotlowski@put.poznan.pl", true, false, null, "WOJCIECH.KOTLOWSKI@PUT.POZNAN.PL", "WOJCIECH.KOTLOWSKI@PUT.POZNAN.PL", "AQAAAAEAACcQAAAAELh13nx/qJzwRZwJPui7NCgmFve7HNDFbToz71Lb/QS5JTgDlc7HQDYPYrYNLrQdTA==", null, false, "", false, "wojciech.kotlowski@put.poznan.pl" },
                    { new Guid("a66aac57-ee44-483c-a8c7-ca52b39d5ceb"), 0, "360787ab-207c-4edf-a272-5b615c44201a", "milosz.kadzinski@put.poznan.pl", true, false, null, "MILOSZ.KADZINSKI@PUT.POZNAN.PL", "MILOSZ.KADZINSKI@PUT.POZNAN.PL", "AQAAAAEAACcQAAAAEJhTPNOlngyUkyFPZA/cSOARbHs8T1zNU+yv0W3wnEp0u+IhtqTZ/3y4BhFNcVsGOg==", null, false, "", false, "milosz.kadzinski@put.poznan.pl" },
                    { new Guid("4d9f5b90-a5f3-4773-8e44-1cf0c2bbb744"), 0, "704b1198-e86e-4ba9-8bac-99c05a146514", "dean4@gmail.com", true, false, null, "DEAN4@GMAIL.COM", "DEAN4@GMAIL.COM", "AQAAAAEAACcQAAAAEMDaRAuUuky1c52rBWtfpjclBu+AHlU3iCJizEjhEHqnXPmtKovkeOMFsCyqnYdI2Q==", null, false, "", false, "dean4@gmail.com" },
                    { new Guid("ed5681f6-8f86-4a2a-962b-71522a6b13bc"), 0, "79c8c31e-4c0d-472c-a6c2-f15550919e58", "irmina.maslowska@put.poznan.pl", true, false, null, "IRMINA.MASLOWSKA@PUT.POZNAN.PL", "IRMINA.MASLOWSKA@PUT.POZNAN.PL", "AQAAAAEAACcQAAAAENMyiulGsuDjFrzyV/sYHVFTrlWbe3KOD6YP9BLts+cSNyYmVjn/gSX/d/03GXzIcA==", null, false, "", false, "irmina.maslowska@put.poznan.pl" },
                    { new Guid("ef0fa462-fb88-4880-b5ef-8e946eb93a6a"), 0, "c84c584d-6d81-4dc9-808a-f6974eac57cf", "student4@gmail.com", true, false, null, "STUDENT4@GMAIL.COM", "STUDENT4@GMAIL.COM", "AQAAAAEAACcQAAAAEMmv6Ex3OEvsx5/oFTGdAYh3AkVA54vipx04l5NxQ8SF28Ep9vy/crLKftliwcGRrw==", null, false, "", false, "student4@gmail.com" },
                    { new Guid("cda651d3-e5c4-47fb-b1af-584494540e87"), 0, "26104d0b-da68-4fd8-a961-3275983a34b1", "student3@gmail.com", true, false, null, "STUDENT3@GMAIL.COM", "STUDENT3@GMAIL.COM", "AQAAAAEAACcQAAAAEKT1ruL0oT+224R8gB6tUPiV91s7LoCAevZ67xifZrh8kmjXvHVIKo5y19NvYAtpsw==", null, false, "", false, "student3@gmail.com" },
                    { new Guid("f2734ade-c745-40d7-9345-143de39447cd"), 0, "8bcafeb4-3944-4d84-95ad-d8b8e500e112", "krzysztof.alejski@put.poznan.pl", true, false, null, "KRZYSZTOF.ALEJSKI@PUT.POZNAN.PL", "KRZYSZTOF.ALEJSKI@PUT.POZNAN.PL", "AQAAAAEAACcQAAAAEA8tsKEHPiAleOrK7EQkWHSYHe9XTyPy302ONp/iyfF7+xb294bq8cLevEGZjEcIqw==", null, false, "", false, "krzysztof.alejski@put.poznan.pl" },
                    { new Guid("8897863e-d618-4972-81f4-31a5a585a1c1"), 0, "a67a3fea-9bd0-45ef-9da4-47a74c0c0dc7", "bartlomiej.predki@put.poznan.pl", true, false, null, "BARTLOMIEJ.PREDKI@PUT.POZNAN.PL", "BARTLOMIEJ.PREDKI@PUT.POZNAN.PL", "AQAAAAEAACcQAAAAEEzjL97bvao0KIkQj3s+RymDh5G/DoJAkeCZT15AD5hXgf63cfixc8BjG1JnqMgMMQ==", null, false, "", false, "bartlomiej.predki@put.poznan.pl" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "FacultyId", "Name" },
                values: new object[,]
                {
                    { new Guid("7dc16766-8b33-4956-9c8a-5b2f91a5ebaa"), new Guid("03caae51-44f9-4817-88fc-d275b996907c"), "Architektura" },
                    { new Guid("7ca57359-b914-4f2b-87ba-3478f8dc7452"), new Guid("a5ad08cb-4c4d-4111-ad84-7c0f65896fb6"), "Inżynieria Farmaceutyczna" },
                    { new Guid("fda22ce5-789c-408f-a367-cc49597d013f"), new Guid("a5ad08cb-4c4d-4111-ad84-7c0f65896fb6"), "Technologie Ochrony Środowiska" },
                    { new Guid("3b0cf983-356d-4c24-bed0-5420b386ab27"), new Guid("a5ad08cb-4c4d-4111-ad84-7c0f65896fb6"), "Technologia Chemiczna / Chemical Technology" },
                    { new Guid("1724cdb6-f086-457b-badb-f127cef78fdc"), new Guid("a5ad08cb-4c4d-4111-ad84-7c0f65896fb6"), "Inżynieria Chemiczna i Procesowa" },
                    { new Guid("35d52bd3-6975-458f-809c-d19a4299b244"), new Guid("6262a945-1e3f-4892-bdda-1d6780f076d3"), "Inżynieria Bezpieczeństwa" },
                    { new Guid("1a4258e3-758f-4368-b631-d11b1f157260"), new Guid("6262a945-1e3f-4892-bdda-1d6780f076d3"), "Inżynieria Zarządzania" },
                    { new Guid("d806e0db-646e-4933-b926-6a5af8b5ce91"), new Guid("6262a945-1e3f-4892-bdda-1d6780f076d3"), "Logistyka" },
                    { new Guid("bc6b6e7a-febd-43a2-84ce-a07e13fe8ee3"), new Guid("b78c65c8-6225-42b1-be9c-1eb10595102a"), "Lotnictwo i Kosmonautyka" },
                    { new Guid("648f9015-500e-4673-ba72-4b2a12fa7cec"), new Guid("b78c65c8-6225-42b1-be9c-1eb10595102a"), "Transport" },
                    { new Guid("638fafe4-6d71-4a7c-81c5-14a2108cf8e2"), new Guid("e8f510a9-5779-4ad9-acaf-edec5a1850d9"), "Sztuczna Inteligencja / Artificial Intelligence" },
                    { new Guid("d81da25c-2f4f-4f2f-a5eb-dc152c04bf77"), new Guid("e8f510a9-5779-4ad9-acaf-edec5a1850d9"), "Bioinformatyka" },
                    { new Guid("ecb2e274-2fd5-4ae3-8b77-b1b079c39e38"), new Guid("e8f510a9-5779-4ad9-acaf-edec5a1850d9"), "Informatyka" },
                    { new Guid("2251044c-1d1c-4aac-bb6d-08f9ddd6f0c1"), new Guid("1852bab2-0286-4a58-a27b-18ef7da226b0"), "Fizyka Techniczna" },
                    { new Guid("f3632127-034e-4148-9e7a-00029afc3f08"), new Guid("1852bab2-0286-4a58-a27b-18ef7da226b0"), "Edukacja Techniczno-Informatyczna" },
                    { new Guid("08401f8f-9e69-414c-bb21-765e367bfb69"), new Guid("b78c65c8-6225-42b1-be9c-1eb10595102a"), "Konstrukcja i Eksploatacja Środków Transportu" },
                    { new Guid("e7857e47-181b-4b7e-962a-2fa959d27cd7"), new Guid("cc8b2de0-d321-4b63-b2b3-d7458ddfc352"), "Energetyka" },
                    { new Guid("28397793-509a-45fc-a03c-c446b6b62058"), new Guid("03caae51-44f9-4817-88fc-d275b996907c"), "Architektura Wnętrz" },
                    { new Guid("29116232-c8e9-4ad6-9c8f-5ddffc627afc"), new Guid("cc8b2de0-d321-4b63-b2b3-d7458ddfc352"), "Matematyka w Technice" },
                    { new Guid("8d0abcb1-f141-4c7d-9052-e9101424ba55"), new Guid("38697f53-c417-41eb-80d7-4ab2cfbe2e5d"), "Inżynieria Środowiska" },
                    { new Guid("61f0b1ba-7a37-491b-9c31-e9ec33f46ba4"), new Guid("27042c1b-c6fc-4cfe-800b-42c11a8440de"), "Inżynieria Biomedyczna" },
                    { new Guid("d2f1a18e-7837-401c-ab8f-a82d0a797ec1"), new Guid("27042c1b-c6fc-4cfe-800b-42c11a8440de"), "Inżynieria Materiałowa" },
                    { new Guid("34c9bec7-ce98-471d-8550-8fcbaa866eb8"), new Guid("27042c1b-c6fc-4cfe-800b-42c11a8440de"), "Mechanika i Budowa Maszyn" },
                    { new Guid("54c1d86f-b089-4014-a57e-7b9e07f56fc0"), new Guid("38697f53-c417-41eb-80d7-4ab2cfbe2e5d"), "Budownictwo" },
                    { new Guid("d719e23d-056e-4646-b520-2cd8ec4db640"), new Guid("27042c1b-c6fc-4cfe-800b-42c11a8440de"), "Zarządzanie i Inżynieria Produkcji" },
                    { new Guid("ee2625a5-2131-4583-ba70-689b5777f872"), new Guid("7d09ff81-de85-46eb-b365-bdf45d8ac67a"), "Elektronika i Telekomunikacja" },
                    { new Guid("2de88dc9-a670-4598-8a56-7da4cc157e3d"), new Guid("7d09ff81-de85-46eb-b365-bdf45d8ac67a"), "Teleinformatyka" },
                    { new Guid("b08225df-4b31-4e61-8f22-2b27c21658d4"), new Guid("cc8b2de0-d321-4b63-b2b3-d7458ddfc352"), "Automatyka i Robotyka" },
                    { new Guid("f2342a0b-3a63-40c5-a8db-cba2ac84f619"), new Guid("cc8b2de0-d321-4b63-b2b3-d7458ddfc352"), "Elektrotechnika" },
                    { new Guid("0380fc92-efcc-4807-9873-b0b14955eee6"), new Guid("27042c1b-c6fc-4cfe-800b-42c11a8440de"), "Mechatronika" }
                });

            migrationBuilder.InsertData(
                table: "Promoters",
                columns: new[] { "Id", "ExpectedNumberOfBachelorProposals", "ExpectedNumberOfMasterProposals", "FirstName", "InstituteId", "LastName", "TitlePostfix", "TitlePrefix", "UserId" },
                values: new object[,]
                {
                    { new Guid("48aea09b-4be3-4372-88bc-d46d78a1552b"), 2, 1, "Jerzy", new Guid("58235289-a170-4ec4-8b32-ececd6df3095"), "Nawrocki", "prof. PP", "dr hab inż.", new Guid("85cfa354-c025-46a0-b0c9-bf97b18bc98d") },
                    { new Guid("9aabdabd-8d1b-4c38-a2d0-0f88dca17533"), 2, 1, "Wojciech", new Guid("58235289-a170-4ec4-8b32-ececd6df3095"), "Kotłowski", "", "dr hab. inż.", new Guid("662c19a1-9ffd-45f3-a5bc-683251a5008d") },
                    { new Guid("4ae4e691-dcff-4236-94ca-c97c102bc66c"), 2, 1, "Miłosz", new Guid("58235289-a170-4ec4-8b32-ececd6df3095"), "Kadziński", "", "dr hab. inż.", new Guid("a66aac57-ee44-483c-a8c7-ca52b39d5ceb") },
                    { new Guid("d979fc9c-94d3-419a-a4e9-014e5664b73c"), 2, 1, "Bartłomiej", new Guid("58235289-a170-4ec4-8b32-ececd6df3095"), "Prędki", "", "dr inż.", new Guid("8897863e-d618-4972-81f4-31a5a585a1c1") },
                    { new Guid("7345a41b-36aa-4ae2-b0fe-b7bb4279603b"), 3, 2, "Krzysztof", new Guid("0b3b05f9-0bc3-4d4d-a297-0cf2f0e8bfd4"), "Alejski", "prof. PP", "dr hab. inż.", new Guid("f2734ade-c745-40d7-9345-143de39447cd") },
                    { new Guid("fb23704f-cec8-48fb-aa79-f3bd0e7e293b"), 1, 1, "Katarzyna", new Guid("0b3b05f9-0bc3-4d4d-a297-0cf2f0e8bfd4"), "Adamska", "", "dr inż.", new Guid("ecb47443-bc6c-47cb-a15a-ce7c203e7b1b") },
                    { new Guid("2a21d8e5-575a-41d9-99ed-fbb5c06a3db9"), 2, 1, "Irmina", new Guid("58235289-a170-4ec4-8b32-ececd6df3095"), "Masłowska", "", "dr inż.", new Guid("ed5681f6-8f86-4a2a-962b-71522a6b13bc") }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ProposalId", "UserId" },
                values: new object[,]
                {
                    { new Guid("c502b6f6-a1b5-4825-8072-159b2e6c1de1"), null, new Guid("ef0fa462-fb88-4880-b5ef-8e946eb93a6a") },
                    { new Guid("be28474a-e038-45ea-98e4-8648975eacc4"), null, new Guid("6d14d3b4-8a16-4783-a62e-4cec7464a35b") },
                    { new Guid("e5dd8488-cb8e-4716-8dab-5ba6e8bfaa77"), null, new Guid("62fb0785-6255-40ad-8058-d4541cb9e683") },
                    { new Guid("8c80c3c2-03ed-44e8-9c54-f4a3c6188642"), null, new Guid("cda651d3-e5c4-47fb-b1af-584494540e87") }
                });

            migrationBuilder.InsertData(
                table: "Proposals",
                columns: new[] { "Id", "CourseId", "Description", "Level", "Mode", "PromoterId", "Specialization", "StartingDate", "Status", "StudyProfile", "TopicEnglish", "TopicPolish" },
                values: new object[,]
                {
                    { new Guid("f2f1039a-9d17-4a51-860d-0c7dbc8e8824"), new Guid("ecb2e274-2fd5-4ae3-8b77-b1b079c39e38"), "Celem pracy jest zaimplementowanie metod Electre 1s i Electre TRI jako aplikacji desktopowych.....", 0, 0, new Guid("2a21d8e5-575a-41d9-99ed-fbb5c06a3db9"), "....................................", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "Implementation of chosen methods from Electre family", "Implementacja wybranych metod z rodziny Electre" },
                    { new Guid("5cf17a9d-72a9-4508-b3bb-355f981f40ed"), new Guid("ecb2e274-2fd5-4ae3-8b77-b1b079c39e38"), "Opis.....", 0, 0, new Guid("d979fc9c-94d3-419a-a4e9-014e5664b73c"), "Opis.......", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "Implementation of decision support methods based on utility function (UTA, Assess)", "Implementacja metod wspomagania decyzji opartych na funkcji użyteczności (UTA, Assess)" },
                    { new Guid("c4d9dbbd-ba75-40f6-a72d-885a19b30ea1"), new Guid("ecb2e274-2fd5-4ae3-8b77-b1b079c39e38"), "Opis.....", 0, 0, new Guid("4ae4e691-dcff-4236-94ca-c97c102bc66c"), "Opis.......", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "Extension of diviz platform", "Rozszerzenie platformy diviz o metody wielokryterialnego wspomagania decyzji oparte na różnych modelach preferencji" },
                    { new Guid("6b7bf042-1be7-4902-998d-82a9373f76b2"), new Guid("ecb2e274-2fd5-4ae3-8b77-b1b079c39e38"), "Opis.....", 0, 0, new Guid("9aabdabd-8d1b-4c38-a2d0-0f88dca17533"), "Opis.......", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "Style transfering using a neural network", "Transfer stylu przy użyciu sieci neuronowej" },
                    { new Guid("0e4c4099-4726-45c3-a38f-4c6f13100f3c"), new Guid("ecb2e274-2fd5-4ae3-8b77-b1b079c39e38"), "Opis.....", 0, 0, new Guid("48aea09b-4be3-4372-88bc-d46d78a1552b"), "Opis.......", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "Capri 2 - system for managing diploma topic cards", "Capri 2 - system do zarządzania kartami tematów prac dyplomowych" },
                    { new Guid("9fbe17ef-904e-4b73-b783-4bf5cb1874c0"), new Guid("1724cdb6-f086-457b-badb-f127cef78fdc"), "Praca będzie polegać na własnoręcznym upakowaniu kolumny chromatograficznej, doborze odpowiednich warunków pomiaru w celu wyznaczenia podstawowych parametrów dla niestandardowych kolumn do HPLC.", 0, 0, new Guid("fb23704f-cec8-48fb-aa79-f3bd0e7e293b"), "Brak opisu", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "No title", "Wyznaczenie parametrów kolumny chromatograficznej za pomocą odwróconej chromatografii cieczowej" },
                    { new Guid("f773dd26-c97d-4b69-a9c3-5aa2cf013c7b"), new Guid("1724cdb6-f086-457b-badb-f127cef78fdc"), "Brak opisu", 1, 0, new Guid("7345a41b-36aa-4ae2-b0fe-b7bb4279603b"), "Brak opisu", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "No title", "Analiza i projektowanie procesów wydzielania produktów otrzymywanych w procesie biokonwersji surowców odnawialnych" }
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
