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
                    { new Guid("7938a0b8-3bdf-488f-974d-1f7420f6ec84"), "Wydział Architektury" },
                    { new Guid("35732b87-f9d6-4842-82c4-e75d7cf59245"), "Wydział Inżynierii Zarządzania" },
                    { new Guid("cbc8262c-09bb-4603-97ad-5b04d9087959"), "Wydział Inżynierii Transportu" },
                    { new Guid("fd427a28-b3fb-4800-922e-22eff30c15ad"), "Wydział Informatyki" },
                    { new Guid("1eaebd3a-3e9b-4123-b145-5ff452c549f8"), "Wydział Fizyki Technicznej" },
                    { new Guid("56084315-9fa7-4ff5-b2d3-942797ef7fbc"), "Wydział Technologii Chemicznej" },
                    { new Guid("2be3b2e7-90e3-464d-b886-6fe81981bf34"), "Wydział Elektroniki i Telekomunikacji" },
                    { new Guid("358c6f7d-8609-4c7f-bde0-79a916422fcb"), "Wydział Budowy Maszyn i Zarządzania" },
                    { new Guid("f8c69bc8-ff1f-480c-8481-feff7d081893"), "Wydział Budownictwa i Inżynierii Środowiska" },
                    { new Guid("649e24b3-658e-4f92-812f-76ae36dbc7ba"), "Wydział Elektryczny" }
                });

            migrationBuilder.InsertData(
                table: "Institutes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("9f4e9162-cf0c-4cf5-bfa9-c383ffc0d1a6"), "Instytut Informatyki" },
                    { new Guid("131dec9d-3818-4bec-a791-a957cbe1ebb9"), "Instytut Mechaniki Stosowanej" },
                    { new Guid("858830b2-6f9c-477f-b500-e7f4f46faf4f"), "Instytut Elektrotechniki i Elektroniki Przemysłowej" },
                    { new Guid("78d30756-498b-4fb3-8fdb-04b8d5bf6c6b"), "Instytut Chemii i Elektrochemii Technicznej" },
                    { new Guid("9ee19018-cf08-482e-8c9a-1fc5f33b75dd"), "Instytut Inżynierii Środowiska" },
                    { new Guid("266a358a-9b33-40f9-a1e1-2cd5c9b30b46"), "Instytut Inżynierii Lądowej" },
                    { new Guid("ff893bf5-156d-4c15-9843-f9ef919cfeba"), "Instytut Technologii Materiałów" },
                    { new Guid("42fc2fec-fcbc-4acf-b071-14545a38ec7f"), "Instytut Matematyki" },
                    { new Guid("92862397-85fa-45b6-9124-05609a70561f"), "Instytut Technologii Mechanicznej" },
                    { new Guid("2ef174a3-2a68-4dd0-b261-781720d68a86"), "Instytut Technologii i Inżynierii Chemicznej" },
                    { new Guid("29aef52a-8428-4207-82d7-891a22e37262"), "Instytut Architektury i Planowania Przestrzennego" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("300d9d53-c3a0-4e5f-811c-d2e14c577075"), "ef0914d9-c3ce-49b8-96e9-6daeb0ce6797", "dean", "dean" },
                    { new Guid("d4e24916-a640-47d2-99f5-43d2d399d94c"), "9ca70ca6-0d95-440a-a2dc-949b64419357", "student", "student" },
                    { new Guid("10fac6b8-1a1f-4438-8d40-1810490d175d"), "0832f754-7451-4689-9a09-73bf39a4ed03", "promoter", "promoter" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("e79fd317-cb4c-4e4c-a57b-7f3a95605c90"), new Guid("10fac6b8-1a1f-4438-8d40-1810490d175d"), new Guid("f6b9cce1-69ab-4a57-80f9-3ca1fd10bfb6") },
                    { new Guid("d4e12e13-babd-487d-b787-780dd508cac8"), new Guid("300d9d53-c3a0-4e5f-811c-d2e14c577075"), new Guid("02878cd2-f40f-401c-91ac-3c4acebd3c9e") },
                    { new Guid("8405d0ad-1eff-4698-bb41-29721df86e5f"), new Guid("300d9d53-c3a0-4e5f-811c-d2e14c577075"), new Guid("c79319c5-ebe0-4fdd-9f00-58e38a441234") },
                    { new Guid("fa9e5267-b015-4a05-912a-35118638d162"), new Guid("300d9d53-c3a0-4e5f-811c-d2e14c577075"), new Guid("57357705-a253-4160-98a0-18eae2783572") },
                    { new Guid("1e678f00-7a97-4a99-8df4-dedf5129d6ae"), new Guid("300d9d53-c3a0-4e5f-811c-d2e14c577075"), new Guid("1eb94068-22b1-41cb-ac93-26c8328a2711") },
                    { new Guid("c36981eb-7636-4cef-9554-3b0b57a98a51"), new Guid("d4e24916-a640-47d2-99f5-43d2d399d94c"), new Guid("4ed2b207-2a1d-4bfb-8bc3-3f74ddb094ad") },
                    { new Guid("22450dbc-d657-4d17-83d1-ed769a639f85"), new Guid("d4e24916-a640-47d2-99f5-43d2d399d94c"), new Guid("fe253e28-e788-49c0-8fbe-91f27c8db205") },
                    { new Guid("e644f011-bbe0-4e68-9c79-92a297d93a41"), new Guid("d4e24916-a640-47d2-99f5-43d2d399d94c"), new Guid("72ff5f39-7435-4ae9-abbc-fe52677b8834") },
                    { new Guid("4c8bdee5-a664-46b8-af38-b82749243b61"), new Guid("10fac6b8-1a1f-4438-8d40-1810490d175d"), new Guid("e88dd219-5c12-4e33-b4c5-1a31620fa8d4") },
                    { new Guid("db3e291f-9e46-4933-bb6d-9a1f96d37acf"), new Guid("10fac6b8-1a1f-4438-8d40-1810490d175d"), new Guid("e7118624-82ed-47bf-b92e-eaf3ae27174b") },
                    { new Guid("19682dda-0a0e-49f9-9bca-f96be35d1e78"), new Guid("10fac6b8-1a1f-4438-8d40-1810490d175d"), new Guid("31b0c1a9-b34f-4f0b-90ee-006dedecbfd5") },
                    { new Guid("f21f9fec-5cbe-4dfc-a470-3aba90dbc9db"), new Guid("10fac6b8-1a1f-4438-8d40-1810490d175d"), new Guid("e0b8f77e-f68a-467e-ba41-0d581c6e8069") },
                    { new Guid("3cbf4ac7-420d-4900-9a05-3a41c138990a"), new Guid("10fac6b8-1a1f-4438-8d40-1810490d175d"), new Guid("33a1f462-bd15-4c7f-9794-4ad5f0eb9c6c") },
                    { new Guid("95ab25af-e108-43af-8bab-2ef400696c4e"), new Guid("d4e24916-a640-47d2-99f5-43d2d399d94c"), new Guid("fce31e52-c600-445b-9226-72f01cd5c60e") },
                    { new Guid("48cd704c-83e2-4518-ad93-fb06a46ac82e"), new Guid("10fac6b8-1a1f-4438-8d40-1810490d175d"), new Guid("75224243-82c3-4137-8926-12af9dbbb4ff") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("fe253e28-e788-49c0-8fbe-91f27c8db205"), 0, "1f2114e4-2605-45c4-b93c-5ced8064d7b4", "student2@gmail.com", true, false, null, "STUDENT2@GMAIL.COM", "STUDENT2@GMAIL.COM", "AQAAAAEAACcQAAAAEDBpafVZbxXJUvmfe/XwAZgQYKe7QOwnQiksP/IrjQNzIUWEqTTcARPxY2gg6+ULNQ==", null, false, "", false, "student2@gmail.com" },
                    { new Guid("02878cd2-f40f-401c-91ac-3c4acebd3c9e"), 0, "7042e2b9-fa43-49b2-bb5c-29519cb0e595", "dean1@gmail.com", true, false, null, "DEAN1@GMAIL.COM", "DEAN1@GMAIL.COM", "AQAAAAEAACcQAAAAEGAv2pbUdcsNvn6qkfQ9yshsDJr+gw/qXyCvKDzRHnKBPgMheyB1c89VBm2THGoh7A==", null, false, "", false, "dean1@gmail.com" },
                    { new Guid("c79319c5-ebe0-4fdd-9f00-58e38a441234"), 0, "eed50f26-df87-48e1-ac7a-83cd4ca8a03a", "dean2@gmail.com", true, false, null, "DEAN2@GMAIL.COM", "DEAN2@GMAIL.COM", "AQAAAAEAACcQAAAAEHgapmBDaRdRyHQLb+dhabVsrxpkHjtHFKlQsu47JD4THQfOVO8AYwII4d6ck9S+Lg==", null, false, "", false, "dean2@gmail.com" },
                    { new Guid("4ed2b207-2a1d-4bfb-8bc3-3f74ddb094ad"), 0, "dccbdbed-ccb0-40e2-a055-e384a12ffcc0", "student1@gmail.com", true, false, null, "STUDENT1@GMAIL.COM", "STUDENT1@GMAIL.COM", "AQAAAAEAACcQAAAAEJJOnnrd9qjp/jiCLpnZhkwvQ9fmhyeCyMlv3N4U3iu+d2IMbKX0mqdi7CNJaQxaYA==", null, false, "", false, "student1@gmail.com" },
                    { new Guid("57357705-a253-4160-98a0-18eae2783572"), 0, "6156d019-47b7-4aef-8480-76418c5a9e61", "dean3@gmail.com", true, false, null, "DEAN3@GMAIL.COM", "DEAN3@GMAIL.COM", "AQAAAAEAACcQAAAAECXSMAX0mGFX7+R9mx7c8rHBjwyxFSGhC2SpXkiAI/peZR7LBlTjGc/f2FVAwBDKVQ==", null, false, "", false, "dean3@gmail.com" },
                    { new Guid("e88dd219-5c12-4e33-b4c5-1a31620fa8d4"), 0, "f9fc260f-fbf1-48f5-bac2-3507c3f4db17", "katarzyna.adamska@put.poznan.pl", true, false, null, "KATARZYNA.ADAMSKA@PUT.POZNAN.PL", "KATARZYNA.ADAMSKA@PUT.POZNAN.PL", "AQAAAAEAACcQAAAAEAVSMk7KPwQoMOCWlXxy9JEI7dOY20Hx/YcJab5hZyqa7HfFth7jL9rN44nXzvcUJA==", null, false, "", false, "katarzyna.adamska@put.poznan.pl" },
                    { new Guid("33a1f462-bd15-4c7f-9794-4ad5f0eb9c6c"), 0, "6d037985-2cd1-4323-9e90-95f42443e4ff", "jerzy.nawrocki@put.poznan.pl", true, false, null, "JERZY.NAWROCKI@PUT.POZNAN.PL", "JERZY.NAWROCKI@PUT.POZNAN.PL", "AQAAAAEAACcQAAAAEGnzWExzVZMw+DMRSA6BtCOu4HTUO7mnryI3bCRzNeQ+rl182v1BHRMv78mVNTPq1g==", null, false, "", false, "jerzy.nawrocki@put.poznan.pl" },
                    { new Guid("e0b8f77e-f68a-467e-ba41-0d581c6e8069"), 0, "10a68fa0-9152-4d3e-bfc3-0c6ca89bfa95", "wojciech.kotlowski@put.poznan.pl", true, false, null, "WOJCIECH.KOTLOWSKI@PUT.POZNAN.PL", "WOJCIECH.KOTLOWSKI@PUT.POZNAN.PL", "AQAAAAEAACcQAAAAEMnVLzZ/p6Vn09HRREy0AWn8EE30KUqH4qqOP9uLiinSZcq6E/vqsyRlj65oR1WXHA==", null, false, "", false, "wojciech.kotlowski@put.poznan.pl" },
                    { new Guid("31b0c1a9-b34f-4f0b-90ee-006dedecbfd5"), 0, "fcf2a260-648f-412e-9a59-8bb2c53b48ac", "milosz.kadzinski@put.poznan.pl", true, false, null, "MILOSZ.KADZINSKI@PUT.POZNAN.PL", "MILOSZ.KADZINSKI@PUT.POZNAN.PL", "AQAAAAEAACcQAAAAEFyzQ9fTY2k4X8HbZEYRiQhVUay4SqxYqzd9Xmn3J3wJFTHUpHe6sWoeNQMGlf2gwg==", null, false, "", false, "milosz.kadzinski@put.poznan.pl" },
                    { new Guid("1eb94068-22b1-41cb-ac93-26c8328a2711"), 0, "b8c2c252-1983-4fdf-8285-e6dafbf9f7ca", "dean4@gmail.com", true, false, null, "DEAN4@GMAIL.COM", "DEAN4@GMAIL.COM", "AQAAAAEAACcQAAAAEAU0XJKGXvjSl2DkZxoLXHDVSDoWabKIw7zMY8yVEwBP5ZbfcVBuXqe1PhHZN33NNw==", null, false, "", false, "dean4@gmail.com" },
                    { new Guid("f6b9cce1-69ab-4a57-80f9-3ca1fd10bfb6"), 0, "2789eb45-dffc-44e5-ba81-b33c06b92d4d", "irmina.maslowska@put.poznan.pl", true, false, null, "IRMINA.MASLOWSKA@PUT.POZNAN.PL", "IRMINA.MASLOWSKA@PUT.POZNAN.PL", "AQAAAAEAACcQAAAAEAo5gM89zGhS9DqT7tYV8SHQad3orRdONHBX9OxmuVfDKd/Rxi8VH8Emukg2hnUWhQ==", null, false, "", false, "irmina.maslowska@put.poznan.pl" },
                    { new Guid("72ff5f39-7435-4ae9-abbc-fe52677b8834"), 0, "ab188fd9-6705-4597-a0df-19e1298225ff", "student4@gmail.com", true, false, null, "STUDENT4@GMAIL.COM", "STUDENT4@GMAIL.COM", "AQAAAAEAACcQAAAAENGVPutn1nX3ZqQClc67ocB2egCrx2zMS2/TCSdpzrYtgZJB0J0vIlNqJnoBG/TupA==", null, false, "", false, "student4@gmail.com" },
                    { new Guid("fce31e52-c600-445b-9226-72f01cd5c60e"), 0, "4cda74d8-fa7f-4751-8e32-a9fdec9e502a", "student3@gmail.com", true, false, null, "STUDENT3@GMAIL.COM", "STUDENT3@GMAIL.COM", "AQAAAAEAACcQAAAAEFSdm47NQA5rhvhXrVK9a1g2rgcF6ToECgRKgT4VKH/wRemrzI5cp0gcA6u5se/8tQ==", null, false, "", false, "student3@gmail.com" },
                    { new Guid("75224243-82c3-4137-8926-12af9dbbb4ff"), 0, "680e9a91-be93-455a-8849-77d8e716ee55", "krzysztof.alejski@put.poznan.pl", true, false, null, "KRZYSZTOF.ALEJSKI@PUT.POZNAN.PL", "KRZYSZTOF.ALEJSKI@PUT.POZNAN.PL", "AQAAAAEAACcQAAAAEP/qXgGPG8msATrpz8m1i96O9lN9KYN3ILwi90/UF1nZMwIAj3WeRi5CmdlgrWV9yQ==", null, false, "", false, "krzysztof.alejski@put.poznan.pl" },
                    { new Guid("e7118624-82ed-47bf-b92e-eaf3ae27174b"), 0, "3047d284-2212-4373-9a4d-4ba1d8c2dbcf", "bartlomiej.predki@put.poznan.pl", true, false, null, "BARTLOMIEJ.PREDKI@PUT.POZNAN.PL", "BARTLOMIEJ.PREDKI@PUT.POZNAN.PL", "AQAAAAEAACcQAAAAEN4VtUnaSs8eHZo2M9Y9ZDwLib2myDpFmFOi1M8varf0Xx5OecnEYthODYFGYSncaQ==", null, false, "", false, "bartlomiej.predki@put.poznan.pl" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "FacultyId", "Name" },
                values: new object[,]
                {
                    { new Guid("1c46ad84-d2fb-432a-97e3-1e4f1a43a8c2"), new Guid("7938a0b8-3bdf-488f-974d-1f7420f6ec84"), "Architektura" },
                    { new Guid("86a9e7d6-8305-4926-b92e-077d47078d99"), new Guid("56084315-9fa7-4ff5-b2d3-942797ef7fbc"), "Inżynieria Farmaceutyczna" },
                    { new Guid("5a183ae9-7f58-4408-b5bf-dcda9fa014b2"), new Guid("56084315-9fa7-4ff5-b2d3-942797ef7fbc"), "Technologie Ochrony Środowiska" },
                    { new Guid("dc710801-e404-4abb-ab9d-284c2a986812"), new Guid("56084315-9fa7-4ff5-b2d3-942797ef7fbc"), "Technologia Chemiczna / Chemical Technology" },
                    { new Guid("7a3f2f4d-1eb1-43cf-8c50-9f52e3de4eb4"), new Guid("56084315-9fa7-4ff5-b2d3-942797ef7fbc"), "Inżynieria Chemiczna i Procesowa" },
                    { new Guid("305fbc16-81a2-4f5f-a1da-eec0dc43f516"), new Guid("35732b87-f9d6-4842-82c4-e75d7cf59245"), "Inżynieria Bezpieczeństwa" },
                    { new Guid("73969c22-c335-45f7-a27e-947ac34d01ef"), new Guid("35732b87-f9d6-4842-82c4-e75d7cf59245"), "Inżynieria Zarządzania" },
                    { new Guid("9137ff55-72bf-464e-a5d0-b58c369cab39"), new Guid("35732b87-f9d6-4842-82c4-e75d7cf59245"), "Logistyka" },
                    { new Guid("ca81fd16-1559-495d-9d85-6f2292716de9"), new Guid("cbc8262c-09bb-4603-97ad-5b04d9087959"), "Lotnictwo i Kosmonautyka" },
                    { new Guid("ff7d4ab7-a5c3-4152-bbb8-15502d6c89bd"), new Guid("cbc8262c-09bb-4603-97ad-5b04d9087959"), "Transport" },
                    { new Guid("563c8950-7942-48c1-aa1f-b3d278c47b20"), new Guid("fd427a28-b3fb-4800-922e-22eff30c15ad"), "Sztuczna Inteligencja / Artificial Intelligence" },
                    { new Guid("3c683c58-16fb-4067-9e52-02d483741022"), new Guid("fd427a28-b3fb-4800-922e-22eff30c15ad"), "Bioinformatyka" },
                    { new Guid("a3fcb965-2e4e-4a8f-9ad4-34098881f9cc"), new Guid("fd427a28-b3fb-4800-922e-22eff30c15ad"), "Informatyka" },
                    { new Guid("73270900-7890-47e0-bb27-2119265cc8f3"), new Guid("1eaebd3a-3e9b-4123-b145-5ff452c549f8"), "Fizyka Techniczna" },
                    { new Guid("2c2ee488-639c-4b8d-8efe-ec979c1d2319"), new Guid("1eaebd3a-3e9b-4123-b145-5ff452c549f8"), "Edukacja Techniczno-Informatyczna" },
                    { new Guid("60f5fe71-bfea-4dc8-a4bc-3af66ab008f7"), new Guid("cbc8262c-09bb-4603-97ad-5b04d9087959"), "Konstrukcja i Eksploatacja Środków Transportu" },
                    { new Guid("111a1029-4cef-4ff6-b823-6279075d22ae"), new Guid("649e24b3-658e-4f92-812f-76ae36dbc7ba"), "Energetyka" },
                    { new Guid("95c30f34-0c00-4641-bf6f-3ceb5433f549"), new Guid("7938a0b8-3bdf-488f-974d-1f7420f6ec84"), "Architektura Wnętrz" },
                    { new Guid("a4a29fde-5376-4251-aeb7-de5a70365f1c"), new Guid("649e24b3-658e-4f92-812f-76ae36dbc7ba"), "Matematyka w Technice" },
                    { new Guid("ba7963d2-50da-40c0-b631-03af9cd7ee39"), new Guid("f8c69bc8-ff1f-480c-8481-feff7d081893"), "Inżynieria Środowiska" },
                    { new Guid("51fc51a5-c0e8-4e86-b082-3594dcf54e34"), new Guid("358c6f7d-8609-4c7f-bde0-79a916422fcb"), "Inżynieria Biomedyczna" },
                    { new Guid("326c5e20-f6eb-4377-a364-b1acaada7cc5"), new Guid("358c6f7d-8609-4c7f-bde0-79a916422fcb"), "Inżynieria Materiałowa" },
                    { new Guid("d5a838ef-3215-466b-b501-ecb620d29c1c"), new Guid("358c6f7d-8609-4c7f-bde0-79a916422fcb"), "Mechanika i Budowa Maszyn" },
                    { new Guid("f0c44b9a-c8bf-4a8d-bc37-d8cb971fe333"), new Guid("f8c69bc8-ff1f-480c-8481-feff7d081893"), "Budownictwo" },
                    { new Guid("6f105593-aa5a-4e77-b683-c051d44fda20"), new Guid("358c6f7d-8609-4c7f-bde0-79a916422fcb"), "Zarządzanie i Inżynieria Produkcji" },
                    { new Guid("a8ea5085-57bb-47da-92ae-258083691737"), new Guid("2be3b2e7-90e3-464d-b886-6fe81981bf34"), "Elektronika i Telekomunikacja" },
                    { new Guid("a66bbba9-5f13-4432-a808-942ba934bd02"), new Guid("2be3b2e7-90e3-464d-b886-6fe81981bf34"), "Teleinformatyka" },
                    { new Guid("416091ac-c0e7-4b59-88d0-a9e8ac6715e1"), new Guid("649e24b3-658e-4f92-812f-76ae36dbc7ba"), "Automatyka i Robotyka" },
                    { new Guid("19c142ff-7961-4404-a279-74cc89cd2120"), new Guid("649e24b3-658e-4f92-812f-76ae36dbc7ba"), "Elektrotechnika" },
                    { new Guid("17c8c553-9c5a-4096-aa9a-f22d2065b8d5"), new Guid("358c6f7d-8609-4c7f-bde0-79a916422fcb"), "Mechatronika" }
                });

            migrationBuilder.InsertData(
                table: "Promoters",
                columns: new[] { "Id", "ExpectedNumberOfBachelorProposals", "ExpectedNumberOfMasterProposals", "FirstName", "InstituteId", "LastName", "TitlePostfix", "TitlePrefix", "UserId" },
                values: new object[,]
                {
                    { new Guid("48aea09b-4be3-4372-88bc-d46d78a1552b"), 2, 1, "Jerzy", new Guid("9f4e9162-cf0c-4cf5-bfa9-c383ffc0d1a6"), "Nawrocki", "prof. PP", "dr hab inż.", new Guid("33a1f462-bd15-4c7f-9794-4ad5f0eb9c6c") },
                    { new Guid("9aabdabd-8d1b-4c38-a2d0-0f88dca17533"), 2, 1, "Wojciech", new Guid("9f4e9162-cf0c-4cf5-bfa9-c383ffc0d1a6"), "Kotłowski", "", "dr hab. inż.", new Guid("e0b8f77e-f68a-467e-ba41-0d581c6e8069") },
                    { new Guid("4ae4e691-dcff-4236-94ca-c97c102bc66c"), 2, 1, "Miłosz", new Guid("9f4e9162-cf0c-4cf5-bfa9-c383ffc0d1a6"), "Kadziński", "", "dr hab. inż.", new Guid("31b0c1a9-b34f-4f0b-90ee-006dedecbfd5") },
                    { new Guid("d979fc9c-94d3-419a-a4e9-014e5664b73c"), 2, 1, "Bartłomiej", new Guid("9f4e9162-cf0c-4cf5-bfa9-c383ffc0d1a6"), "Prędki", "", "dr inż.", new Guid("e7118624-82ed-47bf-b92e-eaf3ae27174b") },
                    { new Guid("7345a41b-36aa-4ae2-b0fe-b7bb4279603b"), 3, 2, "Krzysztof", new Guid("2ef174a3-2a68-4dd0-b261-781720d68a86"), "Alejski", "prof. PP", "dr hab. inż.", new Guid("75224243-82c3-4137-8926-12af9dbbb4ff") },
                    { new Guid("fb23704f-cec8-48fb-aa79-f3bd0e7e293b"), 1, 1, "Katarzyna", new Guid("2ef174a3-2a68-4dd0-b261-781720d68a86"), "Adamska", "", "dr inż.", new Guid("e88dd219-5c12-4e33-b4c5-1a31620fa8d4") },
                    { new Guid("2a21d8e5-575a-41d9-99ed-fbb5c06a3db9"), 2, 1, "Irmina", new Guid("9f4e9162-cf0c-4cf5-bfa9-c383ffc0d1a6"), "Masłowska", "", "dr inż.", new Guid("f6b9cce1-69ab-4a57-80f9-3ca1fd10bfb6") }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ProposalId", "UserId" },
                values: new object[,]
                {
                    { new Guid("89d41b58-aa83-49b3-ab47-4f20c87b382d"), null, new Guid("72ff5f39-7435-4ae9-abbc-fe52677b8834") },
                    { new Guid("04abc5d8-0db1-46e9-9b75-aa9ef5b890b0"), null, new Guid("fe253e28-e788-49c0-8fbe-91f27c8db205") },
                    { new Guid("d439ea51-2792-42be-8b13-1b714d00e48f"), null, new Guid("4ed2b207-2a1d-4bfb-8bc3-3f74ddb094ad") },
                    { new Guid("24f95fea-fb3f-4d3a-9331-c2dc2898a864"), null, new Guid("fce31e52-c600-445b-9226-72f01cd5c60e") }
                });

            migrationBuilder.InsertData(
                table: "Proposals",
                columns: new[] { "Id", "CourseId", "Description", "Level", "MaxNumberOfStudents", "Mode", "OutputData", "PromoterId", "Specialization", "StartingDate", "Status", "StudyProfile", "TopicEnglish", "TopicPolish" },
                values: new object[,]
                {
                    { new Guid("1ac41dae-a5db-4133-83a4-8e381af9f1ef"), new Guid("a3fcb965-2e4e-4a8f-9ad4-34098881f9cc"), "Celem pracy jest zaimplementowanie metod Electre 1s i Electre TRI jako aplikacji desktopowych.....", 0, 0, 0, "Brak danych", new Guid("2a21d8e5-575a-41d9-99ed-fbb5c06a3db9"), "-", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "Implementation of chosen methods from Electre family", "Implementacja wybranych metod z rodziny Electre" },
                    { new Guid("baeeea76-a307-47b7-9f7c-5ba2a0b7898d"), new Guid("a3fcb965-2e4e-4a8f-9ad4-34098881f9cc"), "Opis.....", 0, 0, 0, "Brak danych", new Guid("d979fc9c-94d3-419a-a4e9-014e5664b73c"), "-", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "Implementation of decision support methods based on utility function (UTA, Assess)", "Implementacja metod wspomagania decyzji opartych na funkcji użyteczności (UTA, Assess)" },
                    { new Guid("d121fd44-2d24-49c2-a62c-0e62ce2443a3"), new Guid("a3fcb965-2e4e-4a8f-9ad4-34098881f9cc"), "Opis.....", 0, 0, 0, "Brak danych", new Guid("4ae4e691-dcff-4236-94ca-c97c102bc66c"), "-", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "Extension of diviz platform", "Rozszerzenie platformy diviz o metody wielokryterialnego wspomagania decyzji oparte na różnych modelach preferencji" },
                    { new Guid("676a6b2c-0a85-45b9-97a3-42a324e09500"), new Guid("a3fcb965-2e4e-4a8f-9ad4-34098881f9cc"), "Opis.....", 0, 0, 0, "Brak danych", new Guid("9aabdabd-8d1b-4c38-a2d0-0f88dca17533"), "-", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "Style transfering using a neural network", "Transfer stylu przy użyciu sieci neuronowej" },
                    { new Guid("f79c11c6-3a14-47ec-84a7-7df8381300ca"), new Guid("a3fcb965-2e4e-4a8f-9ad4-34098881f9cc"), "Opis.....", 0, 0, 0, "Brak danych", new Guid("48aea09b-4be3-4372-88bc-d46d78a1552b"), "-", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "Capri 2 - system for managing diploma topic cards", "Capri 2 - system do zarządzania kartami tematów prac dyplomowych" },
                    { new Guid("71684a41-96e3-4f61-a3ef-8e16108547f6"), new Guid("7a3f2f4d-1eb1-43cf-8c50-9f52e3de4eb4"), "Praca będzie polegać na własnoręcznym upakowaniu kolumny chromatograficznej, doborze odpowiednich warunków pomiaru w celu wyznaczenia podstawowych parametrów dla niestandardowych kolumn do HPLC.", 0, 0, 0, "Brak danych", new Guid("fb23704f-cec8-48fb-aa79-f3bd0e7e293b"), "-", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "No title", "Wyznaczenie parametrów kolumny chromatograficznej za pomocą odwróconej chromatografii cieczowej" },
                    { new Guid("2910829d-696e-4de8-a3d5-554dc260a21d"), new Guid("7a3f2f4d-1eb1-43cf-8c50-9f52e3de4eb4"), "Brak opisu", 1, 0, 0, "Brak danych", new Guid("7345a41b-36aa-4ae2-b0fe-b7bb4279603b"), "-", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "No title", "Analiza i projektowanie procesów wydzielania produktów otrzymywanych w procesie biokonwersji surowców odnawialnych" }
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
