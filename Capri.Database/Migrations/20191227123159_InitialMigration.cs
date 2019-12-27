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
                    { new Guid("a49b15c4-8f76-4d77-a05c-2d64c35aff84"), "Wydział Architektury" },
                    { new Guid("bf273264-0019-4e2e-9932-cfd5941d9e30"), "Wydział Inżynierii Zarządzania" },
                    { new Guid("81c99cbd-7707-4823-8905-87bce684512f"), "Wydział Inżynierii Transportu" },
                    { new Guid("326956a0-0805-4480-a31f-59d0f9e535fc"), "Wydział Informatyki" },
                    { new Guid("1cbb8c1b-e8b5-4de2-8ed1-f55640b4fdc8"), "Wydział Fizyki Technicznej" },
                    { new Guid("8ce48e70-e5b4-4224-8ad8-393b2a1a7201"), "Wydział Technologii Chemicznej" },
                    { new Guid("b7dc094f-a595-4844-b429-fd21ca170dd4"), "Wydział Elektroniki i Telekomunikacji" },
                    { new Guid("6a94f221-18f1-4a22-8721-a4cc93886544"), "Wydział Budowy Maszyn i Zarządzania" },
                    { new Guid("4bd3f046-143a-411c-9d4f-a20680c33c4c"), "Wydział Budownictwa i Inżynierii Środowiska" },
                    { new Guid("9277bcfa-9071-4069-9134-b04cb767557e"), "Wydział Elektryczny" }
                });

            migrationBuilder.InsertData(
                table: "Institutes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2a6b55c1-1983-4bff-b0e9-da79433eda22"), "Instytut Informatyki" },
                    { new Guid("f1c4a3c9-3e12-4155-b385-d3f2fb770771"), "Instytut Mechaniki Stosowanej" },
                    { new Guid("fb20aef9-be52-4a5a-992c-120f9c11d0ce"), "Instytut Elektrotechniki i Elektroniki Przemysłowej" },
                    { new Guid("dfad55a5-680b-4bd1-9307-021f3e7b229b"), "Instytut Chemii i Elektrochemii Technicznej" },
                    { new Guid("e05293a1-2bf6-4959-870f-7b49938a1f2f"), "Instytut Inżynierii Środowiska" },
                    { new Guid("5de0c4f2-84ff-4b1b-a06b-2b083bbbd296"), "Instytut Inżynierii Lądowej" },
                    { new Guid("571363ac-7947-47ce-9023-c5eb00e9df57"), "Instytut Technologii Materiałów" },
                    { new Guid("fd6cfd16-b293-4198-8820-1bf378fb9a22"), "Instytut Matematyki" },
                    { new Guid("d0ca6c83-b39c-4058-b59e-7d6f42ba082c"), "Instytut Technologii Mechanicznej" },
                    { new Guid("5904aba9-0699-4e40-bea5-3fc76d42785c"), "Instytut Technologii i Inżynierii Chemicznej" },
                    { new Guid("354656a2-1a96-4037-b49e-df56c2c1864b"), "Instytut Architektury i Planowania Przestrzennego" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("d8913f5b-b1b0-449b-9349-9718e0206680"), "ec745d6d-d31a-4a18-a6d4-ecf4fe2141f2", "dean", "dean" },
                    { new Guid("9af01217-da5a-4579-a2c0-6aeaa03036ea"), "73ee5189-87c4-483a-8f84-d38ee2e5e6d8", "student", "student" },
                    { new Guid("77f3cfe0-5aad-4716-ac77-5611490b8e1f"), "989aa01e-61a6-4474-bf42-0eef6d6933dd", "promoter", "promoter" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("7617d1f9-5107-406e-98ff-fc58d5f24a5a"), new Guid("77f3cfe0-5aad-4716-ac77-5611490b8e1f"), new Guid("b497e663-8983-408d-a788-840e34c0736a") },
                    { new Guid("55a3d68a-df5b-48a7-b660-8d770d86ad36"), new Guid("d8913f5b-b1b0-449b-9349-9718e0206680"), new Guid("eb9e3d32-b583-4f7b-814d-d08a42c638cb") },
                    { new Guid("0d9cccdc-d1d0-4a5d-8f3d-ddfdfdc029bf"), new Guid("d8913f5b-b1b0-449b-9349-9718e0206680"), new Guid("83f8037a-11ec-4849-b43f-3f3e7c038844") },
                    { new Guid("c852ea34-1286-4000-9e33-7893c6b5f6ae"), new Guid("d8913f5b-b1b0-449b-9349-9718e0206680"), new Guid("20063150-21cd-49d9-9fd3-97e241a719f6") },
                    { new Guid("754a9cd2-c452-4f29-b070-02ecad9dfeac"), new Guid("d8913f5b-b1b0-449b-9349-9718e0206680"), new Guid("8ba1a21b-3199-4737-81bd-0b11553af41a") },
                    { new Guid("337063d6-ede9-4577-9efa-cae35173e4b7"), new Guid("9af01217-da5a-4579-a2c0-6aeaa03036ea"), new Guid("4671073c-6dc6-4daf-8ba9-6c5deda31612") },
                    { new Guid("46fce63b-3a84-4125-a1db-a0ada1f2d95a"), new Guid("9af01217-da5a-4579-a2c0-6aeaa03036ea"), new Guid("0b76826e-692f-46b8-805a-f4b6e723bae4") },
                    { new Guid("f363fdc5-b02e-45d6-b9ad-b09ea62e9ee6"), new Guid("9af01217-da5a-4579-a2c0-6aeaa03036ea"), new Guid("9a256119-b8a2-45f7-9a85-5726258e8d16") },
                    { new Guid("86c81919-9cd5-4fba-919c-1fff5e9a47b3"), new Guid("77f3cfe0-5aad-4716-ac77-5611490b8e1f"), new Guid("651ede50-8a9d-46b6-975c-df5e10ffe63f") },
                    { new Guid("a58896a5-4917-4be8-9ef8-e2a93993fb67"), new Guid("77f3cfe0-5aad-4716-ac77-5611490b8e1f"), new Guid("ee871f12-cecd-4b28-ab6e-8087c5db4b92") },
                    { new Guid("3e5a370f-f66b-4d62-9556-f796f710f253"), new Guid("77f3cfe0-5aad-4716-ac77-5611490b8e1f"), new Guid("eee1aac1-756d-4715-abc8-7145358db933") },
                    { new Guid("fad5a3ac-9aab-46e6-bbce-7c5b25c091f7"), new Guid("77f3cfe0-5aad-4716-ac77-5611490b8e1f"), new Guid("562482e9-4bc3-4820-af9b-0d3d475af6f0") },
                    { new Guid("8e279b9e-6ad5-4609-80d5-3b62d174f756"), new Guid("77f3cfe0-5aad-4716-ac77-5611490b8e1f"), new Guid("dab87c07-dd82-47d0-b556-f42fc91b80df") },
                    { new Guid("0e61918e-987e-4b2d-bf62-4972b0ca5827"), new Guid("9af01217-da5a-4579-a2c0-6aeaa03036ea"), new Guid("bec3a8c9-7e41-4279-9882-319eabf2f3f7") },
                    { new Guid("4c31c578-a24e-4ff6-aec7-a7c8cf79995a"), new Guid("77f3cfe0-5aad-4716-ac77-5611490b8e1f"), new Guid("c198a53a-ca32-4a8e-aff1-b6766f8c0e6d") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("0b76826e-692f-46b8-805a-f4b6e723bae4"), 0, "9b77f725-d2b1-4741-ab10-0dd6cdc410b0", "student2@gmail.com", true, false, null, "STUDENT2@GMAIL.COM", "STUDENT2@GMAIL.COM", "AQAAAAEAACcQAAAAECVHDDBAhGzffnC2PqLUpXneffqKPjhmirIXKoepbGXfOde/ho3XZ+//ZjXPNw8+Bg==", null, false, "", false, "student2@gmail.com" },
                    { new Guid("eb9e3d32-b583-4f7b-814d-d08a42c638cb"), 0, "ad67859a-7dee-4a58-b35e-3e49e4482610", "dean1@gmail.com", true, false, null, "DEAN1@GMAIL.COM", "DEAN1@GMAIL.COM", "AQAAAAEAACcQAAAAEA9zU2gmZXipYPHe9E37v1cIclqFjnVPLyGC7u13C7uy52azamufMRixAFSJKLrsvw==", null, false, "", false, "dean1@gmail.com" },
                    { new Guid("83f8037a-11ec-4849-b43f-3f3e7c038844"), 0, "6081e9b9-ca08-4f8a-9daa-9a2cc8ddf317", "dean2@gmail.com", true, false, null, "DEAN2@GMAIL.COM", "DEAN2@GMAIL.COM", "AQAAAAEAACcQAAAAELlV5l2NPuhH8yBKbiIDFbGwHW1022fzuElWAgqw4RFk/KdZAfI4yUGWlxYAENGPJQ==", null, false, "", false, "dean2@gmail.com" },
                    { new Guid("4671073c-6dc6-4daf-8ba9-6c5deda31612"), 0, "39b6992d-33dc-4d3c-9176-c9e1543f5d08", "student1@gmail.com", true, false, null, "STUDENT1@GMAIL.COM", "STUDENT1@GMAIL.COM", "AQAAAAEAACcQAAAAEO3XlgZYWij3Y06Kn8dx9tO4AicJq2a+mJcmYSSx9aDRBA0RvC5zZoVpRMiwp6VvPA==", null, false, "", false, "student1@gmail.com" },
                    { new Guid("20063150-21cd-49d9-9fd3-97e241a719f6"), 0, "00a69def-ad1e-49d7-b2c4-94de7eea0f68", "dean3@gmail.com", true, false, null, "DEAN3@GMAIL.COM", "DEAN3@GMAIL.COM", "AQAAAAEAACcQAAAAEAplASKpCPIUvT2oK/tpzIeu9IyenqPvcjD1a1lCXjNxZLg3dnrGfP1/aqSkOr//7A==", null, false, "", false, "dean3@gmail.com" },
                    { new Guid("651ede50-8a9d-46b6-975c-df5e10ffe63f"), 0, "77029560-381e-498d-9829-58376f422195", "katarzyna.adamska@put.poznan.pl", true, false, null, "KATARZYNA.ADAMSKA@PUT.POZNAN.PL", "KATARZYNA.ADAMSKA@PUT.POZNAN.PL", "AQAAAAEAACcQAAAAEFleeHHguT+oXRP+7DubkU2Tyokez7AbOFox4BbrSOPDkOuCns94J4bKcQzOoILkaw==", null, false, "", false, "katarzyna.adamska@put.poznan.pl" },
                    { new Guid("dab87c07-dd82-47d0-b556-f42fc91b80df"), 0, "3f012fa8-e815-4724-aabe-0be3423e5e07", "jerzy.nawrocki@put.poznan.pl", true, false, null, "JERZY.NAWROCKI@PUT.POZNAN.PL", "JERZY.NAWROCKI@PUT.POZNAN.PL", "AQAAAAEAACcQAAAAEHtr4/qmdXbKz8NNpC6ww9R3IsaVNEqTKYW0HKav+BIgCyGkw+gQwozSfGQnE1lkYg==", null, false, "", false, "jerzy.nawrocki@put.poznan.pl" },
                    { new Guid("562482e9-4bc3-4820-af9b-0d3d475af6f0"), 0, "e4b14a1f-8c2d-49dd-9fdb-44bd87d6ca15", "wojciech.kotlowski@put.poznan.pl", true, false, null, "WOJCIECH.KOTLOWSKI@PUT.POZNAN.PL", "WOJCIECH.KOTLOWSKI@PUT.POZNAN.PL", "AQAAAAEAACcQAAAAEBQN2+4azM+k3ogt+I4d0Li1FVv7n1QAbC9m94mmensWEpeLW8ZCiqzeU7pLAK+hhg==", null, false, "", false, "wojciech.kotlowski@put.poznan.pl" },
                    { new Guid("eee1aac1-756d-4715-abc8-7145358db933"), 0, "475cbb51-e4b4-41e5-b33f-3fc1f0e67419", "milosz.kadzinski@put.poznan.pl", true, false, null, "MILOSZ.KADZINSKI@PUT.POZNAN.PL", "MILOSZ.KADZINSKI@PUT.POZNAN.PL", "AQAAAAEAACcQAAAAEIsPExQOzrqQqCN2QuZ0p9j8G3olMeXk202trS8CIKLJc+CDz2qEA/Pn5kr9tmK23g==", null, false, "", false, "milosz.kadzinski@put.poznan.pl" },
                    { new Guid("8ba1a21b-3199-4737-81bd-0b11553af41a"), 0, "f37df815-4f37-4595-838e-8bb4524b2d2a", "dean4@gmail.com", true, false, null, "DEAN4@GMAIL.COM", "DEAN4@GMAIL.COM", "AQAAAAEAACcQAAAAEA/4Z3GLh2QRjD8Impxsz/Cwl/V0g/GM2hdi42A5klPiH5VeRn+a+aA2NFnLXKqzwg==", null, false, "", false, "dean4@gmail.com" },
                    { new Guid("b497e663-8983-408d-a788-840e34c0736a"), 0, "e6055a53-4377-48ee-a016-a419944d5494", "irmina.maslowska@put.poznan.pl", true, false, null, "IRMINA.MASLOWSKA@PUT.POZNAN.PL", "IRMINA.MASLOWSKA@PUT.POZNAN.PL", "AQAAAAEAACcQAAAAEDrjQ4aoFyxU0pZ9107rbzHxVXwZooPuTk+9jicnqXT3XC0Yp8RIbqJD9ToMNWpxhQ==", null, false, "", false, "irmina.maslowska@put.poznan.pl" },
                    { new Guid("9a256119-b8a2-45f7-9a85-5726258e8d16"), 0, "d3dd5c2c-fbe9-49db-af0f-d6120a0b8ce8", "student4@gmail.com", true, false, null, "STUDENT4@GMAIL.COM", "STUDENT4@GMAIL.COM", "AQAAAAEAACcQAAAAECXhPah4jSnpi8mUzv0OXBFCF2vvrBvnXifhHuzfNVgoJH5dqHsuHgyho7MRG0q5Pg==", null, false, "", false, "student4@gmail.com" },
                    { new Guid("bec3a8c9-7e41-4279-9882-319eabf2f3f7"), 0, "1f9b0142-f90c-4883-b6b8-0d67ce7fb98b", "student3@gmail.com", true, false, null, "STUDENT3@GMAIL.COM", "STUDENT3@GMAIL.COM", "AQAAAAEAACcQAAAAEPQ2XV8YYps6lr76hh+UPa5uovTceEAq0LAsRjOagGgejFcj9egCW+9eN+DirUrz6A==", null, false, "", false, "student3@gmail.com" },
                    { new Guid("c198a53a-ca32-4a8e-aff1-b6766f8c0e6d"), 0, "42c6a5dd-c30a-4032-bdfe-b59beaa6b427", "krzysztof.alejski@put.poznan.pl", true, false, null, "KRZYSZTOF.ALEJSKI@PUT.POZNAN.PL", "KRZYSZTOF.ALEJSKI@PUT.POZNAN.PL", "AQAAAAEAACcQAAAAEFTz6rVVq0tOrVbTUJy8QRlu7SI97EReBDYsFl8El5psNZCnM4NWkk7O+87yPE0bGg==", null, false, "", false, "krzysztof.alejski@put.poznan.pl" },
                    { new Guid("ee871f12-cecd-4b28-ab6e-8087c5db4b92"), 0, "43f678a7-f09a-4ede-a018-075ae2987178", "bartlomiej.predki@put.poznan.pl", true, false, null, "BARTLOMIEJ.PREDKI@PUT.POZNAN.PL", "BARTLOMIEJ.PREDKI@PUT.POZNAN.PL", "AQAAAAEAACcQAAAAEORJI+JaqCt12/3kFAf/rZA3Q5tkXwmNU5ErG5Bmf2yz2JkU0QKArQgKkOiGmAmP3w==", null, false, "", false, "bartlomiej.predki@put.poznan.pl" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "FacultyId", "Name" },
                values: new object[,]
                {
                    { new Guid("823edd98-b38f-44c7-b313-c86dea1fc873"), new Guid("a49b15c4-8f76-4d77-a05c-2d64c35aff84"), "Architektura" },
                    { new Guid("5f316447-13ad-4a9c-9da6-72cd5ed29940"), new Guid("8ce48e70-e5b4-4224-8ad8-393b2a1a7201"), "Inżynieria Farmaceutyczna" },
                    { new Guid("834044be-6d79-4214-8084-7cf29b333164"), new Guid("8ce48e70-e5b4-4224-8ad8-393b2a1a7201"), "Technologie Ochrony Środowiska" },
                    { new Guid("cd4135cf-a0d9-4af5-803a-106de8167b08"), new Guid("8ce48e70-e5b4-4224-8ad8-393b2a1a7201"), "Technologia Chemiczna / Chemical Technology" },
                    { new Guid("b7ab2cab-7cdc-4085-9c8a-84e3e9d04ab5"), new Guid("8ce48e70-e5b4-4224-8ad8-393b2a1a7201"), "Inżynieria Chemiczna i Procesowa" },
                    { new Guid("c06b5d56-2ca7-4bfd-887e-3a2ce7ec4f4d"), new Guid("bf273264-0019-4e2e-9932-cfd5941d9e30"), "Inżynieria Bezpieczeństwa" },
                    { new Guid("91fb6d64-f449-4339-8650-9da156671852"), new Guid("bf273264-0019-4e2e-9932-cfd5941d9e30"), "Inżynieria Zarządzania" },
                    { new Guid("d2991164-c272-4d7a-8841-689ef5b9e3f5"), new Guid("bf273264-0019-4e2e-9932-cfd5941d9e30"), "Logistyka" },
                    { new Guid("a5e0509a-c780-4abd-9c54-fd83d2a8ebe3"), new Guid("81c99cbd-7707-4823-8905-87bce684512f"), "Lotnictwo i Kosmonautyka" },
                    { new Guid("bffaf0af-bf69-4c5c-ba91-9a1410bb836b"), new Guid("81c99cbd-7707-4823-8905-87bce684512f"), "Transport" },
                    { new Guid("d5e90033-3d72-43a0-95c1-47ad83712b9e"), new Guid("326956a0-0805-4480-a31f-59d0f9e535fc"), "Sztuczna Inteligencja / Artificial Intelligence" },
                    { new Guid("07923f63-2c45-4374-a42f-71224e3cfa24"), new Guid("326956a0-0805-4480-a31f-59d0f9e535fc"), "Bioinformatyka" },
                    { new Guid("b2835e49-7d2d-4e0c-992f-190b81a5494d"), new Guid("326956a0-0805-4480-a31f-59d0f9e535fc"), "Informatyka" },
                    { new Guid("85bc0243-91a4-4abc-8b32-784486b46a45"), new Guid("1cbb8c1b-e8b5-4de2-8ed1-f55640b4fdc8"), "Fizyka Techniczna" },
                    { new Guid("fd63ebb1-e8b2-4a93-94cd-5aa640d09d30"), new Guid("1cbb8c1b-e8b5-4de2-8ed1-f55640b4fdc8"), "Edukacja Techniczno-Informatyczna" },
                    { new Guid("3cccfb8b-35f8-4553-864a-8840bc25ffa5"), new Guid("81c99cbd-7707-4823-8905-87bce684512f"), "Konstrukcja i Eksploatacja Środków Transportu" },
                    { new Guid("8dfc1e9c-95c3-487c-bcf9-7188ad66322c"), new Guid("9277bcfa-9071-4069-9134-b04cb767557e"), "Energetyka" },
                    { new Guid("239fb8c5-70ba-4be9-97f2-091e22327252"), new Guid("a49b15c4-8f76-4d77-a05c-2d64c35aff84"), "Architektura Wnętrz" },
                    { new Guid("59daf147-b7d2-4b2d-99c0-fbdf02684f43"), new Guid("9277bcfa-9071-4069-9134-b04cb767557e"), "Matematyka w Technice" },
                    { new Guid("dac18d57-b8ad-4da2-b5d1-db291c84443f"), new Guid("4bd3f046-143a-411c-9d4f-a20680c33c4c"), "Inżynieria Środowiska" },
                    { new Guid("2d5627aa-b8c8-4a90-b8b2-39469bcb535a"), new Guid("6a94f221-18f1-4a22-8721-a4cc93886544"), "Inżynieria Biomedyczna" },
                    { new Guid("80be4439-220b-416c-aa18-df9f41fb3396"), new Guid("6a94f221-18f1-4a22-8721-a4cc93886544"), "Inżynieria Materiałowa" },
                    { new Guid("9f6358fa-ea24-4f92-83dd-b1c3f4fe0b8a"), new Guid("6a94f221-18f1-4a22-8721-a4cc93886544"), "Mechanika i Budowa Maszyn" },
                    { new Guid("a8f3cc69-48a5-454f-8b82-8f5bebb595c0"), new Guid("4bd3f046-143a-411c-9d4f-a20680c33c4c"), "Budownictwo" },
                    { new Guid("81ba48f8-df52-4560-9fb9-62a54a6b06d3"), new Guid("6a94f221-18f1-4a22-8721-a4cc93886544"), "Zarządzanie i Inżynieria Produkcji" },
                    { new Guid("6ebfda66-12d7-48bf-9245-34b0f26967fa"), new Guid("b7dc094f-a595-4844-b429-fd21ca170dd4"), "Elektronika i Telekomunikacja" },
                    { new Guid("aeedf3b3-2476-4e43-96ed-d9bc2308b499"), new Guid("b7dc094f-a595-4844-b429-fd21ca170dd4"), "Teleinformatyka" },
                    { new Guid("0888425b-f839-48a3-9521-f92a884474d8"), new Guid("9277bcfa-9071-4069-9134-b04cb767557e"), "Automatyka i Robotyka" },
                    { new Guid("c9cae424-f28f-426c-8e3e-1b2a21915c70"), new Guid("9277bcfa-9071-4069-9134-b04cb767557e"), "Elektrotechnika" },
                    { new Guid("948aced7-bfa0-4036-a563-3548cf6c6b5b"), new Guid("6a94f221-18f1-4a22-8721-a4cc93886544"), "Mechatronika" }
                });

            migrationBuilder.InsertData(
                table: "Promoters",
                columns: new[] { "Id", "ExpectedNumberOfBachelorProposals", "ExpectedNumberOfMasterProposals", "FirstName", "InstituteId", "LastName", "TitlePostfix", "TitlePrefix", "UserId" },
                values: new object[,]
                {
                    { new Guid("48aea09b-4be3-4372-88bc-d46d78a1552b"), 2, 1, "Jerzy", new Guid("2a6b55c1-1983-4bff-b0e9-da79433eda22"), "Nawrocki", "prof. PP", "dr hab inż.", new Guid("dab87c07-dd82-47d0-b556-f42fc91b80df") },
                    { new Guid("9aabdabd-8d1b-4c38-a2d0-0f88dca17533"), 2, 1, "Wojciech", new Guid("2a6b55c1-1983-4bff-b0e9-da79433eda22"), "Kotłowski", "", "dr hab. inż.", new Guid("562482e9-4bc3-4820-af9b-0d3d475af6f0") },
                    { new Guid("4ae4e691-dcff-4236-94ca-c97c102bc66c"), 2, 1, "Miłosz", new Guid("2a6b55c1-1983-4bff-b0e9-da79433eda22"), "Kadziński", "", "dr hab. inż.", new Guid("eee1aac1-756d-4715-abc8-7145358db933") },
                    { new Guid("d979fc9c-94d3-419a-a4e9-014e5664b73c"), 2, 1, "Bartłomiej", new Guid("2a6b55c1-1983-4bff-b0e9-da79433eda22"), "Prędki", "", "dr inż.", new Guid("ee871f12-cecd-4b28-ab6e-8087c5db4b92") },
                    { new Guid("7345a41b-36aa-4ae2-b0fe-b7bb4279603b"), 3, 2, "Krzysztof", new Guid("5904aba9-0699-4e40-bea5-3fc76d42785c"), "Alejski", "prof. PP", "dr hab. inż.", new Guid("c198a53a-ca32-4a8e-aff1-b6766f8c0e6d") },
                    { new Guid("fb23704f-cec8-48fb-aa79-f3bd0e7e293b"), 1, 1, "Katarzyna", new Guid("5904aba9-0699-4e40-bea5-3fc76d42785c"), "Adamska", "", "dr inż.", new Guid("651ede50-8a9d-46b6-975c-df5e10ffe63f") },
                    { new Guid("2a21d8e5-575a-41d9-99ed-fbb5c06a3db9"), 2, 1, "Irmina", new Guid("2a6b55c1-1983-4bff-b0e9-da79433eda22"), "Masłowska", "", "dr inż.", new Guid("b497e663-8983-408d-a788-840e34c0736a") }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ProposalId", "UserId" },
                values: new object[,]
                {
                    { new Guid("aabd8c30-187f-4cd0-abb0-daca200e905c"), null, new Guid("9a256119-b8a2-45f7-9a85-5726258e8d16") },
                    { new Guid("ecbd0c64-740e-41fe-99f2-5bfce5cb1318"), null, new Guid("0b76826e-692f-46b8-805a-f4b6e723bae4") },
                    { new Guid("448c9194-e82d-4963-958f-8ddc850dc95f"), null, new Guid("4671073c-6dc6-4daf-8ba9-6c5deda31612") },
                    { new Guid("919a2a2d-8cce-445b-b723-6748929d6e11"), null, new Guid("bec3a8c9-7e41-4279-9882-319eabf2f3f7") }
                });

            migrationBuilder.InsertData(
                table: "Proposals",
                columns: new[] { "Id", "CourseId", "Description", "Level", "Mode", "PromoterId", "Specialization", "StartingDate", "Status", "StudyProfile", "TopicEnglish", "TopicPolish" },
                values: new object[,]
                {
                    { new Guid("5d8c4d5d-33cc-443f-baca-6212990f8fd1"), new Guid("b2835e49-7d2d-4e0c-992f-190b81a5494d"), "Celem pracy jest zaimplementowanie metod Electre 1s i Electre TRI jako aplikacji desktopowych.....", 0, 0, new Guid("2a21d8e5-575a-41d9-99ed-fbb5c06a3db9"), "....................................", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "Implementation of chosen methods from Electre family", "Implementacja wybranych metod z rodziny Electre" },
                    { new Guid("1e956971-1e05-4c1c-b512-04b088e05eae"), new Guid("b2835e49-7d2d-4e0c-992f-190b81a5494d"), "Opis.....", 0, 0, new Guid("d979fc9c-94d3-419a-a4e9-014e5664b73c"), "Opis.......", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "Implementation of decision support methods based on utility function (UTA, Assess)", "Implementacja metod wspomagania decyzji opartych na funkcji użyteczności (UTA, Assess)" },
                    { new Guid("115fd046-b41a-434e-9c72-ece1a0183487"), new Guid("b2835e49-7d2d-4e0c-992f-190b81a5494d"), "Opis.....", 0, 0, new Guid("4ae4e691-dcff-4236-94ca-c97c102bc66c"), "Opis.......", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "Extension of diviz platform", "Rozszerzenie platformy diviz o metody wielokryterialnego wspomagania decyzji oparte na różnych modelach preferencji" },
                    { new Guid("48df0675-acc0-452f-bc6d-6245719f0ce6"), new Guid("b2835e49-7d2d-4e0c-992f-190b81a5494d"), "Opis.....", 0, 0, new Guid("9aabdabd-8d1b-4c38-a2d0-0f88dca17533"), "Opis.......", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "Style transfering using a neural network", "Transfer stylu przy użyciu sieci neuronowej" },
                    { new Guid("f384af8a-5457-497b-906e-956030d704a5"), new Guid("b2835e49-7d2d-4e0c-992f-190b81a5494d"), "Opis.....", 0, 0, new Guid("48aea09b-4be3-4372-88bc-d46d78a1552b"), "Opis.......", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "Capri 2 - system for managing diploma topic cards", "Capri 2 - system do zarządzania kartami tematów prac dyplomowych" },
                    { new Guid("79f2ec6f-b816-4d95-b3a2-9db668aefd3b"), new Guid("b7ab2cab-7cdc-4085-9c8a-84e3e9d04ab5"), "Praca będzie polegać na własnoręcznym upakowaniu kolumny chromatograficznej, doborze odpowiednich warunków pomiaru w celu wyznaczenia podstawowych parametrów dla niestandardowych kolumn do HPLC.", 0, 0, new Guid("fb23704f-cec8-48fb-aa79-f3bd0e7e293b"), "Brak opisu", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "No title", "Wyznaczenie parametrów kolumny chromatograficznej za pomocą odwróconej chromatografii cieczowej" },
                    { new Guid("05d765bf-af90-450b-bef4-e97bb073125e"), new Guid("b7ab2cab-7cdc-4085-9c8a-84e3e9d04ab5"), "Brak opisu", 1, 0, new Guid("7345a41b-36aa-4ae2-b0fe-b7bb4279603b"), "Brak opisu", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "No title", "Analiza i projektowanie procesów wydzielania produktów otrzymywanych w procesie biokonwersji surowców odnawialnych" }
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
