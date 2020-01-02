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
                    { new Guid("21f541fb-1876-4e89-af23-b6ff09ab5004"), "Wydział Architektury" },
                    { new Guid("f760b789-5aca-414b-91cb-144a56b202d4"), "Wydział Inżynierii Zarządzania" },
                    { new Guid("bbaf8a32-ca6f-4eb2-84a0-21e83dfed7b9"), "Wydział Inżynierii Transportu" },
                    { new Guid("5040b13b-72c7-4b3c-a983-2d4d4d141e84"), "Wydział Informatyki" },
                    { new Guid("0e0eb4ca-2def-4349-96eb-0e920f24760c"), "Wydział Fizyki Technicznej" },
                    { new Guid("36001ee0-0141-4ed7-9ee5-ba674333e253"), "Wydział Technologii Chemicznej" },
                    { new Guid("3c6a4c75-86c7-4a7d-9356-865d6b6e4451"), "Wydział Elektroniki i Telekomunikacji" },
                    { new Guid("07cc9446-555d-4c97-827f-248e3f851f3d"), "Wydział Budowy Maszyn i Zarządzania" },
                    { new Guid("4ce6c2bc-bde7-45cf-b8ca-0bcb26b95c04"), "Wydział Budownictwa i Inżynierii Środowiska" },
                    { new Guid("25ac48c7-d909-4ff4-b5e8-c8e256b78f5a"), "Wydział Elektryczny" }
                });

            migrationBuilder.InsertData(
                table: "Institutes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("bedc99ed-5cc7-42f8-9fb8-7a413e7cbfa0"), "Instytut Informatyki" },
                    { new Guid("9db566a9-2928-4dbb-8afa-cd91c5fb67e2"), "Instytut Mechaniki Stosowanej" },
                    { new Guid("8503bf23-2a38-4752-92dd-db5373454427"), "Instytut Elektrotechniki i Elektroniki Przemysłowej" },
                    { new Guid("32411ec2-6864-4d06-99d7-6a07faa992c0"), "Instytut Chemii i Elektrochemii Technicznej" },
                    { new Guid("489167a4-2709-4cee-934b-f62e877d6725"), "Instytut Inżynierii Środowiska" },
                    { new Guid("e63cb728-86b0-4cfd-b1e8-02b329ed3083"), "Instytut Inżynierii Lądowej" },
                    { new Guid("641a82dd-a257-4119-92de-1c8f5dff4546"), "Instytut Technologii Materiałów" },
                    { new Guid("6e89e3fe-b110-476f-97ba-eb1afdceeca8"), "Instytut Matematyki" },
                    { new Guid("f0fa358f-5dd6-40ad-9a53-e9fe7665c927"), "Instytut Technologii Mechanicznej" },
                    { new Guid("39dcb4de-d35d-4da5-bf08-421e6aed1ee4"), "Instytut Technologii i Inżynierii Chemicznej" },
                    { new Guid("b936eeac-dac2-456a-ba18-75909446c304"), "Instytut Architektury i Planowania Przestrzennego" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("fba1b750-349a-4114-a363-fa1ceffcc24b"), "de2e2c70-0c28-46cb-9ab4-6819722eed9f", "dean", "dean" },
                    { new Guid("ac360758-2e5d-4504-9e8b-d46f2ffac2b4"), "4abadafa-3b91-4a3d-908e-eb203c9eb422", "student", "student" },
                    { new Guid("726f529f-a2a7-4f34-8d3e-fdb879a402f4"), "b5869aa4-dba3-4007-a3ef-ff677fe1e0aa", "promoter", "promoter" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("c7eabd3c-e7f6-4774-a516-5b1aed311bd5"), new Guid("726f529f-a2a7-4f34-8d3e-fdb879a402f4"), new Guid("1b7c1541-08d5-4d61-aea3-8190812df48f") },
                    { new Guid("d826db85-359a-47b0-b100-d8bcc0bd1ccc"), new Guid("fba1b750-349a-4114-a363-fa1ceffcc24b"), new Guid("bb50ceed-ce6d-4f04-8c8b-ebdbe133c064") },
                    { new Guid("e2dd1202-d7a0-4312-9bc5-127905ffbf9e"), new Guid("fba1b750-349a-4114-a363-fa1ceffcc24b"), new Guid("e5f5cece-b008-4ae8-b240-95b22d213237") },
                    { new Guid("55f3a527-4e49-40b9-8351-9663c699a903"), new Guid("fba1b750-349a-4114-a363-fa1ceffcc24b"), new Guid("de5313fe-6714-41b9-8d91-054f69f08d9a") },
                    { new Guid("a605f61c-86e2-4541-a76c-a54d97939ad4"), new Guid("fba1b750-349a-4114-a363-fa1ceffcc24b"), new Guid("91487701-ffd8-4dac-8b53-7fb02cee4cb6") },
                    { new Guid("21b4be11-9de2-4f6f-a753-2637e8343795"), new Guid("ac360758-2e5d-4504-9e8b-d46f2ffac2b4"), new Guid("c3099d35-0868-4690-8a2b-17b2a41be37b") },
                    { new Guid("28ee27cc-a542-4654-933a-758b5b178e97"), new Guid("ac360758-2e5d-4504-9e8b-d46f2ffac2b4"), new Guid("0189d561-7e83-4084-9185-d705ed21295e") },
                    { new Guid("127c14f0-7748-4230-9842-c1ee942a9265"), new Guid("ac360758-2e5d-4504-9e8b-d46f2ffac2b4"), new Guid("25312726-dafd-4be0-a59d-97013c46bd88") },
                    { new Guid("c5ae2784-167a-4e4a-9277-ae03e3844147"), new Guid("726f529f-a2a7-4f34-8d3e-fdb879a402f4"), new Guid("f823cd14-794c-4afd-98b3-a1dfb3ffba50") },
                    { new Guid("652cba2b-9d79-4dc4-8061-cfa87c745e39"), new Guid("726f529f-a2a7-4f34-8d3e-fdb879a402f4"), new Guid("a6822801-97ab-4581-a478-45535d8adf9e") },
                    { new Guid("737334dc-2f2b-46bf-87e1-e09440c37ea6"), new Guid("726f529f-a2a7-4f34-8d3e-fdb879a402f4"), new Guid("7e53e191-b0a9-48db-9691-c08926577420") },
                    { new Guid("c4d82e02-9df5-4468-bf50-583f54e0a4fb"), new Guid("726f529f-a2a7-4f34-8d3e-fdb879a402f4"), new Guid("bc7716c1-6011-434a-9623-ef0722083cc0") },
                    { new Guid("47aff503-e3c3-46a0-b780-e32db5ec75da"), new Guid("726f529f-a2a7-4f34-8d3e-fdb879a402f4"), new Guid("a350be55-3326-4210-b0a6-becc4bef92ea") },
                    { new Guid("8423efad-2109-450f-b542-0d3deb9a04c6"), new Guid("ac360758-2e5d-4504-9e8b-d46f2ffac2b4"), new Guid("6e9acc5c-2321-4345-af11-50a5af548c3e") },
                    { new Guid("578feef9-e850-4798-b24b-e4a9ccebb862"), new Guid("726f529f-a2a7-4f34-8d3e-fdb879a402f4"), new Guid("c216cba0-63da-4acf-998f-73125906d1fa") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("0189d561-7e83-4084-9185-d705ed21295e"), 0, "832d1d4b-4aee-4f97-9f18-7a3dbbb329e7", "student2@gmail.com", true, false, null, "STUDENT2@GMAIL.COM", "STUDENT2@GMAIL.COM", "AQAAAAEAACcQAAAAEMlRHL/iRglNiB3cRwS8xOu4LBTEM/R6D4P8iI6+bQbUKFiaMRkai59tRIeEdO/uWQ==", null, false, "", false, "student2@gmail.com" },
                    { new Guid("bb50ceed-ce6d-4f04-8c8b-ebdbe133c064"), 0, "c09b3ecf-06ab-4b92-85d1-38b35f564b44", "dean1@gmail.com", true, false, null, "DEAN1@GMAIL.COM", "DEAN1@GMAIL.COM", "AQAAAAEAACcQAAAAELLZAhzWqaM3l1sWIdAyAvsVm0ecutpumSV85zOAamNV5s6gi6j73R+m5SmqFzhr+g==", null, false, "", false, "dean1@gmail.com" },
                    { new Guid("e5f5cece-b008-4ae8-b240-95b22d213237"), 0, "8d2ec2ff-2694-4d38-a236-865278aa78ea", "dean2@gmail.com", true, false, null, "DEAN2@GMAIL.COM", "DEAN2@GMAIL.COM", "AQAAAAEAACcQAAAAEJqs1XY3ImKFPtXKHCeV1zDx60TNq5ynARDMPzt2CqRuC9ded82TEXFWeFJT+w+0pQ==", null, false, "", false, "dean2@gmail.com" },
                    { new Guid("c3099d35-0868-4690-8a2b-17b2a41be37b"), 0, "4e5fa8be-4a82-429f-8478-60f8130de664", "student1@gmail.com", true, false, null, "STUDENT1@GMAIL.COM", "STUDENT1@GMAIL.COM", "AQAAAAEAACcQAAAAEGaRZDY5XTxKfDXEefIC7BcM/Ke5RuLfokgzK4rwP3QIEOXbLO5dfPltvfeP86j+Vg==", null, false, "", false, "student1@gmail.com" },
                    { new Guid("de5313fe-6714-41b9-8d91-054f69f08d9a"), 0, "7289a7ff-6a99-41f2-b1c6-3d32297de78b", "dean3@gmail.com", true, false, null, "DEAN3@GMAIL.COM", "DEAN3@GMAIL.COM", "AQAAAAEAACcQAAAAELzTnhf/tCs/gAdKJZ+lAXVbkPdGfpZl8IMM4+IMjRX0H3/l3GsaO590uHdMGbuiNg==", null, false, "", false, "dean3@gmail.com" },
                    { new Guid("f823cd14-794c-4afd-98b3-a1dfb3ffba50"), 0, "efd2e26c-fbe3-47ea-a3c6-3188245abfb1", "katarzyna.adamska@put.poznan.pl", true, false, null, "KATARZYNA.ADAMSKA@PUT.POZNAN.PL", "KATARZYNA.ADAMSKA@PUT.POZNAN.PL", "AQAAAAEAACcQAAAAEKZhKfaOBXXXKNrJTizdkckUmVFcf6kU3KWEF0z3J4BhGbVNQd86E+6KIemB0o82Aw==", null, false, "", false, "katarzyna.adamska@put.poznan.pl" },
                    { new Guid("a350be55-3326-4210-b0a6-becc4bef92ea"), 0, "964c7543-2f9e-40e6-97c4-5620b24384f9", "jerzy.nawrocki@put.poznan.pl", true, false, null, "JERZY.NAWROCKI@PUT.POZNAN.PL", "JERZY.NAWROCKI@PUT.POZNAN.PL", "AQAAAAEAACcQAAAAEGKl1MY3bgfKtsKGgINE+PpCpLUsDtb6IEeEVeb9uIwYcyqOxlpbR6Gu0jgyafmeaA==", null, false, "", false, "jerzy.nawrocki@put.poznan.pl" },
                    { new Guid("bc7716c1-6011-434a-9623-ef0722083cc0"), 0, "151f3b5d-0b70-46d5-bd10-85ad03973703", "wojciech.kotlowski@put.poznan.pl", true, false, null, "WOJCIECH.KOTLOWSKI@PUT.POZNAN.PL", "WOJCIECH.KOTLOWSKI@PUT.POZNAN.PL", "AQAAAAEAACcQAAAAEJCxj6lPxAab3v0n10vq1ZP6MyOeWMvMDjzxQT7fAbOvb2oxVnTFmto8Cgx/EUVZ2g==", null, false, "", false, "wojciech.kotlowski@put.poznan.pl" },
                    { new Guid("7e53e191-b0a9-48db-9691-c08926577420"), 0, "0f0dba68-995b-4132-80cc-ee4c45237e43", "milosz.kadzinski@put.poznan.pl", true, false, null, "MILOSZ.KADZINSKI@PUT.POZNAN.PL", "MILOSZ.KADZINSKI@PUT.POZNAN.PL", "AQAAAAEAACcQAAAAEGUhk9j1RMENBsBedyUL15tuCV9ekVtry7zXYZbWNmE7FY54r38Ln/Msni/ZqTClfg==", null, false, "", false, "milosz.kadzinski@put.poznan.pl" },
                    { new Guid("91487701-ffd8-4dac-8b53-7fb02cee4cb6"), 0, "e93ed50e-2959-4a34-a87a-e22a59c25499", "dean4@gmail.com", true, false, null, "DEAN4@GMAIL.COM", "DEAN4@GMAIL.COM", "AQAAAAEAACcQAAAAEAIUxOOTi12aQOdwLgpD6k9tHYJSLUahrgcYhzCkkXQmfxOjwFaiBLFM+St7R/e84g==", null, false, "", false, "dean4@gmail.com" },
                    { new Guid("1b7c1541-08d5-4d61-aea3-8190812df48f"), 0, "554fd4dc-6403-490d-82d1-58643747bf30", "irmina.maslowska@put.poznan.pl", true, false, null, "IRMINA.MASLOWSKA@PUT.POZNAN.PL", "IRMINA.MASLOWSKA@PUT.POZNAN.PL", "AQAAAAEAACcQAAAAEJmdszX9Exsw42n+c4nrfE9SZnyXpJLy09GnqqcJk0fXa3VjA2drS9xfxGMZuuaytg==", null, false, "", false, "irmina.maslowska@put.poznan.pl" },
                    { new Guid("25312726-dafd-4be0-a59d-97013c46bd88"), 0, "7949a7ea-8792-4f7c-9f90-935a8dbd12a1", "student4@gmail.com", true, false, null, "STUDENT4@GMAIL.COM", "STUDENT4@GMAIL.COM", "AQAAAAEAACcQAAAAEG7AYUHZcvILza9l2aMJ0arm8X8m0+4DANTnAtqB738RoiwD4z45Ly8bUueLhmmXrg==", null, false, "", false, "student4@gmail.com" },
                    { new Guid("6e9acc5c-2321-4345-af11-50a5af548c3e"), 0, "4f54758b-01c4-44ab-b568-857205a00a4d", "student3@gmail.com", true, false, null, "STUDENT3@GMAIL.COM", "STUDENT3@GMAIL.COM", "AQAAAAEAACcQAAAAELpUqqvCDIFZVeK5G+gX6/X6eDe5zvCPZrbeDjPXQ7XfLYjpvLgoxVWSx+OhIt/s1A==", null, false, "", false, "student3@gmail.com" },
                    { new Guid("c216cba0-63da-4acf-998f-73125906d1fa"), 0, "34e03c81-5b70-452c-886c-f4a62701ff91", "krzysztof.alejski@put.poznan.pl", true, false, null, "KRZYSZTOF.ALEJSKI@PUT.POZNAN.PL", "KRZYSZTOF.ALEJSKI@PUT.POZNAN.PL", "AQAAAAEAACcQAAAAEKDHliXkUblmD6S/n4s985S68BcbLCA+cu/wIYQNvQUTzRU0co5wzP7NpqrXJZQRyg==", null, false, "", false, "krzysztof.alejski@put.poznan.pl" },
                    { new Guid("a6822801-97ab-4581-a478-45535d8adf9e"), 0, "67e634a6-0f78-4eb5-a816-29c55d0d6ce0", "bartlomiej.predki@put.poznan.pl", true, false, null, "BARTLOMIEJ.PREDKI@PUT.POZNAN.PL", "BARTLOMIEJ.PREDKI@PUT.POZNAN.PL", "AQAAAAEAACcQAAAAECHoPq+lsZO9ULuE7PnJGKf6x95VlFIBxWScOPvQ5ysf3OMAhY9y+loYpgox+BmALQ==", null, false, "", false, "bartlomiej.predki@put.poznan.pl" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "FacultyId", "Name" },
                values: new object[,]
                {
                    { new Guid("b4599a30-a0aa-45e6-a15d-3e67ca57aa46"), new Guid("21f541fb-1876-4e89-af23-b6ff09ab5004"), "Architektura" },
                    { new Guid("81e12855-fb34-436d-966c-ae6704a92fe2"), new Guid("36001ee0-0141-4ed7-9ee5-ba674333e253"), "Inżynieria Farmaceutyczna" },
                    { new Guid("3b2f99c9-1409-4f1d-8b63-3e88f1da7382"), new Guid("36001ee0-0141-4ed7-9ee5-ba674333e253"), "Technologie Ochrony Środowiska" },
                    { new Guid("c34aab71-06b1-46f4-9ecb-d155b90e8621"), new Guid("36001ee0-0141-4ed7-9ee5-ba674333e253"), "Technologia Chemiczna / Chemical Technology" },
                    { new Guid("e996a486-f851-40dd-870e-c28a8f1222b5"), new Guid("36001ee0-0141-4ed7-9ee5-ba674333e253"), "Inżynieria Chemiczna i Procesowa" },
                    { new Guid("95ba80cd-8af5-4831-a87e-ff2d53ffe059"), new Guid("f760b789-5aca-414b-91cb-144a56b202d4"), "Inżynieria Bezpieczeństwa" },
                    { new Guid("c20bd095-5485-4cba-8e35-12cabec8ee80"), new Guid("f760b789-5aca-414b-91cb-144a56b202d4"), "Inżynieria Zarządzania" },
                    { new Guid("3a1823f2-b6e1-4683-9961-6147c33fe2c4"), new Guid("f760b789-5aca-414b-91cb-144a56b202d4"), "Logistyka" },
                    { new Guid("91c4a790-227a-40cb-b1f1-e580ac8dd762"), new Guid("bbaf8a32-ca6f-4eb2-84a0-21e83dfed7b9"), "Lotnictwo i Kosmonautyka" },
                    { new Guid("7a3d9e77-fd9a-4fc7-b7e6-e7b92fa088ab"), new Guid("bbaf8a32-ca6f-4eb2-84a0-21e83dfed7b9"), "Transport" },
                    { new Guid("5615ee14-1366-4395-8402-6f21c1731ee1"), new Guid("5040b13b-72c7-4b3c-a983-2d4d4d141e84"), "Sztuczna Inteligencja / Artificial Intelligence" },
                    { new Guid("0f4d118f-2eec-4aa0-9c0d-8029f21e2024"), new Guid("5040b13b-72c7-4b3c-a983-2d4d4d141e84"), "Bioinformatyka" },
                    { new Guid("f19de075-d03c-4120-a1c3-29d05954a995"), new Guid("5040b13b-72c7-4b3c-a983-2d4d4d141e84"), "Informatyka" },
                    { new Guid("053046f6-a344-4bbc-9e39-41856919780c"), new Guid("0e0eb4ca-2def-4349-96eb-0e920f24760c"), "Fizyka Techniczna" },
                    { new Guid("f841a913-5239-47e4-8a25-2391e684aed5"), new Guid("0e0eb4ca-2def-4349-96eb-0e920f24760c"), "Edukacja Techniczno-Informatyczna" },
                    { new Guid("13c77616-9efb-4315-9f2b-8b56330978ae"), new Guid("bbaf8a32-ca6f-4eb2-84a0-21e83dfed7b9"), "Konstrukcja i Eksploatacja Środków Transportu" },
                    { new Guid("ad136db5-1582-4709-928b-7fc6093c5c1a"), new Guid("25ac48c7-d909-4ff4-b5e8-c8e256b78f5a"), "Energetyka" },
                    { new Guid("609f879f-9948-4e65-a6b8-94e11d6f9a49"), new Guid("21f541fb-1876-4e89-af23-b6ff09ab5004"), "Architektura Wnętrz" },
                    { new Guid("4ffa2bee-b3ba-4312-9712-da83541a2788"), new Guid("25ac48c7-d909-4ff4-b5e8-c8e256b78f5a"), "Matematyka w Technice" },
                    { new Guid("00f83410-d613-4b2d-b0ad-2563a76172d0"), new Guid("4ce6c2bc-bde7-45cf-b8ca-0bcb26b95c04"), "Inżynieria Środowiska" },
                    { new Guid("51ee3447-dbb9-4aac-a94e-39e767269cc6"), new Guid("07cc9446-555d-4c97-827f-248e3f851f3d"), "Inżynieria Biomedyczna" },
                    { new Guid("151f2559-9f6c-427c-b3d2-b2d314c2028a"), new Guid("07cc9446-555d-4c97-827f-248e3f851f3d"), "Inżynieria Materiałowa" },
                    { new Guid("49660efe-a92d-43d9-90dd-a35d6356a9d3"), new Guid("07cc9446-555d-4c97-827f-248e3f851f3d"), "Mechanika i Budowa Maszyn" },
                    { new Guid("d141684e-b259-476e-a968-d3d85d3916f2"), new Guid("4ce6c2bc-bde7-45cf-b8ca-0bcb26b95c04"), "Budownictwo" },
                    { new Guid("aac377f9-e11f-4dac-b1b0-abbc00e34bca"), new Guid("07cc9446-555d-4c97-827f-248e3f851f3d"), "Zarządzanie i Inżynieria Produkcji" },
                    { new Guid("6340c89a-cde7-439b-b579-6bbe34aedf20"), new Guid("3c6a4c75-86c7-4a7d-9356-865d6b6e4451"), "Elektronika i Telekomunikacja" },
                    { new Guid("0597346d-9576-405d-94fb-a4f08803a493"), new Guid("3c6a4c75-86c7-4a7d-9356-865d6b6e4451"), "Teleinformatyka" },
                    { new Guid("01c83336-989c-47f0-a241-fdd800334e06"), new Guid("25ac48c7-d909-4ff4-b5e8-c8e256b78f5a"), "Automatyka i Robotyka" },
                    { new Guid("ad1a3b10-ea90-4d8d-a379-57831eebc571"), new Guid("25ac48c7-d909-4ff4-b5e8-c8e256b78f5a"), "Elektrotechnika" },
                    { new Guid("0a8dee16-505e-4804-8ce5-e5d5bcacdf35"), new Guid("07cc9446-555d-4c97-827f-248e3f851f3d"), "Mechatronika" }
                });

            migrationBuilder.InsertData(
                table: "Promoters",
                columns: new[] { "Id", "ExpectedNumberOfBachelorProposals", "ExpectedNumberOfMasterProposals", "FirstName", "InstituteId", "LastName", "TitlePostfix", "TitlePrefix", "UserId" },
                values: new object[,]
                {
                    { new Guid("48aea09b-4be3-4372-88bc-d46d78a1552b"), 2, 1, "Jerzy", new Guid("bedc99ed-5cc7-42f8-9fb8-7a413e7cbfa0"), "Nawrocki", "prof. PP", "dr hab inż.", new Guid("a350be55-3326-4210-b0a6-becc4bef92ea") },
                    { new Guid("9aabdabd-8d1b-4c38-a2d0-0f88dca17533"), 2, 1, "Wojciech", new Guid("bedc99ed-5cc7-42f8-9fb8-7a413e7cbfa0"), "Kotłowski", "", "dr hab. inż.", new Guid("bc7716c1-6011-434a-9623-ef0722083cc0") },
                    { new Guid("4ae4e691-dcff-4236-94ca-c97c102bc66c"), 2, 1, "Miłosz", new Guid("bedc99ed-5cc7-42f8-9fb8-7a413e7cbfa0"), "Kadziński", "", "dr hab. inż.", new Guid("7e53e191-b0a9-48db-9691-c08926577420") },
                    { new Guid("d979fc9c-94d3-419a-a4e9-014e5664b73c"), 2, 1, "Bartłomiej", new Guid("bedc99ed-5cc7-42f8-9fb8-7a413e7cbfa0"), "Prędki", "", "dr inż.", new Guid("a6822801-97ab-4581-a478-45535d8adf9e") },
                    { new Guid("7345a41b-36aa-4ae2-b0fe-b7bb4279603b"), 3, 2, "Krzysztof", new Guid("39dcb4de-d35d-4da5-bf08-421e6aed1ee4"), "Alejski", "prof. PP", "dr hab. inż.", new Guid("c216cba0-63da-4acf-998f-73125906d1fa") },
                    { new Guid("fb23704f-cec8-48fb-aa79-f3bd0e7e293b"), 1, 1, "Katarzyna", new Guid("39dcb4de-d35d-4da5-bf08-421e6aed1ee4"), "Adamska", "", "dr inż.", new Guid("f823cd14-794c-4afd-98b3-a1dfb3ffba50") },
                    { new Guid("2a21d8e5-575a-41d9-99ed-fbb5c06a3db9"), 2, 1, "Irmina", new Guid("bedc99ed-5cc7-42f8-9fb8-7a413e7cbfa0"), "Masłowska", "", "dr inż.", new Guid("1b7c1541-08d5-4d61-aea3-8190812df48f") }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ProposalId", "UserId" },
                values: new object[,]
                {
                    { new Guid("713f95de-c0d4-4d4c-a482-6553f2c5be23"), null, new Guid("25312726-dafd-4be0-a59d-97013c46bd88") },
                    { new Guid("137d6d06-a67f-4d17-8449-4a29ea58a6d0"), null, new Guid("0189d561-7e83-4084-9185-d705ed21295e") },
                    { new Guid("b105b2d1-bf26-4023-b15e-77fc3508e480"), null, new Guid("c3099d35-0868-4690-8a2b-17b2a41be37b") },
                    { new Guid("f1ef9786-c0de-48e2-bee7-4c79b839c93a"), null, new Guid("6e9acc5c-2321-4345-af11-50a5af548c3e") }
                });

            migrationBuilder.InsertData(
                table: "Proposals",
                columns: new[] { "Id", "CourseId", "Description", "Level", "MaxNumberOfStudents", "Mode", "OutputData", "PromoterId", "Specialization", "StartingDate", "Status", "StudyProfile", "TopicEnglish", "TopicPolish" },
                values: new object[,]
                {
                    { new Guid("86cce6a8-6d77-4887-99f5-1e8e61a59079"), new Guid("f19de075-d03c-4120-a1c3-29d05954a995"), "Celem pracy jest zaimplementowanie metod Electre 1s i Electre TRI jako aplikacji desktopowych.....", 0, 4, 0, "Brak danych", new Guid("2a21d8e5-575a-41d9-99ed-fbb5c06a3db9"), "-", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "Implementation of chosen methods from Electre family", "Implementacja wybranych metod z rodziny Electre" },
                    { new Guid("e8da1d5e-a2ff-45c4-a9b3-a74a417433e5"), new Guid("f19de075-d03c-4120-a1c3-29d05954a995"), "Opis.....", 0, 4, 0, "Brak danych", new Guid("d979fc9c-94d3-419a-a4e9-014e5664b73c"), "-", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "Implementation of decision support methods based on utility function (UTA, Assess)", "Implementacja metod wspomagania decyzji opartych na funkcji użyteczności (UTA, Assess)" },
                    { new Guid("149a7370-b956-4ac8-ba7f-a88237481bc3"), new Guid("f19de075-d03c-4120-a1c3-29d05954a995"), "Opis.....", 0, 4, 0, "Brak danych", new Guid("4ae4e691-dcff-4236-94ca-c97c102bc66c"), "-", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "Extension of diviz platform", "Rozszerzenie platformy diviz o metody wielokryterialnego wspomagania decyzji oparte na różnych modelach preferencji" },
                    { new Guid("9d88f8c4-8a00-44e8-9335-eed7a7a4a3ae"), new Guid("f19de075-d03c-4120-a1c3-29d05954a995"), "Opis.....", 0, 4, 0, "Brak danych", new Guid("9aabdabd-8d1b-4c38-a2d0-0f88dca17533"), "-", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "Style transfering using a neural network", "Transfer stylu przy użyciu sieci neuronowej" },
                    { new Guid("c518934d-f083-4168-ae75-a44c83a7a254"), new Guid("f19de075-d03c-4120-a1c3-29d05954a995"), "Opis.....", 0, 4, 0, "Brak danych", new Guid("48aea09b-4be3-4372-88bc-d46d78a1552b"), "-", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "Capri 2 - system for managing diploma topic cards", "Capri 2 - system do zarządzania kartami tematów prac dyplomowych" },
                    { new Guid("dec45138-e53c-4fce-92fb-4245dd161e8f"), new Guid("e996a486-f851-40dd-870e-c28a8f1222b5"), "Praca będzie polegać na własnoręcznym upakowaniu kolumny chromatograficznej, doborze odpowiednich warunków pomiaru w celu wyznaczenia podstawowych parametrów dla niestandardowych kolumn do HPLC.", 0, 4, 0, "Brak danych", new Guid("fb23704f-cec8-48fb-aa79-f3bd0e7e293b"), "-", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "No title", "Wyznaczenie parametrów kolumny chromatograficznej za pomocą odwróconej chromatografii cieczowej" },
                    { new Guid("7df3e851-3665-4cba-be0c-6773c46ac102"), new Guid("e996a486-f851-40dd-870e-c28a8f1222b5"), "Brak opisu", 1, 4, 0, "Brak danych", new Guid("7345a41b-36aa-4ae2-b0fe-b7bb4279603b"), "-", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "No title", "Analiza i projektowanie procesów wydzielania produktów otrzymywanych w procesie biokonwersji surowców odnawialnych" }
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
