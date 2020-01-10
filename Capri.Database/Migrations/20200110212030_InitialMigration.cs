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
                    { new Guid("3729f2b3-8367-4c5b-b590-bb6c66f9810c"), "Wydział Architektury" },
                    { new Guid("eb266185-cea8-4b41-997a-c9ce06963a81"), "Wydział Inżynierii Zarządzania" },
                    { new Guid("f3627f7f-cbd8-42f4-8535-826218ece4c5"), "Wydział Inżynierii Transportu" },
                    { new Guid("6c2aff77-2a73-462a-8ab1-649c834d2639"), "Wydział Informatyki" },
                    { new Guid("6c3f36f5-b1a8-4d1f-a799-843cef1d3c17"), "Wydział Fizyki Technicznej" },
                    { new Guid("9b7b573e-1949-4a96-902e-aab546934ff9"), "Wydział Technologii Chemicznej" },
                    { new Guid("341010e4-698e-4312-b8b6-30c21ae386e2"), "Wydział Elektroniki i Telekomunikacji" },
                    { new Guid("198078da-336b-438a-a5ab-991571891940"), "Wydział Budowy Maszyn i Zarządzania" },
                    { new Guid("9a6f99c5-c9ca-4b3a-b1bd-58217ba50a24"), "Wydział Budownictwa i Inżynierii Środowiska" },
                    { new Guid("e03c3ad2-317a-4038-b23e-ac8f768f599b"), "Wydział Elektryczny" }
                });

            migrationBuilder.InsertData(
                table: "Institutes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("13caf514-8176-4479-9f36-f10127261604"), "Instytut Informatyki" },
                    { new Guid("57030cd1-99f7-4c51-bbad-bc8838591785"), "Instytut Mechaniki Stosowanej" },
                    { new Guid("9f4cf27e-5acc-4d99-956c-add600aeb413"), "Instytut Elektrotechniki i Elektroniki Przemysłowej" },
                    { new Guid("83ad74a8-277e-4f2d-bf6a-5d788f00c178"), "Instytut Chemii i Elektrochemii Technicznej" },
                    { new Guid("0c723f61-ddeb-4645-8207-c65def822a03"), "Instytut Inżynierii Środowiska" },
                    { new Guid("c0a4cb31-39f1-4f5a-983e-79c35cf04488"), "Instytut Inżynierii Lądowej" },
                    { new Guid("9c4ba1c7-84b3-46de-bb98-0cdaeecde7bc"), "Instytut Technologii Materiałów" },
                    { new Guid("279b3099-04d0-4ed8-aae0-440079d301b6"), "Instytut Matematyki" },
                    { new Guid("85c63a5c-e3f2-4d4c-83e4-a4a1835a80da"), "Instytut Technologii Mechanicznej" },
                    { new Guid("c8f78cb6-8853-4fdf-87b0-d45207631979"), "Instytut Technologii i Inżynierii Chemicznej" },
                    { new Guid("2266f42b-2f19-4a49-bd93-daf9b891d9c5"), "Instytut Architektury i Planowania Przestrzennego" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("e940d81a-e99c-4993-8599-2ab6b96ac03a"), "985ca6b5-e9f2-4cc1-ac65-5bd0341aab76", "dean", "dean" },
                    { new Guid("6af5453c-40ce-43d8-96bd-1afa9dd7455e"), "ec8afe79-6fd0-40a6-b49f-1ab3fdf350bc", "student", "student" },
                    { new Guid("3bdcfad1-db72-4cb9-a40c-c1eacaab9203"), "6940a73b-3c8e-42bb-a4c8-6e3ce5d01489", "promoter", "promoter" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("3ecb764a-d160-4b9a-839b-4b197f5ea61b"), new Guid("3bdcfad1-db72-4cb9-a40c-c1eacaab9203"), new Guid("66976584-d86c-476a-9353-96c8a9222b33") },
                    { new Guid("9c350304-8924-4d91-92e4-322fe3e941e1"), new Guid("e940d81a-e99c-4993-8599-2ab6b96ac03a"), new Guid("bda570c4-cf26-4dde-a04f-09bc2b1ef32c") },
                    { new Guid("1b7db9a5-adee-45b5-994e-609f722ba5d8"), new Guid("e940d81a-e99c-4993-8599-2ab6b96ac03a"), new Guid("86cd3aef-37c2-4dbe-bb87-e2aaa7aceca8") },
                    { new Guid("428f87d5-4b3f-46cf-a11f-caf87e58c891"), new Guid("e940d81a-e99c-4993-8599-2ab6b96ac03a"), new Guid("5d1a46b4-a05a-4148-b033-fda7edc1834e") },
                    { new Guid("f015418a-c497-4e4e-9c85-0732bed3b7f6"), new Guid("e940d81a-e99c-4993-8599-2ab6b96ac03a"), new Guid("c7eed095-d0c0-45e0-87da-0a2962644f22") },
                    { new Guid("561c8bc9-0729-414a-b2eb-6957b4cbed00"), new Guid("6af5453c-40ce-43d8-96bd-1afa9dd7455e"), new Guid("1ab53b74-f078-4deb-9441-48056a75ff95") },
                    { new Guid("c8190010-daf7-4715-b083-5b5fa04b8662"), new Guid("6af5453c-40ce-43d8-96bd-1afa9dd7455e"), new Guid("a83a46d0-376e-4979-a0df-e9bb80cbf1fe") },
                    { new Guid("f29c0585-5d31-47d0-a5d0-8e6aa7f039d0"), new Guid("6af5453c-40ce-43d8-96bd-1afa9dd7455e"), new Guid("da6ef588-2cfc-47a3-8352-f83559d04eff") },
                    { new Guid("02517e04-c2da-40c2-bb62-75835c059afc"), new Guid("3bdcfad1-db72-4cb9-a40c-c1eacaab9203"), new Guid("f1de9f8f-632a-4ce1-b153-e715a2c74bd6") },
                    { new Guid("c5037265-e9ba-4bbf-8b95-bc024f411aa6"), new Guid("3bdcfad1-db72-4cb9-a40c-c1eacaab9203"), new Guid("99f25318-9195-4df2-b26b-b12921f5a63b") },
                    { new Guid("ef5648ad-a1b2-4925-a62c-bd0f98d69d54"), new Guid("3bdcfad1-db72-4cb9-a40c-c1eacaab9203"), new Guid("8848e0ae-2d8f-4361-825f-55055fcc4a02") },
                    { new Guid("13dc299e-df4a-46a8-b720-ee6dc6a3abae"), new Guid("3bdcfad1-db72-4cb9-a40c-c1eacaab9203"), new Guid("321eb935-1862-4623-9c6f-d8651e4574bf") },
                    { new Guid("218f1ea0-a734-4b26-a204-40e45be39374"), new Guid("3bdcfad1-db72-4cb9-a40c-c1eacaab9203"), new Guid("58c476f3-c964-41af-a461-44a89f3c2004") },
                    { new Guid("305bb157-b44d-40ff-a5c0-9cce54d00b87"), new Guid("6af5453c-40ce-43d8-96bd-1afa9dd7455e"), new Guid("df78265f-0a76-49b6-a40a-921b173157d0") },
                    { new Guid("b251c823-66a1-48bc-8d5a-df5f29f821cd"), new Guid("3bdcfad1-db72-4cb9-a40c-c1eacaab9203"), new Guid("6b78dd14-1e94-4a43-b79a-0329c798e393") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("a83a46d0-376e-4979-a0df-e9bb80cbf1fe"), 0, "35a909f6-e110-49d0-a065-3a1d9f38037a", "student2@gmail.com", true, false, null, "STUDENT2@GMAIL.COM", "STUDENT2@GMAIL.COM", "AQAAAAEAACcQAAAAEGDLbgFQaKJV3NnWzTpWTn84kuDEuWHZwhX5Yt5uup1AlsbbRVjHNZElWfS8dfHFpg==", null, false, "", false, "student2@gmail.com" },
                    { new Guid("bda570c4-cf26-4dde-a04f-09bc2b1ef32c"), 0, "cdc1eb7f-9eb2-4965-92be-5e254ca9ad00", "dean1@gmail.com", true, false, null, "DEAN1@GMAIL.COM", "DEAN1@GMAIL.COM", "AQAAAAEAACcQAAAAEAbSAzmGT0JhOKu+jnZqqmgSxGkrqhG0B7uYR8LDVg2JnGG4bzWlfIwUfwzPaZ/FRQ==", null, false, "", false, "dean1@gmail.com" },
                    { new Guid("86cd3aef-37c2-4dbe-bb87-e2aaa7aceca8"), 0, "daa50a3c-a3ed-42d2-810f-78b6bb3ab0eb", "dean2@gmail.com", true, false, null, "DEAN2@GMAIL.COM", "DEAN2@GMAIL.COM", "AQAAAAEAACcQAAAAEDoii0LnITQKFP5TlrD501OR7ik3Ix9dd6qsy/AiftnQ9FslKm0TZBHX4ZHjWs+4Hg==", null, false, "", false, "dean2@gmail.com" },
                    { new Guid("1ab53b74-f078-4deb-9441-48056a75ff95"), 0, "4844bfc3-a598-40c0-a690-f6b927cc44fa", "student1@gmail.com", true, false, null, "STUDENT1@GMAIL.COM", "STUDENT1@GMAIL.COM", "AQAAAAEAACcQAAAAEB3ajqdhWs6mAB3jA6qwU5hYjxF/b9cGHmfKmc26UTK8pjHhT8t8Lca4v0zoDo/YOw==", null, false, "", false, "student1@gmail.com" },
                    { new Guid("5d1a46b4-a05a-4148-b033-fda7edc1834e"), 0, "1db485ba-d983-4d07-b4e6-629502f61f40", "dean3@gmail.com", true, false, null, "DEAN3@GMAIL.COM", "DEAN3@GMAIL.COM", "AQAAAAEAACcQAAAAEKVcJyT5/kpJqBcldSDsyXC60kAtbUba439DiZ6SO+RzmOPZhfTkC4Sljk3Uo4cvMA==", null, false, "", false, "dean3@gmail.com" },
                    { new Guid("f1de9f8f-632a-4ce1-b153-e715a2c74bd6"), 0, "326d8109-e502-4251-a03b-965fcf9034ce", "katarzyna.adamska@put.poznan.pl", true, false, null, "KATARZYNA.ADAMSKA@PUT.POZNAN.PL", "KATARZYNA.ADAMSKA@PUT.POZNAN.PL", "AQAAAAEAACcQAAAAEG9hYnL1A3QCg7JskF5UkWSMQ/lfkRLgw3bu4u7V8lvuXFtdGScTIqAK2hi2BIiI9A==", null, false, "", false, "katarzyna.adamska@put.poznan.pl" },
                    { new Guid("58c476f3-c964-41af-a461-44a89f3c2004"), 0, "b36803fe-8ea8-42aa-bfa8-b3cb132f4ae8", "jerzy.nawrocki@put.poznan.pl", true, false, null, "JERZY.NAWROCKI@PUT.POZNAN.PL", "JERZY.NAWROCKI@PUT.POZNAN.PL", "AQAAAAEAACcQAAAAEFFU2Pmnf9TEOaUnqiHcNnCYMc9MK7OD2wLnRx15OluoZb+lwYoHBbgpnbzQfHFY2w==", null, false, "", false, "jerzy.nawrocki@put.poznan.pl" },
                    { new Guid("321eb935-1862-4623-9c6f-d8651e4574bf"), 0, "5b0cac2a-a0fd-4b63-bc6b-079032913be7", "wojciech.kotlowski@put.poznan.pl", true, false, null, "WOJCIECH.KOTLOWSKI@PUT.POZNAN.PL", "WOJCIECH.KOTLOWSKI@PUT.POZNAN.PL", "AQAAAAEAACcQAAAAEKGqFUdGnRAG+yqJOCGblki5ZQ+OrdZCJ8zX4ydi0fL9qPPzQMrU+8FSfgI7MC5wRQ==", null, false, "", false, "wojciech.kotlowski@put.poznan.pl" },
                    { new Guid("8848e0ae-2d8f-4361-825f-55055fcc4a02"), 0, "65ebea97-6274-44f7-b2fc-89d7cf68e67c", "milosz.kadzinski@put.poznan.pl", true, false, null, "MILOSZ.KADZINSKI@PUT.POZNAN.PL", "MILOSZ.KADZINSKI@PUT.POZNAN.PL", "AQAAAAEAACcQAAAAEMDO02RFVS10V2epT07++nRHRAosig7ld10sQUJEEIMS3GyYZjkKga6YbwzPGB+CJw==", null, false, "", false, "milosz.kadzinski@put.poznan.pl" },
                    { new Guid("c7eed095-d0c0-45e0-87da-0a2962644f22"), 0, "8df0b5ff-a2ab-4ede-ab74-221484dfb28a", "dean4@gmail.com", true, false, null, "DEAN4@GMAIL.COM", "DEAN4@GMAIL.COM", "AQAAAAEAACcQAAAAECsRuH9EHm0Qd++7RWkIjpRZUlorAU0HeE7lG9PbYW1hTK/jWuBUH4PpZoVpWqj/lw==", null, false, "", false, "dean4@gmail.com" },
                    { new Guid("66976584-d86c-476a-9353-96c8a9222b33"), 0, "79676950-b35c-421c-9e57-889dc63eb920", "irmina.maslowska@put.poznan.pl", true, false, null, "IRMINA.MASLOWSKA@PUT.POZNAN.PL", "IRMINA.MASLOWSKA@PUT.POZNAN.PL", "AQAAAAEAACcQAAAAELKeiq0mazcZwWUxmf+x4hw6hQVp+nmfwABLzBlRX3sIcCWK9HZFvogjUAGtKjL4Ow==", null, false, "", false, "irmina.maslowska@put.poznan.pl" },
                    { new Guid("da6ef588-2cfc-47a3-8352-f83559d04eff"), 0, "3e42f0a4-20b1-4974-aa9b-e7a31b865bc2", "student4@gmail.com", true, false, null, "STUDENT4@GMAIL.COM", "STUDENT4@GMAIL.COM", "AQAAAAEAACcQAAAAEDNwfIeQ3fXBfXA6hIe/1kPUcVtT+IzmXLYc2u7atFKlAdYwAo+rRtIO/ucA3Ynong==", null, false, "", false, "student4@gmail.com" },
                    { new Guid("df78265f-0a76-49b6-a40a-921b173157d0"), 0, "fa62402e-9cdc-4210-9fd0-fc3e357ba62f", "student3@gmail.com", true, false, null, "STUDENT3@GMAIL.COM", "STUDENT3@GMAIL.COM", "AQAAAAEAACcQAAAAEN96jdwkiFnSvAF4xLW2+9mHpm4F1dIEZcQ5nFw2naHzIxZWsnZp30F8ikHm7rbpkQ==", null, false, "", false, "student3@gmail.com" },
                    { new Guid("6b78dd14-1e94-4a43-b79a-0329c798e393"), 0, "5790aebb-ebe0-463c-b854-c5f577a038a0", "krzysztof.alejski@put.poznan.pl", true, false, null, "KRZYSZTOF.ALEJSKI@PUT.POZNAN.PL", "KRZYSZTOF.ALEJSKI@PUT.POZNAN.PL", "AQAAAAEAACcQAAAAEEVwMN/sxSFfKyACh/qhorhc4FgD6XVhOfBCcGZdAdPUZOytQZFhZvkdmQiG4ogzzQ==", null, false, "", false, "krzysztof.alejski@put.poznan.pl" },
                    { new Guid("99f25318-9195-4df2-b26b-b12921f5a63b"), 0, "0ef8dfed-21c5-44fc-8945-bbc7653cf98c", "bartlomiej.predki@put.poznan.pl", true, false, null, "BARTLOMIEJ.PREDKI@PUT.POZNAN.PL", "BARTLOMIEJ.PREDKI@PUT.POZNAN.PL", "AQAAAAEAACcQAAAAEFvCQN63YJk7iFaCaqOm53hTpPYWvKVemfa8A127b/dFK6AJXBlkLM4QkWemcAFOsQ==", null, false, "", false, "bartlomiej.predki@put.poznan.pl" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "FacultyId", "Name" },
                values: new object[,]
                {
                    { new Guid("c0a1ca26-c845-4273-98f1-96953d35e5b2"), new Guid("3729f2b3-8367-4c5b-b590-bb6c66f9810c"), "Architektura" },
                    { new Guid("238860f6-fdd8-477e-8f0d-cf65c0857650"), new Guid("9b7b573e-1949-4a96-902e-aab546934ff9"), "Inżynieria Farmaceutyczna" },
                    { new Guid("913e08ba-0cc0-461b-905e-54aeaf766d2b"), new Guid("9b7b573e-1949-4a96-902e-aab546934ff9"), "Technologie Ochrony Środowiska" },
                    { new Guid("e9e9c57f-5b1e-4211-8c82-86b6810fa3f9"), new Guid("9b7b573e-1949-4a96-902e-aab546934ff9"), "Technologia Chemiczna / Chemical Technology" },
                    { new Guid("54229a22-50f5-430f-acc9-705df3b5199d"), new Guid("9b7b573e-1949-4a96-902e-aab546934ff9"), "Inżynieria Chemiczna i Procesowa" },
                    { new Guid("e320a018-4092-4f11-aa01-1ad9e8bda495"), new Guid("eb266185-cea8-4b41-997a-c9ce06963a81"), "Inżynieria Bezpieczeństwa" },
                    { new Guid("6737c69b-b942-4080-933d-565a4bba99f4"), new Guid("eb266185-cea8-4b41-997a-c9ce06963a81"), "Inżynieria Zarządzania" },
                    { new Guid("771e9521-49ef-48be-9bad-c124e8b0f9f1"), new Guid("eb266185-cea8-4b41-997a-c9ce06963a81"), "Logistyka" },
                    { new Guid("b838deb6-42ca-49e1-b3c6-bced7b7645f6"), new Guid("f3627f7f-cbd8-42f4-8535-826218ece4c5"), "Lotnictwo i Kosmonautyka" },
                    { new Guid("a8264b7c-9ac4-468a-8601-87b2d7167a31"), new Guid("f3627f7f-cbd8-42f4-8535-826218ece4c5"), "Transport" },
                    { new Guid("33eb4787-7bec-4666-bafe-b2a09b69a9f6"), new Guid("6c2aff77-2a73-462a-8ab1-649c834d2639"), "Sztuczna Inteligencja / Artificial Intelligence" },
                    { new Guid("2584a6f0-6fa6-42c9-ac61-362bc183e7a6"), new Guid("6c2aff77-2a73-462a-8ab1-649c834d2639"), "Bioinformatyka" },
                    { new Guid("fbc1c88c-5f51-47e8-a463-4e5d47834132"), new Guid("6c2aff77-2a73-462a-8ab1-649c834d2639"), "Informatyka" },
                    { new Guid("602953b4-09b1-4369-b2e4-b70be1111b3d"), new Guid("6c3f36f5-b1a8-4d1f-a799-843cef1d3c17"), "Fizyka Techniczna" },
                    { new Guid("6035e82e-151b-440e-89c6-6844ca62a8ad"), new Guid("6c3f36f5-b1a8-4d1f-a799-843cef1d3c17"), "Edukacja Techniczno-Informatyczna" },
                    { new Guid("f9c12316-7a56-4d0a-aa3d-e44ef29787e3"), new Guid("f3627f7f-cbd8-42f4-8535-826218ece4c5"), "Konstrukcja i Eksploatacja Środków Transportu" },
                    { new Guid("2a512117-1ef2-42e5-ba65-8bcd62a51b77"), new Guid("e03c3ad2-317a-4038-b23e-ac8f768f599b"), "Energetyka" },
                    { new Guid("ae6f767c-e60d-4e02-b3b4-26f0fcf1393a"), new Guid("3729f2b3-8367-4c5b-b590-bb6c66f9810c"), "Architektura Wnętrz" },
                    { new Guid("958de599-f245-4af9-b9c9-53f010ffaed9"), new Guid("e03c3ad2-317a-4038-b23e-ac8f768f599b"), "Matematyka w Technice" },
                    { new Guid("eb16be13-a3ae-4ca7-92a9-eeb2b57100c8"), new Guid("9a6f99c5-c9ca-4b3a-b1bd-58217ba50a24"), "Inżynieria Środowiska" },
                    { new Guid("3f491b1c-edbc-4d8a-8246-9f6c562588d0"), new Guid("198078da-336b-438a-a5ab-991571891940"), "Inżynieria Biomedyczna" },
                    { new Guid("a94ab98b-c35c-4482-89d2-19b9ed3c8205"), new Guid("198078da-336b-438a-a5ab-991571891940"), "Inżynieria Materiałowa" },
                    { new Guid("55eeb1c2-5a0e-4d9e-b7d0-62d687da8575"), new Guid("198078da-336b-438a-a5ab-991571891940"), "Mechanika i Budowa Maszyn" },
                    { new Guid("21c3130e-3b69-4fb6-95e8-cf97ce610b11"), new Guid("9a6f99c5-c9ca-4b3a-b1bd-58217ba50a24"), "Budownictwo" },
                    { new Guid("21207478-c248-4cd5-b94e-d47271ddb7e8"), new Guid("198078da-336b-438a-a5ab-991571891940"), "Zarządzanie i Inżynieria Produkcji" },
                    { new Guid("6c2d290e-8277-4278-ad5b-2c2214e6f42f"), new Guid("341010e4-698e-4312-b8b6-30c21ae386e2"), "Elektronika i Telekomunikacja" },
                    { new Guid("5036883a-2e77-4121-b863-f95de727e092"), new Guid("341010e4-698e-4312-b8b6-30c21ae386e2"), "Teleinformatyka" },
                    { new Guid("5ba21951-0279-4ed2-9466-7b998922cdc5"), new Guid("e03c3ad2-317a-4038-b23e-ac8f768f599b"), "Automatyka i Robotyka" },
                    { new Guid("b715e070-9fc9-42b2-8728-8db86d83fb2a"), new Guid("e03c3ad2-317a-4038-b23e-ac8f768f599b"), "Elektrotechnika" },
                    { new Guid("3f16222f-675f-477a-9ecf-e3a17c9ceef1"), new Guid("198078da-336b-438a-a5ab-991571891940"), "Mechatronika" }
                });

            migrationBuilder.InsertData(
                table: "Promoters",
                columns: new[] { "Id", "ExpectedNumberOfBachelorProposals", "ExpectedNumberOfMasterProposals", "FirstName", "InstituteId", "LastName", "TitlePostfix", "TitlePrefix", "UserId" },
                values: new object[,]
                {
                    { new Guid("48aea09b-4be3-4372-88bc-d46d78a1552b"), 2, 1, "Jerzy", new Guid("13caf514-8176-4479-9f36-f10127261604"), "Nawrocki", "prof. PP", "dr hab inż.", new Guid("58c476f3-c964-41af-a461-44a89f3c2004") },
                    { new Guid("9aabdabd-8d1b-4c38-a2d0-0f88dca17533"), 2, 1, "Wojciech", new Guid("13caf514-8176-4479-9f36-f10127261604"), "Kotłowski", "", "dr hab. inż.", new Guid("321eb935-1862-4623-9c6f-d8651e4574bf") },
                    { new Guid("4ae4e691-dcff-4236-94ca-c97c102bc66c"), 2, 1, "Miłosz", new Guid("13caf514-8176-4479-9f36-f10127261604"), "Kadziński", "", "dr hab. inż.", new Guid("8848e0ae-2d8f-4361-825f-55055fcc4a02") },
                    { new Guid("d979fc9c-94d3-419a-a4e9-014e5664b73c"), 2, 1, "Bartłomiej", new Guid("13caf514-8176-4479-9f36-f10127261604"), "Prędki", "", "dr inż.", new Guid("99f25318-9195-4df2-b26b-b12921f5a63b") },
                    { new Guid("7345a41b-36aa-4ae2-b0fe-b7bb4279603b"), 3, 2, "Krzysztof", new Guid("c8f78cb6-8853-4fdf-87b0-d45207631979"), "Alejski", "prof. PP", "dr hab. inż.", new Guid("6b78dd14-1e94-4a43-b79a-0329c798e393") },
                    { new Guid("fb23704f-cec8-48fb-aa79-f3bd0e7e293b"), 1, 1, "Katarzyna", new Guid("c8f78cb6-8853-4fdf-87b0-d45207631979"), "Adamska", "", "dr inż.", new Guid("f1de9f8f-632a-4ce1-b153-e715a2c74bd6") },
                    { new Guid("2a21d8e5-575a-41d9-99ed-fbb5c06a3db9"), 2, 1, "Irmina", new Guid("13caf514-8176-4479-9f36-f10127261604"), "Masłowska", "", "dr inż.", new Guid("66976584-d86c-476a-9353-96c8a9222b33") }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ProposalId", "UserId" },
                values: new object[,]
                {
                    { new Guid("fb655a49-ceb0-4b81-8862-31712513dd94"), null, new Guid("da6ef588-2cfc-47a3-8352-f83559d04eff") },
                    { new Guid("2c8ff37e-512c-4a1a-ad90-bd9a4572d07b"), null, new Guid("a83a46d0-376e-4979-a0df-e9bb80cbf1fe") },
                    { new Guid("ad3064ea-291d-4b45-8a53-6c5b1f34036d"), null, new Guid("1ab53b74-f078-4deb-9441-48056a75ff95") },
                    { new Guid("0c9746f7-9424-4443-af0b-6bfe7d147ed6"), null, new Guid("df78265f-0a76-49b6-a40a-921b173157d0") }
                });

            migrationBuilder.InsertData(
                table: "Proposals",
                columns: new[] { "Id", "CourseId", "Description", "Level", "MaxNumberOfStudents", "Mode", "OutputData", "PromoterId", "Specialization", "StartingDate", "Status", "StudyProfile", "TopicEnglish", "TopicPolish" },
                values: new object[,]
                {
                    { new Guid("ca7e673f-eb16-48eb-9038-0f1b7148937d"), new Guid("fbc1c88c-5f51-47e8-a463-4e5d47834132"), "Celem pracy jest zaimplementowanie metod Electre 1s i Electre TRI jako aplikacji desktopowych.....", 0, 4, 0, "Brak danych", new Guid("2a21d8e5-575a-41d9-99ed-fbb5c06a3db9"), "-", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "Implementation of chosen methods from Electre family", "Implementacja wybranych metod z rodziny Electre" },
                    { new Guid("429709d0-42ae-4b69-9160-0e7e1f2edc9f"), new Guid("fbc1c88c-5f51-47e8-a463-4e5d47834132"), "Opis.....", 0, 4, 0, "Brak danych", new Guid("d979fc9c-94d3-419a-a4e9-014e5664b73c"), "-", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "Implementation of decision support methods based on utility function (UTA, Assess)", "Implementacja metod wspomagania decyzji opartych na funkcji użyteczności (UTA, Assess)" },
                    { new Guid("47288756-0acc-4b06-a324-ba6e4a640d73"), new Guid("fbc1c88c-5f51-47e8-a463-4e5d47834132"), "Opis.....", 0, 4, 0, "Brak danych", new Guid("4ae4e691-dcff-4236-94ca-c97c102bc66c"), "-", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "Extension of diviz platform", "Rozszerzenie platformy diviz o metody wielokryterialnego wspomagania decyzji oparte na różnych modelach preferencji" },
                    { new Guid("d40026df-bb61-4596-90ba-8f5f8e987337"), new Guid("fbc1c88c-5f51-47e8-a463-4e5d47834132"), "Opis.....", 0, 4, 0, "Brak danych", new Guid("9aabdabd-8d1b-4c38-a2d0-0f88dca17533"), "-", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "Style transfering using a neural network", "Transfer stylu przy użyciu sieci neuronowej" },
                    { new Guid("243a9b49-a0a5-4622-9b55-e2cf44410cac"), new Guid("fbc1c88c-5f51-47e8-a463-4e5d47834132"), "Opis.....", 0, 4, 0, "Brak danych", new Guid("48aea09b-4be3-4372-88bc-d46d78a1552b"), "-", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "Capri 2 - system for managing diploma topic cards", "Capri 2 - system do zarządzania kartami tematów prac dyplomowych" },
                    { new Guid("cb9c21e5-4ae1-4268-bc1f-7b7e49b20ea6"), new Guid("54229a22-50f5-430f-acc9-705df3b5199d"), "Praca będzie polegać na własnoręcznym upakowaniu kolumny chromatograficznej, doborze odpowiednich warunków pomiaru w celu wyznaczenia podstawowych parametrów dla niestandardowych kolumn do HPLC.", 0, 4, 0, "Brak danych", new Guid("fb23704f-cec8-48fb-aa79-f3bd0e7e293b"), "-", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "No title", "Wyznaczenie parametrów kolumny chromatograficznej za pomocą odwróconej chromatografii cieczowej" },
                    { new Guid("13a063d5-91b0-48cb-9ea2-6924067a2174"), new Guid("54229a22-50f5-430f-acc9-705df3b5199d"), "Brak opisu", 1, 4, 0, "Brak danych", new Guid("7345a41b-36aa-4ae2-b0fe-b7bb4279603b"), "-", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "No title", "Analiza i projektowanie procesów wydzielania produktów otrzymywanych w procesie biokonwersji surowców odnawialnych" }
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
