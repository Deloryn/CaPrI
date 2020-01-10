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
                    { new Guid("da480316-43e7-4d27-a530-5d31d489e818"), "Wydział Architektury" },
                    { new Guid("77448c20-20d1-484f-b773-9a2addab9841"), "Wydział Inżynierii Zarządzania" },
                    { new Guid("4edcfa46-1689-46d2-9142-7cb2b00d96c2"), "Wydział Inżynierii Transportu" },
                    { new Guid("d2f3e024-5219-4b50-8e43-cb3948359671"), "Wydział Informatyki" },
                    { new Guid("38b58743-dfd7-4be6-894c-5c36d8b9a908"), "Wydział Fizyki Technicznej" },
                    { new Guid("e7d3b852-1caa-47cc-969a-5eeddd21e48c"), "Wydział Technologii Chemicznej" },
                    { new Guid("c44fa4ca-c966-4fff-a710-d77992b02750"), "Wydział Elektroniki i Telekomunikacji" },
                    { new Guid("b547f48c-eeaf-4aea-a72f-b227d3bdc034"), "Wydział Budowy Maszyn i Zarządzania" },
                    { new Guid("9c087bbe-068f-48c1-bde3-99171ada674c"), "Wydział Budownictwa i Inżynierii Środowiska" },
                    { new Guid("72c46ad9-15c6-4a2f-8799-3dc72e5347f6"), "Wydział Elektryczny" }
                });

            migrationBuilder.InsertData(
                table: "Institutes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("a2fbb6c4-4769-46ba-a55d-0707eb8de4a4"), "Instytut Informatyki" },
                    { new Guid("ef34dd01-00ce-4085-b278-4ab8801a129e"), "Instytut Mechaniki Stosowanej" },
                    { new Guid("f0360e1f-0977-4476-8fe9-4cd288afc349"), "Instytut Elektrotechniki i Elektroniki Przemysłowej" },
                    { new Guid("dc876d77-a425-415d-a97b-6f12962164d4"), "Instytut Chemii i Elektrochemii Technicznej" },
                    { new Guid("1e562620-9280-42be-843e-8d594cece35b"), "Instytut Inżynierii Środowiska" },
                    { new Guid("91a86ddd-86b6-4bcc-82e3-8aaa2f1f741c"), "Instytut Inżynierii Lądowej" },
                    { new Guid("7eed4644-f5b0-4330-a757-88a113b6ee2e"), "Instytut Technologii Materiałów" },
                    { new Guid("399e6399-8b71-4a86-99b4-3c1b8867302d"), "Instytut Matematyki" },
                    { new Guid("d8712502-5c83-4299-affa-8c217a4c99fa"), "Instytut Technologii Mechanicznej" },
                    { new Guid("a9760a07-dfac-403e-ac9f-f6386f1fd6bd"), "Instytut Technologii i Inżynierii Chemicznej" },
                    { new Guid("83aaaae9-e0c5-4ba1-a3a1-d6b47449a789"), "Instytut Architektury i Planowania Przestrzennego" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("aa07acea-8110-40f3-9bdb-6369749106b7"), "10cb18b4-bb03-49d4-888c-61100303c87b", "dean", "dean" },
                    { new Guid("c01c613c-5ab1-40af-9667-b0e1d72f481d"), "a8d5be8e-a812-4e25-afe8-2460804fd06a", "student", "student" },
                    { new Guid("ffa9b417-447d-41da-8f04-b960ea54a305"), "4a0c232d-b918-4c90-bf37-bf62be8ee801", "promoter", "promoter" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("1aaf7a09-2056-4706-b7de-87a15dfc9b9e"), new Guid("ffa9b417-447d-41da-8f04-b960ea54a305"), new Guid("e985da90-a106-492e-8f4e-0f34a589244e") },
                    { new Guid("116f4ddf-99b7-41a0-8fc1-74273f2ee8e8"), new Guid("aa07acea-8110-40f3-9bdb-6369749106b7"), new Guid("fcea29c3-1542-4dc6-9c4a-4fbcaadac34d") },
                    { new Guid("7bca3eec-4186-497b-8815-7d94ad8717e0"), new Guid("aa07acea-8110-40f3-9bdb-6369749106b7"), new Guid("d6f83679-4245-4bf3-bfe2-b8b76b5d37e0") },
                    { new Guid("a45d1067-fde3-475e-ab5b-f3ea2b1de71d"), new Guid("aa07acea-8110-40f3-9bdb-6369749106b7"), new Guid("85a79eea-33b1-4de7-840f-6e7011c49729") },
                    { new Guid("fe3f5061-faeb-49cd-b476-ffe492e05a57"), new Guid("aa07acea-8110-40f3-9bdb-6369749106b7"), new Guid("c5e63a6a-a7f0-425d-beee-c073471fd77a") },
                    { new Guid("bb328a1d-0215-480b-b8a6-916def4efc77"), new Guid("c01c613c-5ab1-40af-9667-b0e1d72f481d"), new Guid("332a1c73-0058-4594-993d-b843dba83942") },
                    { new Guid("3af850ac-c162-4641-a2d1-fedc11ae7a26"), new Guid("c01c613c-5ab1-40af-9667-b0e1d72f481d"), new Guid("d17181da-7939-48dd-9849-5ba5d9d2b2aa") },
                    { new Guid("4cbe6280-6c4d-4a36-826a-9ec613ee1fe4"), new Guid("c01c613c-5ab1-40af-9667-b0e1d72f481d"), new Guid("d467e8c7-93cf-4fd4-a935-61be37b22b96") },
                    { new Guid("64e207b9-9882-4872-ae42-fbf31352ce75"), new Guid("ffa9b417-447d-41da-8f04-b960ea54a305"), new Guid("0625cc0d-57e7-4082-889b-e06e5e738bdb") },
                    { new Guid("69561be5-7b89-4d78-8cfa-00c5e6e9aa17"), new Guid("ffa9b417-447d-41da-8f04-b960ea54a305"), new Guid("dea5d287-75c5-4bd0-88bd-f46ace0298ee") },
                    { new Guid("bfe6020b-184d-449c-a831-304b0d11d513"), new Guid("ffa9b417-447d-41da-8f04-b960ea54a305"), new Guid("5e0135f5-a37f-4dc0-bd9b-0314df51cf5d") },
                    { new Guid("8466ef23-f581-44e2-90cf-7786b16108e7"), new Guid("ffa9b417-447d-41da-8f04-b960ea54a305"), new Guid("6e765418-13c0-4cd6-850d-eff7b0da6726") },
                    { new Guid("775893e2-58dc-45a8-ba2c-d8fdee730173"), new Guid("ffa9b417-447d-41da-8f04-b960ea54a305"), new Guid("1f364e39-216c-4b30-b036-7904ce5052f7") },
                    { new Guid("11f11671-4a81-40da-b4f6-5509908b5845"), new Guid("c01c613c-5ab1-40af-9667-b0e1d72f481d"), new Guid("f0cd5bd8-9ea2-481d-94c1-f6cad5304c86") },
                    { new Guid("e2427d7c-f327-4b81-bb3a-469d90dd5aee"), new Guid("ffa9b417-447d-41da-8f04-b960ea54a305"), new Guid("0f74716e-0d32-427a-b0b2-38f4edb0f215") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("d17181da-7939-48dd-9849-5ba5d9d2b2aa"), 0, "0a66526d-c7c9-4b94-bfe5-9bd1f7d39974", "student2@gmail.com", true, false, null, "STUDENT2@GMAIL.COM", "STUDENT2@GMAIL.COM", "AQAAAAEAACcQAAAAEB+/+5lRUtnLFNBX/454A+zZEES4OGI1N0XFcmV7jjN7tsM2y31QjEM6DuwtWml8kg==", null, false, "", false, "student2@gmail.com" },
                    { new Guid("fcea29c3-1542-4dc6-9c4a-4fbcaadac34d"), 0, "29f1dbc6-c342-4171-8a9f-03182cd89b08", "dean1@gmail.com", true, false, null, "DEAN1@GMAIL.COM", "DEAN1@GMAIL.COM", "AQAAAAEAACcQAAAAEC1h7NN4p2uX9RmLD59arO/jO1H1i5yqw1l1U2MHk3Z7qbXcbG3B0A/e8FhdVUVQ3Q==", null, false, "", false, "dean1@gmail.com" },
                    { new Guid("d6f83679-4245-4bf3-bfe2-b8b76b5d37e0"), 0, "8f2932b7-6f43-47fc-9d9a-bf4c548d5690", "dean2@gmail.com", true, false, null, "DEAN2@GMAIL.COM", "DEAN2@GMAIL.COM", "AQAAAAEAACcQAAAAEBsSzrFiExCtghb/8h5lVO011f2lMqX/aKoU57qaisCk/+xwKvseJ1SPZQcMVWIkjQ==", null, false, "", false, "dean2@gmail.com" },
                    { new Guid("332a1c73-0058-4594-993d-b843dba83942"), 0, "220b71cd-e95b-4e28-9ce5-e230c78dfdf8", "student1@gmail.com", true, false, null, "STUDENT1@GMAIL.COM", "STUDENT1@GMAIL.COM", "AQAAAAEAACcQAAAAEEoUHJqVobfXvYU7vj/Pe5ewJhlXPELmD3lgJLXF91ITPjAjwI56g3W2vLXPSirTPQ==", null, false, "", false, "student1@gmail.com" },
                    { new Guid("85a79eea-33b1-4de7-840f-6e7011c49729"), 0, "0236176e-14d8-4613-bcbd-5825c5c35bf6", "dean3@gmail.com", true, false, null, "DEAN3@GMAIL.COM", "DEAN3@GMAIL.COM", "AQAAAAEAACcQAAAAEBpesy303SD8YK7aMWNn1oKM0j4x0eh6aqruqEsFknatIouepnduKVMuWs5Ku7Qm0Q==", null, false, "", false, "dean3@gmail.com" },
                    { new Guid("0625cc0d-57e7-4082-889b-e06e5e738bdb"), 0, "3d927959-a2e6-43fa-8b31-07efd3016efb", "katarzyna.adamska@put.poznan.pl", true, false, null, "KATARZYNA.ADAMSKA@PUT.POZNAN.PL", "KATARZYNA.ADAMSKA@PUT.POZNAN.PL", "AQAAAAEAACcQAAAAEAWFoBRXX25onfP/XxH6OSNaPAq+NXdDvNDzRnaoKlqaxo7lg8OTnteoOR3K6Spc5A==", null, false, "", false, "katarzyna.adamska@put.poznan.pl" },
                    { new Guid("1f364e39-216c-4b30-b036-7904ce5052f7"), 0, "60f3c5c0-f90c-437a-8536-8a0daed3b599", "jerzy.nawrocki@put.poznan.pl", true, false, null, "JERZY.NAWROCKI@PUT.POZNAN.PL", "JERZY.NAWROCKI@PUT.POZNAN.PL", "AQAAAAEAACcQAAAAEMsXzAdqL/9bXYzv7WUSSin3P87jiA/ko7U5E0DYYPpeAySvz43IB/aW4VjganXm3g==", null, false, "", false, "jerzy.nawrocki@put.poznan.pl" },
                    { new Guid("6e765418-13c0-4cd6-850d-eff7b0da6726"), 0, "7999d96a-54ca-4ea6-a848-bc9dbad2d00a", "wojciech.kotlowski@put.poznan.pl", true, false, null, "WOJCIECH.KOTLOWSKI@PUT.POZNAN.PL", "WOJCIECH.KOTLOWSKI@PUT.POZNAN.PL", "AQAAAAEAACcQAAAAED7d4JJX4vlslZqwopcewTURA6TjeU2deYJOrsuqGc/S+CmxeNh/B5AizaZfV/wU/A==", null, false, "", false, "wojciech.kotlowski@put.poznan.pl" },
                    { new Guid("5e0135f5-a37f-4dc0-bd9b-0314df51cf5d"), 0, "6fe3e990-7c3f-460c-9e2b-f54ad77290d2", "milosz.kadzinski@put.poznan.pl", true, false, null, "MILOSZ.KADZINSKI@PUT.POZNAN.PL", "MILOSZ.KADZINSKI@PUT.POZNAN.PL", "AQAAAAEAACcQAAAAELpLO2G3FvPfyRag8gWP02D04ZK/ZaGIKzMnUFRPIinjqzfLFSUISmBL3IMHBrFZLA==", null, false, "", false, "milosz.kadzinski@put.poznan.pl" },
                    { new Guid("c5e63a6a-a7f0-425d-beee-c073471fd77a"), 0, "fe365e3e-dd28-4d18-810a-7cece7a28349", "dean4@gmail.com", true, false, null, "DEAN4@GMAIL.COM", "DEAN4@GMAIL.COM", "AQAAAAEAACcQAAAAEAbLlwiDVTs8ZsmzMSlzDgLpyv71usHGAcqZ43EESs57H1mwPrTKJK82kYdBfIS65Q==", null, false, "", false, "dean4@gmail.com" },
                    { new Guid("e985da90-a106-492e-8f4e-0f34a589244e"), 0, "035aa1be-55ad-4ebb-b32d-a262a732eca6", "irmina.maslowska@put.poznan.pl", true, false, null, "IRMINA.MASLOWSKA@PUT.POZNAN.PL", "IRMINA.MASLOWSKA@PUT.POZNAN.PL", "AQAAAAEAACcQAAAAEJUl9915Jg3dxGtfbWEbj22wJopCikC1W83DMpIs6D0WuD7KMJPpyQG7KMBhBXh0LA==", null, false, "", false, "irmina.maslowska@put.poznan.pl" },
                    { new Guid("d467e8c7-93cf-4fd4-a935-61be37b22b96"), 0, "6a0b88db-d0ef-4154-a88c-0d6c758c6e20", "student4@gmail.com", true, false, null, "STUDENT4@GMAIL.COM", "STUDENT4@GMAIL.COM", "AQAAAAEAACcQAAAAEImQ2eXbdU2OQaQ55bXEWyY6FN2Yf/02fbTZ1vmzcEHzW9sEYuk+JruVMY82dMy35g==", null, false, "", false, "student4@gmail.com" },
                    { new Guid("f0cd5bd8-9ea2-481d-94c1-f6cad5304c86"), 0, "c248dfbd-cd25-45a6-b70e-5926da285cdc", "student3@gmail.com", true, false, null, "STUDENT3@GMAIL.COM", "STUDENT3@GMAIL.COM", "AQAAAAEAACcQAAAAED1f12lLid9rAHmTHTHseJVlfCS4xzvcIP0KKPOmDYEneQN0CPohwd5bemCE5XYVwQ==", null, false, "", false, "student3@gmail.com" },
                    { new Guid("0f74716e-0d32-427a-b0b2-38f4edb0f215"), 0, "dbcd18ec-b0e4-4e9a-a551-c87bf580b203", "krzysztof.alejski@put.poznan.pl", true, false, null, "KRZYSZTOF.ALEJSKI@PUT.POZNAN.PL", "KRZYSZTOF.ALEJSKI@PUT.POZNAN.PL", "AQAAAAEAACcQAAAAEKVWTBkj2UNtJS15ndNxko4L7Ev+aUvDpPtUwN4mnHQ9PmAYUIHM/YrP6S96h1LodA==", null, false, "", false, "krzysztof.alejski@put.poznan.pl" },
                    { new Guid("dea5d287-75c5-4bd0-88bd-f46ace0298ee"), 0, "41432f01-a34a-4c63-a32b-ecfcfa7169e5", "bartlomiej.predki@put.poznan.pl", true, false, null, "BARTLOMIEJ.PREDKI@PUT.POZNAN.PL", "BARTLOMIEJ.PREDKI@PUT.POZNAN.PL", "AQAAAAEAACcQAAAAEKTfAsFSr2GcP+BqmGROFj/kuEhUKcYoDkooILWfi8JdzN2ZLC8FUr8hErlWaiQVqQ==", null, false, "", false, "bartlomiej.predki@put.poznan.pl" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "FacultyId", "Name" },
                values: new object[,]
                {
                    { new Guid("99d30330-0398-442e-ab8a-a723b542c642"), new Guid("da480316-43e7-4d27-a530-5d31d489e818"), "Architektura" },
                    { new Guid("79fbb178-60f2-4e23-8e7f-8e75ebe2e326"), new Guid("e7d3b852-1caa-47cc-969a-5eeddd21e48c"), "Inżynieria Farmaceutyczna" },
                    { new Guid("3fb3628e-6bfa-408b-ac75-741f3cb2a6e1"), new Guid("e7d3b852-1caa-47cc-969a-5eeddd21e48c"), "Technologie Ochrony Środowiska" },
                    { new Guid("c8d3ff57-500a-4784-8843-14a86201f09e"), new Guid("e7d3b852-1caa-47cc-969a-5eeddd21e48c"), "Technologia Chemiczna / Chemical Technology" },
                    { new Guid("9ee27f18-1893-468b-b7a7-641d8e060e6e"), new Guid("e7d3b852-1caa-47cc-969a-5eeddd21e48c"), "Inżynieria Chemiczna i Procesowa" },
                    { new Guid("3671dd26-139e-4c98-b4cd-1a73a7cdd66c"), new Guid("77448c20-20d1-484f-b773-9a2addab9841"), "Inżynieria Bezpieczeństwa" },
                    { new Guid("543a844d-00a6-4b91-bc91-fc91b071a804"), new Guid("77448c20-20d1-484f-b773-9a2addab9841"), "Inżynieria Zarządzania" },
                    { new Guid("fbd863c8-fe4a-477b-b241-f216305b7487"), new Guid("77448c20-20d1-484f-b773-9a2addab9841"), "Logistyka" },
                    { new Guid("69a63029-326f-4759-8181-47cfd1826696"), new Guid("4edcfa46-1689-46d2-9142-7cb2b00d96c2"), "Lotnictwo i Kosmonautyka" },
                    { new Guid("2991a7bd-1f64-4643-89c5-8e4743527752"), new Guid("4edcfa46-1689-46d2-9142-7cb2b00d96c2"), "Transport" },
                    { new Guid("e2b02379-dab7-4047-b7d6-8576c60aeba5"), new Guid("d2f3e024-5219-4b50-8e43-cb3948359671"), "Sztuczna Inteligencja / Artificial Intelligence" },
                    { new Guid("f497d9c9-fec1-4f2a-8240-2ef8042efc02"), new Guid("d2f3e024-5219-4b50-8e43-cb3948359671"), "Bioinformatyka" },
                    { new Guid("99feed76-24e5-45e1-bd75-684c46c8f435"), new Guid("d2f3e024-5219-4b50-8e43-cb3948359671"), "Informatyka" },
                    { new Guid("c33e1523-aace-4bcf-9525-bc65b9474090"), new Guid("38b58743-dfd7-4be6-894c-5c36d8b9a908"), "Fizyka Techniczna" },
                    { new Guid("37ed66c7-d11a-4473-a391-e003e7ea90e2"), new Guid("38b58743-dfd7-4be6-894c-5c36d8b9a908"), "Edukacja Techniczno-Informatyczna" },
                    { new Guid("97e989e6-b869-4736-ac81-ed6b78298b87"), new Guid("4edcfa46-1689-46d2-9142-7cb2b00d96c2"), "Konstrukcja i Eksploatacja Środków Transportu" },
                    { new Guid("06137145-922f-4572-aa3f-25bfb696cc56"), new Guid("72c46ad9-15c6-4a2f-8799-3dc72e5347f6"), "Energetyka" },
                    { new Guid("53d15d63-d3c6-40cf-8235-be76027a6819"), new Guid("da480316-43e7-4d27-a530-5d31d489e818"), "Architektura Wnętrz" },
                    { new Guid("aea9e41b-c496-4ca6-8f5c-7e09bb54b61f"), new Guid("72c46ad9-15c6-4a2f-8799-3dc72e5347f6"), "Matematyka w Technice" },
                    { new Guid("bbfb0b71-e42a-4371-8346-4f09108f7557"), new Guid("9c087bbe-068f-48c1-bde3-99171ada674c"), "Inżynieria Środowiska" },
                    { new Guid("3c68c746-ac0f-47d2-80b9-f701f54a5bf1"), new Guid("b547f48c-eeaf-4aea-a72f-b227d3bdc034"), "Inżynieria Biomedyczna" },
                    { new Guid("0bc905f1-a00a-40f4-b047-ee94f5962d1a"), new Guid("b547f48c-eeaf-4aea-a72f-b227d3bdc034"), "Inżynieria Materiałowa" },
                    { new Guid("a7d521e5-29c0-440c-b981-7bf6d319bb90"), new Guid("b547f48c-eeaf-4aea-a72f-b227d3bdc034"), "Mechanika i Budowa Maszyn" },
                    { new Guid("f14c0f38-647a-4cac-a2a4-a5aedafdc787"), new Guid("9c087bbe-068f-48c1-bde3-99171ada674c"), "Budownictwo" },
                    { new Guid("b87294db-52c7-4f5f-a21e-a0a3d5dea5b2"), new Guid("b547f48c-eeaf-4aea-a72f-b227d3bdc034"), "Zarządzanie i Inżynieria Produkcji" },
                    { new Guid("67813ac4-8e5e-43b3-98b6-47f0d2d8b208"), new Guid("c44fa4ca-c966-4fff-a710-d77992b02750"), "Elektronika i Telekomunikacja" },
                    { new Guid("7047e1c4-a099-49dd-adc6-b2fce4f7b1ca"), new Guid("c44fa4ca-c966-4fff-a710-d77992b02750"), "Teleinformatyka" },
                    { new Guid("fb87a183-09bb-4e6b-8177-44d2fc68dc4d"), new Guid("72c46ad9-15c6-4a2f-8799-3dc72e5347f6"), "Automatyka i Robotyka" },
                    { new Guid("4d163beb-2f56-46c2-90bf-45b382959c47"), new Guid("72c46ad9-15c6-4a2f-8799-3dc72e5347f6"), "Elektrotechnika" },
                    { new Guid("8a37703e-70a1-4814-884c-c6d84fdf743e"), new Guid("b547f48c-eeaf-4aea-a72f-b227d3bdc034"), "Mechatronika" }
                });

            migrationBuilder.InsertData(
                table: "Promoters",
                columns: new[] { "Id", "ExpectedNumberOfBachelorProposals", "ExpectedNumberOfMasterProposals", "FirstName", "InstituteId", "LastName", "TitlePostfix", "TitlePrefix", "UserId" },
                values: new object[,]
                {
                    { new Guid("48aea09b-4be3-4372-88bc-d46d78a1552b"), 2, 1, "Jerzy", new Guid("a2fbb6c4-4769-46ba-a55d-0707eb8de4a4"), "Nawrocki", "prof. PP", "dr hab inż.", new Guid("1f364e39-216c-4b30-b036-7904ce5052f7") },
                    { new Guid("9aabdabd-8d1b-4c38-a2d0-0f88dca17533"), 2, 1, "Wojciech", new Guid("a2fbb6c4-4769-46ba-a55d-0707eb8de4a4"), "Kotłowski", "", "dr hab. inż.", new Guid("6e765418-13c0-4cd6-850d-eff7b0da6726") },
                    { new Guid("4ae4e691-dcff-4236-94ca-c97c102bc66c"), 2, 1, "Miłosz", new Guid("a2fbb6c4-4769-46ba-a55d-0707eb8de4a4"), "Kadziński", "", "dr hab. inż.", new Guid("5e0135f5-a37f-4dc0-bd9b-0314df51cf5d") },
                    { new Guid("d979fc9c-94d3-419a-a4e9-014e5664b73c"), 2, 1, "Bartłomiej", new Guid("a2fbb6c4-4769-46ba-a55d-0707eb8de4a4"), "Prędki", "", "dr inż.", new Guid("dea5d287-75c5-4bd0-88bd-f46ace0298ee") },
                    { new Guid("7345a41b-36aa-4ae2-b0fe-b7bb4279603b"), 3, 2, "Krzysztof", new Guid("a9760a07-dfac-403e-ac9f-f6386f1fd6bd"), "Alejski", "prof. PP", "dr hab. inż.", new Guid("0f74716e-0d32-427a-b0b2-38f4edb0f215") },
                    { new Guid("fb23704f-cec8-48fb-aa79-f3bd0e7e293b"), 1, 1, "Katarzyna", new Guid("a9760a07-dfac-403e-ac9f-f6386f1fd6bd"), "Adamska", "", "dr inż.", new Guid("0625cc0d-57e7-4082-889b-e06e5e738bdb") },
                    { new Guid("2a21d8e5-575a-41d9-99ed-fbb5c06a3db9"), 2, 1, "Irmina", new Guid("a2fbb6c4-4769-46ba-a55d-0707eb8de4a4"), "Masłowska", "", "dr inż.", new Guid("e985da90-a106-492e-8f4e-0f34a589244e") }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ProposalId", "UserId" },
                values: new object[,]
                {
                    { new Guid("98854562-f305-4409-884d-4e548f83c0a1"), null, new Guid("d467e8c7-93cf-4fd4-a935-61be37b22b96") },
                    { new Guid("4af33581-fcd9-4ea2-addd-63c4f0c926ce"), null, new Guid("d17181da-7939-48dd-9849-5ba5d9d2b2aa") },
                    { new Guid("1242c0ce-39ae-41b9-9325-b85471c8125d"), null, new Guid("332a1c73-0058-4594-993d-b843dba83942") },
                    { new Guid("21f129ff-a7be-47b0-8022-d0dcabfaf6c1"), null, new Guid("f0cd5bd8-9ea2-481d-94c1-f6cad5304c86") }
                });

            migrationBuilder.InsertData(
                table: "Proposals",
                columns: new[] { "Id", "CourseId", "Description", "Level", "MaxNumberOfStudents", "Mode", "OutputData", "PromoterId", "Specialization", "StartingDate", "Status", "StudyProfile", "TopicEnglish", "TopicPolish" },
                values: new object[,]
                {
                    { new Guid("8192d4f8-6f50-4b65-9d7c-c07a7b53b85d"), new Guid("99feed76-24e5-45e1-bd75-684c46c8f435"), "Celem pracy jest zaimplementowanie metod Electre 1s i Electre TRI jako aplikacji desktopowych.....", 0, 4, 0, "Brak danych", new Guid("2a21d8e5-575a-41d9-99ed-fbb5c06a3db9"), "-", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "Implementation of chosen methods from Electre family", "Implementacja wybranych metod z rodziny Electre" },
                    { new Guid("2c4d6857-454d-4624-a3ee-1a1f3fc67c21"), new Guid("99feed76-24e5-45e1-bd75-684c46c8f435"), "Opis.....", 0, 4, 0, "Brak danych", new Guid("d979fc9c-94d3-419a-a4e9-014e5664b73c"), "-", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "Implementation of decision support methods based on utility function (UTA, Assess)", "Implementacja metod wspomagania decyzji opartych na funkcji użyteczności (UTA, Assess)" },
                    { new Guid("7f3e5653-1f78-4d89-8971-706b3e3d1bba"), new Guid("99feed76-24e5-45e1-bd75-684c46c8f435"), "Opis.....", 0, 4, 0, "Brak danych", new Guid("4ae4e691-dcff-4236-94ca-c97c102bc66c"), "-", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "Extension of diviz platform", "Rozszerzenie platformy diviz o metody wielokryterialnego wspomagania decyzji oparte na różnych modelach preferencji" },
                    { new Guid("198275cd-f26a-48c0-8bf5-f8d8d106a4d3"), new Guid("99feed76-24e5-45e1-bd75-684c46c8f435"), "Opis.....", 0, 4, 0, "Brak danych", new Guid("9aabdabd-8d1b-4c38-a2d0-0f88dca17533"), "-", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "Style transfering using a neural network", "Transfer stylu przy użyciu sieci neuronowej" },
                    { new Guid("fe0a8286-fabb-46c0-9c53-f7e809a988e7"), new Guid("99feed76-24e5-45e1-bd75-684c46c8f435"), "Opis.....", 0, 4, 0, "Brak danych", new Guid("48aea09b-4be3-4372-88bc-d46d78a1552b"), "-", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "Capri 2 - system for managing diploma topic cards", "Capri 2 - system do zarządzania kartami tematów prac dyplomowych" },
                    { new Guid("6ea28e5f-a3c8-4105-9a38-de9206559bbb"), new Guid("9ee27f18-1893-468b-b7a7-641d8e060e6e"), "Praca będzie polegać na własnoręcznym upakowaniu kolumny chromatograficznej, doborze odpowiednich warunków pomiaru w celu wyznaczenia podstawowych parametrów dla niestandardowych kolumn do HPLC.", 0, 4, 0, "Brak danych", new Guid("fb23704f-cec8-48fb-aa79-f3bd0e7e293b"), "-", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "No title", "Wyznaczenie parametrów kolumny chromatograficznej za pomocą odwróconej chromatografii cieczowej" },
                    { new Guid("382ab1e5-351b-40f2-8b0d-d3133da33107"), new Guid("9ee27f18-1893-468b-b7a7-641d8e060e6e"), "Brak opisu", 1, 4, 0, "Brak danych", new Guid("7345a41b-36aa-4ae2-b0fe-b7bb4279603b"), "-", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "No title", "Analiza i projektowanie procesów wydzielania produktów otrzymywanych w procesie biokonwersji surowców odnawialnych" }
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
