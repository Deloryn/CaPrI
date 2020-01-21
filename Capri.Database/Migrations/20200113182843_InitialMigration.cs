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
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.UniqueConstraint("AK_UserRoles_Id", x => x.Id);
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
                    OutputData = table.Column<string>(nullable: true),
                    MaxNumberOfStudents = table.Column<int>(nullable: false),
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
                    Semester = table.Column<int>(nullable: false),
                    StudyLevel = table.Column<int>(nullable: false),
                    StudyMode = table.Column<int>(nullable: false),
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
                    { new Guid("286182fb-2eff-4f6e-bec6-cf86373bfb06"), "Wydział Architektury" },
                    { new Guid("daf819dd-4dd8-4477-8879-c711bf424562"), "Wydział Inżynierii Zarządzania" },
                    { new Guid("a223465f-4d7c-42d8-bb26-4b36ddd22338"), "Wydział Inżynierii Transportu" },
                    { new Guid("53cfd11a-f8d3-40df-aeb8-56b2a28a7c6e"), "Wydział Informatyki" },
                    { new Guid("3803621e-d4fc-40d2-af6f-bb6423d4fa10"), "Wydział Fizyki Technicznej" },
                    { new Guid("13ebb15c-f09c-4600-b2c8-1e9bd5c268dd"), "Wydział Technologii Chemicznej" },
                    { new Guid("35095857-bb5a-4d2c-bf7d-94bae1eeed06"), "Wydział Elektroniki i Telekomunikacji" },
                    { new Guid("1ca72503-5c6b-48fc-a5a0-28d17e662d83"), "Wydział Budowy Maszyn i Zarządzania" },
                    { new Guid("74de6b59-54f9-449f-b895-bf54f7f4cc0e"), "Wydział Budownictwa i Inżynierii Środowiska" },
                    { new Guid("7fa3fbf3-e14f-4942-8195-8d2693260dfd"), "Wydział Elektryczny" }
                });

            migrationBuilder.InsertData(
                table: "Institutes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("5f23f0a6-d8ff-48d6-8af9-da4c59beb16a"), "Instytut Informatyki" },
                    { new Guid("8fd0290d-6fce-4aeb-abd1-7eb438014300"), "Instytut Mechaniki Stosowanej" },
                    { new Guid("6c48f51c-3310-44f5-9a88-38c250fa23f8"), "Instytut Elektrotechniki i Elektroniki Przemysłowej" },
                    { new Guid("38c10662-59bd-4ac9-a5cf-866ce527349a"), "Instytut Chemii i Elektrochemii Technicznej" },
                    { new Guid("ff82c6fe-347b-401b-afd2-4cad0e684f91"), "Instytut Inżynierii Środowiska" },
                    { new Guid("e76e64dc-b1f1-4926-9d25-2fa7f5fa7685"), "Instytut Inżynierii Lądowej" },
                    { new Guid("19cc3f15-00b5-435c-ab18-5dd9a64a4f6d"), "Instytut Technologii Materiałów" },
                    { new Guid("6b04ff5e-f41c-4e22-9c0d-be270b222538"), "Instytut Matematyki" },
                    { new Guid("631f6158-f915-41d5-9cb7-8611d4462061"), "Instytut Technologii Mechanicznej" },
                    { new Guid("767083df-627d-4549-bf34-31d94855431b"), "Instytut Technologii i Inżynierii Chemicznej" },
                    { new Guid("366fc5ee-ff85-4ca3-bf6e-a1cc24284a25"), "Instytut Architektury i Planowania Przestrzennego" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("b9115348-2ffa-4cf1-b282-e3008665c149"), "922f5127-ea0a-41fe-931d-5d6f836a29c0", "Dean", "Dean" },
                    { new Guid("8270982e-fadd-4d16-b472-f07716ed50fc"), "921987da-89c9-47f9-96fe-23516f7c4467", "Student", "Student" },
                    { new Guid("d71b34a3-6f8e-4916-9abe-74a3fb3f238f"), "21b4787b-64c9-49c8-8b09-93be716ad2a3", "Promoter", "Promoter" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId", "Id" },
                values: new object[,]
                {
                    { new Guid("32de6a04-27ce-4c4c-bc6f-3dc9863aa3b8"), new Guid("d71b34a3-6f8e-4916-9abe-74a3fb3f238f"), new Guid("20f17f4b-8203-42f6-928c-d9b4abfb32c2") },
                    { new Guid("187cf661-0d86-4174-a94f-4c20fc2f91cf"), new Guid("b9115348-2ffa-4cf1-b282-e3008665c149"), new Guid("ac13a907-df76-4a63-8a62-7f8ba3434975") },
                    { new Guid("c50fef05-5454-47e0-93a4-507b6b309961"), new Guid("b9115348-2ffa-4cf1-b282-e3008665c149"), new Guid("64aba70d-2c2a-4c95-97ff-fdeb001ea1cc") },
                    { new Guid("79051779-d90e-4f32-8a54-09f25a519229"), new Guid("b9115348-2ffa-4cf1-b282-e3008665c149"), new Guid("168b98c1-43a3-4e51-9aea-195d98cd2cb9") },
                    { new Guid("0ef4a4ca-9cfc-4753-8054-9a339fda4dd9"), new Guid("b9115348-2ffa-4cf1-b282-e3008665c149"), new Guid("2833d2dc-8bc0-4986-b492-3b64fc3d4a05") },
                    { new Guid("dcab23ee-6e30-401e-a477-82d0747f4620"), new Guid("8270982e-fadd-4d16-b472-f07716ed50fc"), new Guid("d1823795-cdca-4962-83ae-75084b0be85e") },
                    { new Guid("e8a680ad-4d03-4805-bde5-53929e509d8d"), new Guid("8270982e-fadd-4d16-b472-f07716ed50fc"), new Guid("546f878e-5073-435b-a4e5-4108e5c6576c") },
                    { new Guid("414b4914-be9c-4774-bb04-c0d3db715797"), new Guid("8270982e-fadd-4d16-b472-f07716ed50fc"), new Guid("f989d191-edc2-4562-9bff-7a31e16fd937") },
                    { new Guid("c91ff433-4a4f-496a-a7c9-1bf7f81ffaaf"), new Guid("d71b34a3-6f8e-4916-9abe-74a3fb3f238f"), new Guid("7449130f-eddc-4c60-93ff-d52707fa84fe") },
                    { new Guid("d7fccab2-21c9-4a89-8f72-f0e342481692"), new Guid("d71b34a3-6f8e-4916-9abe-74a3fb3f238f"), new Guid("1e55ba59-5acd-4579-b62c-ec08a08b90f1") },
                    { new Guid("2e970899-3edd-41bb-9119-9685aee185a3"), new Guid("d71b34a3-6f8e-4916-9abe-74a3fb3f238f"), new Guid("e72ea699-96ae-48a7-aa94-0b8060663ffb") },
                    { new Guid("008121fd-7e0b-4ff5-bc86-65ab0502da1a"), new Guid("d71b34a3-6f8e-4916-9abe-74a3fb3f238f"), new Guid("da63d89f-4863-4c1b-a0a6-8faa50f68b12") },
                    { new Guid("32a29b01-4688-4de7-98e2-9183357a1fd3"), new Guid("d71b34a3-6f8e-4916-9abe-74a3fb3f238f"), new Guid("b6144062-8217-46d4-9cdc-077b0b513ba1") },
                    { new Guid("365a985a-a140-411a-b829-6c00124b0985"), new Guid("8270982e-fadd-4d16-b472-f07716ed50fc"), new Guid("2041656d-ded7-40e4-8b03-12467a9579b6") },
                    { new Guid("7e0d1efd-5265-4527-8d78-ea00678ae77f"), new Guid("d71b34a3-6f8e-4916-9abe-74a3fb3f238f"), new Guid("b3c93855-8964-4ad4-a179-411ed7fb7f28") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("e8a680ad-4d03-4805-bde5-53929e509d8d"), 0, "38a52f22-c8d6-4b91-8f02-10049d158e8e", "student2@gmail.com", true, false, null, "STUDENT2@GMAIL.COM", "STUDENT2@GMAIL.COM", "AQAAAAEAACcQAAAAEOlF564Hk040wSG4T2eZU2N+o5hE8AoiUEiCsjkiEd5L/OrmyW7hIkJJ8WjhwMrYWA==", null, false, "", false, "student2@gmail.com" },
                    { new Guid("187cf661-0d86-4174-a94f-4c20fc2f91cf"), 0, "08367d25-c254-461e-8de6-c62b7420082d", "dean1@gmail.com", true, false, null, "DEAN1@GMAIL.COM", "DEAN1@GMAIL.COM", "AQAAAAEAACcQAAAAEGCiEzE8bXa/tad8sfuvCm5ZUpfxiMhV19u3i2x5RCjf2rtQVLwMfDjxe213n+Y+Fw==", null, false, "", false, "dean1@gmail.com" },
                    { new Guid("c50fef05-5454-47e0-93a4-507b6b309961"), 0, "8ac4dc76-f8e5-42b0-9ca4-35d04e516492", "dean2@gmail.com", true, false, null, "DEAN2@GMAIL.COM", "DEAN2@GMAIL.COM", "AQAAAAEAACcQAAAAEErdZ6LnXfGFlVOmVOuI7egDPXji4hEAunf/rRyPz8tYk1PvLTtho66Gd095yZgpMA==", null, false, "", false, "dean2@gmail.com" },
                    { new Guid("dcab23ee-6e30-401e-a477-82d0747f4620"), 0, "e81c46a6-2c77-4874-8fe0-8cded227b83b", "student1@gmail.com", true, false, null, "STUDENT1@GMAIL.COM", "STUDENT1@GMAIL.COM", "AQAAAAEAACcQAAAAEDh28hderJzB5cxqyaJkWvpFu3FKAPLk7SEfBsbi661EvmQGHBVHxM+MjvdXefa1Uw==", null, false, "", false, "student1@gmail.com" },
                    { new Guid("79051779-d90e-4f32-8a54-09f25a519229"), 0, "336c905a-0bc6-415e-b35f-8c9a7a6fecc2", "dean3@gmail.com", true, false, null, "DEAN3@GMAIL.COM", "DEAN3@GMAIL.COM", "AQAAAAEAACcQAAAAEOCJG9JeMN7EVkd22IbsEZAb91yxtSd3mnaRhx2LvQeBOZkaGf6OnoKi7MmKO2ZBsQ==", null, false, "", false, "dean3@gmail.com" },
                    { new Guid("c91ff433-4a4f-496a-a7c9-1bf7f81ffaaf"), 0, "7b846c1e-64d4-43c6-82b6-c56a5d43a530", "katarzyna.adamska@put.poznan.pl", true, false, null, "KATARZYNA.ADAMSKA@PUT.POZNAN.PL", "KATARZYNA.ADAMSKA@PUT.POZNAN.PL", "AQAAAAEAACcQAAAAECngEYilsdaFSa4MoV70arqJBnU4KGC9x3wZ1pxmjmispqzRMcnLNI7c0nG8sPcYxg==", null, false, "", false, "katarzyna.adamska@put.poznan.pl" },
                    { new Guid("32a29b01-4688-4de7-98e2-9183357a1fd3"), 0, "481e3b0d-7e46-4acc-b471-2e1b3a2f04ce", "jerzy.nawrocki@put.poznan.pl", true, false, null, "JERZY.NAWROCKI@PUT.POZNAN.PL", "JERZY.NAWROCKI@PUT.POZNAN.PL", "AQAAAAEAACcQAAAAEIn10ZK9t0yT97PAPTDfZNTwdbYPJVRxO12R/Fj2SEiQlaIXtUz5MVoz2FOOoYJl/A==", null, false, "", false, "jerzy.nawrocki@put.poznan.pl" },
                    { new Guid("008121fd-7e0b-4ff5-bc86-65ab0502da1a"), 0, "42c0feee-3c0b-41b7-b78a-d5a62da87490", "wojciech.kotlowski@put.poznan.pl", true, false, null, "WOJCIECH.KOTLOWSKI@PUT.POZNAN.PL", "WOJCIECH.KOTLOWSKI@PUT.POZNAN.PL", "AQAAAAEAACcQAAAAEDwR3a5ICbhmKMb/NYbXU1GL/NFdXX7Ym4G6Z0H3wwxMFnARzzw3fVAAgHINHOOn/g==", null, false, "", false, "wojciech.kotlowski@put.poznan.pl" },
                    { new Guid("2e970899-3edd-41bb-9119-9685aee185a3"), 0, "9b1c5d9c-39b1-4c8b-ad15-e83d1d7c373b", "milosz.kadzinski@put.poznan.pl", true, false, null, "MILOSZ.KADZINSKI@PUT.POZNAN.PL", "MILOSZ.KADZINSKI@PUT.POZNAN.PL", "AQAAAAEAACcQAAAAEJfmFLPus+w+zWyB4R81G866vQjjaAjFIJS99Ekt3iXh1OXynUCoz0G+N7Fmjk6slQ==", null, false, "", false, "milosz.kadzinski@put.poznan.pl" },
                    { new Guid("0ef4a4ca-9cfc-4753-8054-9a339fda4dd9"), 0, "01aaffbc-f775-4020-a91c-d982770006b5", "dean4@gmail.com", true, false, null, "DEAN4@GMAIL.COM", "DEAN4@GMAIL.COM", "AQAAAAEAACcQAAAAEJV54TpvcU9DqQ3SEVHZwfndzaRmiSBQEfOgN0noHPb0FcVHYcSLyqDp9GsMbR8ZLA==", null, false, "", false, "dean4@gmail.com" },
                    { new Guid("32de6a04-27ce-4c4c-bc6f-3dc9863aa3b8"), 0, "cbb7f42a-179f-416c-98bf-dbc91e060ebe", "irmina.maslowska@put.poznan.pl", true, false, null, "IRMINA.MASLOWSKA@PUT.POZNAN.PL", "IRMINA.MASLOWSKA@PUT.POZNAN.PL", "AQAAAAEAACcQAAAAEFYrmhYQAZgvEy+6Oqbi09lyiRXYcuaI3ayX1lyhKIW+EoHSD4sKO7UHzNBXCstw8Q==", null, false, "", false, "irmina.maslowska@put.poznan.pl" },
                    { new Guid("414b4914-be9c-4774-bb04-c0d3db715797"), 0, "9f162f3f-6727-408f-b0af-5387958348b5", "student4@gmail.com", true, false, null, "STUDENT4@GMAIL.COM", "STUDENT4@GMAIL.COM", "AQAAAAEAACcQAAAAEN0bDNHTllw36luG/aopDbykqRFgDmJjShLmsV5wZ8lEc0KJ5js8T6p3n+aTLkJ0jA==", null, false, "", false, "student4@gmail.com" },
                    { new Guid("365a985a-a140-411a-b829-6c00124b0985"), 0, "ad2aa486-8ef4-462a-adbe-3faf89c12283", "student3@gmail.com", true, false, null, "STUDENT3@GMAIL.COM", "STUDENT3@GMAIL.COM", "AQAAAAEAACcQAAAAEFTRjvCsb9OzMSjq+GaVBVJK9mWw+aGQvZXF3gN4c6i46YwsQYEEFKAzF/3UIO9zxw==", null, false, "", false, "student3@gmail.com" },
                    { new Guid("7e0d1efd-5265-4527-8d78-ea00678ae77f"), 0, "c2f136c1-6987-4b6d-9cdf-1b740777877a", "krzysztof.alejski@put.poznan.pl", true, false, null, "KRZYSZTOF.ALEJSKI@PUT.POZNAN.PL", "KRZYSZTOF.ALEJSKI@PUT.POZNAN.PL", "AQAAAAEAACcQAAAAEAlDq6najfQ0dLS/zn8SsdL79YJmvOTB77j5JRaMJ2CUrmZV/M6epTQuvLojzevVaA==", null, false, "", false, "krzysztof.alejski@put.poznan.pl" },
                    { new Guid("d7fccab2-21c9-4a89-8f72-f0e342481692"), 0, "43286458-65a2-4a07-a2da-fa5ee9b60d2f", "bartlomiej.predki@put.poznan.pl", true, false, null, "BARTLOMIEJ.PREDKI@PUT.POZNAN.PL", "BARTLOMIEJ.PREDKI@PUT.POZNAN.PL", "AQAAAAEAACcQAAAAEIEAnPrDlpg0JHN3k6XodohuJUJzsyPvt/B2SAVV+S4ZC/IzJIIphoqlmMVlE5r4vQ==", null, false, "", false, "bartlomiej.predki@put.poznan.pl" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "FacultyId", "Name" },
                values: new object[,]
                {
                    { new Guid("455badb2-e1e8-4431-bbd8-54a0bcb5d992"), new Guid("286182fb-2eff-4f6e-bec6-cf86373bfb06"), "Architektura" },
                    { new Guid("5b6bb82d-bf2a-40fd-b4f4-d155c44b4f36"), new Guid("13ebb15c-f09c-4600-b2c8-1e9bd5c268dd"), "Inżynieria Farmaceutyczna" },
                    { new Guid("68f55fa9-4cd6-4fae-9f68-e07409212a82"), new Guid("13ebb15c-f09c-4600-b2c8-1e9bd5c268dd"), "Technologie Ochrony Środowiska" },
                    { new Guid("ab9c2ba9-01fa-4f73-b61a-e8c9be81bf0a"), new Guid("13ebb15c-f09c-4600-b2c8-1e9bd5c268dd"), "Technologia Chemiczna / Chemical Technology" },
                    { new Guid("eadc3557-5492-4085-b95e-a08f1d31e8b5"), new Guid("13ebb15c-f09c-4600-b2c8-1e9bd5c268dd"), "Inżynieria Chemiczna i Procesowa" },
                    { new Guid("c869999c-bf22-404b-accb-e1ec78d5ad95"), new Guid("daf819dd-4dd8-4477-8879-c711bf424562"), "Inżynieria Bezpieczeństwa" },
                    { new Guid("50d88bde-02aa-45fa-9961-8011cffa3a47"), new Guid("daf819dd-4dd8-4477-8879-c711bf424562"), "Inżynieria Zarządzania" },
                    { new Guid("ae99b625-b072-4de9-873e-f8ebe5f266be"), new Guid("daf819dd-4dd8-4477-8879-c711bf424562"), "Logistyka" },
                    { new Guid("640f9230-2faa-40c3-9cb9-a55fa5fe25ec"), new Guid("a223465f-4d7c-42d8-bb26-4b36ddd22338"), "Lotnictwo i Kosmonautyka" },
                    { new Guid("dc90996a-cda3-4394-b748-7dbea1bb8ba5"), new Guid("a223465f-4d7c-42d8-bb26-4b36ddd22338"), "Transport" },
                    { new Guid("b6a1b4fd-681d-4f19-a843-052c1cf0112b"), new Guid("53cfd11a-f8d3-40df-aeb8-56b2a28a7c6e"), "Sztuczna Inteligencja / Artificial Intelligence" },
                    { new Guid("1bb31a59-ba48-4f26-934f-c17748347901"), new Guid("53cfd11a-f8d3-40df-aeb8-56b2a28a7c6e"), "Bioinformatyka" },
                    { new Guid("70780c06-63a0-4e07-a819-0821b5fa3d84"), new Guid("53cfd11a-f8d3-40df-aeb8-56b2a28a7c6e"), "Informatyka" },
                    { new Guid("5e4c5c6b-74fb-4cc7-9974-a620d8efec50"), new Guid("3803621e-d4fc-40d2-af6f-bb6423d4fa10"), "Fizyka Techniczna" },
                    { new Guid("65f312a0-c6d9-4fe6-a89f-d29e8bd50fe8"), new Guid("3803621e-d4fc-40d2-af6f-bb6423d4fa10"), "Edukacja Techniczno-Informatyczna" },
                    { new Guid("0544acdb-6930-4c4b-9812-87263500c38e"), new Guid("a223465f-4d7c-42d8-bb26-4b36ddd22338"), "Konstrukcja i Eksploatacja Środków Transportu" },
                    { new Guid("c38d9fa2-5d3e-4cab-b955-aae7dda4e088"), new Guid("7fa3fbf3-e14f-4942-8195-8d2693260dfd"), "Energetyka" },
                    { new Guid("051a4255-39d4-4526-976c-629bb8101c36"), new Guid("286182fb-2eff-4f6e-bec6-cf86373bfb06"), "Architektura Wnętrz" },
                    { new Guid("2e65d34d-45aa-4c0d-b8d6-6c90d37eb6ac"), new Guid("7fa3fbf3-e14f-4942-8195-8d2693260dfd"), "Matematyka w Technice" },
                    { new Guid("3349c8ec-5316-4e5e-9790-e388c7f1dbf6"), new Guid("74de6b59-54f9-449f-b895-bf54f7f4cc0e"), "Inżynieria Środowiska" },
                    { new Guid("6233296a-f86c-4c96-ab8c-c5c3409ba0f5"), new Guid("1ca72503-5c6b-48fc-a5a0-28d17e662d83"), "Inżynieria Biomedyczna" },
                    { new Guid("4c559e9b-8302-497b-83d4-5478fafc9976"), new Guid("1ca72503-5c6b-48fc-a5a0-28d17e662d83"), "Inżynieria Materiałowa" },
                    { new Guid("1d29813f-61cb-48a8-83b0-8a80c2e0d4e5"), new Guid("1ca72503-5c6b-48fc-a5a0-28d17e662d83"), "Mechanika i Budowa Maszyn" },
                    { new Guid("b2199a8a-a5c0-4c2d-bbe1-d94479b51c4c"), new Guid("74de6b59-54f9-449f-b895-bf54f7f4cc0e"), "Budownictwo" },
                    { new Guid("359b3ce3-c3e9-40a8-9481-9f950c5b84fd"), new Guid("1ca72503-5c6b-48fc-a5a0-28d17e662d83"), "Zarządzanie i Inżynieria Produkcji" },
                    { new Guid("780bdacd-04aa-4919-873c-246e7b6c13a2"), new Guid("35095857-bb5a-4d2c-bf7d-94bae1eeed06"), "Elektronika i Telekomunikacja" },
                    { new Guid("8c1ec866-5ac9-4756-9468-df9e06804638"), new Guid("35095857-bb5a-4d2c-bf7d-94bae1eeed06"), "Teleinformatyka" },
                    { new Guid("47ce10ca-4612-4553-a065-2def9a55e2ba"), new Guid("7fa3fbf3-e14f-4942-8195-8d2693260dfd"), "Automatyka i Robotyka" },
                    { new Guid("10b6913f-e4ad-4886-b729-c21bbb33eddf"), new Guid("7fa3fbf3-e14f-4942-8195-8d2693260dfd"), "Elektrotechnika" },
                    { new Guid("c9f4acb5-5217-48a1-b734-95e73db5709b"), new Guid("1ca72503-5c6b-48fc-a5a0-28d17e662d83"), "Mechatronika" }
                });

            migrationBuilder.InsertData(
                table: "Promoters",
                columns: new[] { "Id", "ExpectedNumberOfBachelorProposals", "ExpectedNumberOfMasterProposals", "FirstName", "InstituteId", "LastName", "TitlePostfix", "TitlePrefix", "UserId" },
                values: new object[,]
                {
                    { new Guid("48aea09b-4be3-4372-88bc-d46d78a1552b"), 2, 1, "Jerzy", new Guid("5f23f0a6-d8ff-48d6-8af9-da4c59beb16a"), "Nawrocki", "prof. PP", "dr hab inż.", new Guid("32a29b01-4688-4de7-98e2-9183357a1fd3") },
                    { new Guid("9aabdabd-8d1b-4c38-a2d0-0f88dca17533"), 2, 1, "Wojciech", new Guid("5f23f0a6-d8ff-48d6-8af9-da4c59beb16a"), "Kotłowski", "", "dr hab. inż.", new Guid("008121fd-7e0b-4ff5-bc86-65ab0502da1a") },
                    { new Guid("4ae4e691-dcff-4236-94ca-c97c102bc66c"), 2, 1, "Miłosz", new Guid("5f23f0a6-d8ff-48d6-8af9-da4c59beb16a"), "Kadziński", "", "dr hab. inż.", new Guid("2e970899-3edd-41bb-9119-9685aee185a3") },
                    { new Guid("d979fc9c-94d3-419a-a4e9-014e5664b73c"), 2, 1, "Bartłomiej", new Guid("5f23f0a6-d8ff-48d6-8af9-da4c59beb16a"), "Prędki", "", "dr inż.", new Guid("d7fccab2-21c9-4a89-8f72-f0e342481692") },
                    { new Guid("7345a41b-36aa-4ae2-b0fe-b7bb4279603b"), 3, 2, "Krzysztof", new Guid("767083df-627d-4549-bf34-31d94855431b"), "Alejski", "prof. PP", "dr hab. inż.", new Guid("7e0d1efd-5265-4527-8d78-ea00678ae77f") },
                    { new Guid("fb23704f-cec8-48fb-aa79-f3bd0e7e293b"), 1, 1, "Katarzyna", new Guid("767083df-627d-4549-bf34-31d94855431b"), "Adamska", "", "dr inż.", new Guid("c91ff433-4a4f-496a-a7c9-1bf7f81ffaaf") },
                    { new Guid("2a21d8e5-575a-41d9-99ed-fbb5c06a3db9"), 2, 1, "Irmina", new Guid("5f23f0a6-d8ff-48d6-8af9-da4c59beb16a"), "Masłowska", "", "dr inż.", new Guid("32de6a04-27ce-4c4c-bc6f-3dc9863aa3b8") }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ProposalId", "Semester", "StudyLevel", "StudyMode", "UserId" },
                values: new object[,]
                {
                    { new Guid("6a8672dc-a7d0-4f15-a6d6-b14b6b8c98b9"), null, 6, 0, 0, new Guid("414b4914-be9c-4774-bb04-c0d3db715797") },
                    { new Guid("6e90bc48-ed5e-45c1-9226-af30a6d134eb"), null, 6, 0, 0, new Guid("e8a680ad-4d03-4805-bde5-53929e509d8d") },
                    { new Guid("9a3169d3-1751-4637-b057-4f9f5a4fa8ce"), null, 6, 0, 0, new Guid("dcab23ee-6e30-401e-a477-82d0747f4620") },
                    { new Guid("8c2f224a-38ee-4fc8-811d-09f2705990b2"), null, 6, 0, 0, new Guid("365a985a-a140-411a-b829-6c00124b0985") }
                });

            migrationBuilder.InsertData(
                table: "Proposals",
                columns: new[] { "Id", "CourseId", "Description", "Level", "MaxNumberOfStudents", "Mode", "OutputData", "PromoterId", "Specialization", "StartingDate", "Status", "StudyProfile", "TopicEnglish", "TopicPolish" },
                values: new object[,]
                {
                    { new Guid("6b596b4c-c2b6-4084-a628-e535824ce7a3"), new Guid("70780c06-63a0-4e07-a819-0821b5fa3d84"), "Celem pracy jest zaimplementowanie metod Electre 1s i Electre TRI jako aplikacji desktopowych.....", 0, 4, 0, "Brak danych", new Guid("2a21d8e5-575a-41d9-99ed-fbb5c06a3db9"), "-", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "Implementation of chosen methods from Electre family", "Implementacja wybranych metod z rodziny Electre" },
                    { new Guid("c11e5a70-1991-4dbc-9deb-53c24c1c55ac"), new Guid("70780c06-63a0-4e07-a819-0821b5fa3d84"), "Opis.....", 0, 4, 0, "Brak danych", new Guid("d979fc9c-94d3-419a-a4e9-014e5664b73c"), "-", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "Implementation of decision support methods based on utility function (UTA, Assess)", "Implementacja metod wspomagania decyzji opartych na funkcji użyteczności (UTA, Assess)" },
                    { new Guid("4f210ca3-e6d1-4ae1-b776-fe8ff0292247"), new Guid("70780c06-63a0-4e07-a819-0821b5fa3d84"), "Opis.....", 0, 4, 0, "Brak danych", new Guid("4ae4e691-dcff-4236-94ca-c97c102bc66c"), "-", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "Extension of diviz platform", "Rozszerzenie platformy diviz o metody wielokryterialnego wspomagania decyzji oparte na różnych modelach preferencji" },
                    { new Guid("67828e42-918c-4e7b-a381-aa279c785803"), new Guid("70780c06-63a0-4e07-a819-0821b5fa3d84"), "Opis.....", 0, 4, 0, "Brak danych", new Guid("9aabdabd-8d1b-4c38-a2d0-0f88dca17533"), "-", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "Style transfering using a neural network", "Transfer stylu przy użyciu sieci neuronowej" },
                    { new Guid("3444ec67-ee14-4546-8f04-786d27e0080a"), new Guid("70780c06-63a0-4e07-a819-0821b5fa3d84"), "Opis.....", 0, 4, 0, "Brak danych", new Guid("48aea09b-4be3-4372-88bc-d46d78a1552b"), "-", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "Capri 2 - system for managing diploma topic cards", "Capri 2 - system do zarządzania kartami tematów prac dyplomowych" },
                    { new Guid("a6c7e366-0f7b-43b5-baad-6edbbeb92bc7"), new Guid("eadc3557-5492-4085-b95e-a08f1d31e8b5"), "Praca będzie polegać na własnoręcznym upakowaniu kolumny chromatograficznej, doborze odpowiednich warunków pomiaru w celu wyznaczenia podstawowych parametrów dla niestandardowych kolumn do HPLC.", 0, 4, 0, "Brak danych", new Guid("fb23704f-cec8-48fb-aa79-f3bd0e7e293b"), "-", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "No title", "Wyznaczenie parametrów kolumny chromatograficznej za pomocą odwróconej chromatografii cieczowej" },
                    { new Guid("783b7d9b-8fbf-4612-a038-eb763158d34b"), new Guid("eadc3557-5492-4085-b95e-a08f1d31e8b5"), "Brak opisu", 1, 4, 0, "Brak danych", new Guid("7345a41b-36aa-4ae2-b0fe-b7bb4279603b"), "-", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "No title", "Analiza i projektowanie procesów wydzielania produktów otrzymywanych w procesie biokonwersji surowców odnawialnych" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_FacultyId",
                table: "Courses",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Faculties_Name",
                table: "Faculties",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Institutes_Name",
                table: "Institutes",
                column: "Name",
                unique: true);

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
