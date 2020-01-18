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
                    IndexNumber = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
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
                    { new Guid("86ef5494-f5be-458e-810e-6717e029462d"), "Wydział Architektury" },
                    { new Guid("c11f638b-c64a-449b-8469-09669a040426"), "Wydział Inżynierii Zarządzania" },
                    { new Guid("bc387aa9-4bd6-4fbb-a8dc-7c934bf1e86f"), "Wydział Inżynierii Transportu" },
                    { new Guid("2a115952-a7d4-41ff-b004-3dbcd6784a77"), "Wydział Informatyki" },
                    { new Guid("c613d91a-2c53-4d58-b50c-934368b92222"), "Wydział Fizyki Technicznej" },
                    { new Guid("35359070-2a4a-4f4e-80a5-fb51392df559"), "Wydział Technologii Chemicznej" },
                    { new Guid("20da3e1f-33d0-4adf-b0d9-7635d364d66e"), "Wydział Elektroniki i Telekomunikacji" },
                    { new Guid("0309c3f3-3c50-43b8-8e8e-4ac688975198"), "Wydział Budowy Maszyn i Zarządzania" },
                    { new Guid("5dfc5d47-1dc0-469c-a2b9-b18bb6c2b0d6"), "Wydział Budownictwa i Inżynierii Środowiska" },
                    { new Guid("35323056-2b0c-46f5-832e-f138d53a21c0"), "Wydział Elektryczny" }
                });

            migrationBuilder.InsertData(
                table: "Institutes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2b6aba15-f94d-40d8-8987-a61938462d9e"), "Instytut Informatyki" },
                    { new Guid("a2e32b58-d3ea-4dd4-8d0a-7e1f0f3b76c0"), "Instytut Mechaniki Stosowanej" },
                    { new Guid("aaf84d52-faee-43a1-bcfd-44e8f4dc3163"), "Instytut Elektrotechniki i Elektroniki Przemysłowej" },
                    { new Guid("a7208887-1003-4c72-a5d9-d2fb169e26b4"), "Instytut Chemii i Elektrochemii Technicznej" },
                    { new Guid("1ec70ec3-835c-4868-81bb-b0381705d536"), "Instytut Inżynierii Środowiska" },
                    { new Guid("bcfede50-d761-471f-af22-11730426fc2d"), "Instytut Inżynierii Lądowej" },
                    { new Guid("5a68865a-8e62-4af5-8dd0-a71c4ed3e14b"), "Instytut Technologii Materiałów" },
                    { new Guid("4f0ad8df-8817-4320-b919-99db8911ecd3"), "Instytut Matematyki" },
                    { new Guid("64a968fc-d969-4600-8ae1-381ec07521f8"), "Instytut Technologii Mechanicznej" },
                    { new Guid("043be15e-505f-4f7a-ab03-810661aca602"), "Instytut Technologii i Inżynierii Chemicznej" },
                    { new Guid("1734b16b-2f52-489f-a8d3-9b7c9ca3336d"), "Instytut Architektury i Planowania Przestrzennego" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("ddf2657b-f313-4f1c-8a72-859648e3c7b8"), "bc53f6cb-ee10-4174-a924-664aa2c620c1", "Dean", "Dean" },
                    { new Guid("a7b9b785-2981-4c90-8b8c-6d4705ffc34c"), "5f90384c-9351-41fb-b642-2cd5e0fc3ab7", "Student", "Student" },
                    { new Guid("88e13d98-6ce6-453b-a0e8-349b30490f2d"), "3f7d9c1d-0654-4857-8402-aef6825c5a64", "Promoter", "Promoter" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId", "Id" },
                values: new object[,]
                {
                    { new Guid("e7185974-4f61-4acf-8d90-cae62501a502"), new Guid("88e13d98-6ce6-453b-a0e8-349b30490f2d"), new Guid("d79ea29c-91ee-409e-abf8-bc13c008db91") },
                    { new Guid("10a5da4f-5480-405b-8a3b-429cdf019059"), new Guid("ddf2657b-f313-4f1c-8a72-859648e3c7b8"), new Guid("99e6f47a-c81b-4275-937e-68878b3b001c") },
                    { new Guid("719d1278-36c2-40c4-900e-e08be0ffe979"), new Guid("ddf2657b-f313-4f1c-8a72-859648e3c7b8"), new Guid("a68818a2-c08d-42f9-acc0-4b1a17d4760b") },
                    { new Guid("f8a75861-cc22-4396-90c0-0376b982b497"), new Guid("ddf2657b-f313-4f1c-8a72-859648e3c7b8"), new Guid("b51180ea-8202-4ee2-9194-f65a76231b88") },
                    { new Guid("e60007bd-4b69-42c8-a1f7-dbb1a261f839"), new Guid("ddf2657b-f313-4f1c-8a72-859648e3c7b8"), new Guid("27920de9-9141-4446-9c96-09713fdc096d") },
                    { new Guid("f09a9d3c-0ac0-464f-8407-6eb7c7218681"), new Guid("a7b9b785-2981-4c90-8b8c-6d4705ffc34c"), new Guid("9c046456-e42c-4682-b68d-749f3e57c926") },
                    { new Guid("604cae1d-e388-4284-85bf-19bd61d6cf66"), new Guid("a7b9b785-2981-4c90-8b8c-6d4705ffc34c"), new Guid("e8c00f2c-98dc-4616-aa74-1b9db623ba39") },
                    { new Guid("cc234eb6-a1e6-452a-9bed-67d9ce984269"), new Guid("a7b9b785-2981-4c90-8b8c-6d4705ffc34c"), new Guid("3fb47560-7a4d-4760-abf6-d2a9d469b423") },
                    { new Guid("6940aa20-587c-4a95-8702-2b38103d7ca1"), new Guid("88e13d98-6ce6-453b-a0e8-349b30490f2d"), new Guid("e11d1528-412a-45fa-b06f-c3285d220380") },
                    { new Guid("93472e84-0ffa-4a4f-9ab6-3e039007a499"), new Guid("88e13d98-6ce6-453b-a0e8-349b30490f2d"), new Guid("aebb504f-3954-4247-a560-9183561b885e") },
                    { new Guid("55c6f5f3-f432-41bd-a000-043868b75689"), new Guid("88e13d98-6ce6-453b-a0e8-349b30490f2d"), new Guid("6b89023a-af17-4393-887d-600635fb0302") },
                    { new Guid("cd7c38f2-4fe7-46d0-87a8-91465ae74925"), new Guid("88e13d98-6ce6-453b-a0e8-349b30490f2d"), new Guid("b12e5d90-5e28-4b14-9f79-daa449dcd7e7") },
                    { new Guid("2c8f7f14-950d-49a7-824f-66a114fb1ec0"), new Guid("88e13d98-6ce6-453b-a0e8-349b30490f2d"), new Guid("c9a334ac-445a-4e65-9271-c2147625ded1") },
                    { new Guid("754cfe79-028d-4d79-a44f-20567d418aa7"), new Guid("a7b9b785-2981-4c90-8b8c-6d4705ffc34c"), new Guid("c5e62d75-d6bc-400e-8208-4719fabf2b42") },
                    { new Guid("38ef7969-2cec-41e1-a851-3b07f6432a4d"), new Guid("88e13d98-6ce6-453b-a0e8-349b30490f2d"), new Guid("90ba96fe-a2cf-434b-b503-46368b4caec0") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("604cae1d-e388-4284-85bf-19bd61d6cf66"), 0, "0c5ba37b-8a76-45d3-9ed6-413cf1fc2bde", "student2@gmail.com", true, false, null, "STUDENT2@GMAIL.COM", "STUDENT2@GMAIL.COM", "AQAAAAEAACcQAAAAEPPirA1C/G7cvHmMLE/7REiNf7mDBdwYJThpQB1gX+vElcNjzFGNRYBLG8+006CkXw==", null, false, "", false, "student2@gmail.com" },
                    { new Guid("10a5da4f-5480-405b-8a3b-429cdf019059"), 0, "6cf01668-bb77-4666-bee4-24b66e8ec63f", "dean1@gmail.com", true, false, null, "DEAN1@GMAIL.COM", "DEAN1@GMAIL.COM", "AQAAAAEAACcQAAAAEDOF4tpSYk0lR9pZAoZxFGlJS2n7COu3Mo2JOFRr0EW8r+zcJpm9FDoO/EnOo8y7dQ==", null, false, "", false, "dean1@gmail.com" },
                    { new Guid("719d1278-36c2-40c4-900e-e08be0ffe979"), 0, "715bc33a-0a99-4dc2-a9ac-34d53fffaa70", "dean2@gmail.com", true, false, null, "DEAN2@GMAIL.COM", "DEAN2@GMAIL.COM", "AQAAAAEAACcQAAAAEPuD6yeM1/zglNWOQMOxGSiUGHd52cfZmBgnZLtU96/K0MMkagB7wgyAAsyNj12ygQ==", null, false, "", false, "dean2@gmail.com" },
                    { new Guid("f09a9d3c-0ac0-464f-8407-6eb7c7218681"), 0, "5a79db51-f253-4c58-8bda-01b7cada8e07", "student1@gmail.com", true, false, null, "STUDENT1@GMAIL.COM", "STUDENT1@GMAIL.COM", "AQAAAAEAACcQAAAAEO8f+0HIX1AOrEACIUvs/gJOw4VywQ2f/fFdQvlAFn7SQoJeXImOzRV9qrgQVzTQ2Q==", null, false, "", false, "student1@gmail.com" },
                    { new Guid("f8a75861-cc22-4396-90c0-0376b982b497"), 0, "4dd73337-0775-47e6-a2f6-2993e231aeca", "dean3@gmail.com", true, false, null, "DEAN3@GMAIL.COM", "DEAN3@GMAIL.COM", "AQAAAAEAACcQAAAAEGU4ZOIQw2RGCCrTHIhkck86g4C/KnZx5BCE2hNrKuYk8IHyEWZsI0A1xTCk/fmM3g==", null, false, "", false, "dean3@gmail.com" },
                    { new Guid("6940aa20-587c-4a95-8702-2b38103d7ca1"), 0, "c0765c96-e717-423e-a4b7-3d0d66e60ae3", "katarzyna.adamska@put.poznan.pl", true, false, null, "KATARZYNA.ADAMSKA@PUT.POZNAN.PL", "KATARZYNA.ADAMSKA@PUT.POZNAN.PL", "AQAAAAEAACcQAAAAEO2WqNxt87Z79tkRh0qJ8BcpN+D2M7OXu13miG6vyv9RwNvxxMNuFEGTck1UOv3Gxg==", null, false, "", false, "katarzyna.adamska@put.poznan.pl" },
                    { new Guid("2c8f7f14-950d-49a7-824f-66a114fb1ec0"), 0, "95d101f0-98cd-477a-aefd-8f79c17e67e7", "jerzy.nawrocki@put.poznan.pl", true, false, null, "JERZY.NAWROCKI@PUT.POZNAN.PL", "JERZY.NAWROCKI@PUT.POZNAN.PL", "AQAAAAEAACcQAAAAEGvN9vk6n3E9wmrVsGDZEOmhjGt9vJX2N0PSTCZgBgi+UgfxwLP8vVLt3TefcGli7w==", null, false, "", false, "jerzy.nawrocki@put.poznan.pl" },
                    { new Guid("cd7c38f2-4fe7-46d0-87a8-91465ae74925"), 0, "68795e70-b5f0-43eb-8dbf-2ec190d5e834", "wojciech.kotlowski@put.poznan.pl", true, false, null, "WOJCIECH.KOTLOWSKI@PUT.POZNAN.PL", "WOJCIECH.KOTLOWSKI@PUT.POZNAN.PL", "AQAAAAEAACcQAAAAECopdNr2TebxIfXvBEZVxeQqot9TxrfhLoBbju9WhwX9j5EtogsthslcPiDBXvrBlw==", null, false, "", false, "wojciech.kotlowski@put.poznan.pl" },
                    { new Guid("55c6f5f3-f432-41bd-a000-043868b75689"), 0, "cbe5be6b-6600-4e3e-9317-eb893e017c77", "milosz.kadzinski@put.poznan.pl", true, false, null, "MILOSZ.KADZINSKI@PUT.POZNAN.PL", "MILOSZ.KADZINSKI@PUT.POZNAN.PL", "AQAAAAEAACcQAAAAEKjWflXqy5fsBqlQzGe9Uz9Wvd+kV0XAh2BaxpB3oUK3tkVsMrP0zb9VKqw0ZtelRQ==", null, false, "", false, "milosz.kadzinski@put.poznan.pl" },
                    { new Guid("e60007bd-4b69-42c8-a1f7-dbb1a261f839"), 0, "3fced1b2-47e0-4f70-bad7-247978a955fa", "dean4@gmail.com", true, false, null, "DEAN4@GMAIL.COM", "DEAN4@GMAIL.COM", "AQAAAAEAACcQAAAAEL+ZxE3wz+X6JDGHCZmaTdOLu451gK/I/GG1QJpkS4nQQIxYSGsbe2kPI9cTqp77Hw==", null, false, "", false, "dean4@gmail.com" },
                    { new Guid("e7185974-4f61-4acf-8d90-cae62501a502"), 0, "43265e62-9288-4853-bb05-c339d843ddb5", "irmina.maslowska@put.poznan.pl", true, false, null, "IRMINA.MASLOWSKA@PUT.POZNAN.PL", "IRMINA.MASLOWSKA@PUT.POZNAN.PL", "AQAAAAEAACcQAAAAEIkREAMaO7FXNTJ2AaODb+Isf2el306C+REqZj7j1WDvciOBzoqiofO+0Fa/6Yb12w==", null, false, "", false, "irmina.maslowska@put.poznan.pl" },
                    { new Guid("cc234eb6-a1e6-452a-9bed-67d9ce984269"), 0, "c80d73a8-3b5e-4948-a888-280faa315913", "student4@gmail.com", true, false, null, "STUDENT4@GMAIL.COM", "STUDENT4@GMAIL.COM", "AQAAAAEAACcQAAAAEM5Qso/st+/LHsItlge238xc7Dm5zVxLdkSqJkv/bb16gu1cNCAfUcwnRdLrMLY6JQ==", null, false, "", false, "student4@gmail.com" },
                    { new Guid("754cfe79-028d-4d79-a44f-20567d418aa7"), 0, "069781c4-54f5-45d7-a1a0-175e30292f25", "student3@gmail.com", true, false, null, "STUDENT3@GMAIL.COM", "STUDENT3@GMAIL.COM", "AQAAAAEAACcQAAAAEHD8i6oTXb6NbzQdPy3Dwm1lDwswWd/CuXc+C4gOdmIFUh4NJPEP8941ZPIEa128Pw==", null, false, "", false, "student3@gmail.com" },
                    { new Guid("38ef7969-2cec-41e1-a851-3b07f6432a4d"), 0, "88f082f5-9b2e-4fa0-8ce5-b3694f6f7d1f", "krzysztof.alejski@put.poznan.pl", true, false, null, "KRZYSZTOF.ALEJSKI@PUT.POZNAN.PL", "KRZYSZTOF.ALEJSKI@PUT.POZNAN.PL", "AQAAAAEAACcQAAAAEKbP11+upx5lQSUiH/KdKb0hnveBh6X22mfygN2Wc0eCRKuN5KsRfzqiBC02G39r+A==", null, false, "", false, "krzysztof.alejski@put.poznan.pl" },
                    { new Guid("93472e84-0ffa-4a4f-9ab6-3e039007a499"), 0, "aa9bbd5d-8ed2-45fc-b25e-d0ab6bf123e1", "bartlomiej.predki@put.poznan.pl", true, false, null, "BARTLOMIEJ.PREDKI@PUT.POZNAN.PL", "BARTLOMIEJ.PREDKI@PUT.POZNAN.PL", "AQAAAAEAACcQAAAAEOcXmSeCsSPW+B3lPBiotmbp/IQ4AFMF/MI5oowtWn+t/xkZ16b5vd2u8JYSDiUE9g==", null, false, "", false, "bartlomiej.predki@put.poznan.pl" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "FacultyId", "Name" },
                values: new object[,]
                {
                    { new Guid("8706ef96-680b-4ca2-b61c-293b8316eb37"), new Guid("86ef5494-f5be-458e-810e-6717e029462d"), "Architektura" },
                    { new Guid("0ad0a86f-3c16-489d-b9b4-bce6b122f11b"), new Guid("35359070-2a4a-4f4e-80a5-fb51392df559"), "Inżynieria Farmaceutyczna" },
                    { new Guid("55d0b3fa-6f62-4cab-881a-b5155c9133be"), new Guid("35359070-2a4a-4f4e-80a5-fb51392df559"), "Technologie Ochrony Środowiska" },
                    { new Guid("36e4af90-a084-4c0c-b689-b809bf4f29a5"), new Guid("35359070-2a4a-4f4e-80a5-fb51392df559"), "Technologia Chemiczna / Chemical Technology" },
                    { new Guid("40d9ab3a-78a5-47db-8cd6-d0adc64fec53"), new Guid("35359070-2a4a-4f4e-80a5-fb51392df559"), "Inżynieria Chemiczna i Procesowa" },
                    { new Guid("766ab3ca-8042-458c-87c8-c551ac1c971a"), new Guid("c11f638b-c64a-449b-8469-09669a040426"), "Inżynieria Bezpieczeństwa" },
                    { new Guid("3fd34819-ff74-4b75-ba1d-b93b49a6133f"), new Guid("c11f638b-c64a-449b-8469-09669a040426"), "Inżynieria Zarządzania" },
                    { new Guid("20863f48-4023-46c3-9f74-e0c90c301f3a"), new Guid("c11f638b-c64a-449b-8469-09669a040426"), "Logistyka" },
                    { new Guid("87332169-77eb-476e-8d07-e24eaeebf46d"), new Guid("bc387aa9-4bd6-4fbb-a8dc-7c934bf1e86f"), "Lotnictwo i Kosmonautyka" },
                    { new Guid("1f207388-f813-4ea7-8087-fd59540c61b5"), new Guid("bc387aa9-4bd6-4fbb-a8dc-7c934bf1e86f"), "Transport" },
                    { new Guid("f0ff5ec9-0a01-4ef0-8c90-4b029270c768"), new Guid("2a115952-a7d4-41ff-b004-3dbcd6784a77"), "Sztuczna Inteligencja / Artificial Intelligence" },
                    { new Guid("c58ebb37-0c37-499b-98fc-06b25bb2ca3d"), new Guid("2a115952-a7d4-41ff-b004-3dbcd6784a77"), "Bioinformatyka" },
                    { new Guid("20cf1115-275d-4cc5-b931-4a03e1d8cd1e"), new Guid("2a115952-a7d4-41ff-b004-3dbcd6784a77"), "Informatyka" },
                    { new Guid("78f607e3-625f-4837-9ff5-02724803d4c0"), new Guid("c613d91a-2c53-4d58-b50c-934368b92222"), "Fizyka Techniczna" },
                    { new Guid("70884a68-4f23-4426-9c11-b563d549837c"), new Guid("c613d91a-2c53-4d58-b50c-934368b92222"), "Edukacja Techniczno-Informatyczna" },
                    { new Guid("fa449e55-236a-4338-bda5-5aa14a791032"), new Guid("bc387aa9-4bd6-4fbb-a8dc-7c934bf1e86f"), "Konstrukcja i Eksploatacja Środków Transportu" },
                    { new Guid("574c2b79-3a49-45cc-aa7a-a8e5d04bb014"), new Guid("35323056-2b0c-46f5-832e-f138d53a21c0"), "Energetyka" },
                    { new Guid("c5b26ec0-7383-4dee-bcb1-641e1d75808c"), new Guid("86ef5494-f5be-458e-810e-6717e029462d"), "Architektura Wnętrz" },
                    { new Guid("22fe93cb-f0a6-423d-bfba-5afc9fc3444a"), new Guid("35323056-2b0c-46f5-832e-f138d53a21c0"), "Matematyka w Technice" },
                    { new Guid("b81a71a1-152e-4091-ad02-ef4fb1ca2dee"), new Guid("5dfc5d47-1dc0-469c-a2b9-b18bb6c2b0d6"), "Inżynieria Środowiska" },
                    { new Guid("2d8e61f2-3110-44ef-9cc3-58992d2c11da"), new Guid("0309c3f3-3c50-43b8-8e8e-4ac688975198"), "Inżynieria Biomedyczna" },
                    { new Guid("841619c3-f4d1-472a-b0bb-6e31077e3391"), new Guid("0309c3f3-3c50-43b8-8e8e-4ac688975198"), "Inżynieria Materiałowa" },
                    { new Guid("23682890-8cfe-4426-8cff-df21e2b9d70a"), new Guid("0309c3f3-3c50-43b8-8e8e-4ac688975198"), "Mechanika i Budowa Maszyn" },
                    { new Guid("02deab5b-6bd3-437c-bd19-a663e0cc883f"), new Guid("5dfc5d47-1dc0-469c-a2b9-b18bb6c2b0d6"), "Budownictwo" },
                    { new Guid("40491792-581f-4ecf-bb8d-691965d2f7cb"), new Guid("0309c3f3-3c50-43b8-8e8e-4ac688975198"), "Zarządzanie i Inżynieria Produkcji" },
                    { new Guid("50fae299-6ef3-402a-9d0a-6db0913d22ab"), new Guid("20da3e1f-33d0-4adf-b0d9-7635d364d66e"), "Elektronika i Telekomunikacja" },
                    { new Guid("b8e5fdb3-8b12-4c6c-a636-458c0ea82bb0"), new Guid("20da3e1f-33d0-4adf-b0d9-7635d364d66e"), "Teleinformatyka" },
                    { new Guid("0fa1ef4e-d472-44ff-a7a3-07252dbe3dcc"), new Guid("35323056-2b0c-46f5-832e-f138d53a21c0"), "Automatyka i Robotyka" },
                    { new Guid("5ca080fe-248b-49eb-ad47-c3e6f7315f2a"), new Guid("35323056-2b0c-46f5-832e-f138d53a21c0"), "Elektrotechnika" },
                    { new Guid("65a8f725-cb98-4588-a3fc-6530685db71f"), new Guid("0309c3f3-3c50-43b8-8e8e-4ac688975198"), "Mechatronika" }
                });

            migrationBuilder.InsertData(
                table: "Promoters",
                columns: new[] { "Id", "ExpectedNumberOfBachelorProposals", "ExpectedNumberOfMasterProposals", "FirstName", "InstituteId", "LastName", "TitlePostfix", "TitlePrefix", "UserId" },
                values: new object[,]
                {
                    { new Guid("48aea09b-4be3-4372-88bc-d46d78a1552b"), 2, 1, "Jerzy", new Guid("2b6aba15-f94d-40d8-8987-a61938462d9e"), "Nawrocki", "prof. PP", "dr hab inż.", new Guid("2c8f7f14-950d-49a7-824f-66a114fb1ec0") },
                    { new Guid("9aabdabd-8d1b-4c38-a2d0-0f88dca17533"), 2, 1, "Wojciech", new Guid("2b6aba15-f94d-40d8-8987-a61938462d9e"), "Kotłowski", "", "dr hab. inż.", new Guid("cd7c38f2-4fe7-46d0-87a8-91465ae74925") },
                    { new Guid("4ae4e691-dcff-4236-94ca-c97c102bc66c"), 2, 1, "Miłosz", new Guid("2b6aba15-f94d-40d8-8987-a61938462d9e"), "Kadziński", "", "dr hab. inż.", new Guid("55c6f5f3-f432-41bd-a000-043868b75689") },
                    { new Guid("d979fc9c-94d3-419a-a4e9-014e5664b73c"), 2, 1, "Bartłomiej", new Guid("2b6aba15-f94d-40d8-8987-a61938462d9e"), "Prędki", "", "dr inż.", new Guid("93472e84-0ffa-4a4f-9ab6-3e039007a499") },
                    { new Guid("7345a41b-36aa-4ae2-b0fe-b7bb4279603b"), 3, 2, "Krzysztof", new Guid("043be15e-505f-4f7a-ab03-810661aca602"), "Alejski", "prof. PP", "dr hab. inż.", new Guid("38ef7969-2cec-41e1-a851-3b07f6432a4d") },
                    { new Guid("fb23704f-cec8-48fb-aa79-f3bd0e7e293b"), 1, 1, "Katarzyna", new Guid("043be15e-505f-4f7a-ab03-810661aca602"), "Adamska", "", "dr inż.", new Guid("6940aa20-587c-4a95-8702-2b38103d7ca1") },
                    { new Guid("2a21d8e5-575a-41d9-99ed-fbb5c06a3db9"), 2, 1, "Irmina", new Guid("2b6aba15-f94d-40d8-8987-a61938462d9e"), "Masłowska", "", "dr inż.", new Guid("e7185974-4f61-4acf-8d90-cae62501a502") }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FirstName", "IndexNumber", "LastName", "ProposalId", "Semester", "StudyLevel", "StudyMode", "UserId" },
                values: new object[,]
                {
                    { new Guid("52470168-8608-42c9-84ac-b083e8e122ae"), "Andrzej", 132204, "Król", null, 6, 0, 0, new Guid("cc234eb6-a1e6-452a-9bed-67d9ce984269") },
                    { new Guid("0f96c786-df22-497d-87e7-d6625268d7f9"), "Marcin", 132202, "Zawadzki", null, 6, 0, 0, new Guid("604cae1d-e388-4284-85bf-19bd61d6cf66") },
                    { new Guid("0e03b621-b456-469a-b8b2-6d52e1fed7ef"), "Filip", 132201, "Cegielski", null, 6, 0, 0, new Guid("f09a9d3c-0ac0-464f-8407-6eb7c7218681") },
                    { new Guid("5d3894af-9918-4224-a827-bdb2fbeaecbe"), "Szymon", 132203, "Wójcik", null, 6, 0, 0, new Guid("754cfe79-028d-4d79-a44f-20567d418aa7") }
                });

            migrationBuilder.InsertData(
                table: "Proposals",
                columns: new[] { "Id", "CourseId", "Description", "Level", "MaxNumberOfStudents", "Mode", "OutputData", "PromoterId", "Specialization", "StartingDate", "Status", "StudyProfile", "TopicEnglish", "TopicPolish" },
                values: new object[,]
                {
                    { new Guid("06dc60c5-2d38-4b83-ba03-fdcd2d101d16"), new Guid("20cf1115-275d-4cc5-b931-4a03e1d8cd1e"), "Celem pracy jest zaimplementowanie metod Electre 1s i Electre TRI jako aplikacji desktopowych.....", 0, 4, 0, "Brak danych", new Guid("2a21d8e5-575a-41d9-99ed-fbb5c06a3db9"), "-", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "Implementation of chosen methods from Electre family", "Implementacja wybranych metod z rodziny Electre" },
                    { new Guid("a9bc47c5-03b8-431b-add9-303c210633e3"), new Guid("20cf1115-275d-4cc5-b931-4a03e1d8cd1e"), "Opis.....", 0, 4, 0, "Brak danych", new Guid("d979fc9c-94d3-419a-a4e9-014e5664b73c"), "-", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "Implementation of decision support methods based on utility function (UTA, Assess)", "Implementacja metod wspomagania decyzji opartych na funkcji użyteczności (UTA, Assess)" },
                    { new Guid("36d4a426-cbb5-495e-aa16-8a1640d1d81d"), new Guid("20cf1115-275d-4cc5-b931-4a03e1d8cd1e"), "Opis.....", 0, 4, 0, "Brak danych", new Guid("4ae4e691-dcff-4236-94ca-c97c102bc66c"), "-", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "Extension of diviz platform", "Rozszerzenie platformy diviz o metody wielokryterialnego wspomagania decyzji oparte na różnych modelach preferencji" },
                    { new Guid("f567eb85-1d80-4db8-82d3-f7c15e8e46ee"), new Guid("20cf1115-275d-4cc5-b931-4a03e1d8cd1e"), "Opis.....", 0, 4, 0, "Brak danych", new Guid("9aabdabd-8d1b-4c38-a2d0-0f88dca17533"), "-", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "Style transfering using a neural network", "Transfer stylu przy użyciu sieci neuronowej" },
                    { new Guid("57debcce-6ac7-4d3a-92fa-ada9481bbc52"), new Guid("20cf1115-275d-4cc5-b931-4a03e1d8cd1e"), "Opis.....", 0, 4, 0, "Brak danych", new Guid("48aea09b-4be3-4372-88bc-d46d78a1552b"), "-", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "Capri 2 - system for managing diploma topic cards", "Capri 2 - system do zarządzania kartami tematów prac dyplomowych" },
                    { new Guid("60135938-7517-4329-a333-f16ed9cc3c90"), new Guid("40d9ab3a-78a5-47db-8cd6-d0adc64fec53"), "Praca będzie polegać na własnoręcznym upakowaniu kolumny chromatograficznej, doborze odpowiednich warunków pomiaru w celu wyznaczenia podstawowych parametrów dla niestandardowych kolumn do HPLC.", 0, 4, 0, "Brak danych", new Guid("fb23704f-cec8-48fb-aa79-f3bd0e7e293b"), "-", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "No title", "Wyznaczenie parametrów kolumny chromatograficznej za pomocą odwróconej chromatografii cieczowej" },
                    { new Guid("dd83cd53-0c38-4f7a-9a4d-1b77abc1cfd5"), new Guid("40d9ab3a-78a5-47db-8cd6-d0adc64fec53"), "Brak opisu", 1, 4, 0, "Brak danych", new Guid("7345a41b-36aa-4ae2-b0fe-b7bb4279603b"), "-", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "No title", "Analiza i projektowanie procesów wydzielania produktów otrzymywanych w procesie biokonwersji surowców odnawialnych" }
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
                name: "IX_Students_IndexNumber",
                table: "Students",
                column: "IndexNumber",
                unique: true);

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
