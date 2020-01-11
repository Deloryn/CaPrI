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
                    { new Guid("a233998e-936d-4ba2-9bd0-924e5949d548"), "Wydział Architektury" },
                    { new Guid("f60ece9b-d5c6-4a54-a58a-c87cfe480901"), "Wydział Inżynierii Zarządzania" },
                    { new Guid("65432bd8-f65b-4505-b4ef-242f304f25bd"), "Wydział Inżynierii Transportu" },
                    { new Guid("6ff182b8-7b49-438d-a4b1-f0830194d1d2"), "Wydział Informatyki" },
                    { new Guid("f8113a0e-a81c-4a42-b579-b4a8beed32dd"), "Wydział Fizyki Technicznej" },
                    { new Guid("924f928f-531e-4c21-8b25-ad03b24752cc"), "Wydział Technologii Chemicznej" },
                    { new Guid("8e8b61e5-c047-4d3f-b6c5-69a478a1226c"), "Wydział Elektroniki i Telekomunikacji" },
                    { new Guid("8ebfb4c1-3000-4617-8915-8d0cd8142acf"), "Wydział Budowy Maszyn i Zarządzania" },
                    { new Guid("5a0c079f-b7e8-40b7-97ee-6d8981401c7a"), "Wydział Budownictwa i Inżynierii Środowiska" },
                    { new Guid("7326bdb1-9743-4667-852f-dfd1082c9331"), "Wydział Elektryczny" }
                });

            migrationBuilder.InsertData(
                table: "Institutes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("25ff6c03-0edb-4986-aabf-23b385009edc"), "Instytut Informatyki" },
                    { new Guid("43edf3c8-ec55-4ff3-a877-f6ac27dba068"), "Instytut Mechaniki Stosowanej" },
                    { new Guid("5f5a9130-c88a-4071-a5d8-36f1ad4a36a0"), "Instytut Elektrotechniki i Elektroniki Przemysłowej" },
                    { new Guid("23cf2dcc-9051-4930-b51a-82312c332a7e"), "Instytut Chemii i Elektrochemii Technicznej" },
                    { new Guid("d79adb54-a737-437f-beb6-a87993570b57"), "Instytut Inżynierii Środowiska" },
                    { new Guid("e2b9da8c-dbdf-404c-bcce-8fadc7efeccb"), "Instytut Inżynierii Lądowej" },
                    { new Guid("9809b36f-05d0-4361-ad19-b77a3b717ed5"), "Instytut Technologii Materiałów" },
                    { new Guid("7a84b12b-0f48-4dc6-9c96-a2aa0992e4ea"), "Instytut Matematyki" },
                    { new Guid("ed157155-a3d9-47a4-8b55-6c8504ea1b69"), "Instytut Technologii Mechanicznej" },
                    { new Guid("c97f6cd4-0b72-4beb-ac2e-b49eb16a8af3"), "Instytut Technologii i Inżynierii Chemicznej" },
                    { new Guid("ca7fa4f5-56be-4370-ab1f-070fda034593"), "Instytut Architektury i Planowania Przestrzennego" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("50e5f997-56b8-4ad6-87b2-4da3d70d0edf"), "a25260af-8a67-4465-a891-8539efaa2fb3", "dean", "dean" },
                    { new Guid("124293db-28b4-47b8-a0cf-db82f3da2533"), "8474cd5f-3f64-43a4-a939-59e6e1a7ad2a", "student", "student" },
                    { new Guid("6d3bd2e3-1eb7-49fb-a39a-42ffa6a7daed"), "8b1096bc-7765-46d0-8309-ff0de0d8b241", "promoter", "promoter" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId", "Id" },
                values: new object[,]
                {
                    { new Guid("253400a9-7b43-40cb-ac91-e54bef6f37bd"), new Guid("6d3bd2e3-1eb7-49fb-a39a-42ffa6a7daed"), new Guid("bb078ac6-5f80-4989-94e5-cbf0de2e6c09") },
                    { new Guid("82dc4c56-5f0a-4a4f-be1e-1af6c2df9a5a"), new Guid("50e5f997-56b8-4ad6-87b2-4da3d70d0edf"), new Guid("64abe33e-d258-4a28-9e17-68db63ce0655") },
                    { new Guid("091beb58-a490-4614-9661-74974030ca3d"), new Guid("50e5f997-56b8-4ad6-87b2-4da3d70d0edf"), new Guid("736c79c7-972f-4669-bcd2-8d3002f02c10") },
                    { new Guid("5a0cd578-8571-4fb3-a77e-43a8635c1c8b"), new Guid("50e5f997-56b8-4ad6-87b2-4da3d70d0edf"), new Guid("bc90b539-7ddf-4f54-a683-4b64746f35a7") },
                    { new Guid("8250b4c3-51ac-4a59-a561-63b786defaab"), new Guid("50e5f997-56b8-4ad6-87b2-4da3d70d0edf"), new Guid("a15fceb1-56c4-4248-95c5-38393fbc9b09") },
                    { new Guid("6fab43e9-a7e5-4cc6-a176-196eb7465234"), new Guid("124293db-28b4-47b8-a0cf-db82f3da2533"), new Guid("0dc56b87-4288-46de-a85b-087271746445") },
                    { new Guid("0f7eb686-1b49-4c83-99e7-0bb1dc5e3b74"), new Guid("124293db-28b4-47b8-a0cf-db82f3da2533"), new Guid("5a95c844-a705-4677-a108-cf3dcfa44d9b") },
                    { new Guid("f51ee1b2-937c-4f9a-8c8e-0546d82ab45d"), new Guid("124293db-28b4-47b8-a0cf-db82f3da2533"), new Guid("0ec7cd2c-8acb-43a5-ba26-02f89d9b4fe3") },
                    { new Guid("f787b99a-2add-4e81-9e4f-35de3059a8f5"), new Guid("6d3bd2e3-1eb7-49fb-a39a-42ffa6a7daed"), new Guid("071ac202-3ba0-4fd0-b257-fd3836650ae5") },
                    { new Guid("c946e27e-dccd-4d05-9b40-901148074aca"), new Guid("6d3bd2e3-1eb7-49fb-a39a-42ffa6a7daed"), new Guid("d04841fb-e412-425f-9118-774ac9c080fc") },
                    { new Guid("aa338a3b-ae16-4f01-9b7b-53223ea7b509"), new Guid("6d3bd2e3-1eb7-49fb-a39a-42ffa6a7daed"), new Guid("a8fab158-f73f-4c39-98a1-3f6c5d113d15") },
                    { new Guid("23522c1e-fd0a-4305-85a6-de47877b687d"), new Guid("6d3bd2e3-1eb7-49fb-a39a-42ffa6a7daed"), new Guid("b5bab061-50a5-4776-a05a-64dd3d5f6cb3") },
                    { new Guid("75bc900a-a13e-440e-a4a3-4dc07cd705d1"), new Guid("6d3bd2e3-1eb7-49fb-a39a-42ffa6a7daed"), new Guid("3cbdbc25-5825-47c6-a404-e0d1ca18ec78") },
                    { new Guid("00a80c76-ad0d-422b-8451-3a1317f40728"), new Guid("124293db-28b4-47b8-a0cf-db82f3da2533"), new Guid("fe5a6433-305d-4d3f-b0f1-1e8f97663263") },
                    { new Guid("1ab49ee8-862d-4f89-8ae7-93676801f5eb"), new Guid("6d3bd2e3-1eb7-49fb-a39a-42ffa6a7daed"), new Guid("8f7fc631-8701-4136-bf6a-e6f817b09f90") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("0f7eb686-1b49-4c83-99e7-0bb1dc5e3b74"), 0, "e1fa5d0a-2437-4a4c-9aa2-c738a68d2f28", "student2@gmail.com", true, false, null, "STUDENT2@GMAIL.COM", "STUDENT2@GMAIL.COM", "AQAAAAEAACcQAAAAEOWvTKaU2buMPk51gpEahWYTdFIcKlZPny1pC9atLGgB9FZSTFtE9TZDBCrMEJtS2Q==", null, false, "", false, "student2@gmail.com" },
                    { new Guid("82dc4c56-5f0a-4a4f-be1e-1af6c2df9a5a"), 0, "d862c47e-b0b4-4619-988a-d651c2f0d588", "dean1@gmail.com", true, false, null, "DEAN1@GMAIL.COM", "DEAN1@GMAIL.COM", "AQAAAAEAACcQAAAAEIulDOnCwYA2VZ6hO1TOzpBj3XMGFmKHLzLOna4OJEtdVmxwlTRM8+ilsUFSH36tLg==", null, false, "", false, "dean1@gmail.com" },
                    { new Guid("091beb58-a490-4614-9661-74974030ca3d"), 0, "adf3516d-f442-4ee8-8002-42222564dffb", "dean2@gmail.com", true, false, null, "DEAN2@GMAIL.COM", "DEAN2@GMAIL.COM", "AQAAAAEAACcQAAAAEL9t9u//3vwIMJ0SfAhqH9tRuxu0UpfEWswJM1keCHR0FOOJfqEmCGdgrZoBwVLY9Q==", null, false, "", false, "dean2@gmail.com" },
                    { new Guid("6fab43e9-a7e5-4cc6-a176-196eb7465234"), 0, "2719a717-fa4b-4a11-b39e-a3a93d153094", "student1@gmail.com", true, false, null, "STUDENT1@GMAIL.COM", "STUDENT1@GMAIL.COM", "AQAAAAEAACcQAAAAEN20yt3ybbow0ObglcEaSemyOgHaEQpAGULYbnjBTyDI9ew+lSqOwhU4qmGj94ZmWA==", null, false, "", false, "student1@gmail.com" },
                    { new Guid("5a0cd578-8571-4fb3-a77e-43a8635c1c8b"), 0, "6b9a60a2-04d0-4dc5-9e99-0e502ae5e574", "dean3@gmail.com", true, false, null, "DEAN3@GMAIL.COM", "DEAN3@GMAIL.COM", "AQAAAAEAACcQAAAAEGgzk769CpS1cZr+cJiF3JU/4gpCoQDQ4IJq6hzu/lYgIZklcO79lFx6BM4qwnBxNg==", null, false, "", false, "dean3@gmail.com" },
                    { new Guid("f787b99a-2add-4e81-9e4f-35de3059a8f5"), 0, "9dec05f3-3da1-4c02-b610-c1c8f95e6600", "katarzyna.adamska@put.poznan.pl", true, false, null, "KATARZYNA.ADAMSKA@PUT.POZNAN.PL", "KATARZYNA.ADAMSKA@PUT.POZNAN.PL", "AQAAAAEAACcQAAAAEJWwoJHv6xU0D1BZ4zcUBfGEsK+qO0eBjcCS+G13zdu2YkudbJnWUTFUvH7lhPakUA==", null, false, "", false, "katarzyna.adamska@put.poznan.pl" },
                    { new Guid("75bc900a-a13e-440e-a4a3-4dc07cd705d1"), 0, "1a3aeb7f-8d3b-4845-9a92-9bd410fc7a42", "jerzy.nawrocki@put.poznan.pl", true, false, null, "JERZY.NAWROCKI@PUT.POZNAN.PL", "JERZY.NAWROCKI@PUT.POZNAN.PL", "AQAAAAEAACcQAAAAEObTNXOhXGKZp9tTBsQ8UDSIm03bTbpb/+qLGJYyl7CWNBTnzbRZG5k4s9LdyT6+Ig==", null, false, "", false, "jerzy.nawrocki@put.poznan.pl" },
                    { new Guid("23522c1e-fd0a-4305-85a6-de47877b687d"), 0, "075c691b-f571-474f-ac0f-c5121087684c", "wojciech.kotlowski@put.poznan.pl", true, false, null, "WOJCIECH.KOTLOWSKI@PUT.POZNAN.PL", "WOJCIECH.KOTLOWSKI@PUT.POZNAN.PL", "AQAAAAEAACcQAAAAEDzvQn75OZ/kA8nNMPL5H18bqsD8IXzk5fBLELjMMo8vAuoKzJqhD/2K+AHLh8QyiA==", null, false, "", false, "wojciech.kotlowski@put.poznan.pl" },
                    { new Guid("aa338a3b-ae16-4f01-9b7b-53223ea7b509"), 0, "3c6f779c-926a-41d3-bd5a-c30b46c86ca4", "milosz.kadzinski@put.poznan.pl", true, false, null, "MILOSZ.KADZINSKI@PUT.POZNAN.PL", "MILOSZ.KADZINSKI@PUT.POZNAN.PL", "AQAAAAEAACcQAAAAEPcQktEL3mlRQberqCfdrXYMRqC2p+NKxikeeku92A5LVU+r6K1dJ5J/3mwPLjHMjA==", null, false, "", false, "milosz.kadzinski@put.poznan.pl" },
                    { new Guid("8250b4c3-51ac-4a59-a561-63b786defaab"), 0, "5c9f34ea-6cee-42e4-b69c-7eb4691c2d94", "dean4@gmail.com", true, false, null, "DEAN4@GMAIL.COM", "DEAN4@GMAIL.COM", "AQAAAAEAACcQAAAAEF/QSvwbQX5sl1mBDgz4StAUVVRc5PJZ6C1RmCPzOagh3NLA+Jn3Ds+tvnvoXzCjjQ==", null, false, "", false, "dean4@gmail.com" },
                    { new Guid("253400a9-7b43-40cb-ac91-e54bef6f37bd"), 0, "3878538f-5bc5-43c6-a449-776f2e4a029d", "irmina.maslowska@put.poznan.pl", true, false, null, "IRMINA.MASLOWSKA@PUT.POZNAN.PL", "IRMINA.MASLOWSKA@PUT.POZNAN.PL", "AQAAAAEAACcQAAAAED0mMesjv9d42QE/PReAKmSlQ0EYfZyRAmVoxGHP43z98TmYsa7x1XJ2s7TC84nIyA==", null, false, "", false, "irmina.maslowska@put.poznan.pl" },
                    { new Guid("f51ee1b2-937c-4f9a-8c8e-0546d82ab45d"), 0, "3cc2cc2c-5e21-4c94-aa0e-0e64ab7d7a51", "student4@gmail.com", true, false, null, "STUDENT4@GMAIL.COM", "STUDENT4@GMAIL.COM", "AQAAAAEAACcQAAAAELWpT0f8KAFpVrU5KBR+Q1aepFN9xGFXrg1LW45UZmTFO3vjXHk7xOD8Ev5iRcVDNQ==", null, false, "", false, "student4@gmail.com" },
                    { new Guid("00a80c76-ad0d-422b-8451-3a1317f40728"), 0, "4708ae04-a86f-4dce-a090-081c73f183b4", "student3@gmail.com", true, false, null, "STUDENT3@GMAIL.COM", "STUDENT3@GMAIL.COM", "AQAAAAEAACcQAAAAEH8KnAp/VgFETRtKEFrnyMZWMs3pZnkkrMmQRke9xHZlwpgGrMaFt8rNjgrowQ5L8w==", null, false, "", false, "student3@gmail.com" },
                    { new Guid("1ab49ee8-862d-4f89-8ae7-93676801f5eb"), 0, "afc7ac23-e2eb-43eb-9d4f-0dc08c8ca856", "krzysztof.alejski@put.poznan.pl", true, false, null, "KRZYSZTOF.ALEJSKI@PUT.POZNAN.PL", "KRZYSZTOF.ALEJSKI@PUT.POZNAN.PL", "AQAAAAEAACcQAAAAECk6MYw68Ehzku+1R4Ww3ASv6a53GKclyieYLXdj13OVLdTt9GqsGVwe9AGYtbUIJQ==", null, false, "", false, "krzysztof.alejski@put.poznan.pl" },
                    { new Guid("c946e27e-dccd-4d05-9b40-901148074aca"), 0, "b911238a-43e6-419e-bff6-1382ca50fba1", "bartlomiej.predki@put.poznan.pl", true, false, null, "BARTLOMIEJ.PREDKI@PUT.POZNAN.PL", "BARTLOMIEJ.PREDKI@PUT.POZNAN.PL", "AQAAAAEAACcQAAAAEPBLxqEFZRkjwh5cJmincUY0v1kH0i1QejlVxkgZXmdv+cwo15xPCMgKe7g5u8FdcA==", null, false, "", false, "bartlomiej.predki@put.poznan.pl" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "FacultyId", "Name" },
                values: new object[,]
                {
                    { new Guid("a63222ec-8207-4eec-9bbf-87bc02553df0"), new Guid("a233998e-936d-4ba2-9bd0-924e5949d548"), "Architektura" },
                    { new Guid("52a2dc07-e549-4690-857d-f14637f9a799"), new Guid("924f928f-531e-4c21-8b25-ad03b24752cc"), "Inżynieria Farmaceutyczna" },
                    { new Guid("f731ff93-e73c-4ae9-8f92-922257dfaaa0"), new Guid("924f928f-531e-4c21-8b25-ad03b24752cc"), "Technologie Ochrony Środowiska" },
                    { new Guid("14d42480-0ed9-4fc2-9150-26e955560ddc"), new Guid("924f928f-531e-4c21-8b25-ad03b24752cc"), "Technologia Chemiczna / Chemical Technology" },
                    { new Guid("b8f1f542-68f7-406d-9519-a437b0dd42ae"), new Guid("924f928f-531e-4c21-8b25-ad03b24752cc"), "Inżynieria Chemiczna i Procesowa" },
                    { new Guid("654d82f7-da53-4803-abef-1ba090ce98bf"), new Guid("f60ece9b-d5c6-4a54-a58a-c87cfe480901"), "Inżynieria Bezpieczeństwa" },
                    { new Guid("8c7647ad-e836-4d12-9eaa-990e5027fe3e"), new Guid("f60ece9b-d5c6-4a54-a58a-c87cfe480901"), "Inżynieria Zarządzania" },
                    { new Guid("8990b41b-dc80-4a78-bbcb-8d04ad028a0e"), new Guid("f60ece9b-d5c6-4a54-a58a-c87cfe480901"), "Logistyka" },
                    { new Guid("8eaa75b5-15e9-4c6f-9ec4-8b120e601daf"), new Guid("65432bd8-f65b-4505-b4ef-242f304f25bd"), "Lotnictwo i Kosmonautyka" },
                    { new Guid("4f69cdd3-00e5-4503-af41-0abb0159b4aa"), new Guid("65432bd8-f65b-4505-b4ef-242f304f25bd"), "Transport" },
                    { new Guid("4b87b6ec-87f2-4bdc-ae4f-9a8d4521c0cf"), new Guid("6ff182b8-7b49-438d-a4b1-f0830194d1d2"), "Sztuczna Inteligencja / Artificial Intelligence" },
                    { new Guid("0c4dc0cc-dfbb-485d-a81e-9c2f98966061"), new Guid("6ff182b8-7b49-438d-a4b1-f0830194d1d2"), "Bioinformatyka" },
                    { new Guid("99ab87bd-e102-458d-bd19-30eca94f38e4"), new Guid("6ff182b8-7b49-438d-a4b1-f0830194d1d2"), "Informatyka" },
                    { new Guid("c6878b77-83e9-43d3-b4fe-ecc868a53893"), new Guid("f8113a0e-a81c-4a42-b579-b4a8beed32dd"), "Fizyka Techniczna" },
                    { new Guid("8b1fc5f2-e08f-41a7-8072-7c22771c64e7"), new Guid("f8113a0e-a81c-4a42-b579-b4a8beed32dd"), "Edukacja Techniczno-Informatyczna" },
                    { new Guid("62be7e1f-3130-44b2-81ad-9072ccdcf4d9"), new Guid("65432bd8-f65b-4505-b4ef-242f304f25bd"), "Konstrukcja i Eksploatacja Środków Transportu" },
                    { new Guid("7971e4b9-14ed-4271-a5ef-314e6013929b"), new Guid("7326bdb1-9743-4667-852f-dfd1082c9331"), "Energetyka" },
                    { new Guid("0f58d420-a4cf-4eb7-acdb-4f36e3bb923c"), new Guid("a233998e-936d-4ba2-9bd0-924e5949d548"), "Architektura Wnętrz" },
                    { new Guid("6a024bc0-2cb8-4be4-b347-50b6bc17b802"), new Guid("7326bdb1-9743-4667-852f-dfd1082c9331"), "Matematyka w Technice" },
                    { new Guid("ed1f6389-437e-47a3-85ac-8bd940bccc04"), new Guid("5a0c079f-b7e8-40b7-97ee-6d8981401c7a"), "Inżynieria Środowiska" },
                    { new Guid("12de4156-1f8c-472c-b661-bff04da4611a"), new Guid("8ebfb4c1-3000-4617-8915-8d0cd8142acf"), "Inżynieria Biomedyczna" },
                    { new Guid("216689b8-18f4-4c19-a825-df3318878a4f"), new Guid("8ebfb4c1-3000-4617-8915-8d0cd8142acf"), "Inżynieria Materiałowa" },
                    { new Guid("19dc2fb6-1784-47a2-b61d-a31293e2f09a"), new Guid("8ebfb4c1-3000-4617-8915-8d0cd8142acf"), "Mechanika i Budowa Maszyn" },
                    { new Guid("88236a85-29b1-47d2-bf15-3490950ea2c0"), new Guid("5a0c079f-b7e8-40b7-97ee-6d8981401c7a"), "Budownictwo" },
                    { new Guid("0273535e-252b-4e01-a99a-39fcd6ae5fd0"), new Guid("8ebfb4c1-3000-4617-8915-8d0cd8142acf"), "Zarządzanie i Inżynieria Produkcji" },
                    { new Guid("9d3c46a5-fe91-4ac6-9786-d1687ee71221"), new Guid("8e8b61e5-c047-4d3f-b6c5-69a478a1226c"), "Elektronika i Telekomunikacja" },
                    { new Guid("832da2c4-0b8f-4037-8c3f-60ac26e2d5a7"), new Guid("8e8b61e5-c047-4d3f-b6c5-69a478a1226c"), "Teleinformatyka" },
                    { new Guid("698df9a5-d60e-4664-949c-223296ef8f2d"), new Guid("7326bdb1-9743-4667-852f-dfd1082c9331"), "Automatyka i Robotyka" },
                    { new Guid("600053ab-3862-4b6e-87f2-fadbd10c2e18"), new Guid("7326bdb1-9743-4667-852f-dfd1082c9331"), "Elektrotechnika" },
                    { new Guid("64666500-739a-4947-89de-c458b2581ad2"), new Guid("8ebfb4c1-3000-4617-8915-8d0cd8142acf"), "Mechatronika" }
                });

            migrationBuilder.InsertData(
                table: "Promoters",
                columns: new[] { "Id", "ExpectedNumberOfBachelorProposals", "ExpectedNumberOfMasterProposals", "FirstName", "InstituteId", "LastName", "TitlePostfix", "TitlePrefix", "UserId" },
                values: new object[,]
                {
                    { new Guid("48aea09b-4be3-4372-88bc-d46d78a1552b"), 2, 1, "Jerzy", new Guid("25ff6c03-0edb-4986-aabf-23b385009edc"), "Nawrocki", "prof. PP", "dr hab inż.", new Guid("75bc900a-a13e-440e-a4a3-4dc07cd705d1") },
                    { new Guid("9aabdabd-8d1b-4c38-a2d0-0f88dca17533"), 2, 1, "Wojciech", new Guid("25ff6c03-0edb-4986-aabf-23b385009edc"), "Kotłowski", "", "dr hab. inż.", new Guid("23522c1e-fd0a-4305-85a6-de47877b687d") },
                    { new Guid("4ae4e691-dcff-4236-94ca-c97c102bc66c"), 2, 1, "Miłosz", new Guid("25ff6c03-0edb-4986-aabf-23b385009edc"), "Kadziński", "", "dr hab. inż.", new Guid("aa338a3b-ae16-4f01-9b7b-53223ea7b509") },
                    { new Guid("d979fc9c-94d3-419a-a4e9-014e5664b73c"), 2, 1, "Bartłomiej", new Guid("25ff6c03-0edb-4986-aabf-23b385009edc"), "Prędki", "", "dr inż.", new Guid("c946e27e-dccd-4d05-9b40-901148074aca") },
                    { new Guid("7345a41b-36aa-4ae2-b0fe-b7bb4279603b"), 3, 2, "Krzysztof", new Guid("c97f6cd4-0b72-4beb-ac2e-b49eb16a8af3"), "Alejski", "prof. PP", "dr hab. inż.", new Guid("1ab49ee8-862d-4f89-8ae7-93676801f5eb") },
                    { new Guid("fb23704f-cec8-48fb-aa79-f3bd0e7e293b"), 1, 1, "Katarzyna", new Guid("c97f6cd4-0b72-4beb-ac2e-b49eb16a8af3"), "Adamska", "", "dr inż.", new Guid("f787b99a-2add-4e81-9e4f-35de3059a8f5") },
                    { new Guid("2a21d8e5-575a-41d9-99ed-fbb5c06a3db9"), 2, 1, "Irmina", new Guid("25ff6c03-0edb-4986-aabf-23b385009edc"), "Masłowska", "", "dr inż.", new Guid("253400a9-7b43-40cb-ac91-e54bef6f37bd") }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ProposalId", "Semester", "StudyLevel", "StudyMode", "UserId" },
                values: new object[,]
                {
                    { new Guid("912ba719-04f3-4862-8b33-b648f196cb31"), null, 6, 0, 0, new Guid("f51ee1b2-937c-4f9a-8c8e-0546d82ab45d") },
                    { new Guid("fac40401-386d-40ff-893f-64ead862776b"), null, 6, 0, 0, new Guid("0f7eb686-1b49-4c83-99e7-0bb1dc5e3b74") },
                    { new Guid("d912639c-efa3-494e-90ac-5f2ce1ad88b3"), null, 6, 0, 0, new Guid("6fab43e9-a7e5-4cc6-a176-196eb7465234") },
                    { new Guid("136629f6-42c7-4a85-80d3-8238e35a33d6"), null, 6, 0, 0, new Guid("00a80c76-ad0d-422b-8451-3a1317f40728") }
                });

            migrationBuilder.InsertData(
                table: "Proposals",
                columns: new[] { "Id", "CourseId", "Description", "Level", "MaxNumberOfStudents", "Mode", "OutputData", "PromoterId", "Specialization", "StartingDate", "Status", "StudyProfile", "TopicEnglish", "TopicPolish" },
                values: new object[,]
                {
                    { new Guid("4e57c141-416a-41c7-a369-bf9390e33314"), new Guid("99ab87bd-e102-458d-bd19-30eca94f38e4"), "Celem pracy jest zaimplementowanie metod Electre 1s i Electre TRI jako aplikacji desktopowych.....", 0, 4, 0, "Brak danych", new Guid("2a21d8e5-575a-41d9-99ed-fbb5c06a3db9"), "-", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "Implementation of chosen methods from Electre family", "Implementacja wybranych metod z rodziny Electre" },
                    { new Guid("97916d4d-24d6-48ac-88c1-0e345c95e812"), new Guid("99ab87bd-e102-458d-bd19-30eca94f38e4"), "Opis.....", 0, 4, 0, "Brak danych", new Guid("d979fc9c-94d3-419a-a4e9-014e5664b73c"), "-", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "Implementation of decision support methods based on utility function (UTA, Assess)", "Implementacja metod wspomagania decyzji opartych na funkcji użyteczności (UTA, Assess)" },
                    { new Guid("c7d423e5-0574-460f-805d-d6a7c5a35d46"), new Guid("99ab87bd-e102-458d-bd19-30eca94f38e4"), "Opis.....", 0, 4, 0, "Brak danych", new Guid("4ae4e691-dcff-4236-94ca-c97c102bc66c"), "-", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "Extension of diviz platform", "Rozszerzenie platformy diviz o metody wielokryterialnego wspomagania decyzji oparte na różnych modelach preferencji" },
                    { new Guid("cb9bcf3f-17df-4427-8bb6-8a481a782bd8"), new Guid("99ab87bd-e102-458d-bd19-30eca94f38e4"), "Opis.....", 0, 4, 0, "Brak danych", new Guid("9aabdabd-8d1b-4c38-a2d0-0f88dca17533"), "-", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "Style transfering using a neural network", "Transfer stylu przy użyciu sieci neuronowej" },
                    { new Guid("c4bbdd08-2f79-40e6-a9b4-d11d1f9f4dd6"), new Guid("99ab87bd-e102-458d-bd19-30eca94f38e4"), "Opis.....", 0, 4, 0, "Brak danych", new Guid("48aea09b-4be3-4372-88bc-d46d78a1552b"), "-", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "Capri 2 - system for managing diploma topic cards", "Capri 2 - system do zarządzania kartami tematów prac dyplomowych" },
                    { new Guid("7d341b9c-0f4e-4a1c-b20e-4f5f7330dfe1"), new Guid("b8f1f542-68f7-406d-9519-a437b0dd42ae"), "Praca będzie polegać na własnoręcznym upakowaniu kolumny chromatograficznej, doborze odpowiednich warunków pomiaru w celu wyznaczenia podstawowych parametrów dla niestandardowych kolumn do HPLC.", 0, 4, 0, "Brak danych", new Guid("fb23704f-cec8-48fb-aa79-f3bd0e7e293b"), "-", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "No title", "Wyznaczenie parametrów kolumny chromatograficznej za pomocą odwróconej chromatografii cieczowej" },
                    { new Guid("4125feb8-ac09-4fef-a924-b030f28e3bbc"), new Guid("b8f1f542-68f7-406d-9519-a437b0dd42ae"), "Brak opisu", 1, 4, 0, "Brak danych", new Guid("7345a41b-36aa-4ae2-b0fe-b7bb4279603b"), "-", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "No title", "Analiza i projektowanie procesów wydzielania produktów otrzymywanych w procesie biokonwersji surowców odnawialnych" }
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
